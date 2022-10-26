using System.ComponentModel.DataAnnotations;

namespace RPDemo.Pages.Models
{
    public class OrderUpdateModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "You need to keep the name to max of 20 characters")]
        [MinLength(3, ErrorMessage = "You need to enter at least 3 characters for order name")]
        [Display(Name = "Update order Name")]
        public string OrderName { get; set; }
    }
}
