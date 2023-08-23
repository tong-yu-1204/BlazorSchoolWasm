using System.ComponentModel.DataAnnotations;
namespace FormDemonstrate.FormModels.CommonMistakes;

public class UpdatingFieldValueWithoutNotifyingFieldChangedFormModel
{
    [Required]
    public string RequiredString { get; set; } = "Bllllazor School";
}
