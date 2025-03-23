namespace CategoryProductOrderApi.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        // Foreign Key in Table Category
        public int CategoryID { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
        public Category? Category { get; set; }
        public ICollection<Order> Order { get; set; } = new List<Order>();


    }
}
