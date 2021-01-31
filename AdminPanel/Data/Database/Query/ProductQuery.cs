using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminPanel.Content.Model.Product;
using MySql.Data.MySqlClient;


namespace AdminPanel.Data.Database.Query
{
    class ProductQuery
    {
        private static Database database;

        static ProductQuery()
        {
            database = Database.Instance();
        }

        public static List<Product> getProducts()
        {
            List<Product> products = new List<Product>();
            string queryString = "SELECT * FROM product LIMIT 50";

            if (database.isConnected())
            {
                var results = new MySqlCommand(queryString, database.Connection);
                MySqlDataReader reader = results.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product(
                        reader.GetInt32("id"),
                        reader.GetString("name"),
                        reader.GetString("url"),
                        reader.GetFloat("price"),
                        reader.GetString("brand"),
                        reader.GetString("img_url"),
                        reader.GetFloat("rating")
                        );
                    products.Add(product);
                }
            }
            return products;
        }

        public static Product getProduct(int ID)
        {
            string queryString = "SELECT * FROM product WHERE id="+ID+" LIMIT 1";
            if (database.isConnected())
            {
                var results = new MySqlCommand(queryString, database.Connection);
                MySqlDataReader reader = results.ExecuteReader();
                if (reader.Read())
                {
                    Product product = new Product(
                        reader.GetInt32("id"),
                        reader.GetString("name"),
                        reader.GetString("url"),
                        reader.GetFloat("price"),
                        reader.GetString("brand"),
                        reader.GetString("img_url"),
                        reader.GetFloat("rating")
                        );
                    reader.Close();
                    return product;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
            else return null;
            
            
        }

        public static bool updateProduct(string queryString)
        {
            try
            {
                MySqlCommand sqlCmd = new MySqlCommand(queryString, database.Connection);
                MySqlDataReader reader = sqlCmd.ExecuteReader();
                Console.WriteLine("Update Executed");
                if (reader.Read())
                {
                    Console.WriteLine("Reader reads");
                }
                return true;
            }
            catch(MySqlException e)
            {
                Console.WriteLine("Error Mysql");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                
            }
            return false;
        }

    }
}
