using DataDrivenApp.Sessions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataDrivenApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = DBUtility.ConnectToSQLDB())
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Admin", connection);

                //RUN command and dump results into reader
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    //Gets username from table
                    string username = reader["username"].ToString();
                    //Gets password from table
                    string password = reader["password"].ToString();
                    if (usernameTxtbox.Text.Equals(username) && passwordTxtbox.Text.Equals(password))
                    {
                        AdminAppSession.setUsername(usernameTxtbox.Text);
                        Response.Redirect("Admin.aspx");
                    }
                    else
                    {
                        message.Text = "Invalid User";
                    }
                }
                
            }
                
        }
    }
}