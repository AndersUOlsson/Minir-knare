using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Miniräknare
{
    public partial class Form1 : Form
    {
        private readonly Calculator _calculator = new Calculator();

        public Form1()
        {
            InitializeComponent();
        }

       
        //TODO: print result to the label. 

        private void Btn_MouseClick(object sender, MouseEventArgs e)
        {
            _calculator.setOperation((sender as Button)?.Text);
        }

        private void Number_Btn_MouseClick(object sender, MouseEventArgs e)
        {
            _calculator.setNumber(double.Parse((sender as Button)?.Text ?? throw new InvalidOperationException()));
        }

        private void giveResult(object sender, EventArgs e)
        {
            _calculator.Calculate();
        }
    }
}
