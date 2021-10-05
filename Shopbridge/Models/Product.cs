using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge.Models
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        [Required]
        public int ProductNumber { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Product Name cannot exceed 100 characters")]
        public string Name { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "Product Description cannot exceed 500 characters")]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
