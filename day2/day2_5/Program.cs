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

        }
    }
}
