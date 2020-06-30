using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] iArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for (int i = 0; i < iArray.Length; i++)
            {
                Console.WriteLine("iArray[{0}] : {1}", i, iArray[i]);
            }
            // 같은 결과
            foreach (int i in iArray)
            {
                Console.WriteLine("iArray : {0}", i);
            }

            // LINQ
            List<int> iList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var v = from item in iList
                    where item % 2 == 0
                    select item; // new도 가능
            foreach (var vItem in v)
            {
                Console.WriteLine("vItem : {0}", vItem);
            }
        }
    }
}
