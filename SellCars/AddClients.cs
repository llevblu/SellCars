using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SellCars
{
    public partial class AddClients : Form
    {
        public AddClients()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int clientID;
            string address = textBox2.Text;
            string phone = textBox3.Text;
            DateTime purchaseDate;
            string city = textBox4.Text;

            if (!int.TryParse(textBox1.Text, out clientID))
            {
                MessageBox.Show("Пожалуйста, введите действительный идентификатор клиента");
                return;
            }

            if (string.IsNullOrEmpty(address) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(city))
            {
                MessageBox.Show("Пожалуйста, заполните все поля");
                return;
            }

            if (!DateTime.TryParseExact(textBox5.Text, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out purchaseDate))
            {
                MessageBox.Show("Пожалуйста, введите действительную дату покупки в формате гггг-мм-дд");
                return;
            }

            string connString = "Host=172.20.7.6;Port=5432;Username=st2996;Password=pwd2996;Database=SellCars";

            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string insertQuery = "INSERT INTO clients (client_id, Address, Phone_number, Purchase_date, City) " +
                                         "VALUES (@clientID, @address, @phone, @purchaseDate, @city)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("clientID", clientID);
                        cmd.Parameters.AddWithValue("address", address);
                        cmd.Parameters.AddWithValue("phone", phone);
                        cmd.Parameters.AddWithValue("purchaseDate", NpgsqlTypes.NpgsqlDbType.Date, purchaseDate);
                        cmd.Parameters.AddWithValue("city", city);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Клиент успешно добавлен");
                        }
                        else
                        {
                            MessageBox.Show("Ошибка при добавлении клиента");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }

                

            }
        }

        private void AddClients_Load(object sender, EventArgs e)
        {

        }
    }
}
