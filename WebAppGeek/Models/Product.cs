namespace WebAppGeek.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int? ProductGroupId { get; set; }
        public List<Storage> Storages { get; set; }
        public ProductGroup? ProductGroup { get; set; }
    }
}
