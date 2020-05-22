using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;//datatable
using System.Data.SqlClient;//connects to sql DB's and does commands
using System.Configuration;//to access our web.config file
using DataDrivenApp.Sessions;
using System.Text;

namespace DataDrivenApp.Pages
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AdminAppSession.isLoggedIn())
            {
                Response.Redirect("AdminLogin.aspx");
                return;
            }
            titleAdminPage.Text = "Welcome " + AdminAppSession.getUsername();
            //connection to database with the string
            string connectionString = ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString;

            //create sql connection and open it.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();



                //select all from testQuestion table
                SqlCommand command = new SqlCommand("SELECT * FROM TestQuestion", connection);
                //run command from reader
                SqlDataReader reader = command.ExecuteReader();

                //has column and rows
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("questionTxt", typeof(string));

                //reads 1 row of data from the reader at a time
                while (reader.Read())
                {
                    //generate an empty row fro my Datatable
                    DataRow row = dt.NewRow();
                    //put data in the row.
                    row["ID"] = reader["questionId"];
                    row["questionTxt"] = reader["text"];

                    //add rows to data table
                    dt.Rows.Add(row);

                }

                //create colummn headers based on the data in the reader and fill it with the data from reader.
                //dt.Load(reader);

                //give dataGridView on front end to be populated by dt to display
                QuestionGridView1.DataSource = dt;
                QuestionGridView1.DataBind();
            }// close when brackets are closed
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //FOR STEVEN TO WORK ON!!!!!!!!!!
            using (SqlConnection connection = DBUtility.ConnectToSQLDB())
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                StringBuilder sbCommand = new
                    StringBuilder("SELECT * FROM [Users] JOIN Answers ON [Users].userId = Answers.userId");

                if (inputFirstname.Value.Trim() != "")
                {
                    sbCommand.Append(" AND firstName=@firstName");
                    SqlParameter param = new SqlParameter("@firstName", inputFirstname.Value);
                    command.Parameters.Add(param);
                }

                if (inputLastname.Value.Trim() != "")
                {
                    sbCommand.Append(" AND lastName=@lastName");
                    SqlParameter param = new SqlParameter("@lastName", inputLastname.Value);
                    command.Parameters.Add(param);
                }

                if (inputPostcode.Value.Trim() != "")
                {
                    sbCommand.Append(" AND answerText=@Postcode");
                    SqlParameter param = new SqlParameter("@Postcode", inputPostcode.Value);
                    command.Parameters.Add(param);
                }

                if (inputSuburb.Value.Trim() != "")
                {
                    sbCommand.Append(" AND answerText=@Suburb");
                    SqlParameter param = new SqlParameter("@Suburb", inputSuburb.Value);
                    command.Parameters.Add(param);
                }

                command.CommandText = sbCommand.ToString();
                command.CommandType = CommandType.Text;

                SqlDataReader rdr = command.ExecuteReader();
                gvSearchResults.DataSource = rdr;
                gvSearchResults.DataBind();
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}