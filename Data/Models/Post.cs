using System.ComponentModel.DataAnnotations;

namespace Forum_App.Data.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.TitleMaxLeght)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DataConstants.ContentMaxLeght)]
        public string Content { get; set; } = null!;
    }
}
