using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace day4_1 // delegate
{
    delegate void DispFuncDelegate();
    // class type, 변수로 함수의 주소가 들어감
    class Program
    {
        static void DispArrow()
        {
            Console.Write("=>");
        }
        static void DispStar()
        {
            Console.Write("*");
        }
        static void DispPlus()
        {
            Console.Write("+");
        }

        static void Main(string[] args)
        {
            DispFuncDelegate[] DispFuncArray = new DispFuncDelegate[3];
            DispFuncArray[0] = DispArrow;
            DispFuncArray[1] = DispStar;
            DispFuncArray[2] = DispPlus;

            int iChoice = 1;
            while (iChoice != 0)
            {
                Console.WriteLine("1. DispArrow");
                Console.WriteLine("2. DispStar");
                Console.WriteLine("2. DispPlus");

                iChoice = int.Parse(Console.ReadLine());
                if (iChoice > 0 && iChoice <= DispFuncArray.Length)
                {
                    MyFunc(DispFuncArray[iChoice - 1]);
                }
            }
        }

        static void MyFunc(DispFuncDelegate DispFunc)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                DispFunc();
                // 어떤 함수가 실행될 지는 실행시에 결정됨 -> late binding
                // c/c++ 은 pointer로 late binding
                // c#/java 는 pointer가 없으니까 delegate 활용
            }
        }
    }
}
