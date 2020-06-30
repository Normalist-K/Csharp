using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4_4
{
    class Program
    {
        static void Main(string[] args)
        {
            if (MyFunc1() == false)
            {
                Console.WriteLine("함수 호출 실패");
                return;
            }
            Console.WriteLine("함수 호출 성공");
            Console.WriteLine("Main()함수 나머지 계속 실행");
        }
        static bool MyFunc1()
        {
            if (MyFunc2() == false)
            {
                Console.WriteLine("함수 호출 실패");
                return false;
            }
            Console.WriteLine("함수 호출 성공");
            Console.WriteLine("MyFunc1()함수 나머지 계속 실행");
            return true;
        }
        static bool MyFunc2()
        {
            Console.WriteLine("static bool MyFunc2()함수 실행");
            return false;
        }
    }
}
