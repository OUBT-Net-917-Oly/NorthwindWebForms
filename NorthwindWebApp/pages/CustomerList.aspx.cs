using NorthwindWebApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NorthwindWebApp.pages
{
    public partial class CustomerList : System.Web.UI.Page
    {
        public List<Customer> Customers;

        protected void Page_Load(object sender, EventArgs e)
        {
            //populate a list of customers
            //connect to the northwind sql database
            //get the customer data from the customer table
            //put the customer data into the Customers list
            //display it on the CustomerList.aspx page
            Customers = GetCustomerList();
        }

        private List<Customer> GetCustomerList()
        {
            //string connectionString = 
            //    @"Server=(localdb)\MSSQLLocalDB;
            //    Database=Northwind;
            //    Trusted_Connection=True;";

            string connectionString = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            //data to be returned
            List<Customer> customers = new List<Customer>();

            //sql query
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from customers";
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                //loop over the customers and add to the list
                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.CustomerId = reader.GetString(0);
                    customer.CompanyName = reader.GetString(1);

                    customers.Add(customer);
                }
            }

            connection.Close();

            return customers;
        }
    }
}