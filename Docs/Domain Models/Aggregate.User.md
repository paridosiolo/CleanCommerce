# Domain Models

## User

```csharp
class User 
{
	User Register();
	User Login();
	void Logout();
	User Update();
	void Delete();
}
```


```json
{
	"id" :  "00000000-0000-0000-0000-000000000000",
	"firstName" : "Sofia",
	"lastName" : "Loren",
	"email" : "sofia.loren@gmail.com",
	"password" : "secret123",
	"role" : "user",
	"created" : "2016-01-01T00:00:00.0000000Z",
	"lastLogin" : "2016-01-01T00:00:00.0000000Z",
	"isAuthenticated" : false,
	"cartId" :  "00000000-0000-0000-0000-000000000000",
	"orderIds" : [
		"00000000-0000-0000-0000-000000000000",
		"11111111-1111-1111-1111-111111111111"
	],
	"feedbackIds" : [
		"00000000-0000-0000-0000-000000000000",
		"11111111-1111-1111-1111-111111111111"
	],
}
```


