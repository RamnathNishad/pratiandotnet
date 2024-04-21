namespace EmployeesWebAPIDemo.Models
{
    public interface IEmpDataAccess
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(int id);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);

    }
    public class EmpDataAccessLayer : IEmpDataAccess
    {
        private readonly EmpDBContext _dbContext;
        public EmpDataAccessLayer(EmpDBContext empDBContext)
        {
            this._dbContext = empDBContext;
        }
        public void AddEmployee(Employee employee)
        {
            //DAL-EF Core to insert record
            _dbContext.tbl_employees.Add(employee);
            _dbContext.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var record = _dbContext.tbl_employees.Find(id);

            if (record == null)
            {
                throw new Exception("Id does not exist");
            }
            _dbContext.tbl_employees.Remove(record);
            _dbContext.SaveChanges();
        }

        public Employee GetEmployee(int id)
        {
            var record = _dbContext.tbl_employees.Find(id);

            if (record == null)
            {
                throw new Exception("Id does not exist");
            }
            return record;
        }

        public List<Employee> GetEmployees()
        {
           return _dbContext.tbl_employees.ToList();
        }

        public void UpdateEmployee(Employee employee)
        {
            var record = _dbContext.tbl_employees.Find(employee.Id);

            if (record == null)
            {
                throw new Exception("Id does not exist");
            }

            record.Ename = employee.Ename;
            record.Salary = employee.Salary;
            record.Deptid = employee.Deptid;

            _dbContext.SaveChanges();
        }
    }
}
