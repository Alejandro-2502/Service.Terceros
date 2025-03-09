using System.ComponentModel.DataAnnotations;

namespace Terceros.Applications.DTOs.People;

public class SocialDTO
{
    [Display(Name = "discord")]
    public string Discord { get; set; }

    [Display(Name = "reddit")]
    public string Reddit { get; set; }

    [Display(Name = "github")]
    public string Github { get; set; }
}
