using System.ComponentModel.DataAnnotations;
namespace FormDemonstrate.FormModels.CommonMistakes;

public class ForgettingDataAnnotationsTagFormModel
{
    [Required]
    public string RequiredString { get; set; } = "";

}
