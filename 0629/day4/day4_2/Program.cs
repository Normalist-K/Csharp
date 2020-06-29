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
            // 익명 클래스
            var c = new { AGE = 10, NAME = "홍길동" };
            Console.WriteLine("c.NAME = {0}, c.AGE = {1}", c.NAME, c.AGE);

            int[] iArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            DispFunc(iArray, Header, Footer, Seperator);
            DispFunc(iArray, Empty, Empty, delegate(int iPercent) { });
            // Empty == delegate() { }   <- 익명 delegate
            // 한 번 밖에 사용하지 않을거면 익명으로 만드는게 좋아
        }
        static void Empty(int iPercent) { }
        static void Header(int iPercent)
        {
            Console.WriteLine("==============================================");
        }
        static void Footer(int iPercent)
        {
            Console.WriteLine("==============================================");
        }
        static void Seperator(int iPercent)
        {
            Console.WriteLine("----------------------------------------------");
        }

        static void DispFunc(int [] iArray, Action<int> HeaderFunc, Action<int> FooterFunc, Action<int> SepFunc)
            // void return하면 Action
        {
            int iPercent = 10;
            HeaderFunc(iPercent);
            for (int i = 0; i < iArray.Length; i++)
            {
                Console.WriteLine("iArray[{0}] = {1}", i, iArray[i]);
                SepFunc(iPercent);
            }
            FooterFunc(iPercent);
        }
    }
}
