using System.ComponentModel.DataAnnotations;

namespace Terceros.Applications.Responses.People;

public class SocialResponse
{
    [Display(Name = "discord")]
    public string Discord { get; set; }

    [Display(Name = "reddit")]
    public string Reddit { get; set; }

    [Display(Name = "github")]
    public string Github { get; set; }
}
