using System;
using System.Linq;
using System.Windows.Forms;

namespace Miniräknare
{
    public partial class Form1 : Form
    {
        private readonly Calculator calculator = new Calculator();
      
        public string number;

        public Form1()
        {
            InitializeComponent();
        }

        //Listen for the operation the user want to do. 
        private void Btn_MouseClick(object sender, MouseEventArgs e)
        {
            calculator.SetNumber(number);
            Displaylbl.Text = (sender as Button)?.Text ?? throw new InvalidOperationException();
            number = string.Empty;
            calculator.SetOperation((sender as Button)?.Text, Displaylbl);
        }

        //Listen for the number the user wants to operate on.
        private void Number_Btn_MouseClick(object sender, MouseEventArgs e)
        {
            number += (sender as Button)?.Text ?? throw new InvalidOperationException();
            Displaylbl.Text = number;
        }

        //Will genrate and display the result of the number and operation. 
        private void GiveResult(object sender, EventArgs e)
        {
            calculator.SetNumber(number);
            double result = calculator.Calculate(Displaylbl);
            string text = (result == 32) ? Displaylbl.Text = "Error!" : Displaylbl.Text = result.ToString();
            Displaylbl.Text = text;
            number = string.Empty;
        }
    }
}
