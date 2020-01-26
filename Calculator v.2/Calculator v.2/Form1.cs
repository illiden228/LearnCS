using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_v._2
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private double a = 0d;
        private double b = 0d;
        private string c = "";
        private string toa = "0";
        public bool good = false;
        
        
        public string Toa { get => toa; set => toa = value; }
        public string C { get => c; set => c = value; }
        public double B { get => b; set => b = value; }
        public double A { get => a; set => a = value; }

        

        private void num0_Click(object sender, EventArgs e)
        {
            if (toa != "0")
            {
                Toa = "0";
                mainLabel.Text += toa;
            }
        }

        private void num1_Click(object sender, EventArgs e)
        {
            if (toa == "0")
            {
                Toa = "1";
                mainLabel.Text = toa;
            }
            else
            {
                Toa = "1";
                mainLabel.Text += toa;
            }
        }

        private void num2_Click(object sender, EventArgs e)
        {
            if (toa == "0")
            {
                Toa = "2";
                mainLabel.Text = toa;
            }
            else
            {
                Toa = "2";
                mainLabel.Text += toa;
            }
        }

        private void num3_Click(object sender, EventArgs e)
        {
            if (toa == "0")
            {
                Toa = "3";
                mainLabel.Text = toa;
            }
            else
            {
                Toa = "3";
                mainLabel.Text += toa;
            }
        }

        private void num4_Click(object sender, EventArgs e)
        {
            if (toa == "0")
            {
                Toa = "4";
                mainLabel.Text = toa;
            }
            else
            {
                Toa = "4";
                mainLabel.Text += toa;
            }
        }

        private void num5_Click(object sender, EventArgs e)
        {
            if (toa == "0")
            {
                Toa = "5";
                mainLabel.Text = toa;
            }
            else
            {
                Toa = "5";
                mainLabel.Text += toa;
            }
        }

        private void num6_Click(object sender, EventArgs e)
        {
            if (toa == "0")
            {
                Toa = "6";
                mainLabel.Text = toa;
            }
            else
            {
                Toa = "6";
                mainLabel.Text += toa;
            }
        }

        private void num7_Click(object sender, EventArgs e)
        {
            if (toa == "0")
            {
                Toa = "7";
                mainLabel.Text = toa;
            }
            else
            {
                Toa = "7";
                mainLabel.Text += toa;
            }
        }

        private void num8_Click(object sender, EventArgs e)
        {
            if (toa == "0")
            {
                Toa = "8";
                mainLabel.Text = toa;
            }
            else
            {
                Toa = "8";
                mainLabel.Text += toa;
            }
        }

        private void num9_Click(object sender, EventArgs e)
        {
            if (toa == "0")
            {
                Toa = "9";
                mainLabel.Text = toa;
            }
            else {
                Toa = "9";
                mainLabel.Text += toa;
            }
            
        }

        private void dot_Click(object sender, EventArgs e)
        {
            Toa = ".";
            mainLabel.Text += toa;
        }

        private void plus_Click(object sender, EventArgs e)
        {
            
            //if (good)
            //{
            //    B = Convert.ToDouble(mainLabel.Text);
            //    A = a + b;
            //    C = "+";
            //    good = true;
            //    mainLabel.Text = "0";
            //    Toa = "0";
            //}
            //else {
                A = Convert.ToDouble(mainLabel.Text);
                C = "+";
                good = true;
                mainLabel.Text = "0";
                Toa = "0";

            //}
            
        }

        private void minus_Click(object sender, EventArgs e)
        {
            A = Convert.ToDouble(mainLabel.Text);
            C = "-";
            good = true;
            mainLabel.Text = "0";
            Toa = "0";
        }

        private void multi_Click(object sender, EventArgs e)
        {
            A = Convert.ToDouble(mainLabel.Text);
            C = "*";
            good = true;
            mainLabel.Text = "0";
            Toa = "0";
        }

        private void split_Click(object sender, EventArgs e)
        {
            A = Convert.ToDouble(mainLabel.Text);
            C = "/";
            good = true;
            mainLabel.Text = "0";
            Toa = "0";
        }

        private void ans_Click(object sender, EventArgs e)
        {
            B = Convert.ToDouble(mainLabel.Text);
            switch (C)
            {
            case "+":
                mainLabel.Text = Convert.ToString(a + b);
                break;
            case "-":
                mainLabel.Text = Convert.ToString(a - b);
                break;
            case "*":
                mainLabel.Text = Convert.ToString(a * b);
                break;
            case "/":
                mainLabel.Text = Convert.ToString(a / b);
                break;
            }
            A = B;
            B = Convert.ToDouble(mainLabel.Text);
        }

        private void clearAll_Click(object sender, EventArgs e)
        {
            mainLabel.Text = "0";
            A = 0;
            B = 0;
            Toa = "0";
            good = false;
        }

    }
}
