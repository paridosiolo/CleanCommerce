namespace CleanCommerce.Application.Carts.Common
{
    public record CartItemCommand(Guid CartItemId,
                                  Guid ProductId,
                                  int Amount);
}
