using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopData.DatabaseLayer;
using WebShopModel.Model;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata.Ecma335;

namespace WebShopData.DatabaseLayer
{
    public class OrderDatabaseAccess : IOrderAccess
    {
        readonly string _connectionString;

        public OrderDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("CompanyConnection");
        }



        // For test
        public OrderDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;
        }
        public int CreateOrder(Order aOrder)

        {
            int insertedId = -1;

            //
            string insertString = "insert into [order] (customerID,orderDate)  OUTPUT " +
                " INSERTED.ID values  (@wdwd,@OrderDate)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                // Prepace SQL
                SqlParameter customerIdParam = new("@wdwd", aOrder.customerId);
                CreateCommand.Parameters.Add(customerIdParam);
                SqlParameter orderDateParam = new("@OrderDate", aOrder.orderDate);
                CreateCommand.Parameters.Add(orderDateParam);
        
                con.Open();
                //
                // Execute save and read generated key (ID)
                insertedId = (int)CreateCommand.ExecuteScalar();


            }
            return insertedId;
        }



        public bool DeleteOrder(int id)
        {
            throw new NotImplementedException();
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

            foundOrder = new Order(tempId,tempCustomerId, tempOrderDate);
              

            return foundOrder;
        }

        public Order GetOrderById(int findId)
        {
            /* Three possible returns:
            * A Person object
            * An empty Person object (no match on id)
            * Null - Some error occurred
            */
            Order foundOrder;
            //
            string queryString = "select ID,orderDate, customerID, paymentType, notes from [order] where ID = @ID";
            using (SqlConnection con = new SqlConnection(_connectionString))
                using(SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                //Prepare SQL
                SqlParameter idParam = new SqlParameter("@ID", findId);
                readCommand.Parameters.Add(idParam);
                //
                con.Open();
                //Execute read
                SqlDataReader orderReader = readCommand.ExecuteReader();    
                foundOrder = new Order();
                while (orderReader.Read())
                {
                    foundOrder = GetOrderFromReader(orderReader);
                }

            }
            return foundOrder;
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
        public bool UpdateOrder(Order orderToUUpdate)
        {
            throw new NotImplementedException();
        }

        
    }
}
