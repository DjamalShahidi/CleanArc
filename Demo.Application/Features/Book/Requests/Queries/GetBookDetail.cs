using Demo.Application.DTOs.Book;
using MediatR;

namespace Demo.Application.Features.Book.Requests.Queries
{
    public class GetBookDetail : IRequest<BookDto>
    {
        public int Id { get; set; }
    }
}
