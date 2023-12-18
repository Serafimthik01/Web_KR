using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webdb
{
    internal class ProductDao
    {
        string connectionOptions = "datasource=localhost;port=3306;username=root;password=root;database=product";


        public List<Product> GetAll()
        {
            List<Product> result = new List<Product>();
            MySqlConnection connection = new MySqlConnection(connectionOptions);
            connection.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM product", connection);
            using MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Product d = new Product
                {
                    id = reader.GetInt32(0),
                    name = reader.GetString(1),
                    quarity = reader.GetInt32(2),
                };
                result.Add(d);
            }
            connection.Close();
            return result;

        }

        public void UpdateAll(int id, string name, int quantity)
        {
            //Product product = new Product { id = id, name = name, quantity = quantity };

            //MySqlConnection connection = new MySqlConnection(connectionOptions);
            //connection.Open();

            ////MySqlCommand cmd = new MySqlCommand($"UPDATE product SET id = {product.id}, name = {product.name}, quarity = {product.quantity--} ", connection);



            //MySqlCommand cmd = new MySqlCommand();
            //cmd.CommandText = "UPDATE product SET id = @product_id, name = @product_name, quarity = @product_quantity WHERE 1";
            //cmd.Parameters.AddWithValue("@product_id", id);
            //cmd.Parameters.AddWithValue("@product_name", name);
            //cmd.Parameters.AddWithValue("@product_quantity", quantity--);



            //cmd.ExecuteNonQuery();
            
            //connection.Close();

        }

    }
}
