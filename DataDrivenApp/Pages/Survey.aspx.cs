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
            HttpContext.Current.Session["currentUser"] = users;
            


            Response.Redirect("SurveyQuestions.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserRegistration.aspx");
        }
    }
}