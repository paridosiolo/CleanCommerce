using CleanCommerce.Application.Authentication.Commands.Register;
using CleanCommerce.Application.Authentication.Common;
using CleanCommerce.Application.Authentication.Queries.Login;
using CleanCommerce.Contracts.Authentication;
using Mapster;

namespace CleanCommerce.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<LoginRequest, LoginQuery>();
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token) //redundant
                .Map(dest => dest.Id, src => src.User.Id.Value)
                .Map(dest => dest, src => src.User);
        }
    }
}
