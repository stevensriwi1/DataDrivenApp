using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataDrivenApp.Sessions
{
    public class AdminAppSession
    {
        public static void setUsername(string username)
        {
            HttpContext.Current.Session["username"] = username;
        }

        public static string getUsername()
        {
            try
            {
                return (string)HttpContext.Current.Session["username"];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }

        public static bool isLoggedIn()
        {
            string username = getUsername();
            if (username != null && username.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}