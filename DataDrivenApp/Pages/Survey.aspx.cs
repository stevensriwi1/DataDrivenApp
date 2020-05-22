using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;//datatable
using System.Data.SqlClient;//connects to sql DB's and does commands
using System.Configuration;//to access our web.config file

namespace DataDrivenApp
{
    public partial class QuestionWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAnon_Click(object sender, EventArgs e)
        {
            //TODO FOR STEVEN
            //INSERT to database firstname, lastname, dob, phonenumber as blank string 
            //and get hold of users ipAddress the date and set anon to '1' which is true
            Users users = new Users();
            users.firstName = "";
            users.lastName = "";
            users.dob = "";
            users.phoneNumber = "";
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

                    Console.WriteLine("New Product Id: " + newUserId);

                    HttpContext.Current.Session["currentUserId"] = newUserId;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }


            }
            Response.Redirect("SurveyQuestions.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserRegistration.aspx");
        }
    }
}