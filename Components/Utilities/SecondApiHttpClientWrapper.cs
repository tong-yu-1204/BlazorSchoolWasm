using Shared.Data.Models;
using System.Net.Http.Json;

namespace SharedLib.Utilities;

public class SecondApiHttpClientWrapper
{
    private readonly HttpClient _httpClient;

    public SecondApiHttpClientWrapper(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<BookDetails>> GetListOfBookDetails()
    {
        var listOfBooks = (await _httpClient.GetFromJsonAsync<List<BookDetails>>("book")) ?? new();
        return listOfBooks;
    }
}
