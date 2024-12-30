using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductDetailProject.Models
{
    [Table("ProductTable")]
    public class ProductTable
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        
        public int CategoryId { get; set; }
    }
}