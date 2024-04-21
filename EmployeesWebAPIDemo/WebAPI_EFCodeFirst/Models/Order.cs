namespace WebAPI_EFCodeFirst.Models
{
    public class Order
    {        
        public int Id { get; set; }
        public int Quantity {  get; set; }
        public decimal Price { get; set; }

        public Customer Customer { get; set; }
    }
}

//customer---->many orders
//order--->one customer