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
    }
}
