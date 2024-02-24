using AutoMapper;
using Demo.Application.Contracts.Persistence;
using Demo.Application.DTOs.Book;
using Demo.Application.Features.Book.Requests.Queries;
using MediatR;

namespace Demo.Application.Features.Book.Handlers.Queries
{
    public class GetBookDetailHandler:IRequestHandler<GetBookDetail, BookDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookDetailHandler(IBookRepository bookRepository,IMapper mapper)
        {
            this._bookRepository = bookRepository;
            this._mapper = mapper;
        }

        public async Task<BookDto> Handle(GetBookDetail request,CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetAsync(request.Id,cancellationToken);
            return _mapper.Map<BookDto>(book);
        }
    }
}
