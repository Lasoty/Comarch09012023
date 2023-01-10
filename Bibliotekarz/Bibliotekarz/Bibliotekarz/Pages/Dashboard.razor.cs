using Bibliotekarz.Services;
using Bibliotekarz.Shared.SharedModel;
using Blazorise;
using Microsoft.AspNetCore.Components;

namespace Bibliotekarz.Pages;

public partial class Dashboard : ComponentBase
{
    private ICollection<BookDto> books;

    [Inject]
    public INotificationService NotificationService { get; set; }

    [Inject]
    public IBookService BookService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        try
        {
            books = await BookService.GetBooks();
        }
        catch (Exception ex)
        {
            await NotificationService.Error("Błąd pobierania książek!");

            Console.WriteLine(ex);
        }
    }
}
