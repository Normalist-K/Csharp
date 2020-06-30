using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4_2
{
    class IntArray : IEnumerable<int>, IEnumerator<int>
    {
        public IntArray(int size)
        {
            m_iCurrent = 0;
            m_size = size;
            m_data = new int[size];
        }
        public int SIZE
        {
            get { return m_size; }
        }

        public int Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public int this[int idx]
        {
            get { return m_data[idx]; }
            set { m_data[idx] = value; }
        }
        private int[] m_data;
        private int m_size;
        private int m_iCurrent;

        public IEnumerator<int> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
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
            foreach (int i in iArray)
            {
                Console.WriteLine("iArrya = {0}", iArray[i]);
            }
        }
    }
}
