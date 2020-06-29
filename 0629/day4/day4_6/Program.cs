using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4_6 // 회원관리 프로그램
{
    class Member
    {
        public void InputData()
        {
            Console.Write("전화번호: ");
            TelNo = Console.ReadLine();
            Console.Write("이름: ");
            Name = Console.ReadLine();
            Console.Write("주소: ");
            Addr = Console.ReadLine();
        }
        public void PringData()
        {
            Console.Write("전화번호: {0}", TelNo);
            Console.Write("이름: {0}", Name);
            Console.Write("주소: {0}", Addr);
        }
        public bool CompareTelNo(string tel)
        {
            return TelNo == tel;
        }
        private string TelNo;
        private string Name;
        private string Addr;
    }
    class MemberMgr
    {
        private void InsertMember()
        {
            Member m1 = new Member();
            m1.InputData();
            MemList.Add(m1);
        }
        private void PrintAllMember()
        {
            for (int i = 0; i < MemList.Count; i++)
            {
                MemList[i].PringData();
            }
            //같은 함수 간단하게
            //MemList.ForEach(m => m.PringData());
        }
        private List<Member> MemList = new List<Member>();
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
