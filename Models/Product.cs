using System.ComponentModel.DataAnnotations;

namespace QHRMProductsManagement.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        [StringLength(100, ErrorMessage = "Product Name cannot exceed 100 characters.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 999999.99, ErrorMessage = "Price must be a positive number.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
