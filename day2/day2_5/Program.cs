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
    class FreeLine : iShape
    {
        public FreeLine()
        {
            LineList.Add(new Line());
            LineList.Add(new Line());
            LineList.Add(new Line());
            LineList.Add(new Line());
            LineList.Add(new Line());
            LineList.Add(new Line());
        }
        private List<iShape> LineList = new List<iShape>(); 
         void iShape.Draw()
        {
            Console.WriteLine("자유곡선 그리기 시작");
            for (int i = 0; i < LineList.Count; i++)
            {
                LineList[i].Draw();
            }
            Console.WriteLine("자유곡선 그리기 시작");
        }
        string iShape.GetShapeName()
        {
            return "자유곡선";
        }
        iShape iShape.Copy()
        {
            return new FreeLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<iShape> ShapeList = new List<iShape>();
            List<iShape> ShapeMenuList = new List<iShape>() { new Line(), new Rectangle(), new Triangle(), new Circle(), new FreeLine() };
            int iChoice = 1;
            iShape selItem = null;
            while (iChoice != 0)
            {
                Console.WriteLine("1. 도형 선택");
                Console.WriteLine("2. 그림판에 그리기");
                Console.WriteLine("3. 그림판 내용 보기");
                iChoice = int.Parse(Console.ReadLine());

                switch (iChoice)
                {
                    case 1:
                        {
                            for (int i = 0; i < ShapeMenuList.Count; i++)
                            {
                                Console.WriteLine("{0}. {1} 선택", i + 1, ShapeMenuList[i].GetShapeName());
                            }
                            int iSelShape = int.Parse(Console.ReadLine());
                            if (iSelShape > 0 && iSelShape <= ShapeMenuList.Count)
                            {
                                selItem = ShapeMenuList[iSelShape - 1];
                            }
                            else
                            {
                                selItem = null;
                            }
                        }
                        break;
                    case 2:
                        if (selItem != null)
                        {
                            ShapeList.Add(selItem.Copy());
                        }
                        else
                        {
                            Console.WriteLine("도형을 선택하세요.");
                        }
                        break;
                    case 3:
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
