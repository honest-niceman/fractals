using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.Globalization;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0; 
        }

        public void Drawing(String rule, Graphics e, Pen locpen, float alfa)
        {
            int k = 7;
            float x0 = pictureBox1.Width / 4f;
            float y0 = pictureBox1.Height / 3f;
            float x1 = x0;
            float y1 = y0;
            float alfa1 = 0;          
            Stack<float> stack = new Stack<float>();
            char[] Mas_Rule = rule.ToCharArray();
            for (int i = 0; i < Mas_Rule.Length; i++)
            {
                switch (Mas_Rule[i])
                {
                    case 'F':
                        {
                            x1 += (float)(2 * k * Math.Cos((alfa1 * Math.PI) / 180));
                            y1 += (float)(2 * k * Math.Sin((alfa1 * Math.PI) / 180));
                            e.DrawLine(locpen, x0, y0, x1, y1);
                            x0 = x1;
                            y0 = y1;
                            break;
                        }
                    case '+':
                        {
                            alfa1 += alfa;
                            break;
                        }
                    case '-':
                        {
                            alfa1 -= alfa;
                            break;
                        }
                    case '[':
                        {
                            stack.Push(y1);
                            stack.Push(x1);
                            stack.Push(alfa1);
                            break;
                        }
                    case ']':
                        {
                            alfa1 = stack.Pop();
                            x1 = stack.Pop();
                            y1 = stack.Pop();
                            x0 = x1;
                            y0 = y1;
                            break;
                        }
                }
            }
        }

        public string Printing(string Axiom, string rule, int step)
        {
            string LastFormula = Axiom;
            if (step == 0)
            {
                char[] tmp = LastFormula.ToCharArray();
                LastFormula = Axiom;
            }
            else
            {
                for (int j = 0; j < step; j++)
                {
                    int k = 0;
                    char[] tmp = LastFormula.ToCharArray();
                    for (int i = 0; i < tmp.Length; i++)
                    {
                        if (tmp[i] == 'F')
                        {
                            LastFormula = LastFormula.Remove(k, 1);
                            LastFormula = LastFormula.Insert(k, rule);
                            k += rule.Length;
                            continue;
                        }
                        k++;
                    }
                }
            }
            return LastFormula;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pen pen1 = new Pen(Color.Black, 1);
            Graphics gr = pictureBox1.CreateGraphics();
            if (int.TryParse(textBox1.Text, out int i) && (i < 11 && i > -1))
            {

                richTextBox1.Text = Printing(textBox3.Text, textBox2.Text, i);
                gr.Clear(Color.White);
                Drawing(richTextBox1.Text, gr, pen1, float.Parse(textBox4.Text));
            }
            else
            {
                textBox1.Text = "";
                textBox1.Focus();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            pictureBox1.Image = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pen pen1 = new Pen(Color.Black, 1);
            Graphics gr = pictureBox1.CreateGraphics();
            if (int.TryParse(textBox1.Text, out int i) && (i < 12 && i > 0))
            {

                richTextBox1.Text = Printing(textBox3.Text, textBox2.Text, i-1);
                gr.Clear(Color.White);
                Drawing(richTextBox1.Text, gr, pen1, float.Parse(textBox4.Text));
                i -= 1;
                textBox1.Text = i.ToString();
            }
            else
            {
                textBox1.Text = "";
                textBox1.Focus();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Pen pen1 = new Pen(Color.Black, 1);
            Graphics gr = pictureBox1.CreateGraphics();
            if (int.TryParse(textBox1.Text, out int i) && (i < 10 && i > -2))
            {

                richTextBox1.Text = Printing(textBox3.Text, textBox2.Text, i + 1);
                gr.Clear(Color.White);
                Drawing(richTextBox1.Text, gr, pen1, float.Parse(textBox4.Text));
                i += 1;
                textBox1.Text = i.ToString();
            }
            else
            {
                textBox1.Text = "";
                textBox1.Focus();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Back)
            {
                return;
            }
            if (e.KeyChar == 'F')
            {
                return;
            }
            if(e.KeyChar == '-')
            {
                return;
            }
            if(e.KeyChar == '+')
            {
                return;
            }
            if (e.KeyChar == '[')
            {
                return;
            }
            if(e.KeyChar == ']')
            {
                return;
            }
            e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (Char)Keys.Back)
            {
                return;
            }
            if (e.KeyChar == 'F')
            {
                return;
            }
            if (e.KeyChar == '-')
            {
                return;
            }
            if (e.KeyChar == '+')
            {
                return;
            }
            if (e.KeyChar == '[')
            {
                return;
            }
            if (e.KeyChar == ']')
            {
                return;
            }
            e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (e.KeyChar == (Char)Keys.Back)
            {
                return;
            }
            e.Handled = true;
        }

        private void мойВариантToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox3.Text = "F+F+F+F";
            textBox2.Text = "FF+F+F+F+F+F-F";
            textBox4.Text = "90";
            textBox1.Text = "1";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                CultureInfo ci = new CultureInfo("ru-RU");
                Assembly a = Assembly.Load("WindowsFormsApp1");
                ResourceManager rm = new ResourceManager("WindowsFormsApp1.Lang-Ru", a);
                label1.Text = rm.GetString("rule", ci);
                label2.Text = rm.GetString("step0", ci);
                label3.Text = rm.GetString("step", ci);
                label4.Text = rm.GetString("angle", ci);
                button1.Text = rm.GetString("create", ci);
                button2.Text = rm.GetString("clear", ci);
                button3.Text = rm.GetString("back", ci);
                button4.Text = rm.GetString("forward", ci);
                TaskToolStripMenuItem.Text = rm.GetString("task", ci);
                menuStrip1.Text = rm.GetString("labrab", ci);
            }
            if(comboBox1.SelectedIndex == 1)
            {
                CultureInfo ci = new CultureInfo("en-US");
                Assembly a = Assembly.Load("WindowsFormsApp1");
                ResourceManager rm = new ResourceManager("WindowsFormsApp1.Lang-En", a);
                label1.Text = rm.GetString("rule", ci);
                label2.Text = rm.GetString("step0", ci);
                label3.Text = rm.GetString("step", ci);
                label4.Text = rm.GetString("angle", ci);
                button1.Text = rm.GetString("create", ci);
                button2.Text = rm.GetString("clear", ci);
                button3.Text = rm.GetString("back", ci);
                button4.Text = rm.GetString("forward", ci);
                TaskToolStripMenuItem.Text = rm.GetString("task", ci);
                menuStrip1.Text = rm.GetString("labrab", ci);
            }
            if(comboBox1.SelectedIndex == 2)
            {

                CultureInfo ci = new CultureInfo("fr-FR");
                Assembly a = Assembly.Load("WindowsFormsApp1");
                ResourceManager rm = new ResourceManager("WindowsFormsApp1.Lang-Fr", a);
                label1.Text = rm.GetString("rule", ci);
                label2.Text = rm.GetString("step0", ci);
                label3.Text = rm.GetString("step", ci);
                label4.Text = rm.GetString("angle", ci);
                button1.Text = rm.GetString("create", ci);
                button2.Text = rm.GetString("clear", ci);
                button3.Text = rm.GetString("back", ci);
                button4.Text = rm.GetString("forward", ci);
                TaskToolStripMenuItem.Text = rm.GetString("task", ci);
                menuStrip1.Text = rm.GetString("labrab", ci);
            }
        }
    }
}
