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
                new Member() { Name = "박길동", Addr = "대구", TelNo = "567-1234" },
            };
            var v = from item in MemList
                    orderby item.Name
                    group item by item.Addr;
            // vItem 자체가 linked list가 됨
            foreach (var vItem in v)
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("지역 : {0}, 회원수: {1}", vItem.Key, vItem.Count());
                Console.WriteLine("-----------------------------------------");
                foreach (var item in vItem)
                {
                    item.PrintData();
                }
                Console.WriteLine("-----------------------------------------");
            }
        }
    }
}
