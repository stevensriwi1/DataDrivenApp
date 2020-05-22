using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


///THIS IS JUST A TEST, INTEGRATE THIS TO YOUR ANSWER TABLE!!!!!!!!!!!!!

namespace DataDrivenApp.Pages
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Products> products = GetListOfProductsFromSession();
            RefreshList(products);
        }
        //helper functions
        private static List<Products> GetListOfProductsFromSession()
        {
            //make empty list
            List<Products> products = new List<Products>();
            //if stored in session, grab those stored values
            if(HttpContext.Current.Session["products"] != null)
            {
                try
                {
                    products = (List<Products>)HttpContext.Current.Session["products"];
                    
                }
                catch(HttpException e)
                {
                    Console.Write(e.Message);
                }
            }
            return products;
        }

        private void RefreshList(List<Products> products)
        {
            //clear bulleted list
            productBulletedList.Items.Clear();
            //loop through the products and add them to the bulletedList
            foreach(Products product in products)
            {
                productBulletedList.Items.Add(new ListItem(product.Name));

            }
        }

        protected void addButton_Click(object sender, EventArgs e)
        {

            /*
            "INSERT INTO answers (answerText, user_ID, question_ID, option_ID)" +
                                    " VALUES (@answerText, @user_ID, @question_ID, @option_ID);" */


            try
            {
                Products product = new Products();
                product.Name = nameTextbox.Text;
                product.description = descriptionTextBox.Text;
                product.price = float.Parse(priceTextBox.Text);
                ///get list from session
                List<Products> products = GetListOfProductsFromSession();
                products.Add(product);
                //save this list into the session (overwrite existing list if any)
                HttpContext.Current.Session["products"] = products;

                RefreshList(products);

            }
            catch(ArgumentException argEx)
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

        protected void saveButton_Click(object sender, EventArgs e)
        {
            List<Products> products = GetListOfProductsFromSession();

            using (SqlConnection connection = DBUtility.ConnectToSQLDB())
            {
                foreach (Products product in products)
                {
                    SqlCommand command = new SqlCommand("INSERT INTO Products (name, description, price)" + 
                        " VALUES ('"+product.Name+ "','" + product.description + "','" + product.price + "')",connection);

                    int rowsAffected = command.ExecuteNonQuery();

                    if(rowsAffected<= 0)
                    {
                        //could not insert
                        //do something about it like show to user that the stuff didnt insert properly
                    }
                }
            }
            //empty products out of session
            HttpContext.Current.Session["products"] = null;

            //reload page
            Response.Redirect("AddProduct.aspx");
        }
    }
}