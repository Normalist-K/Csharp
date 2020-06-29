using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] iArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            DispFunc(iArray);
        }

        static void DispFunc(int [] iArray)
        {
            Console.WriteLine("==============================================");
            for (int i = 0; i < iArray.Length; i++)
            {
                Console.WriteLine("iArray[{0}] = {1}", i, iArray[i]);
                Console.WriteLine("----------------------------------------------");
            }
            Console.WriteLine("==============================================");
        }
        static void DispFunc2(int[] iArray)
        {
            for (int i = 0; i < iArray.Length; i++)
            {
                Console.WriteLine("iArray[{0}] = {1}", i, iArray[i]);
            }
        }
        static void DispFunc3(int[] iArray, int iGubun)
        {
            if (iGubun == 1)
            {
                Console.WriteLine("==============================================");
            }
            for (int i = 0; i < iArray.Length; i++)
            {
                Console.WriteLine("iArray[{0}] = {1}", i, iArray[i]);
                if (iGubun==1)
                {
                    Console.WriteLine("---------------------------------------------");
                }
            }
            if (iGubun == 1)
            {
                Console.WriteLine("==============================================");
            }
        }
    }
}
