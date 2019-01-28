using System;
using System.Linq;
using System.Windows.Forms;

namespace Miniräknare
{
    public partial class Form1 : Form
    {
        private readonly Calculator _calculator = new Calculator();
        private int counter = 0;
        public string number;

        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_MouseClick(object sender, MouseEventArgs e)
        {
            _calculator.setNumber(number);
            Displaylbl.Text = (sender as Button)?.Text ?? throw new InvalidOperationException();
            number = string.Empty;
            _calculator.setOperation((sender as Button)?.Text, Displaylbl);
        }

        private void Number_Btn_MouseClick(object sender, MouseEventArgs e)
        {
            number += (sender as Button)?.Text ?? throw new InvalidOperationException();
            Displaylbl.Text = number;
        }

        private void giveResult(object sender, EventArgs e)
        {
            _calculator.setNumber(number);
            double result = _calculator.Calculate(Displaylbl);
            string text = (result == 32) ? Displaylbl.Text = "Error!" : Displaylbl.Text = result.ToString();
            Displaylbl.Text = text;
            number = string.Empty;
        }
    }
}
