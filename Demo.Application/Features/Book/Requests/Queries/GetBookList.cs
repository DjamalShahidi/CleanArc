using Demo.Application.DTOs.Book;
using Demo.Application.Responses;
using MediatR;

namespace Demo.Application.Features.Book.Requests.Queries
{
    public class GetBookList : IRequest<Response>
    {
    }
}
