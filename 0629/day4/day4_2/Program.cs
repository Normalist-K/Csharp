using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4_2
{
    class Program
    {
        delegate void DecoDelegate();
        static void Main(string[] args)
        {
            int[] iArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            DispFunc(iArray, Header, Footer, Seperator);
            DispFunc(iArray, Empty, Empty, delegate() { });
            // Empty == delegate() { }
        }
        static void Empty() { }
        static void Header()
        {
            Console.WriteLine("==============================================");
        }
        static void Footer()
        {
            Console.WriteLine("==============================================");
        }
        static void Seperator()
        {
            Console.WriteLine("----------------------------------------------");
        }

        static void DispFunc(int [] iArray, DecoDelegate HeaderFunc, DecoDelegate FooterFunc, DecoDelegate SepFunc)
        {
            HeaderFunc();
            for (int i = 0; i < iArray.Length; i++)
            {
                Console.WriteLine("iArray[{0}] = {1}", i, iArray[i]);
                SepFunc();
            }
            FooterFunc();
        }
    }
}
