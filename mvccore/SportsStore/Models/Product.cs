namespace SportsStore.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal RetailPrice { get; set; }
        public  Category Category { get; set; }
    }
}