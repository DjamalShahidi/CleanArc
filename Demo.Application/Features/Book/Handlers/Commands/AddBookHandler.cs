using AutoMapper;
using Demo.Application.Contracts.Persistence;
using Demo.Application.DTOs.Book.Validators;
using Demo.Application.Exceptions;
using Demo.Application.Features.Book.Requests.Commands;
using MediatR;

namespace Demo.Application.Features.Book.Handlers.Commands
{
    public class AddBookHandler : IRequestHandler<AddBook, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddBookHandler(IUnitOfWork unitOfWork,  IBookRepository bookRepository, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<int> Handle(AddBook request, CancellationToken cancellationToken)
        {
            var validator = new AddBookDtoValidator(_unitOfWork.BookRepository);
            var validatorResult = await validator.ValidateAsync(request.AddBookDto);

            if(validatorResult.IsValid==false)
            {
                throw new ValidationException(validatorResult);
            }

            var book = _mapper.Map<Domain.Book>(request.AddBookDto);

            //throw new NotFoundException(nameof(Book),id);


            book = await _unitOfWork.BookRepository.AddAsync(book);

            await _unitOfWork.Save(cancellationToken);

            return book.Id;
        }
    }
}
