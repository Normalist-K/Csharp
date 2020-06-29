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
    class DispFuncClass
    {
        public string MenuString;
        public DispFuncDelegate DeleFunc;
    }
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
            DispFuncClass[] DispFuncClassArray = new DispFuncClass[3] { 
                new DispFuncClass() { MenuString = "DispArrow", DeleFunc=DispArrow }, 
                new DispFuncClass() { MenuString = "DispStar", DeleFunc=DispStar }, 
                new DispFuncClass() { MenuString = "DispPlus", DeleFunc=DispPlus }, 
            };
            int iChoice = 1;
            while (iChoice != 0)
            {
                for (int i = 0; i < DispFuncClassArray.Length; i++)
                {
                    Console.WriteLine("{0}.{1}", i + 1, DispFuncClassArray[i].MenuString);
                }
                iChoice = int.Parse(Console.ReadLine());
                if (iChoice > 0 && iChoice <= DispFuncClassArray.Length)
                {
                    MyFunc(DispFuncClassArray[iChoice - 1].DeleFunc);
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
                // c#/java 는 pointer가 없으니까 delegate 활용 (late binding하려고 virtual쓰기도 함)
            }
            Console.WriteLine("");
        }
    }
}
