using AutoMapper;
using Demo.Application.Contracts.Persistence;
using Demo.Application.DTOs.Book;
using Demo.Application.Features.Book.Requests.Queries;
using MediatR;

namespace Demo.Application.Features.Book.Handlers.Queries
{
    public class GetBookListHandler : IRequestHandler<GetBookList, List<BookDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookListHandler(IBookRepository bookRepository,IMapper mapper)
        {
            this._bookRepository = bookRepository;
            this._mapper = mapper;
        }
        
        public async Task<List<BookDto>> Handle(GetBookList request,CancellationToken cancellationToken)
        {
            Func<Domain.Book, bool> filter = a => a.IsDeleted == false;

            var books = await _bookRepository.GetRangeAsync(filter,null,null,cancellationToken);

            return _mapper.Map<List<BookDto>>(books);
        }
    }
}
