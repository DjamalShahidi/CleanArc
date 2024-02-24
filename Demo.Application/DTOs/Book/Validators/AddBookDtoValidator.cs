using Demo.Application.Contracts.Persistence;
using FluentValidation;

namespace Demo.Application.DTOs.Book.Validators
{
    public class AddBookDtoValidator:AbstractValidator<AddBookDto>
    {
        private readonly IBookRepository _bookRepository;

        public AddBookDtoValidator(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            RuleFor(a => a.Title)
                .NotNull().WithMessage("{PropertyName} must be send")
                .MustAsync(async (title, token) =>
                {
                    var isExist = await _bookRepository.IsExistWithTitle(title,token);
                    return !isExist;

                }).WithMessage("Book with this title is exist");


        }
    }
}
