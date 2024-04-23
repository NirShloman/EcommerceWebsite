namespace EcommerceWebsite.Server.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public virtual ICollection<SubCategory> SubCategory { get; set; } = new HashSet<SubCategory>();
    }
}