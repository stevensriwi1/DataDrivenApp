using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; //SQL
using System.Data; //SQL datatypes

namespace DataDrivenApp.Pages
{
    public partial class InsertNewProductGetId : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                Products product = new Products();
                product.Name = nameTextbox.Text;
                product.description = descriptionTextBox.Text;
                product.price = float.Parse(priceTextBox.Text);

                using(SqlConnection connection = DBUtility.ConnectToSQLDB())
                {
                    //create insert using parameters
                    //scope_identity gives the id of what ever you just inserted in the database
                    SqlCommand command = new SqlCommand("INSERT INTO Products (name, description, price) VALUES (@name, @description, @price); SELECT CAST(scope_identity() as int);", connection);
                    //add parameter
                    //prevents sql injection
                    command.Parameters.Add("@name", SqlDbType.VarChar, 50);
                    command.Parameters["@name"].Value = product.Name;

                    command.Parameters.Add("@description", SqlDbType.VarChar, 200);
                    command.Parameters["@description"].Value = product.description;

                    command.Parameters.Add("@price", SqlDbType.Float);
                    command.Parameters["@price"].Value = product.price;


                    //execute scalar returns first column and row of the comman results
                    int newId = (int)command.ExecuteScalar();

                    IdLabel.Text = "New User Id: " + newId;


                }

            }
            catch(Exception ex)
            {
                //problems
                Response.Write(ex.Message);
                IdLabel.Text = ex.Message;

            }
        }
    }
}