using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace TestStack
{
    public class myStack
    {
        const int _IS_DIGIT_ = 2;
        const int _IS_OPERATION_ = 1;
        const int _IS_UNKNOWN_ = 0;
        Object[] element;
        private int size = 0;

        public myStack()
        {
            element = new Object[2];
        }
        public myStack(string input_string)
        {
            input_string = input_string.ToString().Replace('.', ','); // in simple way TryParse wait number with ',', not with '.', so replace '.' if its nessesary
            string[] tmp = input_string.Split(' ');
            element = new Object[tmp.Length];
            foreach (var s in tmp)
            {
                try
                {
                    myPush(s);
                }
                catch (myException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Insert element
        /// </summary>
        /// <param name="newElement">Object</param>
        public void myPush(Object newElement) // insert
        {
            // if unknown symbol dont put in stack
            if (ParseSymbol(newElement) == _IS_UNKNOWN_) throw new myException("Unknown symbols");
            if (ParseSymbol(newElement) == _IS_OPERATION_)
            {
                if (size < 2) throw new myException("Not enough data for operation");

                double result = .0;
                double a, b;

                //b = Convert.ToDouble(myPop(), CultureInfo.InvariantCulture); //ignorit zapjatuu, tol'ko to4ka!!!
                //a = Convert.ToDouble(myPop(), CultureInfo.InvariantCulture);
                b = Convert.ToDouble(myPop()); //ignorit zapjatuu, tol'ko to4ka!!!
                a = Convert.ToDouble(myPop());
                switch (newElement.ToString())
                {
                    case "+": result = a + b; break;
                    case "-": result = a - b; break;
                    case "*": result = a * b; break;
                    case "/": if (b != 0) result = a / b; break;
                }

                //Console.WriteLine("{0}",result);
                newElement = result;
            }


            try
            {
                element[size] = new Object();
                element[size] = newElement;
                size++;
            }
            catch (IndexOutOfRangeException)
            {
                Array.Resize<Object>(ref element, size + 1);
                element[size] = new Object();
                element[size] = newElement;
                size++;
            }

        }
        /// <summary>
        /// Take element
        /// </summary>
        /// <returns>Object element</returns>
        public Object myPop()
        {

            size--; // make size smaller, means one element (last one is taken)
            return element[size]; // return last element
        }

        /// <summary>
        /// Parse symbols (digit or operation) with checking
        /// </summary>
        /// <returns>0 - for unknow, 1 - for operation, 2 - for digits</returns>
        public int ParseSymbol(Object element)
        {
            switch (element.ToString())
            {
                case "+":
                case "-":
                case "*":
                case "/": return _IS_OPERATION_;
                default:
                    double d;
                    //if (!Double.TryParse(element.ToString(), NumberStyles.Number, CultureInfo.InvariantCulture, out d)
                    if (!Double.TryParse(element.ToString(), out d)
                        || !Double.TryParse(element.ToString(), out d)) return _IS_UNKNOWN_;
                    
                    return _IS_DIGIT_;
            }

        }
    }
}
