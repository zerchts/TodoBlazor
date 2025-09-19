using System.ComponentModel.DataAnnotations;

namespace TodoBlazor.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [StringLength(2000)]
        public string? Description { get; set; }

        [Display(Name = "Creation Date & Time")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
