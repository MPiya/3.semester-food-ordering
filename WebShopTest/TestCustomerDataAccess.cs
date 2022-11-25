using System.Collections.Generic;
using WebShopData.DatabaseLayer;
using WebShopModel.Model;
using Xunit;
using Xunit.Abstractions;

namespace WebShopTest
{
    public class TestCustomerDataAccess
    {
        private readonly ITestOutputHelper extraOutput;

        readonly private ICustomerAccess _customerAccess;
        readonly string _connectionString = "Server=hildur.ucn.dk;Database=DMA-CSD-S211_10407521;User id=DMA-CSD-S211_10407521;password= Password1!;";

        public TestCustomerDataAccess(ITestOutputHelper outPut)
        {
            this.extraOutput = outPut;
            _customerAccess = new CustomerDatabaseAccess(_connectionString);
        }


        [Fact]
        public void TestGetCustomerAll()
        { // Arrange


          // Act

            List<Customer> readCustomers = _customerAccess.GetCustomerAll();
            bool customersWereRead = (readCustomers.Count > 0);
            // Print additional output
            extraOutput.WriteLine("Number of customers: " + readCustomers.Count);
            // Assert
            Assert.True(customersWereRead);
        }

    }


}