using System.ComponentModel.DataAnnotations;

namespace mom2spexet.Models
{
    public class MemberModel
    {
        //Properties
        [Required(ErrorMessage = "Du måste fylla i förnamn!")]
        [Display(Name = "Förnamn")]
        public string? Firstname { get; set; }

        [Required(ErrorMessage = "Du måste fylla i efternamn!")]
        [Display(Name = "Efternamn")]
        public string? Lastname { get; set; }

        [Required(ErrorMessage = "Du måste fylla i födelseår!")]
        [Display(Name = "Födelseår")]
        public int? YOB { get; set; }

        [Required(ErrorMessage = "Du måste välja medlemsår!")]
        [Display(Name = "Medlemsår")]
        public int? MemberYears { get; set; }

        [Required(ErrorMessage = "Du måste välja minst en grupp!")]
        [Display(Name = "Grupper")]
        public string[]? Groups { get; set; }

        public int? Age { get; set; }
    }


}
