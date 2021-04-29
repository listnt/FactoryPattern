using System;
using My_Shapes;
namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                double[] sides = { 13, 5, 12 };
                var someShape = ClientCode(new ThreeSideFactory(), sides);
                double[] shapeSides = someShape.Sides;
                Console.WriteLine("Sides: [{0}]", string.Join(", ", shapeSides));
                Console.WriteLine("Calculated Area: {0}", Convert.ToString(someShape.Calculate_Area()));
                Console.WriteLine("Type of Shape: " + someShape.GetType());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        // Место где неизвестен тип фигуры
        public static convexShape ClientCode(IAbstractFactory someFactory, double[] sides)
        {
            var someShape = someFactory.CreateShape(sides);
            return someShape;
        }
    }
}
