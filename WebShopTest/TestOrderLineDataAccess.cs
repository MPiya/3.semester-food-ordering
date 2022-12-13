using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopData.DatabaseLayer;
using WebShopModel.Model;
using Xunit.Abstractions;

namespace WebShopTest
{
    public class TestOrderLineDataAccess
    {
        private readonly ITestOutputHelper extraOutput;

        readonly private IOrderLineAccess _orderLineAccess;
		readonly string _connectionString = "Server=hildur.ucn.dk;Database=DMA-CSD-S211_10407521;User id=DMA-CSD-S211_10407521;password= Password1!;";

        public TestOrderLineDataAccess(ITestOutputHelper outPut)
        {
            this.extraOutput = outPut;
            _orderLineAccess = new OrderLineDatabaseAccess(_connectionString);
        }


        [Fact]
        public void TestGetOrderLineAll()
        {
            //Arrange


            //Act
            List<OrderLine> readOrderLines = _orderLineAccess.GetOrderLineAll();
            bool orderLinesWereRead = (readOrderLines.Count > 0);
            //// Print additional output
            extraOutput.WriteLine("Number of orderLines: " + readOrderLines.Count);


            //Assert
            Assert.True(orderLinesWereRead);
        }


    }
}
