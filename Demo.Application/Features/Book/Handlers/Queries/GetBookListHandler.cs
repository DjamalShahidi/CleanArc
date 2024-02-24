using AutoMapper;
using Demo.Application.Contracts.Persistence;
using Demo.Application.DTOs.Book;
using Demo.Application.Features.Book.Requests.Queries;
using Demo.Application.Responses;
using MediatR;
using System.Linq.Expressions;

namespace Demo.Application.Features.Book.Handlers.Queries
{
    public class GetBookListHandler : IRequestHandler<GetBookList, Response>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookListHandler(IBookRepository bookRepository,IMapper mapper)
        {
            this._bookRepository = bookRepository;
            this._mapper = mapper;
        }
        
        public async Task<Response> Handle(GetBookList request,CancellationToken cancellationToken)
        {
            Expression<Func<Domain.Book, bool>> filter = a => a.IsDeleted == false;

            var books = await _bookRepository.GetRangeAsync(filter,null,null);

            var bookDtos= _mapper.Map<List<BookDto>>(books);

            return new Response(bookDtos);
        }
    }
}
