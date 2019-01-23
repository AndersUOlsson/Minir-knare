using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Miniräknare
{
    class Calculator
    {
        private string Operation { get; set; }
        private double firstNumber { get; set; }
        private double secondNumber { get; set; }


        public double Calculate()
        {
            double result = 0;
            switch (Operation)
            {
                case "-":
                    return firstNumber - secondNumber;
                  
                case "+":
                    return firstNumber + secondNumber;
                   
                case "÷":
                    return firstNumber / secondNumber;
                
                case "*":
                    return firstNumber * secondNumber;
                
                default:
                    return ' '; 
            }
        }

        public void setNumber(double d)
        {
            if(firstNumber == 0)
             firstNumber = d;
            else
                secondNumber = d;
        }

        public void setOperation(string s)
        {
            Operation = s;
        }
    }
}
