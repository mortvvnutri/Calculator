using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Creating_an_application_win_forms
{
    public partial class Salon : Form
    {
        
        public Salon()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = true;
            label1.Visible = false;
            checkBox1.Visible = true;
            checkBox2.Visible = true;
            checkBox3.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            radioButton4.Visible = true;
            radioButton5.Visible = true;
            radioButton6.Visible = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = true;
            label1.Visible = false;
            label3.Visible = true;
            checkBox1.Visible = true;
            checkBox2.Visible = true;
            checkBox3.Visible = true;
            label2.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
        }

        private void Salon_Load(object sender, EventArgs e)
        {
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            radioButton6.Visible = false;
            button3.Visible = false;
            
        }


        public void button3_Click(object sender, EventArgs e)
        {
            int sum1 = 0;
            int stri = 0;
            int procedures01 = 0;
            int procedures11 = 0;
            int procedures21 = 0;
            int coloring = 0;
            try
            {
                textBox2.Text = null;
                label3.Visible = true;
                textBox2.Visible = true;
                bool stri0 = radioButton1.Checked;
                bool stri1 = radioButton2.Checked;
                bool stri2 = radioButton3.Checked;
                bool stri3 = radioButton4.Checked;
                bool stri4 = radioButton5.Checked;
                bool stri5 = radioButton6.Checked;
                bool procedures0 = checkBox1.Checked;
                bool procedures1 = checkBox2.Checked;
                bool procedures2 = checkBox3.Checked;
                string coloring0 = textBox1.Text;
                string coloring1 = textBox3.Text;
                int c0 = coloring0.Length;
                int c1 = coloring1.Length;


                if (stri0)
                {
                    stri = 1000;
                }
                else if (stri1)
                {
                    stri = 1500;
                }
                else if (stri2)
                {
                    stri = 1600;
                }
                else if (stri3)
                {
                    stri = 500;
                }
                else if (stri4)
                {
                    stri = 300;
                }
                else if (stri5)
                {
                    stri = 150;
                }
                if (procedures0)
                {
                    procedures01 = 1000;
                }
                else if (procedures1)
                {
                    procedures11 = 1500;
                }
                else if (procedures2)
                {
                    procedures21 = 1600;
                }
                if (c0 != 0)
                {
                    coloring = 1500;
                }
                else if (c1 != 0)
                {
                    coloring = 1000;
                }
                sum1 = stri + procedures01 + procedures11 + procedures21 + coloring;
                string sum = sum1.ToString();
                textBox2.ReadOnly = true;
                textBox2.Text = sum;
                sum1 = 0;
                sum = null;

            }
            catch{
                MessageBox.Show("Проверьте правильность введённых данных");
            }


        }

        
    }
}
