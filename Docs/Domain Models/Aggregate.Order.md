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
	"id" :  "00000000-0000-0000-0000-000000000000",
	"userId" :  "00000000-0000-0000-0000-000000000000",
	"orderItems" : [
		{
			"productId" :  "00000000-0000-0000-0000-000000000000",
			"amount" : 1
		},
		{
			"productId" :  "11111111-1111-1111-1111-111111111111",
			"amount" : 2
		}],
	"totalPrice" : 100.00,
	"shippingAddress" : {
		"street" : "123 Main St.",
		"city" : "New York",
		"state" : "NY",
		"zip" : "10001"
	},
	"created" : "2016-01-01T00:00:00.0000000Z",
	"updated" : "2016-01-01T00:00:00.0000000Z",
	"status" : "working"
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