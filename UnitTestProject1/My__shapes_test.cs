using Microsoft.VisualStudio.TestTools.UnitTesting;
using My_Shapes;
using System;
namespace UnitTestProject1
{
    [TestClass]
    public class My__shapes_test
    {
        //проверка на круг
        [TestMethod]
        public void TestCase1()
        {
            double[] sides = { 4 };
            OneSideFactory oneSideFactory = new OneSideFactory();
            var Circle = oneSideFactory.CreateShape(sides);
            Assert.AreEqual(sides[0] * sides[0] * Math.PI, Circle.Calculate_Area());
        }
        //проверка на неккоректный ввод
        [TestMethod]
        public void TestCase2()
        {
            double[] sides = { 4,5 };
            OneSideFactory oneSideFactory = new OneSideFactory();
            try 
            { 
                oneSideFactory.CreateShape(sides);
                Assert.Fail();
            }
            catch (Exception)
            {  }
        }
        //Проверка на прямоугольный треугольгик
        [TestMethod]
        public void TestCase3()
        {
            double[] sides = { 5, 4, 3 };
            ThreeSideFactory threeSideFactory = new ThreeSideFactory();
            Console.WriteLine(threeSideFactory.CreateShape(sides).GetType());
            Assert.IsTrue(threeSideFactory.CreateShape(sides) is RightTriangle);
        }
    }
}
