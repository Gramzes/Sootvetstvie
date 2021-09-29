using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Sootvetstvie
{
    class Matrix
    {
        int[,] matrix;
        Form1 form;
        List<TextBox> textBoxes = new List<TextBox>();
        List<Button> x_but = new List<Button>();
        List<Button> y_but = new List<Button>();
        List<int> x_choose = new List<int>();
        List<int> y_choose = new List<int>();
        List<int> result = new List<int>();
        public Matrix(int M1, int M2, Random rnd, Form1 form)
        {
            matrix = new int[M1, M2];
            this.form = form;
            for (int i=0;i<M1; i++)
            {
                for (int k=0; k<M2;k++)
                {
                    matrix[i,k] = rnd.Next(0, 2);
                }
            }
            Show_Matrix();
        }

        void Show_Matrix()
        {
            for (int i = 0; i < matrix.GetLength(0)+1; i++)
            {
                for (int k = 0; k <=matrix.Length/(matrix.GetLength(0)); k++)
                {
                    if (i == 0 && k > 0)
                    {
                        Button but = new Button();
                        x_but.Add(but);
                        but.Text = "x" + k;
                        but.Location = new Point(form.textBox3.Location.X + 40 * k, form.textBox3.Location.Y + 30 * i);
                        but.Size = form.textBox3.Size;
                        form.Controls.Add(but);
                        but.Visible = true;
                        but.Enabled = true;
                        but.Tag = k;
                        but.Click += x_Click;
                    }
                    else if (i > 0 && k == 0)
                    {
                        Button but = new Button();
                        y_but.Add(but);
                        but.Text = "y" + i;
                        but.Location = new Point(form.textBox3.Location.X + 40 * k, form.textBox3.Location.Y + 30 * i);
                        but.Size = form.textBox3.Size;
                        form.Controls.Add(but);
                        but.Visible = true;
                        but.Enabled = true;
                        but.Tag = i;
                        but.Click += y_Click;
                    }
                    else if (i != 0 && k != 0)
                    {
                        TextBox btz = new TextBox();
                        textBoxes.Add(btz);
                        btz.Text = matrix[i - 1, k - 1].ToString();
                        btz.Location = new Point(form.textBox3.Location.X + 40 * k, form.textBox3.Location.Y + 30 * i);
                        btz.Size = form.textBox3.Size;
                        form.Controls.Add(btz);
                        btz.Visible = true;
                        btz.Enabled = false;
                    }
                }
            }
        }

        void x_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            if (but.BackColor == Color.Blue)
            {
                but.BackColor = form.button1.BackColor;
                x_choose.Remove((int)but.Tag-1);
            }
            else
            {
                but.BackColor = Color.Blue;
                x_choose.Add((int)but.Tag-1);
            }
            if (y_choose.Count!=0)
            {
                foreach(int i in y_choose)
                {
                    y_but[i].BackColor = form.button1.BackColor;
                }
                y_choose = new List<int>();
                result = new List<int>();
            }
        }

        void y_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            if (but.BackColor == Color.Blue)
            {
                but.BackColor = form.button1.BackColor;
                y_choose.Remove((int)but.Tag-1);
            }
            else
            {
                but.BackColor = Color.Blue;
                y_choose.Add((int)but.Tag-1);
            }
            if (x_choose.Count != 0)
            {
                foreach (int i in x_choose)
                {
                    x_but[i].BackColor = form.button1.BackColor;
                }
                x_choose = new List<int>();
                result = new List<int>();
            }
        }

        public void galua()
        {
            bool check = true;
            if (y_choose.Count>0)
            {
                for (int i=0; i<matrix.GetLength(1);i++)
                {
                    check = true;
                    for (int k=1; k<y_choose.Count; k++)
                    {
                        if (!(matrix[y_choose[k],i] == 1 && matrix[y_choose[k-1],i]==1))
                        {
                            check = false;
                        }
                    }
                    if (check)
                    {
                        result.Add(i);
                    }
                }
            }
        }
        public void re_galua()
        {
            bool check = true;
            if (x_choose.Count > 0)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    check = true;
                    for (int k = 1; k < x_choose.Count; k++)
                    {
                        if (!(matrix[i, x_choose[k]] == 1 && matrix[i, x_choose[k-1]] == 1))
                        {
                            check = false;
                        }
                    }
                    if (check)
                    {
                        result.Add(i);
                    }
                }
            }
        }

        public string view_galua(string name)
        {
            string str = "{";
            foreach (int i in result)
            {
                str += name +(i+1) + " ";
            }
            str.Remove(str.Length-1,1);
            str.Replace(" ", ", ");
            str += "}";
            result = new List<int>();
            return str;
        }
    }
}
