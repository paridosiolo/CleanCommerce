using CleanCommerce.Application.Common.Interfaces.Persistence;
using CleanCommerce.Application.Common.Errors;
using CleanCommerce.Domain.Carts;
using CleanCommerce.Domain.Categories;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Carts.Commands
{
    public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand, Result<bool>>
    {
        private readonly ICartRepository _cartRepository;

        public DeleteCartCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Result<bool>> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            //check if cart exists
            if (_cartRepository.GetById(request.CartId) is not Cart cart)
            {
                return Result.Fail(ApplicationErrors.Carts.CartNotFound(
                    cartId: request.CartId.ToString()));
            }

            if (!_cartRepository.Delete(cart))
            {
                return Result.Fail(ApplicationErrors.Carts.CouldNotDelete(
                    cartId: request.CartId.ToString()));
            }

            return Result.Ok();
        }
    }
}
