using Demo.Application.Persistence.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    var isExist = await _bookRepository.IsExistWithTitle(title);
                    return !isExist;

                }).WithMessage("Book with this title is exist");


        }
    }
}
