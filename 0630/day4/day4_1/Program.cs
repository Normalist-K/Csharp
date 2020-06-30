using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4_1
{
    class Program
    {
        class Cat
        {
            public int AGE
            { get; set; }
            public void PrintData()
            {
                Console.WriteLine("AGE: {0}", AGE);
            }
        }
        static void Main(string[] args)
        {
            // LINQ
            List<int> iList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var v = from item in iList
                    where item % 2 == 0
                    select new Cat() { AGE = item };
            foreach (var vItem in v)
            {
                vItem.PrintData();
            }
        }
    }
}
