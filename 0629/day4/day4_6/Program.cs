using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4_6 // 회원관리 프로그램
{
    class Member
    {
        private Member()
        {

        }
        public static Member CreateObject(IMemberMgrForSearch mMgr)
        {
            Console.Write("전화번호: ");
            string strTelNo = Console.ReadLine();
            Member m = mMgr.SearchMember(strTelNo);
            // MemberMgr에 있는 SearchMember 메서드를 쓰기 위해 parameter로 받아옴
            if (m != null)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("이미 등록되어있는 회원입니다.");
                Console.WriteLine("---------------------------------");
                m.PrintData();
                Console.WriteLine("---------------------------------");
                return null;
            }

            Member NewMember = new Member();
            NewMember.TelNo = strTelNo;
            NewMember.InputData();
            return NewMember;
        }
        // CreateObject로 관리하지 않으면, 먼저 new 하고 전화번호 비교 -> 이미 등록되어 있는 경우 계속해서 heap 메모리에 빈 객체가 쌓인다
        public bool InputData()
        {
            Console.Write("이름: ");
            Name = Console.ReadLine();
            Console.Write("주소: ");
            Addr = Console.ReadLine();
            return true;
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

        private string TelNo; // key값으로 활용
        private string Name;
        private string Addr;
    }
    interface IMemberMgrForSearch
    {
        Member SearchMember(string strTelNo);
    }
    // virtual fn 과 비교해서 코드를 짤 수 없다 -> interface == pure virtual fn
    class MemberMgr : IMemberMgrForSearch
    {
        public void Menu()
        {
            int iChoice = 1;
            while (iChoice != 0)
            {
                Console.WriteLine("1. 회원 등록");
                Console.WriteLine("2. 회원 출력");
                Console.WriteLine("3. 회원 검색");
                Console.WriteLine("4. 회원 수정");
                Console.WriteLine("5. 회원 삭제");

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
                    case 4:
                        ModifyMember();
                        break;
                    case 5:
                        DeleteMember();
                        break;
                    
                }
            }
        }
        private void ModifyMember()
        {
            Console.Write("수정할 전화번호: ");
            string strTelNo = Console.ReadLine();

            Member m = SearchMember(strTelNo);
            if (m == null)
            {
                Console.WriteLine("찾으려는 데이터가 없습니다.");
            }
            else
            {
                m.InputData();
            }
        }
        private void DeleteMember()
        {
            Console.Write("삭제할 전화번호: ");
            string strTelNo = Console.ReadLine();

            Member m = SearchMember(strTelNo);
            if (m == null)
            {
                Console.WriteLine("삭제하려는 데이터가 없습니다.");
            }
            else
            {
                MemList.Remove(m);
            }
        }

        private void InsertMember()
            //                    MemberMgr this
        {
            Member m1 = Member.CreateObject(this);
            if (m1 != null)
            {
                MemList.Add(m1);
            }
            else
            {
                Console.WriteLine("회원등록 실패");
            }
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
        public Member SearchMember(string strTelNo)
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
    // 대여 관리
    // =====================================================================
    // 1. 대여등록
    //   1) 회원번호 입력
    //     1-1) 등록된 회원인지 검색. 등록되어 있지 않으면 실패
    //     1-2) 등록된 회원이면 회원 정보 출력
    //     1-3) 미 반납 비디오 출력
    //   2) 비디오번호 등록
    //     2-1) 등록된 비디오인지 검색. 등록되어 있지 않으면 실패
    //     2-2) 등록된 비디오이면 비디오 정보 출력
    // 2. 대여출력
    //   1) 비디오 정보, 회원 정보, 대여일, 반납일 출력
    // 3. 반납
    //   1) 대여 리스트에서 검색
    //     1-1) 대여된 비디오이면 대여 클래스의 ReturnDate에 현재 일시 등록
    // 4. 대여삭제
    //   1) 비디오 번호, 회원 번호 입력 후 검색하여 대여리스트에서 삭제
    // =====================================================================
    // =====================================================================
    // 비디오 관리
    // =====================================================================
    // 1. 비디오 번호, 영화 제목, 주연배우, 대여료
    // =====================================================================
    class Rent
    {
        public void PrintData()
        {
            Console.WriteLine("RentDate: {0}", RentDate);
            Console.WriteLine("ReturnDate: {0}", ReturnDate);

        }
        private string TelNo;
        private string VideoNo;
        private DateTime RentDate;
        private DateTime ReturnDate;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Rent r1 = null;
            Rent r2 = new Rent();
            r2.PrintData();

            //int i;
            //Console.WriteLine("{0}", i);
            // error!! 
            int? i = null;

            MemberMgr m = new MemberMgr();
            m.Menu();
        }
    }
}
