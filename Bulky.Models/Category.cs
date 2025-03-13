using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name="Category Name")]
        [MaxLength(30)]
        public string Name { get; set; }
        [Display(Name="Display Order")]
        [Range(1,100,ErrorMessage = "Enter Range between 1 to 100 ")]
        public int DisplayOrder { get; set; }
    }
}
