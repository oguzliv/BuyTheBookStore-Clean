using BuyTheBookStore.Application.Dtos.UserAPIDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTheBookStore.Application.Validators.UserDtoValidators
{
    public class LoginDtoValidatior: AbstractValidator<LoginDto>
    {
        public LoginDtoValidatior()
        {
           RuleFor(user => user.Password).
                NotEmpty().
                Matches("^(?=.*?[a-z])(?=.*?[0-9]).{6,}$").
                WithMessage("Password must contain one lower character and one numeric character and has at least 6 characters"); ;
           RuleFor(user => user.Email).NotEmpty().EmailAddress();
        }
    }
}
