using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "홍길동 김길동 이길동 박길동";
            string[] sArray = s.Split(' ');
            for (int i = 0; i < sArray.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i, sArray[i]);
            }
        }
    }
}
