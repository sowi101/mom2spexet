using System.ComponentModel.DataAnnotations;

namespace mom2spexet.Models
{
    public class GroupModel
    {
        //Properties
        [Required(ErrorMessage = "Du måste fylla i gruppnamn!")]
        [Display(Name = "Gruppnamn")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Du måste fylla i dag och tid!")]
        [Display(Name = "Dag och tid för möte")]
        public string? DayAndTime { get; set; }

        [Required(ErrorMessage = "Du måste fylla i information!")]
        [Display(Name = "Information")]
        public string? Information { get; set; }
    }
}
