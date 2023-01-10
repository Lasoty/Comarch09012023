﻿using Bibliotekarz.Shared.SharedModel;
using System.Net.Http.Json;
using System.Text.Json;

namespace Bibliotekarz.Services;

public class BookService : IBookService
{
    private readonly HttpClient httpClient;

    public BookService(HttpClient httpClient)
	{
        this.httpClient = httpClient;
    }

    public async Task<ICollection<BookDto>> GetBooks()
    {
        ICollection<BookDto>? result = 
            await httpClient.GetFromJsonAsync<ICollection<BookDto>>("/Books/GetAll");

        return result;
        //HttpResponseMessage response = await httpClient.GetAsync("/Books/GetAll");
        //result = JsonSerializer.Deserialize<ICollection<BookDto>>(await response.Content.ReadAsStringAsync());
    }
}

public interface IBookService
{
    Task<ICollection<BookDto>> GetBooks();
}