using CleanCommerce.Domain.Orders.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        [Obsolete]
        public UpdateOrderCommandValidator() 
        {
            Transform(x => x.Status.Trim(), status => status)
                .IsEnumName(typeof(OrderStatus))
                .WithName(nameof(UpdateOrderCommand.Status));
        }
    }
}
