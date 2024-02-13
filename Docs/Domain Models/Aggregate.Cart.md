# Domain Models

## Cart
```csharp
class Cart 
{
	Cart Create();
	Cart Get();
	Cart Update();
	void Delete();
	Cart Empty();
}
```

```json
{
	"id" :  "00000000-0000-0000-0000-000000000000",
	"userId" :  "00000000-0000-0000-0000-000000000000",
	"cartItems" : [
		{
			"productId" :  "00000000-0000-0000-0000-000000000000",
			"amount" : 1
		},
		{
			"productId" :  "11111111-1111-1111-1111-111111111111",
			"amount" : 2
		}],
}
```