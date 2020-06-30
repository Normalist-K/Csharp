using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "홍길동";

            FileStream f = new FileStream("C://Users//uvent//source//repos//Normalist-K//hustar2//0630//day4//day4_5//1.txt", FileMode.Create);
            //FileStream f = new FileStream(@"C:\Users\uvent\source\repos\Normalist-K\hustar2\0630", FileMode.Create);
            // 역슬래쉬 쓰는 두가지 방법

            // string을 파일로 저장할 때 byte 배열로 인코딩해야 함
            byte[] data = Encoding.Default.GetBytes(s);
            f.Write(data, 0, data.Length);
            f.Close();
            f.Dispose();
        }
    }
}
