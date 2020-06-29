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
        public static
        
    }
    // string 같이 상속이 안되는 클래스는 extention을 사용

    class Program
    {
        static void DispInt(int i)
        {
            Console.WriteLine("i : {0}", i);
        }
        static void Main(string[] args)
        {
            List<int> iList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            // iList.ForEach(DispInt);
            
            // 위 함수랑 같음, 익명 delegate 활용
            iList.ForEach(delegate (int i)
            {
                Console.WriteLine("i : {0}", i);
            });

            // 람다식. 마찬가지로 위에 있는 함수랑 같음
            iList.ForEach((int i) => Console.WriteLine("i : {0}", i));
            
            // int는 이미 iList로 알 수 있으니 빼도 상관없음
            iList.ForEach((i) => Console.WriteLine("i : {0}", i));


            for (int i = 0; i < iList.Count; i++)
            {
                Console.WriteLine("iList[{0}] : {1}", i, iList[i]);
            }
        }
    }
}
