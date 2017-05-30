using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principles
{
    public class Open_Closed_Principle
    {
        #region Implementation Without O/C principle
        //public class Rectangle
        //{
        //    public int Height { get; set; }
        //    public int Width { get; set; }
        //}

        //public class Circle
        //{
        //    public double Radius { get; set; }
        //}

        //public class CalculateArea
        //{
        //    public double TotalArea(Rectangle[] arrRectangles)
        //    {
        //        double area = 0;
        //        foreach (var rectangleArea in arrRectangles)
        //        {
        //            area += rectangleArea.Height * rectangleArea.Width;
        //        }

        //        return area;
        //    }
        //}       

        #region If we want to add the area calculation of a circle as well to the exsisting above code

        //public class CalculateArea
        //{
        //    public double TotalArea(object[] arrObject)
        //    {
        //        double area = 0;
        //        Rectangle objRectangle;
        //        Circle objCircle;
        //        foreach (var obj in arrObject)
        //        {
        //            if (obj is Rectangle)
        //            {
        //                objRectangle = (Rectangle)obj;
        //                area += objRectangle.Height * objRectangle.Width;
        //            }
        //            else
        //            {
        //                objCircle = (Circle)obj;
        //                area += objCircle.Radius * objCircle.Radius * Math.PI;
        //            }
        //        }

        //        return area;
        //    }
        //}

        #endregion

        #endregion

        #region Still the above code is not following the O/C principle as each time there is a change the CalculateArea method will be changed

        public abstract class Shape
        {
            public abstract double Area();
        }

        public class Rectangle : Shape
        {
            public int Height { get; set; }
            public int Width { get; set; }
            public override double Area()
            {
                return Height * Width;
            }
        }

        public class Circle : Shape
        {
            public double Radius { get; set; }
            public override double Area()
            {
                return Radius * Radius * Math.PI;
            }
        }

        public class CalculateArea
        {
            public double TotalArea(Shape[] objShape)
            {
                double area = 0;
                foreach (var obj in objShape)
                {
                    area += obj.Area();
                }
                return area;
            }
        }

        #endregion
    }
}
