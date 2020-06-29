using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4_5
{
    class Cat
    {
        public Cat()
        {
            Console.WriteLine("pulbic Cat()생성자 호출");
        }
        //~Cat()
        //{
        //    Console.WriteLine("pulbic Cat()소멸자 호출");
        //}
        // 소멸자 쓰면 이거 호출하려고 한 사이클 더 돌기 때문에 안써 -> 대신 소멸자 역할하는 함수를 사용
        public void Dispose()
        {
            Console.WriteLine("pulbic Cat()소멸자 호출");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Cat c = new Cat();
            c.Dispose();
        }
    }
}
