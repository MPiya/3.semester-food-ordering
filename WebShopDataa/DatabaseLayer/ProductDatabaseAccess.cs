using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopModel.Model;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;


namespace WebShopData.DatabaseLayer
{
    public class ProductDatabaseAccess : IProductAccess
    {
        readonly string _connectionString;



        public ProductDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Company");
        }

        public ProductDatabaseAccess(string inconnectionString)
        {
            _connectionString = inconnectionString;
        }

        // For test public ProductDatabaseAccess(string inConnectionString) {
        // _connectionString = inConnectionString;
        // }
        
        public int CreateProduct(Product pProduct)
        {
            int insertedId = -1;
            string insertString = "insert into Product (name, price, image , stockQuantity, isStock, discription) OUTPUT" +
                " INSERTED.ID values(@Nam, @Price, @Image,@StockQuantity, @IsStock, @Discription)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                // Prepace SQL
                SqlParameter nameParam = new("@Nam", pProduct.Name);
                CreateCommand.Parameters.Add(nameParam);
                SqlParameter priceParam = new("@Price", pProduct.Price);
                CreateCommand.Parameters.Add(priceParam);
                SqlParameter imageParam = new("@Image", pProduct.Image);
                CreateCommand.Parameters.Add(imageParam);
                SqlParameter stockQuantityParam = new("@StockQuantity", pProduct.StockQuantity);
                CreateCommand.Parameters.Add(stockQuantityParam);
                SqlParameter isStockParam = new("@IsStock", pProduct.IsStock);
                CreateCommand.Parameters.Add(isStockParam);
                SqlParameter discriptionParam = new("@Discription", pProduct.Discription);
                CreateCommand.Parameters.Add(discriptionParam);

                //
                con.Open();
                // Execute save and read generated key (ID)
                insertedId = (int)CreateCommand.ExecuteScalar();
            }
            return insertedId;
        }




         public List<Product> GetProductAll()
        {
            List<Product> foundProducts;
            Product readProduct;
            string queryString = "select id, name, price, image, stockQuantity, isStock, discription from Product";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                con.Open();
                // Execute read
                SqlDataReader productReader = readCommand.ExecuteReader();
                // Collect data
                foundProducts = new List<Product>();
                while (productReader.Read())
                {
                    readProduct = GetProductFromReader(productReader);
                    foundProducts.Add(readProduct);
                }
            }
            return foundProducts;
        }
        private Product GetProductFromReader(SqlDataReader productReader)
        {
            Product foundProduct;
            int tempId;
            string tempName, tempImage;
            double tempPrice;
            int tempStockQuantity;
            bool tempIsStock;
            string tempDiscription;
            tempId = productReader.GetInt32(productReader.GetOrdinal("id"));
            tempName = productReader.GetString(productReader.GetOrdinal("name"));
            tempPrice = productReader.GetDouble(productReader.GetOrdinal("price"));
            tempImage = productReader.GetString(productReader.GetOrdinal("image"));
            tempStockQuantity = productReader.GetInt32(productReader.GetOrdinal("stockQuantity"));
            tempIsStock = productReader.GetBoolean(productReader.GetOrdinal("isStock"));
            tempDiscription = productReader.GetString(productReader.GetOrdinal("discription"));
            foundProduct = new Product(tempId, tempName, tempPrice, tempImage, tempStockQuantity, tempIsStock,tempDiscription );

            return foundProduct;
        }

        public Product GetProductById(int findId)
        {
            Product foundProduct;
            string queryString = "select id, name, price, image, stockQuantity, isStock, discription from Product where id = @Id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                // Prepace SQL
                SqlParameter idParam = new SqlParameter("@id", findId);
                readCommand.Parameters.Add(idParam);
                //
                con.Open();
                // Execute read
                SqlDataReader productReader = readCommand.ExecuteReader();
                foundProduct = new Product();
                while (productReader.Read())
                {
                    foundProduct = GetProductFromReader(productReader);
                }
            }
            return foundProduct;
        }
        public bool UpdateProduct(Product productToUpdate)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProductById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
