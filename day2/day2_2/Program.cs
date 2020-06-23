using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace day2_1 // Menu Automation
{
    class Program
    {
        class Animal
        {
            public int AGE
            {
                get { return m_iAge; }
                set { m_iAge = value; }
            }
            public virtual void Speak()
            {
                Console.WriteLine("Animal Speak...");
            }
            public virtual string GetAnimalName()
            {
                return "Animal";
            }
            public virtual Animal Copy()
            {
                return new Animal();
            }
            private int m_iAge;
        }
        class Cat : Animal
        {
            public override void Speak()
            {
                Console.WriteLine("miyaong...");
            }
            public override string GetAnimalName()
            {
                return "Cat";
            }
            public override Animal Copy()
            {
                return new Cat();
            }
        }
        class Dog : Animal
        {
            public override void Speak()
            {
                Console.WriteLine("wafwaf...");
            }
            public override string GetAnimalName()
            {
                return "Dog";
            }
            public override Animal Copy()
            {
                return new Dog();
            }
        }
        class Pig : Animal
        {
            public override void Speak()
            {
                Console.WriteLine("qqqqqqq....");
            }
            public override string GetAnimalName()
            {
                return "Pig";
            }
            public override Animal Copy()
            {
                return new Pig();
            }
        }
        class Horse : Animal
        {
            public override void Speak()
            {
                Console.WriteLine("hihihihiiiing....");
            }
            public override string GetAnimalName()
            {
                return "Horse";
            }
            public override Animal Copy()
            {
                return new Horse();
            }
        }

        static void Main(string[] args)
        {
            List<Animal> AnimalList = new List<Animal>();

            List<Animal> AnimalMenuList = new List<Animal>()
            { new Cat(), new Dog(), new Pig(), new Horse() };
            // 모든 메뉴의 추가, 제거, 수정은 이 코드로 다 작업할 수 있다!

            List<Animal> AnimalDeleteMenuBuffer = new List<Animal>();
            // 삭제한 메뉴 담는 List. 나중에 다시 살릴 수 있도록

            int iChoice = 1;
            while (iChoice != 0)
            {
                int i;
                for (i = 0; i < AnimalMenuList.Count; i++)
                {
                    Console.WriteLine("{0}. {1}", i + 1, AnimalMenuList[i].GetAnimalName());
                }
                //Console.WriteLine("1. Cat");
                //Console.WriteLine("2. Dog");
                //Console.WriteLine("3. Pig");
                //Console.WriteLine("4. Horse");
                Console.WriteLine("{0}. 메뉴삭제", i + 1);
                Console.WriteLine("{0}. 메뉴추가", i + 2);

                iChoice = int.Parse(Console.ReadLine());

                if (iChoice > 0 && iChoice <= AnimalMenuList.Count)
                {
                    AnimalList.Add(AnimalMenuList[iChoice - 1].Copy());
                }
                else if (iChoice == AnimalMenuList.Count + 1 && AnimalMenuList.Count != 0)
                {
                    AnimalDeleteMenuBuffer.Add(AnimalMenuList[0]);
                    AnimalMenuList.RemoveAt(0);
                    // AnimalMenuList heap 메모리만 사라지고 순서 앞으로 한 칸씩 당겨짐
                }
                else if (iChoice == AnimalMenuList.Count + 2 && AnimalDeleteMenuBuffer.Count > 0)
                {
                    AnimalMenuList.Insert(0, AnimalDeleteMenuBuffer[0]);
                    AnimalDeleteMenuBuffer.RemoveAt(0);
                }
                //switch는 그렇게 좋은 코드가 아니다. 메뉴가 추가될 때 마다 코드를 직접 추가해야 하기 때문
                //switch (iChoice)
                //{
                //    case 1:
                //        AnimalList.Add(new Cat());
                //        break;
                //    case 2:
                //        AnimalList.Add(new Dog());
                //        break;
                //    case 3:
                //        AnimalList.Add(new Pig());
                //        break;
                //    case 4:
                //        AnimalList.Add(new Horse());
                //        break;
                //}

                for (i = 0; i < AnimalList.Count; i++)
                {
                    AnimalList[i].Speak();
                }
            }
        }
    }
}
