using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_EFCodeFirst.Models
{
    public class Customer
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] //for autoincrement identity column
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public List<Order> Orders { get; set; }
    }
}
