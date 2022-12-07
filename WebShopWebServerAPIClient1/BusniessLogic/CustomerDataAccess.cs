using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopModel.Model;

namespace WebShop.BusniessLogic
{
    public class CustomerDatabaseAccessa
    {
        readonly string _connectionString;



        public CustomerDatabaseAccessa(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public CustomerDatabaseAccessa(string inconnectionString)
        {
            _connectionString = inconnectionString;
        }

        // For test public PersonDatabaseAccess(string inConnectionString) {
        // _connectionString = inConnectionString;
        // }

        public int CreateCustomera(Customer aCustomer)
        {
            int insertedId = -1;
            string insertString = "insert into [Customer](firstName, lastName, phoneNumber, Email) OUTPUT" +
                " INSERTED.ID values(@FirstNam, @LastNam, @Phonenu,@Email)";
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

                SqlParameter emailParam = new("@Email", aCustomer.Email);
                CreateCommand.Parameters.Add(emailParam);

                //
                con.Open();
                // Execute save and read generated key (ID)
                insertedId = (int)CreateCommand.ExecuteScalar();
                insertedId -= 1;
            }
            return insertedId;
        }
        public bool DeletePersonById(int id)
        {
            throw new NotImplementedException();
        }
        public int CreateCustomer(Customer aCustomer)
        {
            int insertedId = -1;
            string insertString = "insert into [Customer](firstName, lastName, phoneNumber, Email) OUTPUT" +
                " INSERTED.ID values(@FirstNam, @LastNam, @Phonenu,@Email)";
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
          
                SqlParameter emailParam = new("@Email", aCustomer.Email);
                CreateCommand.Parameters.Add(emailParam);

                //
                con.Open();
                // Execute save and read generated key (ID)
                insertedId = (int)CreateCommand.ExecuteScalar();
                Console.WriteLine(insertedId.ToString());
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
            string queryString = "select id, firstName, lastName, phoneNu, email from [Customer] where id = @Id";
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


        public int CreateOrder( Order aOrder)

        {
            int insertedId = -1;
            DateTime insertedDateTime = DateTime.Now;
            //
            string insertString = "insert into [order] (customerID,orderDate)  values" +
                "(@wdwd,@OrderDate)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                // Prepace SQL
                SqlParameter customerIdParam = new("@wdwd", aOrder.customerId);
                CreateCommand.Parameters.Add(customerIdParam);
                SqlParameter orderDateParam = new("@OrderDate", aOrder.orderDate);
                CreateCommand.Parameters.Add(orderDateParam);
                //  SqlParameter paymentTypeParam = new("@paymentType", aOrder.paymentType);
                //   CreateCommand.Parameters.Add(paymentTypeParam);


                //
                con.Open();
                //
                // Execute save and read generated key (ID)
               CreateCommand.ExecuteScalar();
               

            }
            return insertedId;
        }


    }
}
