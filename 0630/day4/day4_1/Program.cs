using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] iArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for (int i = 0; i < iArray.Length; i++)
            {
                Console.WriteLine("iArray[{0}] : {1}", i, iArray[i]);
            }
        }
    }
}
