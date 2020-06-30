using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4_2
{
    class IntArray
    {
        public IntArray(int size)
        {
            m_size = size;
            m_data = new int[size];
        }
        public int SIZE
        {
            get { return m_size; }
        }
        public int this[int idx]
        {
            get { return m_data[idx]; }
            set { m_data[idx] = value; }
        }
        private int[] m_data;
        private int m_size;
    }
    class Program
    {
        static void Main(string[] args)
        {
            IntArray iArray = new IntArray(10);
            for (int i = 0; i < iArray.SIZE; i++)
            {
                iArray[i] = i;
            }
            for (int i = 0; i < iArray.SIZE; i++)
            {
                Console.WriteLine("iArray[{0}] = {1}", i, iArray[i]);
            }
        }
    }
}
