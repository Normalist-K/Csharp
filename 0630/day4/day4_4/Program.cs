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
            try
            {
                MyFunc1();
                Console.WriteLine("함수 호출 성공");
                Console.WriteLine("Main()함수 나머지 계속 실행");
            }
            catch (Exception e)
            {
                Console.WriteLine("함수 호출 실패 ErrMsg : {0}", e.Message);
                return;
            }
        }
        static void MyFunc1()
        {
            MyFunc2();
            Console.WriteLine("함수 호출 성공");
            Console.WriteLine("MyFunc1()함수 나머지 계속 실행");
        }
        static void MyFunc2()
        {
            Console.WriteLine("static bool MyFunc2()함수 실행");
            throw new Exception("MyFunc2 Error");
        }
    }
}
