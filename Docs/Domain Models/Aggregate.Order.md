# Domain Models

## Order
```csharp
class Order 
{
	Order Create();
	Order Get();
	Order Update();
	void Delete();
	Order Pay();
}
```


```json
{
	"id" :  { "value" : "00000000-0000-0000-0000-000000000000" },
	"userId" :  { "value" : "00000000-0000-0000-0000-000000000000" },
	"orderItems" : [
		{
			"productId" :  { "value" : "00000000-0000-0000-0000-000000000000" },
			"quantity" : 1
		},
		{
			"productId" :  { "value" : "11111111-1111-1111-1111-111111111111" },
			"quantity" : 2
		}],
	"totalPrice" : 100.00,
	"shippingAddress" : {
		"street" : "123 Main St.",
		"city" : "New York",
		"state" : "NY",
		"zip" : "10001"
	},
	"created" : "2016-01-01T00:00:00.0000000Z",
	"status" : "pending"
	"payment" : {
		"cardNumber" : "0000000000000000",
		"expirationDate" : "2016-01-01T00:00:00.0000000Z",
		"securityCode" : "000",
		"currency" : "EUR",
		"billingAddress" : {
			"street" : "123 Main St.",
			"city" : "New York",
			"state" : "NY",
			"zip" : "10001"
		}
	}
}
```