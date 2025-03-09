using System.ComponentModel.DataAnnotations;

namespace Terceros.Applications.DTOs.People;

public class SupportDTO
{
    [Display(Name = "contact")]
    public string Contact { get; set; }

    [Display(Name = "donate")]
    public string Donate { get; set; }
}
