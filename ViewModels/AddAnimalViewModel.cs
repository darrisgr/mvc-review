
using System.ComponentModel.DataAnnotations;

namespace mvc_review.ViewModels
{
    public class AddAnimalViewModel
    {
        [Required(ErrorMessage = "Your animal must have a name!")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Animal name must be between 4 and 50 characters long.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Your animal must have a species!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Species must be between 3 and 30 characters long.")]
        public string Species { get; set; }
        [Required(ErrorMessage = "Your animal must have a description!")]
        [StringLength(255, ErrorMessage = "Description cannot exceed 255 characetrs in length")]
        public string Description { get; set; }
    }
}
