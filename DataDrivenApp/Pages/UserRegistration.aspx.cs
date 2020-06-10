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
            users.anon = 0;
            users.ipAddress = Request.UserHostAddress;
            users.date = DateTime.Now.ToString("dd-MM-yyyy");
            // storing this for future reference like inserting to data base after survey is done
            HttpContext.Current.Session["currentUser"] = users;

            Response.Redirect("SurveyQuestions.aspx");
        }
    }
}