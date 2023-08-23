using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
namespace FormDemonstrate.FormModels;

public class AllBlazorFormControlsFormModel
{
    public bool SingleCheckbox { get; set; }


    // Assuming the type of the option is string
    public CheckboxModel[] CheckedCheckboxArray { get; set; } = Array.Empty<CheckboxModel>();

    public DateTime DateTime { get; set; }

    public DateTimeOffset DateTimeOffset { get; set; }

    public string SelectedRadio { get; set; }

    public IReadOnlyList<IBrowserFile>? SelectedFiles { get; set; }

    public IBrowserFile? SelectedFile { get; set; }

    public int Number { get; set; }

    // Assuming the type of the option is string
    public string SingleOption { get; set; } = "";


    // Assuming the type of the option is string
    [MaxLength(3)]
    public string[]? MultipleOptions { get; set; } = Array.Empty<string>();


    public string SimpleText { get; set; } = "";

    public string LongText { get; set; } = "";



}
