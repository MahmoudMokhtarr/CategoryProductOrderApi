namespace CategoryProductOrderApi.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }

}
