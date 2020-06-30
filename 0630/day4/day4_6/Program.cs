using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4_6
{
    class Member
    {
        public Member()
        {
        }
        public Member(string name, string addr, string telNo, int age)
        {
            Name = name;
            Addr = addr;
            TelNo = telNo;
            Age = age;
        }
        public void PrintData()
        {
            Console.WriteLine("이름 : {0}", Name);
            Console.WriteLine("주소 : {0}", Addr);
            Console.WriteLine("전화번호 : {0}", TelNo);
            Console.WriteLine("나이 : {0}", Age);
        }
        public void SaveToFile(StreamWriter w)
        {
            w.WriteLine(Name);
            w.WriteLine(Addr);
            w.WriteLine(TelNo);
            w.WriteLine("{0}",Age);
        }
        public void LoadFromFile(StreamReader r)
        {
            Name = r.ReadLine();
            Addr = r.ReadLine();
            TelNo = r.ReadLine();
            Age = int.Parse(r.ReadLine());

        }
        private string Name;
        private string Addr;
        private string TelNo;
        private int Age;
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Member> MemList = new List<Member>()
            {
                new Member("김길동","서울","123-1234",10),
                new Member("박길동","대전","234-1234",11),
                new Member("이길동","대구","345-3456",12),
                new Member("고길동","부산","456-4577",13),
                new Member("최길동","포항","567-5678",14),
                new Member("김길동","마산","678-6789",15),
            };
            StreamWriter w = new StreamWriter(@"C:\Users\uvent\source\repos\Normalist-K\hustar2\0630\day4\day4_6\1.txt");
            w.WriteLine("{0}", MemList.Count);
            foreach (Member m in MemList)
            {
                m.SaveToFile(w);
            }
            w.Close();
            w.Dispose();

            MemList.RemoveAll(m => true);
            MemList.ForEach(m => m.PrintData());

            StreamReader r = new StreamReader(@"C:\Users\uvent\source\repos\Normalist-K\hustar2\0630\day4\day4_6\1.txt");
            int iCount = int.Parse(r.ReadLine());
            for (int i = 0; i < iCount; i++)
            {
                Member m = new Member();
                m.LoadFromFile(r);
                MemList.Add(m);
            }
            r.Close();
            r.Dispose();

            MemList.ForEach(m => m.PrintData());
        }
    }
}
