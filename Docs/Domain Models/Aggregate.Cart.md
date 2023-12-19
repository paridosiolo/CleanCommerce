# Domain Models

## Cart
```csharp
class Cart 
{
	Cart Create();
	Cart Get();
	Cart Update();
	Cart Empty();
	void Delete();
}
```

```json
{
	"id" :  { "value" : "00000000-0000-0000-0000-000000000000" },
	"userId" :  { "value" : "00000000-0000-0000-0000-000000000000" },
	"cartItems" : [
		{
			"productId" :  { "value" : "00000000-0000-0000-0000-000000000000" },
			"quantity" : 1
		},
		{
			"productId" :  { "value" : "11111111-1111-1111-1111-111111111111" },
			"quantity" : 2
		}],
}
```