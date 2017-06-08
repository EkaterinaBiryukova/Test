using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TestStack
{
    class myStack
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
            string[] tmp = input_string.Split(' ');
            element = new Object[tmp.Length];
            foreach (var s in tmp)
            {
                myPush(s);
            }
        }

        /// <summary>
        /// Insert element
        /// </summary>
        /// <param name="newElement">Object</param>
        public void myPush(Object newElement) // insert
        {
            // if unknown symbol dont put in stack
            if (ParseSymbol(newElement) == _IS_UNKNOWN_) return;
            if (ParseSymbol(newElement) == _IS_OPERATION_)
            {

                int result = 0;
                int a, b;

                b = Convert.ToInt32(myPop());
                a = Convert.ToInt32(myPop());
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
                    string pattern = "[0-9]";
                    if (!Regex.IsMatch(element.ToString(), pattern)) return _IS_UNKNOWN_;
                    return _IS_DIGIT_;
            }

        }
    }
}
