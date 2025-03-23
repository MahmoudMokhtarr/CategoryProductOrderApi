namespace CategoryProductOrderApi.Models
{
    public class OrderDetails
    {
        public int OrderDetailID { get; set; }

        // Foreign Key in Table Orders
        public int OrderID { get; set; }
        public Order? Order { get; set; }

        // Foreign Key in Table Products
        public int ProductID { get; set; }
        public Product? Product { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
