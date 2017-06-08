using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace TestStack
{
    class Program
    {
        static void Main(string[] args)
        {

            string str = Console.ReadLine();
            
            Console.WriteLine("'{0}', compare to empty string - {1}", str, str.Equals(""));


            Console.WriteLine("Input string. Type 'exit' for exit");
            string input_string = Console.ReadLine();
            while (!input_string.Equals("exit"))
            {
                try
                {
                    myStack tmp = new myStack(input_string);
                    // get the result
                    Console.WriteLine(tmp.myPop());
                }
                catch (myException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    input_string = Console.ReadLine();
                }
            }
        }
    }
}
