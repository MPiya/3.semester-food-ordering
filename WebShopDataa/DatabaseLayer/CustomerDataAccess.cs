using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopModel.Model;

namespace WebShopDataa.DatabaseLayer
{
    public class CustomerDatabaseAccess : ICustomerAccess
    {
        readonly string _connectionString;



        public CustomerDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("WebShop");
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
        public int CreateCustomer(Customer aCustomer)
        {
            int insertedId = -1;
            string insertString = "insert into [Customer](firstName, lastName, phoneNu, email, address) OUTPUT" +
                " INSERTED.ID values(@FirstNam, @LastNam, @Phonenu,@Email, @Addres)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                // Prepace SQL
                SqlParameter fNameParam = new("@FirstNam", aCustomer.FirstName);
                CreateCommand.Parameters.Add(fNameParam);
                SqlParameter lNameParam = new("@LastNam", aCustomer.LastName);
                CreateCommand.Parameters.Add(lNameParam);
                SqlParameter phoneNuParam = new("@Phonenu", aCustomer.PhoneNu);
                CreateCommand.Parameters.Add(phoneNuParam);
                SqlParameter eAddressParam = new("@Email", aCustomer.Email);
                CreateCommand.Parameters.Add(eAddressParam);
                SqlParameter addressParam = new("@Addres", aCustomer.Address);
                CreateCommand.Parameters.Add(addressParam);

                //
                con.Open();
                // Execute save and read generated key (ID)
                insertedId = (int)CreateCommand.ExecuteScalar();
            }
            return insertedId;
        }


      

        public List<Customer> GetCustomerAll()
        {
            List<Customer> foundCustomers;
            Customer readCustomer;
            string queryString = "select id, firstName, lastName, phoneNu, email, address from [Customer]";
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
            temPhoneNu = customerReader.GetString(customerReader.GetOrdinal("phoneNu"));
            tempEmail = customerReader.GetString(customerReader.GetOrdinal("email"));
            tempAddress = customerReader.GetString(customerReader.GetOrdinal("address"));
            foundCustomer = new Customer (tempId, tempFirstName, tempLastName,
                temPhoneNu, tempEmail, tempAddress);

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
