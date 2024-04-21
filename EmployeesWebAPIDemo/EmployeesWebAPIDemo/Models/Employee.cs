using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesWebAPIDemo.Models
{
    [Table("tbl_employee")]
    public class Employee
    {        
        public int Id { get; set; }
        public string Ename { get; set; }
        public int Salary {  get; set; }
        public int Deptid { get; set; }
    }
}
