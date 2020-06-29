using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4_3
{
    static class ExtentionClass
    // static class 는 멤버 변수로 static만 가능
    // 누구나 사용 가능하게 할 때
    {
        public static int StringCount(this string s)
        {
            return s.Split(' ').Length;
        }
        public static void StringSplitPrint(this string s)
        {
            string[] sArray = s.Split(' ');
            // " " 은 뒤에 null이 붙어있음. ' ' 과 다름 주의
            for (int i = 0; i < sArray.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i, sArray[i]);
            }
        }
        
    }
    // string 같이 상속이 안되는 클래스는 extention을 사용

    class Program
    {
        static void Main(string[] args)
        {
            string s = "홍길동 김길동 이길동 박길동";
            Console.WriteLine("s.StringCount : {0}", s.StringCount());
            s.StringSplitPrint();
        }
    }
}
