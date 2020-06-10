using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//new
using System.Data.SqlClient; //sql stuff
using System.Configuration; //access to webconfig
using System.Diagnostics;
using System.Data;
//using System.Exception;

namespace DataDrivenApp.Pages
{
    public partial class SurveyQuestions : System.Web.UI.Page
    {
        public const string SESSION_EXTRA_QUESTION = "extraQuestions";
        public string ipAddress;
        public const string QUESTION_ID = "questionID";
        public const string EXTRA_QUESTION_AND_SKIP_BUTTON = "extraQuestionAndSkipButton";

        public static string SESSION_ANSWER_TEXTBOX;
        public static string SESSION_ANSWER_CHECKBOX;
        public static string SESSION_ANSWER_RADIOBUTTON;
        List<int> extraQuestionAndSkipButton = new List<int>();

        public int currentUserId;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            skipBtn.Style["visibility"] = "hidden";
            Console.WriteLine(HttpContext.Current.Session[EXTRA_QUESTION_AND_SKIP_BUTTON]);
            try
            {
                currentUserId = (int)HttpContext.Current.Session["currentUserId"];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            //GetIpAddress(out ipAddress);
            if (AppSession.isLoggedIn())
            {
                titleSurvey.Text = "Welcome " + AppSession.getUsername();
            }


            //get current questionID
            int currentQuestionID = getCurrentQuestionIDFromSession();

            using (SqlConnection connection = DBUtility.ConnectToSQLDB())
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Questions WHERE questionId = " + currentQuestionID, connection);

                //RUN command and dump results into reader
                SqlDataReader reader = command.ExecuteReader();
                //must do one read to gete onto first row of results in reader (can only show 1 question per page, so 1 read is all we need)
                if (reader.Read())
                {
                    //get question text and put it in our label
                    string questionText = (string)reader["questionText"];
                    questionLabel.Text = questionText;

                    //makes all the value in the reader typeName to lowercase
                    string questionType = ((string)reader["questionType"]).ToLower();

                    if (questionType == "textbox")
                    {
                        TextBox textBox = new TextBox();
                        textBox.ID = "questionTextBox";


                        QuestionPlaceHolder.Controls.Add(textBox);
                    }
                    else if (questionType == "checkbox")
                    {
                        CheckBoxList checkBoxList = new CheckBoxList();
                        checkBoxList.ID = "questionCheckBox";

                        //get options associated with this current question and dump into checkBoxList
                        SqlCommand optionCommand = new SqlCommand("SELECT * FROM Options WHERE questionId = " + currentQuestionID, connection);

                        SqlDataReader optionReader = optionCommand.ExecuteReader();

                        //loop through all the question option results and chuck into the checkBox
                        while (optionReader.Read())
                        {
                            //takes the text value from database as first input and id as last input
                            ListItem item = new ListItem((string)optionReader["optionText"], optionReader["optionId"].ToString());

                            checkBoxList.Items.Add(item);
                        }

                        QuestionPlaceHolder.Controls.Add(checkBoxList);
                        HttpContext.Current.Session["currentUserId"] = currentUserId;

                        if(HttpContext.Current.Session[EXTRA_QUESTION_AND_SKIP_BUTTON] != null)
                        {
                            //show when there is extra question
                            skipBtn.Style["visibility"] = "show";
                            HttpContext.Current.Session[EXTRA_QUESTION_AND_SKIP_BUTTON] = null;
                        }
                        else
                        {
                            //make it hidden when there is no extra question
                            skipBtn.Style["visibility"] = "hidden";
                        }
                        
                    }
                    else if (questionType == "radiobutton")
                    {
                        RadioButtonList radioButtonList = new RadioButtonList();
                        radioButtonList.ID = "questionRadioButton";

                        //get options associated with this current question and dump into checkBoxList
                        SqlCommand optionCommand = new SqlCommand("SELECT * FROM Options WHERE questionId = " + currentQuestionID, connection);

                        SqlDataReader optionReader = optionCommand.ExecuteReader();

                        //loop through all the question option results and chuck into the checkBox
                        while (optionReader.Read())
                        {
                            //takes the text value from database as first input and id as last input
                            ListItem item = new ListItem((string)optionReader["optionText"], optionReader["optionId"].ToString());

                            radioButtonList.Items.Add(item);
                        }

                        QuestionPlaceHolder.Controls.Add(radioButtonList);
                    }
                }

            }

        }
        //helper functions
        private static List<Answers> GetListOfAnswersFromSession()
        {
            //make empty list
            List<Answers> answers = new List<Answers>();
            //if stored in session, grab those stored values
            if (HttpContext.Current.Session["answers"] != null)
            {
                try
                {
                    answers = (List<Answers>)HttpContext.Current.Session["answers"];

                }
                catch (HttpException e)
                {
                    Console.Write(e.Message);
                }
            }
            return answers;
        }

