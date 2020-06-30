using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace day4_2
{
    class IntArray : IEnumerator, IEnumerable
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

        public object Current => m_data[m_iCurrent];

        public int this[int idx]
        {
            get { return m_data[idx]; }
            set { m_data[idx] = value; }
        }
        private int[] m_data;
        private int m_size;
        private int m_iCurrent;

        public IEnumerator GetEnumerator()
        {
            return m_data.GetEnumerator();
        }

        public bool MoveNext()
        {
            ++m_iCurrent;
            return m_iCurrent < m_size;
        }

        public void Reset()
        {
            m_iCurrent = 0;
        }

        public IEnumerable Next()
        {
            int iStart = 0;
            while (true)
	        {
                Console.WriteLine("public IEnumerable Next() iStart : {0}", iStart);
                if (iStart == m_size)
	            {
                    yield break;
                    // yield break하면 완전히 종료
	            }
                yield return m_data[iStart];
                // yield return하면 일단 여기서 실행이 멈춤. 각 return 값이 foreach 구문으로 넘어가서 실행되고 다시 돌아옴.
                ++iStart;
	        }
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
            foreach (int i in iArray.Next())
	        {
                Console.WriteLine("iArrya = {0}", iArray[i]);
	        }
        }
    }
}
