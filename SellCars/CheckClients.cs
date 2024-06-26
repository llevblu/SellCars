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
    public partial class CheckClients : Form
    {
        public CheckClients()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = "Host=172.20.7.6;Port=5432;Username=st2996;Password=pwd2996;Database=SellCars";

            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string selectQuery = "SELECT * FROM clients";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(selectQuery, conn))
                    {
                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable clientsTable = new DataTable();
                            adapter.Fill(clientsTable);
                            dataGridView1.DataSource = clientsTable;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }
    }
}
