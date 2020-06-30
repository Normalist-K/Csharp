using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4_1
{
    class Program
    {
        class Member
        {
            public void PrintData()
            {
                Console.WriteLine("이름: {0}", Name);
                Console.WriteLine("주소: {0}", Addr);
                Console.WriteLine("전화번호: {0}", TelNo);
            }
            public bool CompareAddr(string strAddr)
            {
                return Addr == strAddr;
            }
            public string Name;
            public string Addr;
            public string TelNo;
            // public으로 한 이유는 초기화 쉽게 하기위해서.. 원래는 private!
        }
        static void Main(string[] args)
        {
            // LINQ
            List<Member> MemList = new List<Member>() { 
                new Member() { Name = "홍길동", Addr = "서울", TelNo = "123-1234" },
                new Member() { Name = "김길동", Addr = "대전", TelNo = "234-1234" },
                new Member() { Name = "이길동", Addr = "대구", TelNo = "345-1234" },
                new Member() { Name = "기길동", Addr = "서울", TelNo = "456-1234" },
                new Member() { Name = "지길동", Addr = "포항", TelNo = "567-1234" },
                new Member() { Name = "박길동", Addr = "서울", TelNo = "567-1234" },
            };
            // enumerable <- List가 IOrderedEnumerable Interface 상속받음
            // 원하는 클래스로 바꿀 수도 있다.
            List<Member> v = (from item in MemList
                              where item.CompareAddr("서울")
                              orderby item.Name ascending
                              select item).ToList<Member>();
            foreach (var vItem in v)
            {
                vItem.PrintData();
            }
        }
    }
}
