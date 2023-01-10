using Bibliotekarz.Shared.SharedModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bibliotekarz.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public BookController()
        {

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            List<BookDto> result = new List<BookDto>()
            {
                new BookDto
                {
                    Id= 1,
                    Author = "Leszek Lewandowski",
                    Title = "Programowanie w C#",
                    IsBorrowed= true,
                    Borrower = new CustomerDto
                    {
                        Id= 2,
                        FirstName = "Adam",
                        LastName = "Nowak"
                    }
                }
            };

            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(BookDto book)
        {
            return Ok();
        }
    }
}
