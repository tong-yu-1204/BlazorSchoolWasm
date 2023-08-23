using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
namespace FormDemonstrate.FormModels;

public class BlazorFormEventsFormModel
{
    [Required]
    [EditorRequired]
    public string ExampleString { get; set; } = "Blazor Schoollllll學習";
}
