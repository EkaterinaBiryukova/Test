using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStack
{
    class Program
    {
        static void Main(string[] args)
        {
            string input_string = Console.ReadLine();

            myStack tmp = new myStack(input_string);

            // get the result
            Console.WriteLine(tmp.myPop());

            Console.ReadLine();
        }
    }
}
