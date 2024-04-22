using EmployeesWebAPIDemo.Controllers;
using EmployeesWebAPIDemo.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class UnitTestEmpAPI
    {

        [TestInitialize]
        public void Setup()
        {
            //one time task like default data initialization that
            //are needed in multiple test methods can be done here
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestGetEmpById()
        {
            //A: Arrange
            int id = 107;
            //Employee emp = new Employee
            //{
            //    Id=107,
            //    Ename="Ratnesh",
            //    Salary=1111,
            //    Deptid=203
            //};
            //dependency arrangement
            Mock<IEmpDataAccess> mock = new Mock<IEmpDataAccess>();
            //mock.Setup(o=>o.GetEmployee(id)).Returns(emp);

            EmployeesController controller=new EmployeesController(mock.Object);
            //A: Act
            //Employee actual=controller.GetEmpById(id);
            //A: Assert
            //Assert.AreEqual("Ratnesh", actual.Ename);

            Assert.ThrowsException<Exception>(()=>controller.GetEmpById(id));

        }

        [TestMethod]
        public void TestDeleteEmp()
        {
            //A: Arrange
            int id = 106;
            Employee emp = null;;

            //dependency arrangement
            Mock<IEmpDataAccess> mock = new Mock<IEmpDataAccess>();
            mock.Setup(o => o.GetEmployee(id)).Returns(emp);

            EmployeesController controller = new EmployeesController(mock.Object);
            //A: Act
            controller.Delete(id);
            Employee actualAfterDel = controller.GetEmpById(id);

            //A: Assert
            Assert.IsNull(actualAfterDel);
        }
    
    }
}
