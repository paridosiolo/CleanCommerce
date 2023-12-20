# Domain Models

## Feedback
```csharp
class Feedback 
{
	Feedback Create();
	Feedback Get();
	Feedback Update();
	void Delete();
}
```
```json
{
	"id" :  { "value" : "00000000-0000-0000-0000-000000000000" },
	"productId" :  { "value" : "00000000-0000-0000-0000-000000000000" },
	"userId" :  { "value" : "00000000-0000-0000-0000-000000000000" },
	"orderId" :  { "value" : "00000000-0000-0000-0000-000000000000" },
	"rating" : 5,
	"text" : "Review of the product",
	"created" : "2016-01-01T00:00:00.0000000Z",
	"updated" : "2016-01-01T00:00:00.0000000Z"
}
```