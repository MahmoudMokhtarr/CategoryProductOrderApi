namespace CategoryProductOrderApi.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
