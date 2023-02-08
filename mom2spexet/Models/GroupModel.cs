using System.ComponentModel.DataAnnotations;

namespace mom2spexet.Models
{
    public class GroupModel
    {
        [Required(ErrorMessage = "Du måste fylla i gruppnamn!")]
        [Display(Name = "Gruppnamn")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Du måste fylla i datum och tid!")]
        [Display(Name = "Nästa möte")]
        public string? DateAndTime { get; set; }
        [Required(ErrorMessage = "Du måste fylla i information!")]
        [Display(Name = "Information")]
        public string? Information { get; set; }
    }
}
