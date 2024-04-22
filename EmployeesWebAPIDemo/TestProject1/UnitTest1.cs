using EmployeesWebAPIDemo.Models;

namespace TestProject1
{
    [TestClass]
    public class UnitTestCalculator
    {
        int a, b;

        [TestInitialize]
        public void Setup()
        {
            a = 100;
            b = 200;
        }
        [TestMethod]
        public void TestAddNumbers()
        {
            //A: Arrange
            Calculator calculator = new Calculator();
            //int a = 100, b = 50;
            int expectedResult = 300;
            //A:- Act
            int actualResult=calculator.AddNumbers(a, b);
            //A: Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestSubtract()
        {
            //A: Arrange
            Calculator calculator = new Calculator();
            //int a = 100, b = 50;
            int expectedResult = -100;
            //A:- Act
            int actualResult = calculator.Subtract(a, b);
            //A: Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestMultiply()
        {
            //A: Arrange
            Calculator calculator = new Calculator();
            //int a = 100, b = 50;
            int expectedResult = 20000;
            //A:- Act
            int actualResult = calculator.Multiply(a, b);
            //A: Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        [ExpectedException(typeof(System.DivideByZeroException))]
        public void TestDivide()
        {
            //A: Arrange
            Calculator calculator = new Calculator();
            //int a = 100, b = 0;            
            //A:- Act
            //Assert.ThrowsException<System.DivideByZeroException>(()=>calculator.Divide(a,b));
            calculator.Divide(a, b);
        
        }
    }
}