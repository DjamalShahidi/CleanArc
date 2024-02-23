using Demo.Application.DTOs.Book;
using MediatR;

namespace Demo.Application.Features.Book.Requests.Queries
{
    public class GetBookList : IRequest<List<BookDto>>
    {
    }
}
