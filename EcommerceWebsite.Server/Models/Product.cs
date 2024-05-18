using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWebsite.Server.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ProductName { get; set; }
        public string Details { get; set; }
        public decimal UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public byte[] ProductImagePath { get; set; }

        //public int CartId { get; set; }
        public int? CategoryId { get; set; }

        // public int OrderLineId { get; set; }
        //public int? PictureId { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();

        public virtual Category Categories { get; set; }
        public virtual ICollection<OrderLine> OrderLine { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}