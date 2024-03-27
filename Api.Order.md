# Clean Commerce Api

Table of contents
- [Clean Commerce Api](#clean-commerce-api)
  - [Order](#order)
    - [Create](#create)
    - [Get](#get)
    - [Update](#update)
    - [Delete](#delete)



# Order

## Create

```js
POST {{host}}/order/create
```

### Create request
```json
{
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

### Create response
```js
201 Created
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

## Get

```js
GET {{host}}/order/{{id}}
```

### Get request
```json
{
}
```

### Get response
```js
200 OK
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


## Update

```js
PUT {{host}}/order/{{id}}
```

### Update request
```json
{
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

### Update response
```js
200 OK
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
	"status" : "working",
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

## Delete

```js
DELETE {{host}}/order/{{id}}
```

### Delete request
```json
{
}
```

### Delete response
```js
200 OK
```

```json
{
}
```