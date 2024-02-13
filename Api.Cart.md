# Clean Commerce Api

Table of contents
- [Clean Commerce Api](#clean-commerce-api)
  - [Cart](#cart)
    - [Create](#create)
    - [Get](#get)
    - [Update](#update)
    - [Delete](#delete)
    - [Empty](#empty)



# Cart

## Create

```js
POST {{host}}/cart/create
```

### Create request
```json
{
	"userId" :  "00000000-0000-0000-0000-000000000000"
}
```

### Create response
```js
201 Created
```

```json
{
	"cartId" :  "00000000-0000-0000-0000-000000000000",
	"userId" :  "00000000-0000-0000-0000-000000000000",
	"cartItems" : [],
}
```

## Get

```js
GET {{host}}/cart/{{cartId}}
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
	"cartId" :  "00000000-0000-0000-0000-000000000000",
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

## Update

```js
PUT {{host}}/cart/{{cartId}}
```

### Update request
```json
{
    "cartId" : "b18ef197-7571-4d65-89e8-f4a6527e14e5",
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

### Update response
```js
200 OK
```

```json
{
    "cartId" : "b18ef197-7571-4d65-89e8-f4a6527e14e5",
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

## Delete

```js
DELETE {{host}}/cart/{{cartId}}
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


## Empty

```js
PUT {{host}}/cart/{{cartId}}/empty
```

### Empty request
```json
{
}
```

### Empty response
```js
200 OK
```

```json
{
    "cartId" : "b18ef197-7571-4d65-89e8-f4a6527e14e5",
	"userId" :  "00000000-0000-0000-0000-000000000000",
	"cartItems" : [],
}
```