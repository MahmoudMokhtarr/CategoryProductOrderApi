namespace CategoryProductOrderApi.Dtos
{
    public class ProductDto
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        // Foreign Key in Table Category
        public int CategoryID { get; set; }

    }
}
