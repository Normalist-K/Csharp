using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace day4_3
{
    delegate void DispErrDelegate(string strMessage);
    class Cat
    {
        public int AGE
        {
            get { return m_iAge; }
            set
            {
                if (value <= 0)
                {
                    DispErrEvent("나이는 1보다 작을 수 없습니다.");
                    //Console.WriteLine("나이는 1보다 작을 수 없습니다.");
                    // 이렇게 하면 콘솔에서 밖에 사용할 수 없다. 사용환경에 맞게 쓸 수 있도록 하려면 event로 정보를 넘겨줘.
                    return;
                }
                m_iAge = value;
            }
        }
        public event DispErrDelegate DispErrEvent;
        private int m_iAge;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Cat c = new Cat();
            c.DispErrEvent += C_DispErrEvent;
            c.AGE = -1;

            Cat c2 = new Cat();
            c2.DispErrEvent += C2_DispErrEvent;
            c2.AGE = -1;
        }

        private static void C2_DispErrEvent(string strMessage)
        {
            MessageBox.Show(strMessage);
        }

        private static void C_DispErrEvent(string strMessage)
        {
            Console.WriteLine("ErrMsg : {0}", strMessage);
        }
    }
}
