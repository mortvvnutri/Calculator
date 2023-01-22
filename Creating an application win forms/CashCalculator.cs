using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Creating_an_application_win_forms
{
    public partial class CashCalculator : Form
    {
        public CashCalculator()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string rub = textBox1.Text;
                WebClient client = new WebClient();
                var xml = client.DownloadString("https://www.cbr-xml-daily.ru/daily.xml");
                XDocument xdoc = XDocument.Parse(xml);
                var el = xdoc.Element("ValCurs").Elements("Valute");
                string eur = el.Where(x => x.Attribute("ID").Value == "R01239").Select(x => x.Element("Value").Value).FirstOrDefault();
                string sek = el.Where(x => x.Attribute("ID").Value == "R01770").Select(x => x.Element("Value").Value).FirstOrDefault();
                string jpy = el.Where(x => x.Attribute("ID").Value == "R01820").Select(x => x.Element("Value").Value).FirstOrDefault();
                double eur1 = Math.Round(Convert.ToDouble(rub) / Convert.ToDouble(eur), 2);
                double sek1 = Math.Round(Convert.ToDouble(rub) / Convert.ToDouble(sek), 2);
                double jpy1 = Math.Round(Convert.ToDouble(rub) / Convert.ToDouble(jpy), 2);
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox2.Text = eur1.ToString() + " €";
                textBox3.Text = sek1.ToString() + " kr";
                textBox4.Text = jpy1.ToString() + " ¥";
            }
            catch
            {
                MessageBox.Show("Проверьте правильность введённых данных"); 
            }
        }

        private void CashCalculator_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(185, 197, 143);
            label2.BackColor = Color.FromArgb(185, 197, 143);
            label3.BackColor = Color.FromArgb(185, 197, 143);
            label4.BackColor = Color.FromArgb(185, 197, 143);
            textBox1.BackColor = Color.FromArgb(208, 167, 128);
            textBox2.BackColor = Color.FromArgb(208, 167, 128);
            textBox3.BackColor = Color.FromArgb(208, 167, 128);
            textBox4.BackColor = Color.FromArgb(208, 167, 128);
        }

        
    }
}
