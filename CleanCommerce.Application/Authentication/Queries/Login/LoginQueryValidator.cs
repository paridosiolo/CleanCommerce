using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Authentication.Queries.Login
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty();
            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}
