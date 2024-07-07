using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order_Management.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Display(Name = "UOM")]
        public string UnitOfMeasureId { get; set; }
        public double DefaultBuyingPrice { get; set; } = 0.0;
        public double DefaultSellingPrice { get; set; } = 0.0;
    }
}
