using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Common.Security.Request
{
    public interface IAuthorizableRequest<T> : IRequest<T>
    {
        public Guid UserId { get; }
    }
}
