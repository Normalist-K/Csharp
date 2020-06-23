using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day2_3 // Late Binding w/ virtual-override & Refactoring
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
            public virtual string GetAnimalName()
            {
                return "Animal";
            }
            public virtual void Speak()
            {
                Console.WriteLine("Animal Speak");
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
                Console.WriteLine("miyaong");
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
                Console.WriteLine("waf waf");
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
                Console.WriteLine("quekkkkk");
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
                Console.WriteLine("hyyyyyyyng");
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
        class AnimalMenuMgr
        {
            public int DispMenu()
            {
                // Generate Menu
                for (int i = 0; i < AnimalMenuList.Count; i++)
                {
                    Console.WriteLine("{0}. {1}", i + 1, AnimalMenuList[i].GetAnimalName());
                }
                Console.WriteLine("{0}. Remove Menu", AnimalMenuList.Count + 1);
                Console.WriteLine("{0}. Insert Menu", AnimalMenuList.Count + 2);

                // Choice Menu
                return int.Parse(Console.ReadLine());
            }
            public int Count
            {
                get { return AnimalMenuList.Count; }
            }
            public Animal this[int idx]
            {
                get
                {
                    if (idx < 0 || idx >= AnimalMenuList.Count)
                    {
                        return AnimalMenuList[0];
                    }
                    return AnimalMenuList[idx];
                }
            }
            public void RemoveMenu()
            {
                if (AnimalMenuList.Count > 0)
                {
                    AnimalMenuBufferList.Add(AnimalMenuList[0]);
                    AnimalMenuList.RemoveAt(0);
                }
            }
            public void InsertMenu()
            {
                if (AnimalMenuBufferList.Count > 0)
                {
                    AnimalMenuList.Insert(0, AnimalMenuBufferList[0]);
                    AnimalMenuBufferList.RemoveAt(0);
                }
            }
            //public void RemoveAt(int idx)
            //{
            //    if (idx >= 0 && idx < AnimalMenuList.Count)
            //    {
            //        AnimalMenuList.RemoveAt(idx);
            //    }
            //}
            //public void Insert(int idx, Animal a)
            //{
            //    if (idx >= 0 && idx < AnimalMenuList.Count)
            //    {
            //        AnimalMenuList.Insert(idx, a);
            //    }
            //}

            List<Animal> AnimalMenuList = new List<Animal>() { new Cat(), new Dog(), new Pig(), new Horse() };
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
                        MenuMgr.InsertMenu();
                    }
                }

                // Selected Animal Speak
                for (int i = 0; i < AnimalList.Count; i++)
                {
                    AnimalList[i].Speak();
                }
            }
            List<Animal> AnimalList = new List<Animal>();
            AnimalMenuMgr MenuMgr = new AnimalMenuMgr();
        }
        static void Main(string[] args)
        {
            AnimalMgr m = new AnimalMgr();
            m.Menu();
        }
    }
}
