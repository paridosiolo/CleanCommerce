using CleanCommerce.Application.Common.Errors;
using CleanCommerce.Application.Common.Interfaces.Persistence;
using CleanCommerce.Domain.Carts;
using CleanCommerce.Domain.Carts.Entities;
using CleanCommerce.Domain.Carts.ValueObjects;
using CleanCommerce.Domain.Common.Models.User.ValueObjects;
using CleanCommerce.Domain.Products.ValueObjects;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Carts.Commands
{
    public class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommand, Result<Cart>>
    {
        private readonly ICartRepository _cartRepository;

        public UpdateCartCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Result<Cart>> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var updatedCart = _cartRepository.Update(request.CartId,
                                   request.CartItems.ConvertAll(ci => CartItem.Create(ProductId.Create(ci.ProductId), ci.Amount)));

            if(updatedCart == null) 
            {
                return Result.Fail(ApplicationErrors.Carts.CartNotFound(
                    cartId: request.CartId.ToString()));
            }
            return updatedCart;
        }
    }
}
