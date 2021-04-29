using System;

namespace My_Shapes
{
    public abstract class convexShape
    {
        protected double area = 0;
        public abstract double[] Sides { get; }
        public double Area
        {
            get
            {
                return area;
            }

        }
        public abstract double Calculate_Area();
        public virtual void Debug()
        {
            Console.WriteLine("Area of Figure: ", area);
        }

    }
    public class Circle : convexShape
    {
        private double r;

        public override double[] Sides
        {
            get { return new double[] { r }; }
        }
        //Создает экземпляр Circle с базовым значение r=10
        public Circle()
        {
            r = 10;
        }
        public Circle(double R)
        {
            this.r = R;
        }
        public override double Calculate_Area()
        {
            return r * r * Math.PI;
        }
    }
    public abstract class Triangle:convexShape
    {
        protected double a, b, c;
        public override double[] Sides
        {
            get
            {
                return  new double[] { a,b,c};
            }
        }
        public Triangle()
        {
            a = 2;b = 2;c = 2;
        }
        public Triangle(double a1,double b1,double c1)
        {
            this.a = a1; this.b = b1; this.c = c1;
        }
        public override double Calculate_Area()
        {
            double S = (this.a + this.b + this.c)/2;
            return Math.Sqrt(S * (S - this.a) * (S - this.b) * (S - this.c));
        }
    }
    public class AcuteTriangle: Triangle
    {
        public AcuteTriangle() : base() { }
        public AcuteTriangle(double a1, double b1, double c1) : base(a1, b1, c1) { }
        public override double[] Sides => base.Sides;
        public override double Calculate_Area()
        {
            return base.Calculate_Area();
        }
    }
    public class ObtuseTriangle: Triangle
    {
        public ObtuseTriangle() : base() { }
        public ObtuseTriangle(double a1, double b1, double c1) : base(a1, b1, c1) { }
        public override double[] Sides => base.Sides;
        public override double Calculate_Area()
        {
            return base.Calculate_Area();
        }
    }
    public class RightTriangle: Triangle
    {
        public RightTriangle() : base() { }
        public RightTriangle(double a1, double b1, double c1) : base(a1, b1, c1) { }
        public override double[] Sides => base.Sides;
        public override double Calculate_Area()
        {
            return base.Calculate_Area();
        }
    }
    public interface IAbstractFactory
    {
        convexShape CreateShape(double [] sides);
    }
    public class ThreeSideFactory:IAbstractFactory
    {
        public convexShape CreateShape(double[] sides)
        {
            if(sides.Length!=3)
            {
                throw new Exception("This factory \"" + this.GetType().Name + "\" does not correspond to this number of sides " +Convert.ToString(sides.Length));
            }
            if(sides[0]<=0 || sides[1]<=0 || sides[2] <= 0)
            {
                throw new Exception("Error: non valid side, one of the side is negative");
            }
            if(sides[0]>sides[1]+sides[2] || sides[1] > sides[2] + sides[0] || sides[2] > sides[1] + sides[0])
            {
                throw new Exception("Error: non valid side, one of sides bigger than sum of others");
            }
            double[] angles=new double[3];
            angles[0] = Math.Acos((sides[1] * sides[1] + sides[2] * sides[2] - sides[0] * sides[0]) / (2 * sides[1] * sides[2]));
            angles[1] = Math.Acos((sides[0] * sides[0] + sides[2] * sides[2] - sides[1] * sides[1]) / (2 * sides[0] * sides[2]));
            angles[2] = Math.Acos((sides[1] * sides[1] + sides[0] * sides[0] - sides[2] * sides[2]) / (2 * sides[1] * sides[0]));
            if (angles[0] < Math.PI/2 && angles[1] < Math.PI / 2 && angles[2] < Math.PI / 2)
            {
                return new AcuteTriangle(sides[0], sides[1], sides[2]);
            }
            else if (angles[0] == Math.PI / 2 || angles[1] == Math.PI / 2 || angles[2] == Math.PI / 2)
            {
                return new RightTriangle(sides[0], sides[1], sides[2]);
            }
            else
            {
                return new ObtuseTriangle(sides[0], sides[1], sides[2]);
            }
        }
    }
    public class OneSideFactory : IAbstractFactory
    {
        public convexShape CreateShape(double[] sides)
        {
            if (sides.Length != 1)
            {
                throw new Exception("This factory \"" + this.GetType().Name + "\" does not correspond to this number of sides " + Convert.ToString(sides.Length));
            }
            if (sides[0] <= 0)
            {
                throw new Exception("Error: non valid side, one of the side is negative");
            }
            return new Circle(sides[0]);
        }
    }

}
