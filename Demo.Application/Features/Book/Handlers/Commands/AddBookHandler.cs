using AutoMapper;
using Demo.Application.DTOs.Book.Validators;
using Demo.Application.Exceptions;
using Demo.Application.Features.Book.Requests.Commands;
using Demo.Application.Persistence.Contracts;
using Demo.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.Book.Handlers.Commands
{
    public class AddBookHandler : IRequestHandler<AddBook, int>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public AddBookHandler(IBookRepository bookRepository, IMapper mapper)
        {
            this._bookRepository = bookRepository;
            this._mapper = mapper;
        }

        public async Task<int> Handle(AddBook request, CancellationToken cancellationToken)
        {
            var validator = new AddBookDtoValidator(_bookRepository);
            var validatorResult = await validator.ValidateAsync(request.AddBookDto);

            if(validatorResult.IsValid==false)
            {
                throw new ValidationException(validatorResult);
            }

            var book = _mapper.Map<Domain.Book>(request.AddBookDto);

            //throw new NotFoundException(nameof(Book),id);


            book = await _bookRepository.AddAsync(book);

            return book.Id;
        }
    }
}
