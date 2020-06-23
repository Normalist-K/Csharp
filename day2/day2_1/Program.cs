using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace day2_1 // Late Binding
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
        }

        static void Main(string[] args)
        {
            List<Animal> AnimalList = new List<Animal>();
            
            //  Early Binding -> w/o virtual-override

            //  AnimalList.Add(new Cat());
            //  AnimalList.Add(new Dog());
            //  AnimalList.Add(new Pig());
            //  for (int i = 0; i < AnimalList.Count; i++)
            //  {
            //      AnimalList[i].Speak();
            //  }


            // Late Binding 

            int iChoice = 1;
            while (iChoice != 0)
            {
                Console.WriteLine("1. Cat");
                Console.WriteLine("2. Dog");
                Console.WriteLine("3. Pig");
                Console.WriteLine("4. Horse");

                iChoice = int.Parse(Console.ReadLine());
                switch (iChoice)
                {
                    case 1:
                        AnimalList.Add(new Cat());
                        break;
                    case 2:
                        AnimalList.Add(new Dog());
                        break;
                    case 3:
                        AnimalList.Add(new Pig());
                        break;
                    case 4:
                        AnimalList.Add(new Horse());
                        break;

                }
                for (int i = 0; i < AnimalList.Count; i++)
                {
                    AnimalList[i].Speak();
                }
            }
        }
    }
}
