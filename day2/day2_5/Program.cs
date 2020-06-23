using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day2_5
{
    interface iShape
    {
        void Draw();
        string GetShapeName();
        iShape Copy();
        
    }
    class Line : iShape
    {
        void iShape.Draw()
        {
            Console.WriteLine("라인 그리기");
        }
        string iShape.GetShapeName()
        {
            return "라인";
        }
        iShape iShape.Copy()
        {
            return new Line();
        }

    }
    class Triangle : iShape
    {
        void iShape.Draw()
        {
            Console.WriteLine("삼각형 그리기");
        }
        string iShape.GetShapeName()
        {
            return "삼각형";
        }
        iShape iShape.Copy()
        {
            return new Triangle();
        }
    }
    class Rectangle : iShape
    {
         void iShape.Draw()
        {
            Console.WriteLine("사각형 그리기");
        }
        string iShape.GetShapeName()
        {
            return "사각형";
        }
        iShape iShape.Copy()
        {
            return new Rectangle();
        }
    }
    class Circle : iShape
    {
         void iShape.Draw()
        {
            Console.WriteLine("원형 그리기");
        }
        string iShape.GetShapeName()
        {
            return "원형";
        }
        iShape iShape.Copy()
        {
            return new Circle();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<iShape> ShapeList = new List<iShape>();
            List<iShape> ShapeMenuList = new List<iShape>() { new Line(), new Rectangle(), new Triangle(), new Circle() };
            int iChoice = 1;
            iShape selItem = null;
            while (iChoice != 0)
            {
                Console.WriteLine("1. 라인 선택");
                Console.WriteLine("2. 삼각형 선택");
                Console.WriteLine("3. 사각형 선택");
                Console.WriteLine("4. 원형 선택");
                Console.WriteLine("5. 그림판에 그리기");
                Console.WriteLine("6. 그림판 내용 보기");
                iChoice = int.Parse(Console.ReadLine());

                switch (iChoice)
                {
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:
                        selItem = ShapeMenuList[iChoice - 1];
                        break;
                    case 5:
                        ShapeList.Add(selItem.Copy());
                        break;
                    case 6:
                        {
                            for (int i = 0; i < ShapeList.Count; i++)
                            {
                                ShapeList[i].Draw();
                            }
                        }
                        break;

                }
            }
            
        }
    }
}
