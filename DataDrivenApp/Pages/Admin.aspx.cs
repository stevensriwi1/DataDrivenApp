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
        string optIDs = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!AdminAppSession.isLoggedIn())
            {
                Response.Redirect("AdminLogin.aspx");
                return;
            }
            titleAdminPage.Text = "Welcome " + AdminAppSession.getUsername();
            try
            {
                using (SqlConnection connection = DBUtility.ConnectToSQLDB())
                {
                    //numbers of questionId for SQL purposes
                    int questionIdState = 3;
                    int questionIdBank = 6;
                    int questionIdBankCommbank = 8;
                    int questionIdBankNAB = 11;
                    int questionIdBankANZ = 12;
                    int questionIdNewspaper = 7;
                    int questionIdGender = 1;
                    int questionIdSports = 9;
                    int questionIdTravel = 10;

                    //checking whether the page has been render before, if no then do so.
                    if (!IsPostBack)
                    {
                        //State
                        SqlCommand optionCommandState = new SqlCommand("SELECT * FROM Options WHERE questionId = " + questionIdState, connection);
                        SqlDataReader optionReaderState = optionCommandState.ExecuteReader();

                        //loop through all the question option results and chuck into the checkBox
                        while (optionReaderState.Read())
                        {
                            //takes the text value from database as first input and id as last input
                            ListItem item = new ListItem((string)optionReaderState["optionText"], optionReaderState["optionId"].ToString());

                            CheckBoxListInputState.Items.Add(item);
                        }
                        //Bank
                        SqlCommand optionCommandBank = new SqlCommand("SELECT * FROM Options WHERE questionId = " + questionIdBank, connection);
                        SqlDataReader optionReaderBank = optionCommandBank.ExecuteReader();


                        //loop through all the question option results and chuck into the checkBox
                        while (optionReaderBank.Read())
                        {
                            //takes the text value from database as first input and id as last input
                            ListItem item = new ListItem((string)optionReaderBank["optionText"], optionReaderBank["optionId"].ToString());

                            CheckBoxListBank.Items.Add(item);
                        }

                        //-----Bank Services----
                        //Bank Services Commbank
                        SqlCommand optionCommandBankServicesCommbank = new SqlCommand("SELECT * FROM Options WHERE questionId = " + questionIdBankCommbank, connection);
                        SqlDataReader optionReaderBankServicesCommbank = optionCommandBankServicesCommbank.ExecuteReader();


                        //loop through all the question option results and chuck into the checkBox
                        while (optionReaderBankServicesCommbank.Read())
                        {
                            //takes the text value from database as first input and id as last input
                            ListItem item = new ListItem((string)optionReaderBankServicesCommbank["optionText"], optionReaderBankServicesCommbank["optionId"].ToString());

                            CheckBoxListBankServicesCommbank.Items.Add(item);
                        }

                        //Bank Services NAB
                        SqlCommand optionCommandBankServicesNAB = new SqlCommand("SELECT * FROM Options WHERE questionId = " + questionIdBankNAB, connection);
                        SqlDataReader optionReaderBankServicesNAB = optionCommandBankServicesNAB.ExecuteReader();


                        //loop through all the question option results and chuck into the checkBox
                        while (optionReaderBankServicesNAB.Read())
                        {
                            //takes the text value from database as first input and id as last input
                            ListItem item = new ListItem((string)optionReaderBankServicesNAB["optionText"], optionReaderBankServicesNAB["optionId"].ToString());

                            CheckBoxListBankServicesNAB.Items.Add(item);
                        }

                        //Bank Services ANZ
                        SqlCommand optionCommandBankServicesANZ = new SqlCommand("SELECT * FROM Options WHERE questionId = " + questionIdBankANZ, connection);
                        SqlDataReader optionReaderBankServicesANZ = optionCommandBankServicesANZ.ExecuteReader();


                        //loop through all the question option results and chuck into the checkBox
                        while (optionReaderBankServicesANZ.Read())
                        {
                            //takes the text value from database as first input and id as last input
                            ListItem item = new ListItem((string)optionReaderBankServicesANZ["optionText"], optionReaderBankServicesANZ["optionId"].ToString());

                            CheckBoxListBankServicesANZ.Items.Add(item);
                        }

                        //-----Newspaper related-----
                        //Newspaper
                        SqlCommand optionCommandNewspaper = new SqlCommand("SELECT * FROM Options WHERE questionId = " + questionIdNewspaper, connection);
                        SqlDataReader optionReaderNewspaper = optionCommandNewspaper.ExecuteReader();


                        //loop through all the question option results and chuck into the checkBox
                        while (optionReaderNewspaper.Read())
                        {
                            //takes the text value from database as first input and id as last input
                            ListItem item = new ListItem((string)optionReaderNewspaper["optionText"], optionReaderNewspaper["optionId"].ToString());

                            CheckBoxListNewspaper.Items.Add(item);
                        }

                        //Gender
                        SqlCommand optionCommandGender = new SqlCommand("SELECT * FROM Options WHERE questionId = " + questionIdGender, connection);
                        SqlDataReader optionReaderGender = optionCommandGender.ExecuteReader();

                        //loop through all the question option results and chuck into the checkBox
                        while (optionReaderGender.Read())
                        {
                            //takes the text value from database as first input and id as last input
                            ListItem item = new ListItem((string)optionReaderGender["optionText"], optionReaderGender["optionId"].ToString());

                            CheckBoxListGender.Items.Add(item);
                        }


                        //Sports
                        SqlCommand optionCommandSports = new SqlCommand("SELECT * FROM Options WHERE questionId = " + questionIdSports, connection);
                        SqlDataReader optionReaderSports = optionCommandSports.ExecuteReader();


                        //loop through all the question option results and chuck into the checkBox
                        while (optionReaderSports.Read())
                        {
                            //takes the text value from database as first input and id as last input
                            ListItem item = new ListItem((string)optionReaderSports["optionText"], optionReaderSports["optionId"].ToString());

                            CheckBoxListSports.Items.Add(item);
                        }
                        //Travel
                        SqlCommand optionCommandTravel = new SqlCommand("SELECT * FROM Options WHERE questionId = " + questionIdTravel, connection);
                        SqlDataReader optionReaderTravel = optionCommandTravel.ExecuteReader();


                        //loop through all the question option results and chuck into the checkBox
                        while (optionReaderTravel.Read())
                        {
                            //takes the text value from database as first input and id as last input
                            ListItem item = new ListItem((string)optionReaderTravel["optionText"], optionReaderTravel["optionId"].ToString());

                            CheckBoxListTravel.Items.Add(item);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            

            string start = "SELECT * FROM [Users] JOIN Answers ON [Users].userId = Answers.userId WHERE [Users].userId IN((SELECT userId FROM Answers WHERE";
            string end = "))";
            optIDs = "";
            //For each loops to check whether items has been selected line 185 to 311
            foreach (ListItem checkbox in CheckBoxListGender.Items)
            {
                if (checkbox.Selected)
                {
                    if (optIDs == "")
                    {
                        optIDs = " optionId = " + checkbox.Value;
                    }
                    else
                    {
                        optIDs = optIDs + " OR optionId = " + checkbox.Value;
                    }
                }
            }
            foreach (ListItem checkbox in CheckBoxListInputState.Items)
            {
                if (checkbox.Selected)
                {
                    if (optIDs == "")
                    {
                        optIDs = " optionId = " + checkbox.Value;
                    }
                    else
                    {
                        optIDs = optIDs + " OR optionId = " + checkbox.Value;
                    }
                }
            }
            foreach (ListItem checkbox in CheckBoxListBank.Items)
            {
                if (checkbox.Selected)
                {
                    if (optIDs == "")
                    {
                        optIDs = " optionId = " + checkbox.Value;
                    }
                    else
                    {
                        optIDs = optIDs + " OR optionId = " + checkbox.Value;
                    }
                }
            }
            foreach (ListItem checkbox in CheckBoxListBankServicesCommbank.Items)
            {
                if (checkbox.Selected)
                {
                    if (optIDs == "")
                    {
                        optIDs = " optionId = " + checkbox.Value;
                    }
                    else
                    {
                        optIDs = optIDs + " OR optionId = " + checkbox.Value;
                    }
                }
            }
            foreach (ListItem checkbox in CheckBoxListBankServicesNAB.Items)
            {
                if (checkbox.Selected)
                {
                    if (optIDs == "")
                    {
                        optIDs = " optionId = " + checkbox.Value;
                    }
                    else
                    {
                        optIDs = optIDs + " OR optionId = " + checkbox.Value;
                    }
                }
            }
            foreach (ListItem checkbox in CheckBoxListBankServicesANZ.Items)
            {
                if (checkbox.Selected)
                {
                    if (optIDs == "")
                    {
                        optIDs = " optionId = " + checkbox.Value;
                    }
                    else
                    {
                        optIDs = optIDs + " OR optionId = " + checkbox.Value;
                    }
                }
            }
            foreach (ListItem checkbox in CheckBoxListNewspaper.Items)
            {
                if (checkbox.Selected)
                {
                    if (optIDs == "")
                    {
                        optIDs = " optionId = " + checkbox.Value;
                    }
                    else
                    {
                        optIDs = optIDs + " OR optionId = " + checkbox.Value;
                    }
                }
            }
            foreach (ListItem checkbox in CheckBoxListSports.Items)
            {
                if (checkbox.Selected)
                {
                    if (optIDs == "")
                    {
                        optIDs = " optionId = " + checkbox.Value;
                    }
                    else
                    {
                        optIDs = optIDs + " OR optionId = " + checkbox.Value;
                    }
                }
            }
            foreach (ListItem checkbox in CheckBoxListTravel.Items)
            {
                if (checkbox.Selected)
                {
                    if (optIDs == "")
                    {
                        optIDs = " optionId = " + checkbox.Value;
                    }
                    else
                    {
                        optIDs = optIDs + " OR optionId = " + checkbox.Value;
                    }
                }
            }


            //Where admin selects, it will do these queries
            using (SqlConnection connection = DBUtility.ConnectToSQLDB())
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                if (optIDs != "")
                {
                    StringBuilder sbCommand = new
                StringBuilder(start + optIDs);


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
                    sbCommand.Append(end);
                    command.CommandText = sbCommand.ToString();
                    command.CommandType = CommandType.Text;

                    SqlDataReader rdr = command.ExecuteReader();
                    SearchResultsGridView.DataSource = rdr;
                    SearchResultsGridView.DataBind();
                }
                else
                {
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
                    SearchResultsGridView.DataSource = rdr;
                    SearchResultsGridView.DataBind();
                }
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}