        private int getCurrentQuestionIDFromSession()
        {
            //if questionId not in session, set it up with default one
            if (HttpContext.Current.Session[QUESTION_ID] == null)
            {
                //TODO Find out min questionID from question Table and use that as starting question id
                //answer: SELECT MIN(questionId) FROM TestQuestion;
                try
                {
                    using (SqlConnection connection = DBUtility.ConnectToSQLDB())
                    {
                        SqlCommand minimumNumberCommand = new SqlCommand("SELECT MIN(questionId) FROM Questions", connection);
                        //RUN command and execute straight away , execute scalar gives back the first row and first value in the first column
                        int min = (int)minimumNumberCommand.ExecuteScalar();

                        HttpContext.Current.Session[QUESTION_ID] = min;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            //get QuestionID stored in current clients session 
            return (int)HttpContext.Current.Session[QUESTION_ID];
        }
        protected void nextBtn_Click(object sender, EventArgs e)
        {
            int currentQuestionID = getCurrentQuestionIDFromSession();


            //get extra questions list from session if it exist, if not make a new one
            List<int> extraQuestions = new List<int>();

            


            if (HttpContext.Current.Session[SESSION_EXTRA_QUESTION] != null)
            {
                extraQuestions = (List<int>)HttpContext.Current.Session[SESSION_EXTRA_QUESTION];
            }

            try
            {

                using (SqlConnection connection = DBUtility.ConnectToSQLDB())
                {
                    //check if it was a textbox question
                    TextBox questionTextBox = (TextBox)QuestionPlaceHolder.FindControl("questionTextBox");
                    if (questionTextBox != null)
                    {
                        //if it was a textBox, do something with the answers
                        string typedAnswer = questionTextBox.Text;
                        HttpContext.Current.Session[SESSION_ANSWER_TEXTBOX] = typedAnswer;


                        //TODO FOR STEVEN
                        //get hold of optionId, the answerText and userID and add to session
                        try
                        {
                            Answers answer = new Answers();
                            answer.optionId = null;
                            answer.answerText = typedAnswer;
                            ///get list from session
                            List<Answers> answers = GetListOfAnswersFromSession();
                            answers.Add(answer);
                            //save this list into the session (overwrite existing list if any)
                            HttpContext.Current.Session["answers"] = answers;


                        }
                        catch (ArgumentException argEx)
                        {
                            Response.Write(argEx.Message);
                        }
                        catch (FormatException formatEx)
                        {
                            Response.Write(formatEx.Message);
                        }
                        catch (OverflowException overflowEx)
                        {
                            Response.Write(overflowEx.Message);
                        }


                    }
                    //check if it was a checkbox question
                    CheckBoxList questionCheckBoxList = (CheckBoxList)QuestionPlaceHolder.FindControl("questionCheckBox");
                    if (questionCheckBoxList != null)
                    {

                        List<int> listOptionId = new List<int>();
                        foreach (ListItem item in questionCheckBoxList.Items)
                        {
                            if (item.Selected)
                            {
                                try
                                {
                                    Answers answer = new Answers();
                                    int optionId = int.Parse(item.Value);// may throw exception.

                                    listOptionId.Add(optionId);

                                    SqlCommand optionsCommand = new SqlCommand("SELECT nextQuestionId FROM Options WHERE optionId = " + optionId, connection);
                                    //RUN command and execute straight away , execute scalar gives back the first row and first value in the first column
                                    var dbResult = optionsCommand.ExecuteScalar();


                                    if (dbResult.ToString() != "")
                                    {
                                        extraQuestions.Add((int)dbResult);
                                        extraQuestionAndSkipButton.Add((int)dbResult);
                                    }

                                    //get hold of optionId, the answerText and userID and add to session
                                    try
                                    {
                                        answer.optionId = optionId;
                                        answer.answerText = item.ToString();
                                        ///get list from session
                                        List<Answers> answers = GetListOfAnswersFromSession();
                                        answers.Add(answer);
                                        //save this list into the session (overwrite existing list if any)
                                        HttpContext.Current.Session["answers"] = answers;
                                    }
                                    catch (ArgumentException argEx)
                                    {
                                        Response.Write(argEx.Message);
                                    }
                                    catch (FormatException formatEx)
                                    {
                                        Response.Write(formatEx.Message);
                                    }
                                    catch (OverflowException overflowEx)
                                    {
                                        Response.Write(overflowEx.Message);
                                    }

                                }
                                catch (Exception ex)
                                {
                                    Debug.WriteLine(ex);
                                }
                            }
                        }
                        HttpContext.Current.Session[SESSION_ANSWER_CHECKBOX] = listOptionId;
                        Debug.WriteLine(HttpContext.Current.Session[SESSION_ANSWER_CHECKBOX]);
                        Debug.WriteLine(listOptionId);
                    }

                    //check if it was a radiobutton question
                    RadioButtonList questionRadioButtonList = (RadioButtonList)QuestionPlaceHolder.FindControl("questionRadioButton");
                    if (questionRadioButtonList != null)
                    {

                        string selectedAnswer = questionRadioButtonList.SelectedItem.Text;
                        HttpContext.Current.Session[SESSION_ANSWER_TEXTBOX] = selectedAnswer;
                        try
                        {
                            int optionId = int.Parse(questionRadioButtonList.SelectedValue);// may throw exception.


                            SqlCommand optionsCommand = new SqlCommand("SELECT nextQuestionId FROM Options WHERE optionId = " + optionId, connection);
                            //RUN command and execute straight away , execute scalar gives back the first row and first value in the first column

                            var dbResult = optionsCommand.ExecuteScalar();


                            if (dbResult.ToString() != "")
                            {
                                extraQuestions.Add((int)dbResult);
                            }
                            //TODO FOR STEVEN
                            //get hold of optionId, the answerText and userID and add to session

                            try
                            {
                                Answers answer = new Answers();
                                answer.optionId = optionId;
                                answer.answerText = selectedAnswer;
                                ///get list from session
                                List<Answers> answers = GetListOfAnswersFromSession();
                                answers.Add(answer);
                                //save this list into the session (overwrite existing list if any)
                                HttpContext.Current.Session["answers"] = answers;


                            }
                            catch (ArgumentException argEx)
                            {
                                Response.Write(argEx.Message);
                            }
                            catch (FormatException formatEx)
                            {
                                Response.Write(formatEx.Message);
                            }
                            catch (OverflowException overflowEx)
                            {
                                Response.Write(overflowEx.Message);
                            }


                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex);
                        }


                    }

                    if (extraQuestions.Count <= 0)
                    {
                        SqlCommand command = new SqlCommand("SELECT * FROM Questions WHERE questionId = " + currentQuestionID, connection);

                        //RUN command and dump results into reader
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            //get index for the nextQuestion column
                            int nextQuestionColumnIndex = reader.GetOrdinal("nextQuestion");
                            //check if value in this row and column is NULL
                            if (reader.IsDBNull(nextQuestionColumnIndex))
                            {
                                //insert User details and get userId
                                Users users = (Users)HttpContext.Current.Session["currentUser"];
                                
                                SqlCommand commandInsertUsers = new SqlCommand("INSERT INTO Users (firstName, lastName, dob, phoneNumber, date, anonymous, ipAddress) VALUES (@firstName, @lastName, @dob, @phoneNumber, @date, @anonymous, @ipAddress); SELECT CAST(scope_identity() as int);", connection);
                                //add parameter
                                //prevents sql injection
                                commandInsertUsers.Parameters.Add("@firstName", SqlDbType.VarChar, 50);
                                commandInsertUsers.Parameters["@firstName"].Value = users.firstName;

                                commandInsertUsers.Parameters.Add("@lastName", SqlDbType.VarChar, 50);
                                commandInsertUsers.Parameters["@lastName"].Value = users.lastName;

                                commandInsertUsers.Parameters.Add("@dob", SqlDbType.VarChar, 50);
                                commandInsertUsers.Parameters["@dob"].Value = users.dob;

                                commandInsertUsers.Parameters.Add("@phoneNumber", SqlDbType.VarChar, 50);
                                commandInsertUsers.Parameters["@phoneNumber"].Value = users.phoneNumber;

                                commandInsertUsers.Parameters.Add("@anonymous", SqlDbType.Int, 4);
                                commandInsertUsers.Parameters["@anonymous"].Value = users.anon;

                                commandInsertUsers.Parameters.Add("@date", SqlDbType.VarChar, 50);
                                commandInsertUsers.Parameters["@date"].Value = users.date;

                                commandInsertUsers.Parameters.Add("@ipAddress", SqlDbType.VarChar, 50);
                                commandInsertUsers.Parameters["@ipAddress"].Value = users.ipAddress;

                                //get the userId from database
                                int newUserId = (int)commandInsertUsers.ExecuteScalar();

                                Console.WriteLine("New Product Id: " + newUserId);



                                //Insert Answers
                                List<Answers> answers = GetListOfAnswersFromSession();

                                foreach (Answers answer in answers)
                                {
                                    SqlCommand commandInsert = new SqlCommand("INSERT INTO Answers (optionId, answerText, userId) VALUES (@optionId, @answerText, @userId);", connection);
                                    //add parameter
                                    //prevents sql injection
                                    commandInsert.Parameters.Add("@optionId", SqlDbType.VarChar, 50);
                                    commandInsert.Parameters["@optionId"].Value = answer.optionId;
                                    if (commandInsert.Parameters["@optionId"].Value == null)
                                    {
                                        commandInsert.Parameters["@optionId"].Value = DBNull.Value;
                                    }

                                    commandInsert.Parameters.Add("@answerText", SqlDbType.VarChar, 50);
                                    commandInsert.Parameters["@answerText"].Value = answer.answerText;

                                    commandInsert.Parameters.Add("@userId", SqlDbType.Int, 4);
                                    commandInsert.Parameters["@userId"].Value = newUserId;


                                    var rowsAffected = commandInsert.ExecuteNonQuery();

                                    if (rowsAffected <= 0)
                                    {
                                        //could not insert
                                        //do something about it like show to user that the stuff didnt insert properly
                                        Console.WriteLine("failed to write");
                                    }
                                }

                                //empty products out of session
                                HttpContext.Current.Session["answers"] = null;
                                //clear all session
                                Session.Clear();

                                //if null, at end of survey 
                                Response.Redirect("ThankYouPage.aspx");
                            }
                            else
                            {
                                //If not null, get the value of the nextQuestion column so we can load that question up next
                                int nextQuestionId = (int)reader["nextQuestion"];
                                //save this as the current questionId in session.
                                HttpContext.Current.Session["questionID"] = nextQuestionId;
                                HttpContext.Current.Session["currentUserId"] = currentUserId;
                                //reload this page
                                Response.Redirect("SurveyQuestions.aspx");

                            }
                        }
                    }
                    else
                    {
                        //if we do have questions on that list
                        //set current question to load to be equal to first question in the extraQuestions List
                        HttpContext.Current.Session[QUESTION_ID] = extraQuestions[0];
                        //add to skip button session
                        HttpContext.Current.Session[EXTRA_QUESTION_AND_SKIP_BUTTON] = extraQuestions[0];
                        //remove this question from the list 
                        extraQuestions.RemoveAt(0);
                        //save extraQuestionlist into session
                        HttpContext.Current.Session[SESSION_EXTRA_QUESTION] = extraQuestions;
                        HttpContext.Current.Session["currentUserId"] = currentUserId;


                        //reload this page
                        Response.Redirect("SurveyQuestions.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void GetIpAddress(out string userip)
        {
            userip = Request.UserHostAddress;
            if (Request.UserHostAddress != null)
            {
                Int64 macinfo = new Int64();
                string macSrc = macinfo.ToString("X");
                if (macSrc == "0")
                {
                    if (userip == "127.0.0.1")
                    {
                        Response.Write("visited Localhost!");
                    }
                    else
                    {
                        Response.Write(userip);
                    }
                }
            }
        }

        protected void skipBtn_Click(object sender, EventArgs e)
        {
            int currentQuestionID = getCurrentQuestionIDFromSession();


            //get extra questions list from session if it exist, if not make a new one
            List<int> extraQuestions = new List<int>();
            if (HttpContext.Current.Session[SESSION_EXTRA_QUESTION] != null)
            {
                extraQuestions = (List<int>)HttpContext.Current.Session[SESSION_EXTRA_QUESTION];
            }

            try
            {

                using (SqlConnection connection = DBUtility.ConnectToSQLDB())
                {
                    

                    if (extraQuestions.Count <= 0)
                    {
                        SqlCommand command = new SqlCommand("SELECT * FROM Questions WHERE questionId = " + currentQuestionID, connection);

                        //RUN command and dump results into reader
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            //get index for the nextQuestion column
                            int nextQuestionColumnIndex = reader.GetOrdinal("nextQuestion");
                            //check if value in this row and column is NULL
                            if (reader.IsDBNull(nextQuestionColumnIndex))
                            {
                                List<Answers> answers = GetListOfAnswersFromSession();

                                foreach (Answers answer in answers)
                                {
                                    //insert User details and get userId
                                    Users users = (Users)HttpContext.Current.Session["currentUserId"];

                                    SqlCommand commandInsertUsers = new SqlCommand("INSERT INTO Users (firstName, lastName, dob, phoneNumber, date, anonymous, ipAddress) VALUES (@firstName, @lastName, @dob, @phoneNumber, @date, @anonymous, @ipAddress); SELECT CAST(scope_identity() as int);", connection);
                                    //add parameter
                                    //prevents sql injection
                                    commandInsertUsers.Parameters.Add("@firstName", SqlDbType.VarChar, 50);
                                    commandInsertUsers.Parameters["@firstName"].Value = users.firstName;

                                    commandInsertUsers.Parameters.Add("@lastName", SqlDbType.VarChar, 50);
                                    commandInsertUsers.Parameters["@lastName"].Value = users.lastName;

                                    commandInsertUsers.Parameters.Add("@dob", SqlDbType.VarChar, 50);
                                    commandInsertUsers.Parameters["@dob"].Value = users.dob;

                                    commandInsertUsers.Parameters.Add("@phoneNumber", SqlDbType.VarChar, 50);
                                    commandInsertUsers.Parameters["@phoneNumber"].Value = users.phoneNumber;

                                    commandInsertUsers.Parameters.Add("@anonymous", SqlDbType.Int, 4);
                                    commandInsertUsers.Parameters["@anonymous"].Value = users.anon;

                                    commandInsertUsers.Parameters.Add("@date", SqlDbType.VarChar, 50);
                                    commandInsertUsers.Parameters["@date"].Value = users.date;

                                    commandInsertUsers.Parameters.Add("@ipAddress", SqlDbType.VarChar, 50);
                                    commandInsertUsers.Parameters["@ipAddress"].Value = users.ipAddress;

                                    //get the userId from database
                                    int newUserId = (int)commandInsertUsers.ExecuteScalar();

                                    Console.WriteLine("New Product Id: " + newUserId);

                                    SqlCommand commandInsert = new SqlCommand("INSERT INTO Answers (optionId, answerText, userId) VALUES (@optionId, @answerText, @userId);", connection);
                                    //add parameter
                                    //prevents sql injection
                                    commandInsert.Parameters.Add("@optionId", SqlDbType.VarChar, 50);
                                    commandInsert.Parameters["@optionId"].Value = answer.optionId;
                                    if (commandInsert.Parameters["@optionId"].Value == null)
                                    {
                                        commandInsert.Parameters["@optionId"].Value = DBNull.Value;
                                    }

                                    commandInsert.Parameters.Add("@answerText", SqlDbType.VarChar, 50);
                                    commandInsert.Parameters["@answerText"].Value = answer.answerText;

                                    commandInsert.Parameters.Add("@userId", SqlDbType.Int, 4);
                                    commandInsert.Parameters["@userId"].Value = newUserId;


                                    var rowsAffected = commandInsert.ExecuteNonQuery();

                                    if (rowsAffected <= 0)
                                    {
                                        //could not insert
                                        //do something about it like show to user that the stuff didnt insert properly
                                        Console.WriteLine("failed to write");
                                    }
                                }

                                //empty products out of session
                                HttpContext.Current.Session["answers"] = null;
                                //clear all session
                                Session.Clear();

                                //if null, at end of survey 
                                Response.Redirect("ThankYouPage.aspx");
                            }
                            else
                            {
                                //If not null, get the value of the nextQuestion column so we can load that question up next
                                int nextQuestionId = (int)reader["nextQuestion"];
                                //save this as the current questionId in session.
                                HttpContext.Current.Session["questionID"] = nextQuestionId;
                                HttpContext.Current.Session["currentUserId"] = currentUserId;
                                //reload this page
                                Response.Redirect("SurveyQuestions.aspx");

                            }
                        }
                    }
                    else
                    {
                        //if we do have questions on that list
                        //set current question to load to be equal to first question in the extraQuestions List
                        HttpContext.Current.Session[QUESTION_ID] = extraQuestions[0];
                        //add to skip button session
                        HttpContext.Current.Session[EXTRA_QUESTION_AND_SKIP_BUTTON] = extraQuestions[0];
                        //remove this question from the list 
                        extraQuestions.RemoveAt(0);
                        //save extraQuestionlist into session
                        HttpContext.Current.Session[SESSION_EXTRA_QUESTION] = extraQuestions;
                        HttpContext.Current.Session["currentUserId"] = currentUserId;


                        //reload this page
                        Response.Redirect("SurveyQuestions.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}