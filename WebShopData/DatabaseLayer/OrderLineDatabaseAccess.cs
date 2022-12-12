using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopModel.Model;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace WebShopData.DatabaseLayer
{
    public class OrderLineDatabaseAccess : IOrderLineAccess
    {
        readonly string _connectionString;
        private int tempSaleQuantity;

        public OrderLineDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("CompanyConnection");
        }
        public OrderLineDatabaseAccess(string inconnectionString)
        {
            _connectionString = inconnectionString;
        }


        
        public OrderLine GetOrderLineByProductID(int findProductID)
        {
            OrderLine foundOrderLine;
            string queryString = "select productID, orderID, saleQuentity, totalPrice, from OrderLine where productI = @ProductID";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                // Prepace SQL
                SqlParameter productIDParam = new SqlParameter("@productID", findProductID);
                readCommand.Parameters.Add(productIDParam);
                //
                con.Open();
                // Execute read
                SqlDataReader orderLineReader = readCommand.ExecuteReader();
                foundOrderLine = new OrderLine();
                while (orderLineReader.Read())
                {
                    foundOrderLine = GetOrderLineFromReader(orderLineReader);
                }
            }
            return foundOrderLine;
        }
        public List<OrderLine> GetOrderLineAll()
        {
            List<OrderLine> foundOrderLines;
            OrderLine readOrderLine;
            string queryString = "select productID, orderID, saleQuantity , totalPrice from OrderLine";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                con.Open();
                // Execute read
                SqlDataReader orderLineReader = readCommand.ExecuteReader();
                // Collect data
                foundOrderLines = new List<OrderLine>();
                while (orderLineReader.Read())
                {
                    readOrderLine = GetOrderLineFromReader(orderLineReader);
                    foundOrderLines.Add(readOrderLine);
                }
            }
            return foundOrderLines;
        }
        private OrderLine GetOrderLineFromReader(SqlDataReader orderLineReader)
        {
            OrderLine foundOrderLine;
            int tempProductID, tempOrderID, tempSaleQuantity;
            double tempTotalPrice;
            tempProductID = orderLineReader.GetInt32(orderLineReader.GetOrdinal("productID"));
            tempOrderID = orderLineReader.GetInt32(orderLineReader.GetOrdinal("orderID"));
            tempSaleQuantity = orderLineReader.GetInt32(orderLineReader.GetOrdinal("saleQuantity"));
            tempTotalPrice = orderLineReader.GetDouble(orderLineReader.GetOrdinal("totalPrice"));

            foundOrderLine = new OrderLine(tempProductID, tempOrderID, tempSaleQuantity, tempTotalPrice);

            return foundOrderLine;
        }


        public bool UpdateOrderLine(OrderLine OrderLineToUpdate)
        {
            throw new NotImplementedException();
        }

        public int CreateOrderLine(OrderLine oOrderLine)
        {

            int insertedId = -1;
            string insertString = "insert into OrderLine ( productID, orderID, saleQuantity, totalPrice) OUTPUT" +
                " INSERTED.ID values(@Product, @OrderID, @SaleQuantity,@TotalPrice";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                // Prepace SQL
                SqlParameter productIDParam = new("@ProductID", oOrderLine.ProductID);
                CreateCommand.Parameters.Add(productIDParam);
                SqlParameter orderIDParam = new("@OrderID", oOrderLine.OrderID);
                CreateCommand.Parameters.Add(orderIDParam);
                SqlParameter saleQuantityParam = new("@SaleQuantity", oOrderLine.Quantity);
                CreateCommand.Parameters.Add(saleQuantityParam);
                SqlParameter totalPriceParam = new("@ProductID", oOrderLine.TotalPrice);
                CreateCommand.Parameters.Add(totalPriceParam);
                //
                con.Open();
                // Execute save and read generated key (ID)
                insertedId = (int)CreateCommand.ExecuteScalar();
            }
            return insertedId;
        }
    }
}

