using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator
{
    public partial class Kalkulator : Form
    {
        struct Unos
        {
            public double number;
            public string operation;
        }

        List<Unos> stack = new List<Unos>();
        Boolean newNumber = false;
        string currentOperation = null;

        public Kalkulator()
        {
            InitializeComponent();
        }


        void HandleKey(string label)
        {
            var operations = new HashSet<string>() { "+", "-", "/", "*" };

            double trenutnaVrijednost;
            double.TryParse(textbox.Text, out trenutnaVrijednost);

            int brojka;
            int.TryParse(label, out brojka);

            if (newNumber && (brojka != 0 || label == "0"))
            {
                newNumber = false;
                textbox.Text = "";
            }

            if (brojka != 0)
            {
                if (textbox.Text == "0")
                {
                    textbox.Text = "";
                }

                textbox.Text += label;

            }
            else if (label == "0" && textbox.Text != "0")
            {
                textbox.Text += label;
            }
            else if (operations.Contains(label))
            {
                stack.Add(new Unos() { number = trenutnaVrijednost, operation = currentOperation });
                currentOperation = label;
                newNumber = true;
            }
            else if (label == "C")
            {
                if (Math.Abs(trenutnaVrijednost - 0.0) < double.Epsilon)
                {
                    stack.Clear();
                }
                textbox.Text = "0";
            }
            else if (label == ".")
            {
                if (!textbox.Text.Contains("."))
                {
                    textbox.Text += ".";
                }
            }
            else if (label == "=")
            {
                stack.Add(new Unos() { number = trenutnaVrijednost, operation = currentOperation });

                double result = DoMath();

                textbox.Text = result.ToString("0.#####");
                stack.Clear();
                currentOperation = null;
            }
        }

        double DoMath()
        {
            double result = 0;
            foreach (Unos e in stack)
            {
                var oper = e.operation;
                var a = e.number;

                if (oper == "*")
                {
                    result *= a;
                }
                else if (oper == "/")
                {
                    result /= a;
                }
                else if (oper == "+")
                {
                    result += a;
                }
                else if (oper == "-")
                {
                    result -= a;
                }
                else if (oper == null)
                {
                    result = a;
                }
            }

            return result;
        }

        private void HandleClick(object sender, EventArgs e)
        {
            var button = sender as MetroFramework.Controls.MetroTile;
            HandleKey(button.Text);
        }

    }
}
