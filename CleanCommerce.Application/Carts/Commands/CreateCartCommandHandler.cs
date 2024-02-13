using CleanCommerce.Application.Common.Interfaces.Persistence;
using CleanCommerce.Domain.Carts;
using CleanCommerce.Domain.Common.Models.User.ValueObjects;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Carts.Commands
{
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, Result<Cart>>
    {
        private readonly ICartRepository _cartRepository;

        public CreateCartCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Result<Cart>> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var cart = Cart.Create(UserId.Create(request.UserId));

            _cartRepository.Add(cart);

            return cart;
        }
    }
}
