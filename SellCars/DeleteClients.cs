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

namespace SellCars
{
    public partial class DeleteClients : Form
    {
        public DeleteClients()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int clientID;

            if (!int.TryParse(textBox1.Text, out clientID))
            {
                MessageBox.Show("Пожалуйста, введите действительный идентификатор клиента");
                return;
            }

            string connString = "Host=172.20.7.6;Port=5432;Username=st2996;Password=pwd2996;Database=SellCars";

            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string deleteOrderCarQuery = @"
                                DELETE FROM Order_Car 
                                USING Orders
                                WHERE Order_Car.order_id = Orders.order_id
                                AND Orders.client_id = @clientID";
                            using (NpgsqlCommand cmd = new NpgsqlCommand(deleteOrderCarQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("clientID", clientID);
                                cmd.ExecuteNonQuery();
                            }

                            string deleteOrdersQuery = "DELETE FROM Orders WHERE client_id = @clientID";
                            using (NpgsqlCommand cmd = new NpgsqlCommand(deleteOrdersQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("clientID", clientID);
                                cmd.ExecuteNonQuery();
                            }

                            string deleteCarsQuery = @"
                                DELETE FROM Car 
                                USING Orders
                                WHERE Car.car_id = Orders.order_id
                                AND Orders.client_id = @clientID";
                            using (NpgsqlCommand cmd = new NpgsqlCommand(deleteCarsQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("clientID", clientID);
                                cmd.ExecuteNonQuery();
                            }

                            string deleteClientQuery = "DELETE FROM Clients WHERE client_id = @clientID";
                            using (NpgsqlCommand cmd = new NpgsqlCommand(deleteClientQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("clientID", clientID);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Клиент успешно удален");
                                }
                                else
                                {
                                    MessageBox.Show("Клиент не найден");
                                }
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Ошибка: " + ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        private void DeleteClients_Load(object sender, EventArgs e)
        {

        }
    }
}
