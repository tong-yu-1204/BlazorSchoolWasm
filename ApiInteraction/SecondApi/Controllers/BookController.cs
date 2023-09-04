using Microsoft.AspNetCore.Mvc;
using Shared.Data.Models;

namespace SecondApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    public IEnumerable<BookDetails> Get()
    {
        var books = new List<BookDetails>()
        {
            new()
            {
                Title = "Blazor介紹",
                Author = "謝東宇",
                Publisher = "第三波"
            },
            new()
            {
                Title = "Blazor進階",
                Author = "李進",
                Publisher = "人民郵電"
            },
            new()
            {
                Title = "ASP.NET core 11",
                Author = "蔣金楠",
                Publisher = "清華大學"
            },
            new()
            {
                Title = ".NET Maui實作",
                Author = "謝東東",
                Publisher = "博碩"
            },
            new()
            {
                Title = "Spring Boot使用Kotlin",
                Author = "張作霖",
                Publisher = "北京大學出版社"
            },
            new()
            {
                Title = "微軟雲端平台Azure介紹",
                Author = "謝東宇",
                Publisher = "Microsoft"
            }
        };
        return books;
    }
}
