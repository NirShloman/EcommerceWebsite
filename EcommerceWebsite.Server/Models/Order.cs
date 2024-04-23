using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace EcommerceWebsite.Server.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateOfOrder { get; set; }
        public decimal TotalOrder { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Custoner { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}