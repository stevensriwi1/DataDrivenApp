using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataDrivenApp.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            if (firstnameTxtbox.Text.Length > 0)
            {
                AppSession.setUsername(firstnameTxtbox.Text);
            }
            //TODO FOR STEVEN
            //INSERT to Users table database firstname, lastname, dob, phonenumber with above strings strings 
            //and get hold of users ipAddress the date and set anon to '0' which is false
            Users users = new Users();
            users.firstName = firstnameTxtbox.Text;
            users.lastName = lastnameTxtbox.Text;
            users.dob = dobTextBox.Text;
            users.phoneNumber = phonenumberTxtbox1.Text;
            users.anon = 1;
            users.ipAddress = Request.UserHostAddress;
            users.date = DateTime.Now.ToString("dd-MM-yyyy");

            using (SqlConnection connection = DBUtility.ConnectToSQLDB())
            {
                try
                {
                    SqlCommand command = new SqlCommand("INSERT INTO Users (firstName, lastName, dob, phoneNumber, date, anonymous, ipAddress) VALUES (@firstName, @lastName, @dob, @phoneNumber, @date, @anonymous, @ipAddress); SELECT CAST(scope_identity() as int);", connection);
                    //add parameter
                    //prevents sql injection
                    command.Parameters.Add("@firstName", SqlDbType.VarChar, 50);
                    command.Parameters["@firstName"].Value = users.firstName;

                    command.Parameters.Add("@lastName", SqlDbType.VarChar, 50);
                    command.Parameters["@lastName"].Value = users.lastName;

                    command.Parameters.Add("@dob", SqlDbType.VarChar, 50);
                    command.Parameters["@dob"].Value = users.dob;

                    command.Parameters.Add("@phoneNumber", SqlDbType.VarChar, 50);
                    command.Parameters["@phoneNumber"].Value = users.phoneNumber;

                    command.Parameters.Add("@anonymous", SqlDbType.Int, 4);
                    command.Parameters["@anonymous"].Value = users.anon;

                    command.Parameters.Add("@date", SqlDbType.VarChar, 50);
                    command.Parameters["@date"].Value = users.date;

                    command.Parameters.Add("@ipAddress", SqlDbType.VarChar, 50);
                    command.Parameters["@ipAddress"].Value = users.ipAddress;

                    //get the userId from database
                    int newUserId = (int)command.ExecuteScalar();

                    Console.WriteLine("New User Id: " + newUserId);

                    HttpContext.Current.Session["currentUserId"] = newUserId;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }


            Response.Redirect("SurveyQuestions.aspx");
        }
    }
}