# Domain Models

## Promotion
```csharp
class Promotion 
{
	Promotion Create();
	Promotion Get();
	Promotion Update();
	void AssignToProduct(List<string> productIds);
	void Delete();
}
```
```json
{
	"id" :  { "value" : "00000000-0000-0000-0000-000000000000" },
	"name" : "30% Discount",
	"description" : "Description of promo",
	"isPercentage" : true
	"discount" : 30,
	"startDate" : "2016-01-01T00:00:00.0000000Z",
	"endDate" : "2016-01-01T00:00:00.0000000Z",
	"productIds" : [
		{ "value" : "00000000-0000-0000-0000-000000000000" },
		{ "value" : "11111111-1111-1111-1111-111111111111" }
	]
}
```