using System.ComponentModel.DataAnnotations;

namespace StockManagement.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [Range(0, 100)]
        public int? AgeRestriction { get; set; }
        [Required]
        [StringLength(50)]
        public string Company { get; set; }
        [Required]
        [Range(1, 1000)]
        public float Price { get; set; }
    }
}
