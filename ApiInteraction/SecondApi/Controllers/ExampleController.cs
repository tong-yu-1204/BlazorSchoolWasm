using Microsoft.AspNetCore.Mvc;
using Shared.Data.Models;
using Newtonsoft.Json;

namespace SecondApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ExampleController: ControllerBase
{
    [HttpGet("[action]")]
    public void ProcessPrimitiveUrlData(string url)
    {
        Console.WriteLine($"Data received: {url}");
    }


    [HttpPost("[action]")]
    public void ProcessComplexData([FromBody] ExampleClass data) {
        Console.WriteLine($"Data received: {JsonConvert.SerializeObject(data)}");
    }


    [HttpPost("[action]")]
    public void ProcessPrimitiveData([FromBody] string data)
    {
        Console.WriteLine($"Data received: {data}");
    }

    [HttpPost("[action]")]
    public void ProcessStreamData([FromForm] ExampleStreamClass streamModel)
    {
        Console.WriteLine($"Data received with length: ${streamModel.FileStream.Length}");
    }

    [HttpGet("[action]")]
    public IActionResult ReturnPrimitiveData() => Ok("Blazor School的教學");

    [HttpGet("[action]")]
    public IActionResult ReturnComplexData() => Ok(new ExampleClass() { ExampleString = "Blazor School課程" });


    [HttpGet("[action]")]
    public IActionResult ReturnStreamData() => Ok(new FileStream($"{Environment.CurrentDirectory}/SampleFiles/logo.png", FileMode.Open));
}
