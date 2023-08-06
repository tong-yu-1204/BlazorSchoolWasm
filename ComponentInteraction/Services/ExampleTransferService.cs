using Data.Models;
using System.Collections.ObjectModel;

namespace ComponentInteraction.Services;

public class ExampleTransferService
{
    private string _data = "Blazor school";

    public string Data
    {
        get
        {
            return _data;
        }
        set
        {
            _data = value;
            DataChanged?.Invoke(this, value);

        }
    }

    public event EventHandler<string> DataChanged = (sender, args) => { };

    public ObservableCollection<ExampleClass> ExampleInstances { get; set; } = new();
}
