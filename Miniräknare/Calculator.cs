using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Miniräknare
{
    class Calculator
    {
        public List<string> Operation = new List<string>();
        private List<double> numbers = new List<double>();

        public Calculator()
        {
            Operation.Add("");
            Operation.Add("");
        }

        public double Calculate(Control display)  
        {
            int size = numbers.Count-1;

            if (size > 0 && !Operation.ElementAt(0).Equals(null) &&  !Operation.ElementAt(1).Equals(","))
            {
                switch (Operation.ElementAt(0))
                {
                    case "-":
                        numbers.Insert(size + 1, (numbers.ElementAt(size - 1) - numbers.ElementAt(size)));
                        return numbers.ElementAt(size + 1);

                    case "+":
                        numbers.Insert(size + 1, (numbers.ElementAt(size - 1) + numbers.ElementAt(size)));
                        return numbers.ElementAt(size + 1);

                    case "÷":
                        numbers.Insert(size + 1, (numbers.ElementAt(size) != 0 ? numbers.ElementAt(size - 1) / numbers.ElementAt(size) : ' '));
                        return numbers.ElementAt(size + 1);
                  
                    case "×":
                        numbers.Insert(size + 1, (numbers.ElementAt(size - 1) * numbers.ElementAt(size)));
                        return numbers.ElementAt(size + 1);

                    case ",":
                        
                        numbers.Insert(size + 1, (numbers.ElementAt(size - 1) + (numbers.ElementAt(size) / 10)));

                        if ((numbers.ElementAt(size - 1) + (numbers.ElementAt(size))/10) == numbers.ElementAt(size + 1))
                        {
                            numbers.Insert(size - 1, numbers.ElementAt(size + 1));
                            return numbers.ElementAt(size - 1);
                        }
                        else 
                            return numbers.ElementAt(size + 1);

                    default:
                        return ' ';
                }
            }

            if (Operation.ElementAt(1).Equals(",") && !Operation.ElementAt(0).Equals(""))
            {
                numbers.Insert(size + 1, (numbers.ElementAt(size - 1) + (numbers.ElementAt(size) / 10)));

                if ((numbers.ElementAt(size - 1) + (numbers.ElementAt(size)) / 10) == numbers.ElementAt(size + 1))
                {
                    numbers.Insert(size - 1, numbers.ElementAt(size + 1));
                    Operation.Insert(1,"");
                    for (int i = numbers.Count-1; i > 1; i--)
                    {
                        numbers.RemoveAt(i);
                    }
                    size = numbers.Count - 1;
                    return numbers.ElementAt(size);
                }

                Operation.RemoveAt(1);
                return numbers.ElementAt(size + 1);
            }

            Console.WriteLine("JElle");
            numbers.Insert(size + 1, (numbers.ElementAt(size - 1) + (numbers.ElementAt(size) / 10)));

           

            Operation.RemoveAt(1);
            return numbers.ElementAt(size + 1);

       
        }

        public void setNumber(double d, Control display)
        {
            numbers.Add(d);
            display.Text = d.ToString();
        }

        public void setOperation(string s, Control display)
        {
            int size = numbers.Count - 1;
            switch (s)
            {
                case "Delete":
                    numbers.Remove(numbers.Count);
                    display.Text = string.Empty;
                    break;

                case "CE":
                    numbers.Clear();
                    Operation.Insert(0,"");
                    Operation.Insert(1, "");

                    display.Text = string.Empty;
                    break;

                case ",":
                    display.Text = string.Empty;
                    Operation.RemoveAt(1);
                    Operation.Insert(1,s); 
                    break;

                case "C":
                    display.Text = string.Empty;
                    break;

                case "±":
                    numbers.Insert(size + 1,   numbers.ElementAt(size) * -1);
                    display.Text = numbers.ElementAt(size + 1).ToString();
                    break;

                default:
                    Operation.RemoveAt(0);
                    Operation.Insert(0,s);
                    break;
            }
        }
    }
}
