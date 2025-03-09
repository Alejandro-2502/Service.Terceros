using System.ComponentModel.DataAnnotations;

namespace Terceros.Applications.Responses.People;

public class SupportResponse
{
    [Display(Name = "contact")]
    public string Contact { get; set; }

    [Display(Name = "donate")]
    public string Donate { get; set; }
}
