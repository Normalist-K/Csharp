using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace day4_1
{
    class Program
    {
        class Member
        {
            public void PrintData()
            {
                Console.WriteLine("이름: {0}", Name);
                Console.WriteLine("주소: {0}", Addr);
                Console.WriteLine("전화번호: {0}", TelNo);
            }
            public bool CompareAddr(string strAddr)
            {
                return Addr == strAddr;
            }
            public string Name;
            public string Addr;
            public string TelNo;
            // public으로 한 이유는 초기화 쉽게 하기위해서.. 원래는 private!
        }
        class Video
        {
            public void PrintData()
            {
                Console.WriteLine("비디오 번호: {0}", VideoNo);
                Console.WriteLine("비디오 제목: {0}", Title);
            }
            public string VideoNo;
            public string Title;
        }
        class Rent
        {
            public string Name;
            public string VideoNo;
        }
        static void Main(string[] args)
        {
            // LINQ
            List<Member> MemList = new List<Member>() { 
                new Member() { Name = "홍길동", Addr = "서울", TelNo = "123-1234" },
                new Member() { Name = "김길동", Addr = "대전", TelNo = "234-1234" },
                new Member() { Name = "이길동", Addr = "대구", TelNo = "345-1234" },
                new Member() { Name = "기길동", Addr = "서울", TelNo = "456-1234" },
                new Member() { Name = "지길동", Addr = "포항", TelNo = "567-1234" },
                new Member() { Name = "박길동", Addr = "대구", TelNo = "567-1234" },
            };
            List<Video> VideoList = new List<Video>() {
                new Video() { VideoNo = "1", Title = "블랙미러" },
                new Video() { VideoNo = "2", Title = "메트릭스" },
                new Video() { VideoNo = "3", Title = "노트북" },
                new Video() { VideoNo = "4", Title = "부산행" },
                new Video() { VideoNo = "5", Title = "아이언맨" },
                new Video() { VideoNo = "6", Title = "어벤져스" },
            };
            List<Rent> RentList = new List<Rent>() {
                new Rent() { VideoNo = "1", Name = "홍길동" },
                new Rent() { VideoNo = "2", Name = "홍길동" },
                new Rent() { VideoNo = "3", Name = "김길동" },
                new Rent() { VideoNo = "4", Name = "박길동" },
                new Rent() { VideoNo = "5", Name = "김길동" },
                new Rent() { VideoNo = "6", Name = "홍길동" },
                new Rent() { VideoNo = "3", Name = "지길동" },
                new Rent() { VideoNo = "2", Name = "기길동" },
                new Rent() { VideoNo = "1", Name = "이길동" },
                new Rent() { VideoNo = "4", Name = "지길동" },
            };

            var v = from item in RentList
                    join video in VideoList on item.VideoNo equals video.VideoNo
                    join mem in MemList on item.Name equals mem.Name
                    select new { 
                        VideoNo = item.VideoNo, 
                        Title = video.Title, 
                        Name = item.Name, 
                        Addr = mem.Addr, 
                        TelNo = mem.TelNo, 
                    };
            foreach (var i in v)
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("비디오 번호: {0}", i.VideoNo);
                Console.WriteLine("비디오 제목: {0}", i.Title);
                Console.WriteLine("회원 이름: {0}", i.Name);
                Console.WriteLine("회원 주소: {0}", i.Addr);
                Console.WriteLine("회원 전화번호: {0}", i.TelNo);

            }
        }
    }
}
