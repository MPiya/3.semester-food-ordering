using System.Collections.Generic;
using WebShopData.DatabaseLayer;
using WebShopModel.Model;
using Xunit.Abstractions;
using Xunit;

namespace WebShopTest
{
    public class TestProductDataAccess
    {
        private readonly ITestOutputHelper extraOutput;

        readonly private IProductAccess _productAccess;
		readonly string _connectionString = "Server=hildur.ucn.dk;Database=DMA-CSD-S211_10407521;User id=DMA-CSD-S211_10407521;password= Password1!;";

        public TestProductDataAccess(ITestOutputHelper outPut)
        {
            this.extraOutput = outPut;
            _productAccess = new ProductDatabaseAccess(_connectionString);
        }


        [Fact]
        public void TestGetProductAll()
        {
            //Arrange


            //Act
            List<Product> readProducts = _productAccess.GetProductAll();
            bool productsWereRead = (readProducts.Count > 0);
            //// Print additional output
            extraOutput.WriteLine("Number of prodducts: " + readProducts.Count);


            //Assert
            Assert.True(productsWereRead);
        }


    }
}
