# Clean Commerce Api

Table of contents
- [Clean Commerce Api](#clean-commerce-api)
  - [Product](#product)
    - [Create](#create)
    - [Get](#get)
    - [Update](#update)
    - [Delete](#delete)



# Product

## Create

```js
POST {{host}}/product/create
```

### Create request
```json
{
	"name" : "Hoodie",
	"description" : "Hoodie description",
	"price" : 100.00,
	"stock" : 10,
	"images" : [
		{ "url" : "00000000-0000-0000-0000-000000000000" },
		{ "url" : "11111111-1111-1111-1111-111111111111" }
	]
}
```

### Create response
```js
201 Created
```

```json
{
	"id" :  "00000000-0000-0000-0000-000000000000",
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
		"00000000-0000-0000-0000-000000000000",
		"11111111-1111-1111-1111-111111111111"
	],
	"promotionIds" : [
		"00000000-0000-0000-0000-000000000000",
		"11111111-1111-1111-1111-111111111111"
	],
	"feedbackIds" : [
		"00000000-0000-0000-0000-000000000000",
		"11111111-1111-1111-1111-111111111111"
	]
}
```

## Get

```js
GET {{host}}/product/{{id}}
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
		"00000000-0000-0000-0000-000000000000",
		"11111111-1111-1111-1111-111111111111"
	],
	"promotionIds" : [
		"00000000-0000-0000-0000-000000000000",
		"11111111-1111-1111-1111-111111111111"
	],
	"feedbackIds" : [
		"00000000-0000-0000-0000-000000000000",
		"11111111-1111-1111-1111-111111111111"
	]
}
```


## Update

```js
PUT {{host}}/product/{{id}}
```

### update request
```json
{
	"id" :  "00000000-0000-0000-0000-000000000000",
	"name" : "Hoodie",
	"description" : "Hoodie description",
	"price" : 100.00,
	"stock" : 10,
	"images" : [
		{ "url" : "00000000-0000-0000-0000-000000000000" },
		{ "url" : "11111111-1111-1111-1111-111111111111" }
	]
}
```

### update response
```js
200 OK
```

```json
{
	"id" :  "00000000-0000-0000-0000-000000000000",
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
		"00000000-0000-0000-0000-000000000000",
		"11111111-1111-1111-1111-111111111111"
	],
	"promotionIds" : [
		"00000000-0000-0000-0000-000000000000",
		"11111111-1111-1111-1111-111111111111"
	],
	"feedbackIds" : [
		"00000000-0000-0000-0000-000000000000",
		"11111111-1111-1111-1111-111111111111"
	]
}
```

## Delete

```js
DELETE {{host}}/product/{{id}}
```

### delete request
```json
{
}
```

### delete response
```json
{
}
```