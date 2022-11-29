using Humanizer;
using Microsoft.Data.SqlClient;
using System.Xml.Linq;
using WebShop.Models;

namespace WebShop.Busniesslogic
{
    public class Databaseaccess
    {

        readonly string _connectionString;



        public Databaseaccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public Databaseaccess(string inconnectionString)    
        {
            _connectionString = inconnectionString;
        }
        public int CreateProduct(ShoppingCart shopCart)
        {

            int insertedId = -1;
            string insertString = "insert into ShoppingCart (ProductId, Count) OUTPUT" + 
                " INSERTED.ShoppingCartId  values(@ProductId,@Count)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                // Prepace SQL
             
                SqlParameter PIDParam = new("@ProductId", shopCart.ProductId);
                CreateCommand.Parameters.Add(PIDParam);
                SqlParameter count= new("@Count", shopCart.Count);
                CreateCommand.Parameters.Add(count);
             

                //
                con.Open();
                // Execute save and read generated key (ID)
                 CreateCommand.ExecuteNonQuery();
            }
            return insertedId;
        }

        public List<ShoppingCart> getAll()
        {
            List<ShoppingCart> foundShoppingCart;
            ShoppingCart readShoppingCart;
            string queryString = "Select ShoppingCartId, ProductId,Count from ShoppingCartId";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                con.Open();
                SqlDataReader shoppingCartReader = readCommand.ExecuteReader();
                foundShoppingCart = new List<ShoppingCart>();
                while (shoppingCartReader.Read())
                {
                    readShoppingCart = GetShoppingCartListFromReader(shoppingCartReader);
                    foundShoppingCart.Add(readShoppingCart);
                }

            }
            return foundShoppingCart;
        }

        public List<ShoppingCart> showTable()
        {
            List<ShoppingCart> foundShoppingCart;
            ShoppingCart readShoppingCart;
            string queryString = " Select ShoppingCart.Count, Product.name, Product.price\r\nFrom Product\r\nINNER JOIN ShoppingCart\r\nOn Product.ID =ShoppingCart.ProductId\r\n\r\n\r\n";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                con.Open();
                SqlDataReader shoppingCartReader = readCommand.ExecuteReader();
                foundShoppingCart = new List<ShoppingCart>();
                while (shoppingCartReader.Read())
                {
                    readShoppingCart = showTableJoinReader(shoppingCartReader);
                    foundShoppingCart.Add(readShoppingCart);
                }
                return foundShoppingCart;
            }
            

        }

        private ShoppingCart showTableJoinReader(SqlDataReader productReader)
        {
            ShoppingCart foundCart;
            int count;
                double Price;
            String name;
           

            count = productReader.GetInt32(productReader.GetOrdinal("Count"));
            name = productReader.GetString(productReader.GetOrdinal("name"));
            Price = productReader.GetDouble(productReader.GetOrdinal("Price"));
         
            foundCart = new ShoppingCart(count,name,Price);

            return foundCart;
        }
        private ShoppingCart GetShoppingCartListFromReader(SqlDataReader productReader)
        {
            ShoppingCart foundCart;
            int tempId, tempPId, tempCount;


            tempId = productReader.GetInt32(productReader.GetOrdinal("ShoppingCartId"));
            tempPId = productReader.GetInt32(productReader.GetOrdinal("ProductId"));
            tempCount = productReader.GetInt32(productReader.GetOrdinal("Count"));

            foundCart = new ShoppingCart(tempId, tempPId, tempCount);

            return foundCart;
        }



    }
}
