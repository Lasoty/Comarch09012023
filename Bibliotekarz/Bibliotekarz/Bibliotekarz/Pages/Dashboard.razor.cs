using Bibliotekarz.Services;
using Bibliotekarz.Shared.SharedModel;
using Blazorise;
using Microsoft.AspNetCore.Components;
using System.Windows.Input;

namespace Bibliotekarz.Pages;

public partial class Dashboard : ComponentBase
{
    private ICollection<BookDto> books;
    private Modal addBookModalRef;
    private BookDto addBookDto = new()
    {
        Borrower = new() { }
    };

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

    private async void AddBook()
    {
        addBookDto = new BookDto
        {
            Borrower = new CustomerDto()
        };

        await addBookModalRef.Show();
    }

    private async void HideModal()
    {
        await addBookModalRef.Hide();
    }

    private async void AddBookModal()
    {
        try
        {
            await BookService.AddBook(addBookDto);
            await addBookModalRef.Hide();
            await NotificationService.Success($"Dodano {addBookDto.Author} {addBookDto.Title}");
        }
        catch (Exception ex)
        {
            await NotificationService.Error($"Wystąpił błąd podczas dodawania książki.");

        }

    }
}
