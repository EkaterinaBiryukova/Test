using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Todo
             * N - make Gethashcode not depend on N
             * make override here?
             */
            int N = 20;
            int[] inputArray = { 5, 100, 10, 24, 13, 44, 205, 86, 7, 864, 99 };

            myHashTable<int, int> tmp = new myHashTable<int, int>();

            for (int i = 0; i < inputArray.Length; i++)
            {
                tmp.Insert(inputArray[i], inputArray[i], N);
            }

            tmp.PrintHashTable(N);

            myHashTable<string, int> tmp2 = new myHashTable<string, int>();
            tmp2.Insert("qwe", 3, N);
            tmp2.Insert("fff", 8, N);
            tmp2.Insert("dfgdgfdg", 4, N);
            tmp2.PrintHashTable(N);

            Console.ReadLine();
        }


    }
}
