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
        public void PrintData()
        {
            Console.WriteLine("전화번호: {0}", TelNo);
            Console.WriteLine("이름: {0}", Name);
            Console.WriteLine("주소: {0}", Addr);
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
        public void Menu()
        {
            int iChoice = 1;
            while (iChoice != 0)
            {
                Console.WriteLine("1. 회원 등록");
                Console.WriteLine("2. 회원 출력");
                Console.WriteLine("3. 회원 검색");
                iChoice = int.Parse(Console.ReadLine());
                switch (iChoice)
                {
                    case 1:
                        InsertMember();
                        break;
                    case 2:
                        PrintAllMember();
                        break;
                    case 3:
                        SearchMember();
                        break;
                    
                }
            }
        }
        private void InsertMember()
        {
            Member m1 = new Member();
            m1.InputData();
            MemList.Add(m1);
        }
        private void PrintAllMember()
        {
            //for (int i = 0; i < MemList.Count; i++)
            //{
            //    MemList[i].PrintData();
            //}
            //같은 함수 간단하게
            MemList.ForEach(m => m.PrintData());
        }
        private Member SearchMember(string strTelNo)
        {
            //for (int i = 0; i < MemList.Count; i++)
            //{
            //    if (MemList[i].CompareTelNo(strTelNo))
            //    {
            //        return MemList[i];
            //    }
            //}
            //return null;

            return MemList.Find(m => m.CompareTelNo(strTelNo));
        }
        private void SearchMember()
        {
            Console.Write("찾을 전화번호: ");
            string strTelNo = Console.ReadLine();

            Member m = SearchMember(strTelNo);
            if (m==null)
            {
                Console.WriteLine("찾으려는 데이터가 없습니다.");
            }
            else
            {
                m.PrintData();
            }
        }
        private List<Member> MemList = new List<Member>();
    }
    class Program
    {
        static void Main(string[] args)
        {
            MemberMgr m = new MemberMgr();
            m.Menu();
        }
    }
}
