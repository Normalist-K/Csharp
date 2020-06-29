using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace review
{
    static
    class Program
    {
        static bool MyAllFunc(int i)
        {
            return i > 0;
        }
        static bool MyPreFunc(int i)
        {
            return i == 5;
        }
        static void Main(string[] args)
        {
            List<int> iList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            iList.ForEach(delegate (int i)
            {
                Console.WriteLine("i => {0}", i);
            });
            iList.ForEach((int i) => Console.WriteLine("i => {0}", i));
            iList.ForEach(i => Console.WriteLine("i => {0}", i));
            Console.WriteLine("iList.All(MyAllFunc) : {0}", iList.All(MyAllFunc)); 
            Console.WriteLine("iList.All(MyAllFunc) : {0}", 
                iList.All(delegate(int i) {
                    return i > 0;
                })
            );
            Console.WriteLine("iList.All(MyAllFunc) : {0}", 
                iList.All((i) => i > 0)
            );
            Console.WriteLine("iList.Find(MyPreFunc) : {0}", iList.Find(MyPreFunc));

            int iFindValue = int.Parse(Console.ReadLine());
            Console.WriteLine("iList.Find(MyPreFunc) : {0}", iList.Find(delegate(int i)
            {
                return i == iFindValue;
            }));
            Console.WriteLine("iList.Find(MyPreFunc) : {0}", iList.Find((int i) => i == iFindValue));
            Console.WriteLine("iList.Find(MyPreFunc) : {0}", iList.Find(i => i == iFindValue));
        }
    }
}
