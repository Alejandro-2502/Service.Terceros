using System.ComponentModel.DataAnnotations;

namespace Terceros.Applications.Responses.People;

public class ResultResponse
{
    [Display(Name = "uid")]
    public string UId { get; set; }

    [Display(Name = "name")]
    public string Name { get; set; }

    [Display(Name = "url")]
    public string Url { get; set; }
}
