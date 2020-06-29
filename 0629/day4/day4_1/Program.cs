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

        static void Main(string[] args)
        {
            MyFunc(DispArrow);
            // DispArrow함수의 주소를 파라미터로 넣어줌
        }

        static void MyFunc(DispFuncDelegate DispFunc)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                DispFunc();
            }
        }
    }
}
