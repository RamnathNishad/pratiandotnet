using Microsoft.AspNetCore.Mvc;
using EmployeesWebAPIDemo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeesWebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmpDataAccess _dataAccess;
        public EmployeesController(IEmpDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _dataAccess.GetEmployees();
        }

        // GET api/<EmployeesController>/5
        [HttpGet]
        [Route("GetEmpById/{id}")]
        public Employee GetEmpById(int id)
        {
            return _dataAccess.GetEmployee(id);
        }

        //get employees by deptid
        // GET api/<EmployeesController>/5
        //[HttpGet]
        //[Route("GetEmpsByDid/{id}")]
        //public List<Employee> GetEmpsByDid(int id)
        //{
        //    return _dbContext.tbl_employees
        //                    .Where(o=>o.Deptid== id)
        //                    .ToList();

        //}


        // POST api/<EmployeesController>
        [HttpPost]
        [Route("AddEmp")]
        public void Post([FromBody] Employee emp)
        {
           _dataAccess.AddEmployee(emp);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee emp)
        {
           _dataAccess.UpdateEmployee(emp);
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dataAccess.DeleteEmployee(id);
        }

        //[HttpGet]
        //[Route("AddNumbers/{a}/{b}")]
        //public int AddNumbers(int a,int b)
        //{
        //    return a + b;
        //}
    }
}
