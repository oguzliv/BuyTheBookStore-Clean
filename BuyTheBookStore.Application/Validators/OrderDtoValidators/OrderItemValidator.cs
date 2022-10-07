using BuyTheBookStore.Application.Dtos.OrderAPIDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTheBookStore.Application.Validators.OrderDtoValidators
{
    public class OrderItemValidator:AbstractValidator<OrderItem>
    {
        public OrderItemValidator()
        {
            RuleFor(oi => oi.BookId).NotEmpty().WithMessage("There has to be item in the cart");
            RuleFor(oi => oi.Count).GreaterThan(0).WithMessage("Item count must be greater than 0");
        }
    }
}
