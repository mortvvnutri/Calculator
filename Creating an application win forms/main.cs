using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Creating_an_application_win_forms
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            shop newForm = new shop();
            newForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CashCalculator newForm = new CashCalculator();
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Salon newForm = new Salon();
            newForm.Show();
        }
    }
}
