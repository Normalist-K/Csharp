using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "홍길동";
            string s2 = "김길동";
            string s3 = "박길동";

            StreamWriter w = new StreamWriter(@"C:\Users\uvent\source\repos\Normalist-K\hustar2\0630\day4\day4_5\1.txt");
            w.WriteLine(s1);
            w.WriteLine(s2);
            w.WriteLine(s3);

            w.Close();
            w.Dispose();

            StreamReader r = new StreamReader(@"C:\Users\uvent\source\repos\Normalist-K\hustar2\0630\day4\day4_5\1.txt");
            while (r.EndOfStream == false)
            {
                Console.WriteLine(r.ReadLine());
            }
        }
    }
}
