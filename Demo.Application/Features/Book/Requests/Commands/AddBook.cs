using Demo.Application.DTOs.Book;
using MediatR;

namespace Demo.Application.Features.Book.Requests.Commands
{
    public class AddBook :IRequest<int>
    {
        public AddBookDto AddBookDto { get; set; }
    }
}
