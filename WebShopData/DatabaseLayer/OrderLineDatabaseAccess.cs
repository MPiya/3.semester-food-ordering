﻿using Microsoft.Extensions.Configuration;
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
        IOrderLineAccess _orderAccess;
        public OrderLineDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("CompanyConnection");
           _orderAccess = new OrderLineDatabaseAccess(configuration);
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
            string queryString = "select productID, orderID,quantity,totalPrice from OrderLine";
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
            tempSaleQuantity = orderLineReader.GetInt32(orderLineReader.GetOrdinal("quantity"));
            tempTotalPrice = orderLineReader.GetDouble(orderLineReader.GetOrdinal("totalPrice"));

            foundOrderLine = new OrderLine(tempProductID, tempOrderID, tempSaleQuantity, tempTotalPrice);

            return foundOrderLine;
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

                _orderAccess.ReduceProductQuantity(oOrderLine);
                insertedId = (int)CreateCommand.ExecuteNonQuery();
            }
            return insertedId;
        }


        public void ReduceProductQuantity(OrderLine oOrderLine)
        {

            string query = "UPDATE PRODUCT SET stockQuantity =stockQuantity - @value Where ID =@id  AND RowVersion = RowVersion";
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
    }
}

