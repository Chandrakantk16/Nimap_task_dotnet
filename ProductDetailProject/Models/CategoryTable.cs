using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductDetailProject.Models
{

    [Table("CategoryTable")]
    public class CategoryTable
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        
        public int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual ProductTable ProductTable { get; set; }
    }
}