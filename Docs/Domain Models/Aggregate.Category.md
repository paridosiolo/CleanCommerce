# Domain Models

## Category
```csharp
class Category 
{
	Category Create();
	Category Get();
	Category Update();
	void Delete();
}
```

```json
{
	"id" :  "00000000-0000-0000-0000-000000000000",
	"name" : "Hoodies",
	"description" : "Hoodies description",
	"image" : { "url" : "00000000-0000-0000-0000-000000000000" },
	"parent" :  "00000000-0000-0000-0000-000000000000",
	"children" : [
		"00000000-0000-0000-0000-000000000000",
		"11111111-1111-1111-1111-111111111111"
	],
	"productIds" : [
		"00000000-0000-0000-0000-000000000000",
		"11111111-1111-1111-1111-111111111111"
	]
}
```