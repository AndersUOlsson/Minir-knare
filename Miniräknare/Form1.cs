using System;
using System.Linq;
using System.Windows.Forms;

namespace Miniräknare
{
    public partial class Form1 : Form
    {
        private readonly Calculator calculator = new Calculator();
      
        private string number;
        private static bool flag = false;

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
            flag = true;
            


            if(((Control)sender).Text == "CE" || ((Control)sender).Text == "C" || ((Control)sender).Text == "Delete")
            {
                plusBtn.Enabled = true;
                minusBtn.Enabled = true;
                dividedBtn.Enabled = true;
                multiplicationBtn.Enabled = true;
            }
            else
            {
                plusBtn.Enabled = false;
                minusBtn.Enabled = false;
                dividedBtn.Enabled = false;
                multiplicationBtn.Enabled = false;
            }
            
            
        }

        //Listen for the number the user wants to operate on.
        private void Number_Btn_MouseClick(object sender, MouseEventArgs e)
        {
            number += (sender as Button)?.Text ?? throw new InvalidOperationException();
            Displaylbl.Text = number;
            flag = true;
        }

        //Will genrate and display the result of the number and operation. 
        private void GiveResult(object sender, EventArgs e)
        {
            if(flag)
            {
                calculator.SetNumber(number);
                double result = calculator.Calculate(Displaylbl);
                string text = (result == 32) ? Displaylbl.Text = "Error!" : Displaylbl.Text = result.ToString();
                Displaylbl.Text = text;
                number = string.Empty;
                flag                      = false;
                plusBtn.Enabled           = true;
                minusBtn.Enabled          = true;
                dividedBtn.Enabled        = true;
                multiplicationBtn.Enabled = true;
            }
        }
    }
}
