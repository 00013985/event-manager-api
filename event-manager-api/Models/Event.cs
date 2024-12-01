using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppWorkshop.Models
{
    public class Event
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }

        [ForeignKey("LocationId")]
        public int? LocationId { get; set; }

        public Location? Location { get; set; }
    }
}
