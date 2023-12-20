#Domain Models

## Product
```csharp
class Product 
{
	Product Create();
	Product Get();
	Product Update();
	void Delete();
}
```


```json
{
	"id" :  { "value" : "00000000-0000-0000-0000-000000000000" },
	"name" : "Hoodie",
	"description" : "Hoodie description",
	"images" : [
		{ "url" : "00000000-0000-0000-0000-000000000000" },
		{ "url" : "11111111-1111-1111-1111-111111111111" }
	],
	"price" : 100.00,
	"stock" : 10,
	"created" : "2016-01-01T00:00:00.0000000Z",
	"updated" : "2016-01-01T00:00:00.0000000Z",
	"categoryIds" : [
		{ "value" : "00000000-0000-0000-0000-000000000000" },
		{ "value" : "11111111-1111-1111-1111-111111111111" }
	],
	"promotionIds" : [
		{ "value" : "00000000-0000-0000-0000-000000000000" },
		{ "value" : "11111111-1111-1111-1111-111111111111" }
	],
	"feedbackIds" : [
		{ "value" : "00000000-0000-0000-0000-000000000000" },
		{ "value" : "11111111-1111-1111-1111-111111111111" }
	]
}
```