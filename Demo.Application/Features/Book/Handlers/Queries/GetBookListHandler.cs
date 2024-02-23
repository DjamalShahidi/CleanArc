using AutoMapper;
using Demo.Application.DTOs.Book;
using Demo.Application.Features.Book.Requests.Queries;
using Demo.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var books = await _bookRepository.GetListAsync();

            return _mapper.Map<List<BookDto>>(books);
        }
    }
}
