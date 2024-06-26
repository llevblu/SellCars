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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListCity listCity = new ListCity();
            listCity.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddClients addClients = new AddClients();
            addClients.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteClients deleteClients = new DeleteClients();
            deleteClients.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CheckClients checkClients = new CheckClients();
            checkClients.ShowDialog();
        }
    }
}
