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
            DateTime insertedDateTime = DateTime.Now;
            //
            string insertString = "insert into [order](customerID) OUTPUT INSERTED.ID  values" +
                "(@customerID)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                // Prepace SQL
           
                SqlParameter customerIdParam = new("@cusotmerID", aOrder.customerId);
                CreateCommand.Parameters.Add(customerIdParam);
              //  SqlParameter paymentTypeParam = new("@paymentType", aOrder.paymentType);
             //   CreateCommand.Parameters.Add(paymentTypeParam);
              
     
                //
                con.Open();
                //
                // Execute save and read generated key (ID)
                insertedId = (int)CreateCommand.ExecuteScalar();
                insertedDateTime = (DateTime)CreateCommand.ExecuteScalar();

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

        public bool UpdateOrder(Order orderToUUpdate)
        {
            throw new NotImplementedException();
        }

       


       
    }
}
