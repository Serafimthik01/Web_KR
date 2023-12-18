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
            //button2.Visible = false;
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

                // Ваш SQL-запрос для обновления данных
                string updateQuery = $"UPDATE product SET quarity = {product.quarity - 1} WHERE id = {text1}";

                using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                {
                    // Выполнение запроса
                    int rowsAffected = command.ExecuteNonQuery();

                    //if (rowsAffected > 0)
                    //{
                    //    // Обновление выполнено успешно
                    //    MessageBox.Show("Данные успешно обновлены.");
                    //}
                    //else
                    //{
                    //    // Ни одна запись не была обновлена
                    //    MessageBox.Show("Нет записей для обновления.");
                    //}
                }


                //dataGridView1.DataSource = typeof(List);
                //dataGridView1.DataSource = itemStates;

                //dataTable.Clear();
                //updateQuery.ResetBindings();

                //dataGridView1.Refresh();

                UpdateData();
                productBindingSource.DataSource = productDao.GetAll();
                dataGridView1.DataSource = productBindingSource;


                if (product.quarity <= 1)
                {
                    label1.Visible = true;
                    button1.Enabled = false;
                }

            }


            //int id = (int)dataGridView1.Rows[0].Cells[0].Value;
            //string name = (string)dataGridView1.Rows[0].Cells[1].Value;
            //int quantity = (int)dataGridView1.Rows[0].Cells[2].Value;

            //productDao.UpdateAll(id, name, quantity);

            //productBindingSource.DataSource = productDao.GetAll();
            //dataGridView1.DataSource = productBindingSource;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text1 = textBox1.Text;
            Product product = productDao.GetAll().First();

            using (MySqlConnection connection = new MySqlConnection(connectionOptions))
            {
                connection.Open();

                // Ваш SQL-запрос для обновления данных
                string updateQuery = $"UPDATE product SET quarity = {product.quarity + 1} WHERE id = {text1}";

                using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                {
                    // Выполнение запроса
                    int rowsAffected = command.ExecuteNonQuery();



                    //dataTable.Clear();

                    //// Обновление DataGridView
                    //dataGridView1.Refresh();
                }
            }
            UpdateData();
            productBindingSource.DataSource = productDao.GetAll();
            dataGridView1.DataSource = productBindingSource;
        }
    }
}
