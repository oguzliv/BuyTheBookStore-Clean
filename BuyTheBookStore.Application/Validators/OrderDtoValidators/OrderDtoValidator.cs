using BuyTheBookStore.Application.Dtos.OrderAPIDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTheBookStore.Application.Validators.OrderDtoValidators
{
    public class OrderDtoValidator:AbstractValidator<OrderDto>
    {
        public OrderDtoValidator()
        {
            RuleFor(order => order.OrderItems).NotEmpty().WithMessage("Order list is empty");
            RuleForEach(order => order.OrderItems).SetValidator(new OrderItemValidator());
        }
    }
}
