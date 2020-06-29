﻿using System;
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
            DispFunc(iArray, Empty, Empty, delegate() { });
            // Empty == delegate() { }   <- 익명 delegate
            // 한 번 밖에 사용하지 않을거면 익명으로 만드는게 좋아
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

        static void DispFunc(int [] iArray, Action HeaderFunc, Action FooterFunc, Action SepFunc)
            // void return하면 Action
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
