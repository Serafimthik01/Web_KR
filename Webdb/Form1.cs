using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Webdb
{
    public partial class Form1 : Form
    {
        ProductDao productDao = new ProductDao();

        BindingSource productBindingSource = new BindingSource();

        string connectionOptions = "datasource=localhost;port=3306;username=root;password=root;database=product";

        DataTable dataTable = new DataTable();

        public Form1()
        {
            InitializeComponent();
            productBindingSource.DataSource = productDao.GetAll();
            dataGridView1.DataSource = productBindingSource;
            label1.Visible = false;
            Product product = productDao.GetAll().First();
            if (product.quarity <= 1)
            {
                label1.Visible = true;
                button1.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private List<Product> GetData()
        {
            List<Product> list = new List<Product>();
            return list;
        }

        private void UpdateData()
        {
            var list = GetData();
            dataGridView1.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text1 = textBox1.Text;

            Product product = productDao.GetAll().First();
            using (MySqlConnection connection = new MySqlConnection(connectionOptions))
            {
                connection.Open();

                string updateQuery = $"UPDATE product SET quarity = {product.quarity - 1} WHERE id = {text1}";

                using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                }

                UpdateData();
                productBindingSource.DataSource = productDao.GetAll();
                dataGridView1.DataSource = productBindingSource;

                if (product.quarity <= 1)
                {
                    label1.Visible = true;
                    button1.Enabled = false;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text1 = textBox1.Text;
            Product product = productDao.GetAll().First();

            using (MySqlConnection connection = new MySqlConnection(connectionOptions))
            {
                connection.Open();

                string updateQuery = $"UPDATE product SET quarity = {product.quarity + 1} WHERE id = {text1}";

                using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
            UpdateData();
            productBindingSource.DataSource = productDao.GetAll();
            dataGridView1.DataSource = productBindingSource;
        }
    }
}
