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
            size = numbers.Count;
            opSize = operation.Count;

            switch (operation.ElementAt(opSize-1))
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

        //Adds the number from keyboard in a buffer (numbers)
        public void SetNumber(string number)
        {
            if (number == "")
                return;
            else 
                numbers.Add(double.Parse(number));
        }

        //This is the function for the rest of operations that the calculate can do 
        //like delete, invert value etc. 
        public void SetOperation(string operation, Control display)
        {
            
            switch (operation)
            {
                case "Delete":
                    numbers.Remove(numbers.Count-1);
                    display.Text = string.Empty;
                    break;

                case "CE":
                    numbers.Clear();
                    display.Text = string.Empty;
                    break;

                case "C":
                    display.Text = string.Empty;
                    break;

                case "±":
                    if (size > 0)
                    {
                        numbers.Add(numbers.ElementAt(size) * -1);
                        display.Text = numbers.ElementAt(size + 1).ToString();
                        size = numbers.Count - 1;
                    }
                    else
                        display.Text = numbers.ElementAt(size).ToString();
                    
                    break;

                default:
                    this.operation.Add(operation); 
                    break;
            }
        }
    }
}
