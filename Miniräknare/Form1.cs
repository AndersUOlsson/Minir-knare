using System;
using System.Linq;
using System.Windows.Forms;

namespace Miniräknare
{
    public partial class Form1 : Form
    {
        private readonly Calculator _calculator = new Calculator();
        private int counter = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_MouseClick(object sender, MouseEventArgs e)
        {
            counter = 0;
            _calculator.setOperation((sender as Button)?.Text, Displaylbl);
        }

        private void Number_Btn_MouseClick(object sender, MouseEventArgs e)
        {
            counter = 0;
             _calculator.setNumber(double.Parse((sender as Button)?.Text ?? throw new InvalidOperationException()), Displaylbl);

             if (_calculator.Operation.ElementAt(1).Equals(","))
             {
                giveResult(sender, e);
                counter = 0;
             }
                 
        }

        private void giveResult(object sender, EventArgs e)
        {
            if (counter < 1)
            {
                counter++;
                double result = _calculator.Calculate(Displaylbl);
                string text = (result == 32) ? Displaylbl.Text = "Error!" : Displaylbl.Text = result.ToString();
                Displaylbl.Text = text;
               
            }
        }
    }
}
