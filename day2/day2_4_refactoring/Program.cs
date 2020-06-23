using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6
{
    abstract class Animal
    {
        public int AGE
        {
            get { return m_iAge; }
            set { m_iAge = value; }
        }
        public abstract void Speak();
        public abstract string GetAnimalName();
        public abstract Animal Copy();
        private int m_iAge;
    }
    class Cat : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("야옹!!!");
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
            Console.WriteLine("멍멍!!!");
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
            Console.WriteLine("꿀꿀!!!");
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
            Console.WriteLine("히잉!!!");
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
    class Tiger : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("어흥!!!");
        }
        public override string GetAnimalName()
        {
            return "Tiger";
        }
        public override Animal Copy()
        {
            return new Tiger();
        }
    }
    class AnimalMenuMgr
    {
        public int DispMenu()
        {
            int i;
            for (i = 0; i < AnimalMenuList.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, AnimalMenuList[i].GetAnimalName());
            }
            Console.WriteLine("{0}. 메뉴삭제", i + 1);
            Console.WriteLine("{0}. 메뉴추가", i + 2);
            return int.Parse(Console.ReadLine());
        }
        public Animal this[int iIndex]
        {
            get { return AnimalMenuList[iIndex]; }
        }
        public int Count // 포함
        {
            get { return AnimalMenuList.Count; }
        }
        public void RemoveMenu()
        {
            AnimalMenuBufferList.Add(AnimalMenuList[0]);
            AnimalMenuList.RemoveAt(0);
        }
        public void AppendMenu()
        {
            if (AnimalMenuBufferList.Count > 0)
            {
                AnimalMenuList.Insert(0, AnimalMenuBufferList[0]);
                AnimalMenuBufferList.RemoveAt(0);
            }
        }
        List<Animal> AnimalMenuList = new List<Animal>() { new Dog(), new Cat(), new Pig(), new Horse(), new Tiger() };
        List<Animal> AnimalMenuBufferList = new List<Animal>();
    }
    class AnimalMgr
    {
        public void Menu()
        {
            int iChoice = 1;
            while (iChoice != 0)
            {
                iChoice = MenuMgr.DispMenu();

                if (iChoice > 0 && iChoice <= MenuMgr.Count)
                {
                    AnimalList.Add(MenuMgr[iChoice - 1].Copy());
                }
                else if (iChoice == MenuMgr.Count + 1)
                {
                    MenuMgr.RemoveMenu();
                }
                else if (iChoice == MenuMgr.Count + 2)
                {
                    MenuMgr.AppendMenu();
                }
            }
            for (int i = 0; i < AnimalList.Count; i++)
            {
                AnimalList[i].Speak();
            }
        }

        List<Animal> AnimalList = new List<Animal>();
        AnimalMenuMgr MenuMgr = new AnimalMenuMgr();
    }
    class Program
    {
        static void Main(string[] args)
        {
            AnimalMgr m = new AnimalMgr();
            m.Menu();
        }
    }
}