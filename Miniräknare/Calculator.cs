using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Miniräknare
{
    class Calculator
    {
        public List<string> operation = new List<string>();
        private List<double> numbers = new List<double>();
        private int size;
        private int opSize;

        //This function thus the calculation depending of the operation for instent +,- etc.
        public double Calculate(Control display)  
        {
            try
            {
                size = numbers.Count;
                opSize = operation.Count;

                switch (operation.ElementAt(opSize - 1))
                {
                    case "-":
                        numbers.Add(numbers.ElementAt(size - 2) - numbers.ElementAt(size - 1));

                        return numbers.ElementAt(size);

                    case "+":
                        numbers.Add(numbers.ElementAt(size - 2) + numbers.ElementAt(size - 1));
                        return numbers.ElementAt(size);

                    case "÷":
                        numbers.Add(numbers.ElementAt(size - 1) != 0 ? numbers.ElementAt(size - 2) / numbers.ElementAt(size - 1) : ' ');
                        return numbers.ElementAt(size);

                    case "×":
                        numbers.Add(numbers.ElementAt(size - 2) * numbers.ElementAt(size - 1));
                        return numbers.ElementAt(size);

                    default:
                        return ' ';
                }
            }
            catch(Exception e)
            {
                return ' ';
            }
        }

        //Adds the number from keyboard in a buffer (numbers)
        public void SetNumber(string number)
        {
            try
            {
                if (number == "" || number == null || number == ",")
                {
                    return;
                }
                else
                {
                    numbers.Add(double.Parse(number));
                }
            }
            catch(Exception e)
            {
                throw  e;
            } 
        }

        //This is the function for the rest of operations that the calculate can do. 
        public void SetOperation(string operation, Control display)
        {
            switch (operation)
            {
                case "Delete":
                    if(numbers.ToArray().Length != 0)
                    {
                        numbers.RemoveAt(numbers.Count - 1);
                        display.Text = string.Empty;
                    }
                    break;

                case "CE":
                    numbers.Clear();
                    display.Text = string.Empty;
                    break;

                case "C":
                    if (numbers.ToArray().Length != 0)
                    {
                        numbers.RemoveAt(numbers.Count - 1);
                        display.Text = string.Empty;
                    }
                    break;

                default:
                    this.operation.Add(operation); 
                    break;
            }
        }
    }
}
