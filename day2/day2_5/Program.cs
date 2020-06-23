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
    class ToolBarMenu
    {
        public void WriteList(List<iShape> DispList)
        {
            for (int i = 0; i < DispList.Count; i++)
            {
                Console.WriteLine("{0}. {1} 선택", i + 1, DispList[i].GetShapeName());
            }
        }
        public int DispList(List<iShape> ListObj)
        {
            WriteList(ListObj);
            return int.Parse(Console.ReadLine());
        }
        public int DispMenu()
        {
            WriteList(ShapeMenuList);
            Console.WriteLine("{0}. 도형 삭제", ShapeMenuList.Count + 1);
            Console.WriteLine("{0}. 도형 복원", ShapeMenuList.Count + 2);
            Console.WriteLine("0. 이전 메뉴로");
            return int.Parse(Console.ReadLine());
        }
        private void SwapListData(List<iShape> FromList, List<iShape> ToList, int idx)
        {
            ToList.Add(FromList[idx - 1]);
            FromList.RemoveAt(idx - 1);
        }
        private void RemoveMenu()
        {
            if (ShapeMenuList.Count == 0)
            {
                Console.WriteLine("더 이상 삭제할 도형이 없습니다.");
                return;
            }
            int iRemoveShape = DispList(ShapeMenuList);
            SwapListData(ShapeMenuList, ShapeMenuBufferList, iRemoveShape);
        }
        private void RestoreMenu()
        {
            if (ShapeMenuBufferList.Count == 0)
            {
                Console.WriteLine("더 이상 복원할 도형이 없습니다.");
                return;
            }
            int iRestoreShape = DispList(ShapeMenuBufferList);
            SwapListData(ShapeMenuBufferList, ShapeMenuList, iRestoreShape);
        }
        public iShape SubMenu()
        {
            int iSelShape = DispMenu();
            while (iSelShape != 0)
            {
                if (iSelShape > 0 && iSelShape <= ShapeMenuList.Count)
                    return ShapeMenuList[iSelShape - 1];
                else if (iSelShape == ShapeMenuList.Count + 1)
                    RemoveMenu();
                else if (iSelShape == ShapeMenuList.Count + 2)
                    RestoreMenu();
                iSelShape = DispMenu();
            }
            return null;
        }
        List<iShape> ShapeMenuList = new List<iShape>() { new Line(), new Rectangle(), new Triangle(), new Circle(), new FreeLine() };
        List<iShape> ShapeMenuBufferList = new List<iShape>();
    }
    class ShapeMgr
    {
        public void Menu()
        {
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
                        selItem = toolBarMenu.SubMenu();
                        break;
                    case 2:
                        InsertShape(selItem);
                        break;
                    case 3:
                        DrawAllShape();
                        break;
                }
            }
        }
        private void InsertShape(iShape selItem)
        {
            if (selItem != null)
                ShapeList.Add(selItem.Copy());
            else
                Console.WriteLine("도형을 선택하세요.");
        }
        private void DrawAllShape()
        {
            for (int i = 0; i < ShapeList.Count; i++)
                ShapeList[i].Draw();
        }
        List<iShape> ShapeList = new List<iShape>();
        ToolBarMenu toolBarMenu = new ToolBarMenu();
    }
    class Program
    {
        static void Main(string[] args)
        {
            ShapeMgr m = new ShapeMgr();
            m.Menu();
        }
    }
}
