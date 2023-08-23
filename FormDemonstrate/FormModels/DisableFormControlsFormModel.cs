using System.ComponentModel.DataAnnotations;
namespace FormDemonstrate.FormModels;

public class DisableFormControlsFormModel
{
    [Required]
    public string ExampleString { get; set; } = "關閉表單控制項";
}
