using System.Collections.Generic;
using System.Data.SqlClient;
using WebShopData.DatabaseLayer;
using WebShopModel.Model;
using Xunit;
using Xunit.Abstractions;




namespace WebShopTest
{
    public class TestOrderDataAccess
    {
        private readonly ITestOutputHelper extraOutput;

        readonly private IOrderAccess _orderAccess;
        readonly string _connectionString = "Server=hildur.ucn.dk;Database=DMA-CSD-S211_10407521;User id=DMA-CSD-S211_10407521;password= Password1!;";


        public TestOrderDataAccess(ITestOutputHelper outPut)
        {
            this.extraOutput = outPut;
            _orderAccess = new OrderDatabaseAccess(_connectionString);
        }


        [Fact]
        public void TestGetOrderAll()
        {
            //Arrange


            //Act
            List<Order> readOrders = _orderAccess.GetOrderAll();
            bool ordersWereRead = (readOrders.Count > 0);
            //// Print additional output
            extraOutput.WriteLine("Number of orders: " + readOrders.Count);


            //Assert
            Assert.True(ordersWereRead);
        }

        [Fact]
        // orderId return true if it returns >0 because there is executeScalar in the method CreateOrder
        public void TestCreateOrder()
        {
            //Arrange
           //335 is customerID in DB 
            DateTime currentDateTime = DateTime.Now;
            Order order = new(335, currentDateTime);

            //Act
            int orderID = _orderAccess.CreateOrder(order);
            bool checkId= (orderID > 0);
        

            //Assert
            Assert.True(checkId);
        }

       
        

    }
}
