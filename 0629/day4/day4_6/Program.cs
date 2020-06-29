using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4_6 // 도서관리 프로그램
{
    class Member
    {
        public void inputData()
        {
            Console.Write("전화번호: ");
            TelNo = Console.ReadLine();
            Console.Write("이름: ");
            Name = Console.ReadLine();
            Console.Write("주소: ");
            Addr = Console.ReadLine();
        }
        private string TelNo;
        private string Name;
        private string Addr;
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
