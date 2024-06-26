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
    public partial class ListCity : Form
    {
        public ListCity()
        {
            InitializeComponent();
        }

        private void ListCity_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int carID;
            DateTime startDate, endDate;

            if (!int.TryParse(textBox1.Text, out carID))
            {
                MessageBox.Show("Введите ID автомобиля!");
                return;
            }

            if (!DateTime.TryParseExact(textBox2.Text, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out startDate))
            {
                MessageBox.Show("Введите допустимую дату начала в формате гггг-мм-дд");
                return;
            }

            if (!DateTime.TryParseExact(textBox3.Text, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out endDate))
            {
                MessageBox.Show("Введите допустимую дату начала в формате гггг-мм-дд");
                return;
            }

            string connString = "Host=172.20.7.6;Port=5432;Username=st2996;Password=pwd2996;Database=SellCars";

            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    using (NpgsqlCommand cmd = new NpgsqlCommand("GetDeliveryCities", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("carID", carID);
                        cmd.Parameters.AddWithValue("startDate", startDate);
                        cmd.Parameters.AddWithValue("endDate", endDate);

                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridView1.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
