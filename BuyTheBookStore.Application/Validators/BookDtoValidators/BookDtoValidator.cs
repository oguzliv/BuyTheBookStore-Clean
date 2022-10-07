using BuyTheBookStore.Application.Dtos.BookAPIDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTheBookStore.Application.Validators.BookDtoValidators
{
    public class BookDtoValidator:AbstractValidator<BookDto>
    {
        public BookDtoValidator()
        {
            RuleFor(book => book.Name).NotEmpty().WithMessage("Book name is required !");
            RuleFor(book => book.GenreText).NotEmpty().WithMessage("Book genre is required !"); ;
            RuleFor(book => book.AuthorName).NotEmpty().WithMessage("Book author is required !"); ;
            RuleFor(book => book.Price).GreaterThan(0);
        }
    }
}
