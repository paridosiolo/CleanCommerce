using CleanCommerce.Application;
using CleanCommerce.Infrastructure;

namespace CleanCommerce.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //Builder configuration
            {
                builder.Services.AddApplication()
                                .AddPresentation()
                                .AddInfrastructure(builder.Configuration);

            }

            var app = builder.Build();
            //Pipeline Configuration
            {
                app.UseExceptionHandler("/error");
                app.UseAuthentication();
                app.UseAuthorization();
                app.UseHttpsRedirection();
                app.MapControllers();
            }

            app.Run();
        }
    }
}