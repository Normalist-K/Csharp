using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day2_5
{
    abstract class Shape
    {
        public abstract void Draw();
        public abstract string GetShapeName();
        public abstract Shape Copy();
        
    }
    class Line : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("라인 그리기");
        }
        public override string GetShapeName()
        {
            return "라인";
        }
        public override Shape Copy()
        {
            return new Line();
        }

    }
    class Triangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("삼각형 그리기");
        }
        public override string GetShapeName()
        {
            return "삼각형";
        }
        public override Shape Copy()
        {
            return new Triangle();
        }
    }
    class Rectangle : Shape
    {
         public override void Draw()
        {
            Console.WriteLine("사각형 그리기");
        }
        public override string GetShapeName()
        {
            return "사각형";
        }
        public override Shape Copy()
        {
            return new Rectangle();
        }
    }
    class Circle : Shape
    {
         public override void Draw()
        {
            Console.WriteLine("원형 그리기");
        }
        public override string GetShapeName()
        {
            return "원형";
        }
        public override Shape Copy()
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
