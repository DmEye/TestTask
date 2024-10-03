
using TestLib;
namespace TestProject
{
    [TestFixture]
    public class ShapeAreaCalculatorTests
    {
        [Test]
        public void Circle_Area_Calculation()
        {
            var circle = new Circle(5);
            Assert.AreEqual(Math.PI * 25, circle.Area, 1e-10);
        }

        [Test]
        public void Triangle_Area_Calculation()
        {
            var triangle = new Triangle(3, 4, 5);
            Assert.AreEqual(6, triangle.Area, 1e-10);
        }

        [Test]
        public void Triangle_Is_Right_Triangle()
        {
            var triangle = new Triangle(3, 4, 5);
            Assert.IsTrue(triangle.IsRightTriangle());
        }

        [Test]
        public void Invalid_Triangle_Throws_Exception()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(1, 2, 3));
        }

        [Test]
        public void Negative_Radius_Throws_Exception()
        {
            Assert.Throws<ArgumentException>(() => new Circle(-1));
        }
    }
}