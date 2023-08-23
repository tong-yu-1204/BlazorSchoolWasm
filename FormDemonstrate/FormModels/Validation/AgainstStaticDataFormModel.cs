using System.ComponentModel.DataAnnotations;

namespace FormDemonstrate.FormModels.Validation;

public class AgainstStaticDataFormModel
{
    [Required(ErrorMessage = "必須輸入文字")]
    public string ExampleString { get; set; } = "";

    [Range(2, int.MaxValue, ErrorMessage = "數字必須大於等於2")]
    public int ExampleInt { get; set; } = 1;
}
