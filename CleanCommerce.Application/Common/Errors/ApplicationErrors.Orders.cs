using CleanCommerce.Domain.Common.Errors;

namespace CleanCommerce.Application.Common.Errors
{
    public static partial class ApplicationErrors
    {
        public static class Orders
        {
            public static ErrorBase OrderNotFound(
                string code = "Orders.NotFound",
                string orderId = "Default") =>
                new ErrorBase(code, ErrorType.NotFound, $"Following OrderId was not found: {orderId}");

            public static ErrorBase CouldNotDelete(
                string code = "Orders.CouldNotDelete",
                string orderId = "Default") =>
                new ErrorBase(code, ErrorType.Failure, $"Could not delete the following order: {orderId}");
        }
    }
}
