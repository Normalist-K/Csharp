using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4_3
{
    class Cat
    {
        public int AGE
        {
            get { return m_iAge; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("나이는 1보다 작을 수 없습니다.");
                    return;
                }
                m_iAge = value;
            }
        }
        private int m_iAge;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Cat c = new Cat();
            c.AGE = -1;
        }
    }
}
