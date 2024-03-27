using CleanCommerce.Domain.Orders;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Orders.Queries.GetOrder
{
    public record GetOrderQuery(Guid OrderId)
        :IRequest<Result<Order>>;
}
