using FluentResults;
using MediatR;

namespace CleanCommerce.Application.Orders.Commands
{
    public record DeleteOrderCommand(Guid OrderId)
        : IRequest<Result<bool>>;
}
