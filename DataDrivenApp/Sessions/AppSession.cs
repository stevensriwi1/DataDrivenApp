using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataDrivenApp
{
    
    public class AppSession
    {
        public const string SESSION_USERNAME = "username";
        public const string SESSION_QUESTION_NUMBER = "questionNumber";
        public static void setUsername(string username)
        {
            HttpContext.Current.Session[SESSION_USERNAME] = username;
        }

        public static string getUsername()
        {
            try
            {
                return (string)HttpContext.Current.Session[SESSION_USERNAME];
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            
        }

        public static bool isLoggedIn()
        {
            string username = getUsername();
            if(username != null && username.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int getQuestionNumber()
        {
            //check if questionNumber does not exist in session
            if(HttpContext.Current.Session[SESSION_QUESTION_NUMBER] == null)
            {
                HttpContext.Current.Session[SESSION_QUESTION_NUMBER] = 1;
            }

            return (int)HttpContext.Current.Session[SESSION_QUESTION_NUMBER];
        }

        public static void incrementQuestionNumber()
        {
            int q = getQuestionNumber();
            q++;
            HttpContext.Current.Session[SESSION_QUESTION_NUMBER] = q;
        }
    }
}