using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Convert;

namespace Creating_an_application_win_forms
{
    public partial class shop : Form
    {
        List<int> prices = new List<int>() { };

        public shop()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            double sum;
            int breadCount = ToInt32(numericUpDown1.Text);
            int shocoladeCount = ToInt32(numericUpDown2.Text);
            int sausageCount = ToInt32(numericUpDown3.Text);
            int sheeseCount = ToInt32(numericUpDown4.Text);
            int tomatoCount = ToInt32(numericUpDown5.Text);
            int potatoCount = ToInt32(numericUpDown6.Text);

            sum = prices[0] * breadCount + prices[1] * shocoladeCount + prices[2] * sausageCount + prices[3] * sheeseCount / 1000 + prices[4] * tomatoCount / 1000 + prices[5] * potatoCount / 1000;

            string promo = textBox1.Text;

            textBox2.ReadOnly = true;
            try
            {
                double promoPersentage = double.Parse(promo) / 100;
                if (promoPersentage < 1)
                {
                    sum -= sum * promoPersentage;
                }
                textBox2.Text = sum.ToString();
            }
            catch
            {
                textBox2.Text = sum.ToString();
            }

            if (sum > 0)
            {
                DateTime centuryBegin = new DateTime(2022, 12, 31); //событие от которого рассчитывается количество тактов
                DateTime currentDate = DateTime.Now;
                long elapsedTicks = currentDate.Ticks - centuryBegin.Ticks;

                string connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Magazine;Integrated Security=True;Pooling=False";
                string sqlExpression = $"INSERT INTO TotalCheck VALUES({elapsedTicks}, {ToInt32(sum)}, '{breadCount} {shocoladeCount} {sausageCount} {sheeseCount} {tomatoCount} {potatoCount}');";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    reader.Close();
                }
            }

        }

        private void shop_Load(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '*';

            string connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Magazine;Integrated Security=True;Pooling=False";
            string sqlExpression = "SELECT * FROM Products";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    // выводим названия столбцов
                    Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                    while (reader.Read()) // построчно считываем данные
                    {
                        object id = reader.GetValue(0);
                        object name = reader.GetValue(1);
                        object price = reader.GetValue(2);

                        prices.Add(ToInt32(reader.GetValue(2)));

                        Console.WriteLine("{0} \t{1} \t{2}", id, name, price);
                    }
                }
                reader.Close();
            }
        }
    }
}
