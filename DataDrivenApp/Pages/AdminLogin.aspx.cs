using DataDrivenApp.Sessions;
using System;
using System.Collections.Generic;
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
            
            if (usernameTxtbox.Text.Equals("Admin") && passwordTxtbox.Text.Equals("Admin123"))
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