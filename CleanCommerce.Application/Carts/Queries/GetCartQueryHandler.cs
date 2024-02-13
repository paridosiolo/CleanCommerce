using CleanCommerce.Application.Common.Errors;
using CleanCommerce.Application.Common.Interfaces.Persistence;
using CleanCommerce.Domain.Carts;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Carts.Queries
{
    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, Result<Cart>>
    {
        private readonly ICartRepository _cartRepository;

        public GetCartQueryHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Result<Cart>> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            if(_cartRepository.GetById(request.CartId) is not Cart cart)
            {
                return ApplicationErrors.Carts.CartNotFound(
                    cartId: request.CartId.ToString());
            }

            return cart;
        }
    }
}
