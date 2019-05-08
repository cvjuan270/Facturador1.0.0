using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;

namespace FormBase1
{
    public partial class FormCalculadora : Form
    {
        double Num1, Result;
        double Num2 = 0.0;
        string Operador;

        public FormCalculadora(int x, int y)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.DesktopLocation = new Point(x, y);


        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "0";
        }

        private void buttonPun_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + ".";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "9";
        }

        private void buttonCopCam_Click(object sender, EventArgs e)
        {
         //   Form1 form1 = Owner as Form1;
          //  form1.textBoxButton2.Text = textBox1.Text;
          //  this.Close();
        }

        public void buttonDiv_Click(object sender, EventArgs e)
        {
            Num1 = double.Parse(textBox1.Text);
            Operador = "Div";
            textBox1.Text = "";
        }

        private void buttonMul_Click(object sender, EventArgs e)
        {
            Num1 = double.Parse(textBox1.Text);
            Operador = "Mul";
            textBox1.Text = "";
        }

        private void buttonRes_Click(object sender, EventArgs e)
        {
            Num1 = double.Parse(textBox1.Text);
            Operador = "Res";
            textBox1.Text = "";
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
            if ((char.IsNumber(e.KeyChar)) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator))
            {

            }
            else
            {
                e.Handled = true;
                return;
            }
        }

        private void buttonSum_Click(object sender, EventArgs e)
        {
            Num1 = double.Parse(textBox1.Text);
            Operador = "Sum";
            textBox1.Text = "";
        }

        private void FormCalculadora_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!textBox1.Focused)
            {
                textBox1.Focus();
                textBox1.Text += e.KeyChar;
                textBox1.Select(textBox1.Text.Length + 1, 0);
            }

            switch (e.KeyChar)
            {
                case (char)Keys.Escape:
                    this.Close();
                    break;
                case (char)Keys.Enter:
                    Calcular();
                    break;
                case '/':
                    Num1 = double.Parse(textBox1.Text);
                    Operador = "Div";
                    textBox1.Text = "";
                    break;

                case '*':
                    Num1 = double.Parse(textBox1.Text);
                    Operador = "Mul";
                    textBox1.Text = "";
                    break;

                case '-':
                    Num1 = double.Parse(textBox1.Text);
                    Operador = "Res";
                    textBox1.Text = "";
                    break;

                case '+':
                    Num1 = double.Parse(textBox1.Text);
                    Operador = "Sum";
                    textBox1.Text = "";
                    break;
            }
        }

        private void buttonIgu_Click(object sender, EventArgs e)
        {
            Calcular();
        }
        public void Calcular()
        {
            try
            {

                switch (Operador)
                {
                    case "Div":
                        Num2 = double.Parse(textBox1.Text);
                        Result = Num1 / Num2;
                        textBox1.Text = Result.ToString();
                        break;
                    case "Mul":
                        Num2 = double.Parse(textBox1.Text);
                        Result = Num1 * Num2;
                        textBox1.Text = Result.ToString();
                        break;
                    case "Sum":
                        Num2 = double.Parse(textBox1.Text);
                        Result = Num1 + Num2;
                        textBox1.Text = Result.ToString();
                        break;
                    case "Res":
                        Num2 = double.Parse(textBox1.Text);
                        Result = Num1 - Num2;
                        textBox1.Text = Result.ToString();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                textBox1.Text = ex.Message;
            }
        }
    }
}
