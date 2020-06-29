using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4_5
{
    class Cat : IDisposable
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
        // IDisposable 상속하면 반드시 Dispose 함수가 있어야 함
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (Cat c = new Cat())
            {
                Console.WriteLine("Hello, World!");
            }
            // using을 쓰면 자동으로 Dispose함수 호출, 근데 쓰는 경우는 잘 없음. 
            // 그냥 c.Dispose(); 주로 사용
        }
    }
}
