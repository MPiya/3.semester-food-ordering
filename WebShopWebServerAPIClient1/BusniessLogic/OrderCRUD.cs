using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebShop.Models;

namespace WebShop.BusniessLogic
{
    public class OrderCRUD
    {
        readonly string _connectionString;

        public OrderCRUD(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public OrderCRUD(string inconnectionString)
        {
            _connectionString = inconnectionString;
        }

        // For test public PersonDatabaseAccess(string inConnectionString) {
        // _connectionString = inConnectionString;
        // }

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
                insertedId -= 1;
            }
            return insertedId;
        }
        public bool DeletePersonById(int id)
        {
            throw new NotImplementedException();
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

            foundCustomer = new Customer(tempId, tempFirstName, tempLastName,
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


        public int CreateOrder(Order aOrder)

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
               insertedId = (int)CreateCommand.ExecuteScalar();


            }
            return insertedId;
        }


        public int CreateOrderLine(OrderLine oOrderLine)
        {

            int insertedId = -1;
            string insertString = "INSERT INTO OrderLine (productID,orderID,quantity,totalPrice) VALUES" +
                   "(@a,@b,@c,@d)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                // Prepace SQL
                SqlParameter productIDParam = new("@a", oOrderLine.ProductID);
                CreateCommand.Parameters.Add(productIDParam);
                SqlParameter orderIDParam = new("@b", oOrderLine.OrderID);
                CreateCommand.Parameters.Add(orderIDParam);
                SqlParameter saleQuantityParam = new("@c", oOrderLine.Quantity);
                CreateCommand.Parameters.Add(saleQuantityParam);
                SqlParameter totalPriceParam = new("@d", oOrderLine.TotalPrice);
                CreateCommand.Parameters.Add(totalPriceParam);
                //
                con.Open();
                // Execute save and read generated key (ID)
                insertedId = (int)CreateCommand.ExecuteNonQuery();
            }
            return insertedId;
        }


        public void ReduceProductQuantity(OrderLine oOrderLine)
        {

            string query = "UPDATE PRODUCT SET stockQuantity =stockQuantity - @value Where ID =@id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(query, con))
            {
                // Prepace SQL
                SqlParameter value = new("@value", oOrderLine.Quantity);
                CreateCommand.Parameters.Add(value);
              
                SqlParameter saleQuantityParam = new("@id", oOrderLine.ProductID);
                CreateCommand.Parameters.Add(saleQuantityParam);
  
                con.Open();
                // Execute save and read generated key (ID)
CreateCommand.ExecuteNonQuery();
            }

        }


       
     
        public List<Order> GetOrerIdCustomerNameDate()
        {
            List<Order> foundOrders;
            Order readOrder;

            //string query_GetOrderIdCustomerNameDate = "SELECT [Order].OrderId, Customer.firstName, Customer.lastName, [Order].orderDate\r\nFROM [Order]\r\nINNER JOIN Customer ON [Order].CustomerID=Customer.CustomerId;";
            string query_GetOrderIdCustomerNameDate = "SELECT [Order].ID, Customer.firstName, [Order].orderDate FROM [Order] INNER JOIN Customer ON [Order].CustomerID=Customer.ID";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(query_GetOrderIdCustomerNameDate, conn))
            {
                conn.Open();
                SqlDataReader ordersReader = readCommand.ExecuteReader();
                foundOrders = new List<Order>();
                while (ordersReader.Read())
                {
                    readOrder = GetOrderIdCustomerNameDate(ordersReader);
                    foundOrders.Add(readOrder);
                }
            }
            return foundOrders;
        }

        public Order GetOrderIdCustomerNameDate(SqlDataReader orderReader)
        {

            Order foundOrder;

            int tempOrderId;
            string tempCustomerName;
            DateTime tempDate;

            tempOrderId = orderReader.GetInt32(orderReader.GetOrdinal("ID"));
            tempCustomerName = orderReader.GetString(orderReader.GetOrdinal("firstName"));
            tempDate = orderReader.GetDateTime(orderReader.GetOrdinal("orderDate"));

            foundOrder = new Order(tempOrderId, tempCustomerName, tempDate);
            return foundOrder;

        }

        public List<Order> GetOrderAll()
        {
            List<Order> foundOrders;
            Order readOrder;
            //
            string queryString = "select ID, customerID, orderDate from [Order]";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                con.Open();
                // Execute read
                SqlDataReader orderReader = readCommand.ExecuteReader();
                // Collect data
                foundOrders = new List<Order>();
                while (orderReader.Read())
                {
                    readOrder = GetOrderFromReader(orderReader);
                    foundOrders.Add(readOrder);
                }
            }
            return foundOrders;


        }

        private Order GetOrderFromReader(SqlDataReader orderReader)
        {
            Order foundOrder;
            int tempId, tempCustomerId;
            DateTime tempOrderDate;

            tempId = orderReader.GetInt32(orderReader.GetOrdinal("ID"));
            tempOrderDate = orderReader.GetDateTime(orderReader.GetOrdinal("orderDate"));

            tempCustomerId = orderReader.GetInt32(orderReader.GetOrdinal("customerId"));

            foundOrder = new Order(tempId, tempCustomerId, tempOrderDate);


            return foundOrder;
        }

    }
}
