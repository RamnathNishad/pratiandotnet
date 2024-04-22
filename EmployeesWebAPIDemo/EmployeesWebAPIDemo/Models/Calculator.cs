namespace EmployeesWebAPIDemo.Models
{
    public class Calculator
    {
        public int AddNumbers(int a,int b)
        {
            return a + b;
        }
        public int Subtract(int a, int b)
        {
            return a - b;
        }
        public int Multiply(int a, int b)
        {
            return a * b;
        }
        public int Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new System.DivideByZeroException("denominator must not be 0");
            }
            return a / b;
        }
    }
}
