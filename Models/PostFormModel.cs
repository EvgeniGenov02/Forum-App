using System.ComponentModel.DataAnnotations;
using static Forum_App.Data.DataConstants;
namespace Forum_App.Models
{
    public class PostFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(TitleMaxLeght, MinimumLength = TitleMinLeght)]
        public string Title { get; set; } = String.Empty;

        [Required]
        [StringLength(ContentMaxLeght, MinimumLength = ContentMinLeght)]
        public string Content { get; set; } = String.Empty;

    }
}
