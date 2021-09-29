using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sootvetstvie
{
    public partial class Form1 : Form
    {
        Matrix matrix;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int M1, M2;
            if (int.TryParse(textBox1.Text,out M1) && int.TryParse(textBox2.Text, out M2) && M1 > 0 && M2 > 0)
            {
                matrix = new Matrix(M1, M2, new Random(), this);
            }
            else
            {
                MessageBox.Show("Значения введены неверно");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            matrix.galua();
            textBox4.Text = matrix.view_galua("x");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            matrix.re_galua();
            textBox4.Text = matrix.view_galua("y");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
