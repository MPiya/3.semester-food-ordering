using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopModel.Model;

namespace WebShopData.DatabaseLayer
{
    public class CustomerDatabaseAccess : ICustomerAccess
    {
        readonly string _connectionString;



        public CustomerDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("CompanyConnection");
        }

        public CustomerDatabaseAccess(string inconnectionString)
        {
            _connectionString = inconnectionString;
        }

        // For test public PersonDatabaseAccess(string inConnectionString) {
        // _connectionString = inConnectionString;
        // }
        public bool DeletePersonById(int id)
        {
            throw new NotImplementedException();
        }
        public bool CreateCustomer(Customer aCustomer)
        {
            bool insertedId = false;
            string insertString = "insert into [Customer](firstName, lastName, phoneNumber) OUTPUT" +
                " INSERTED.ID values(@FirstName, @LastName, @Phone";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                // Prepace SQL
                SqlParameter fNameParam = new("@FirstNam", aCustomer.FirstName);
                CreateCommand.Parameters.Add(fNameParam);
                SqlParameter lNameParam = new("@LastName", aCustomer.LastName);
                CreateCommand.Parameters.Add(lNameParam);
                SqlParameter phoneNuParam = new("@Phone", aCustomer.PhoneNu);
                CreateCommand.Parameters.Add(phoneNuParam);
              

                //
                con.Open();
                // Execute save and read generated key (ID)
                insertedId = (bool)CreateCommand.ExecuteScalar();

                con.Close();
            }
            return insertedId;
        }





        public List<Customer> GetCustomerAll()
        {
            List<Customer> foundCustomers;
            Customer readCustomer;
            string queryString = "select ID, firstName, lastName, phoneNumber, email from Customer";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                con.Open();
                // Execute read
                SqlDataReader customerReader = readCommand.ExecuteReader();
                // Collect data
                foundCustomers = new List<Customer>();
                while (customerReader.Read())
                {
                    readCustomer = GetCustomerFromReader(customerReader);
                    foundCustomers.Add(readCustomer);
                }
            }
            return foundCustomers;
        }
        private Customer GetCustomerFromReader(SqlDataReader customerReader)
        {
            Customer foundCustomer;
            int tempId;
            string tempFirstName, tempLastName, temPhoneNu, tempEmail, tempAddress;
            tempId = customerReader.GetInt32(customerReader.GetOrdinal("id"));
            tempFirstName = customerReader.GetString(customerReader.GetOrdinal("firstName"));
            tempLastName = customerReader.GetString(customerReader.GetOrdinal("lastName"));
            temPhoneNu = customerReader.GetString(customerReader.GetOrdinal("phoneNumber"));
            tempEmail = customerReader.GetString(customerReader.GetOrdinal("email"));
          
            foundCustomer = new Customer (tempId, tempFirstName, tempLastName,
                temPhoneNu, tempEmail);

            return foundCustomer;
        }

        public Customer GetCustomerById(int findId)
        {
            Customer foundCustomer;
            string queryString = "select id, firstName, lastName, phoneNu, email, address from [Customer] where id = @Id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                // Prepace SQL
                SqlParameter idParam = new SqlParameter("@Id", findId);
                readCommand.Parameters.Add(idParam);
                //
                con.Open();
                // Execute read
                SqlDataReader customerReader = readCommand.ExecuteReader();
                foundCustomer = new Customer();
                while (customerReader.Read())
                {
                    foundCustomer = GetCustomerFromReader(customerReader);
                }
            }
            return foundCustomer;
        }
        public bool UpdateCustomer(Customer CustmerToUpdate)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomerById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
