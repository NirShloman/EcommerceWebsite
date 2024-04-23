namespace EcommerceWebsite.Server.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Price { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
        public int? CustomerId { get; set; }
        public int? ProductId { get; set; }
    }
}