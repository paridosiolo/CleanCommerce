# Clean Commerce Api

Table of contents
- [Clean Commerce Api](#clean-commerce-api)
  - [Category](#category)
    - [Create](#create)
    - [Get](#get)
    - [Update](#update)
    - [Delete](#delete)



# Category

## Create

```js
POST {{host}}/category/create
```

### Create request
```json
{
	"name" : "Sportswear",
	"description" : "Sportswear description",
	"image" : { "url" : "00000000-0000-0000-0000-000000000000" },
	"parent" :  "00000000-0000-0000-0000-000000000000",
	"children" : [
		"00000000-0000-0000-0000-000000000000",
		"11111111-1111-1111-1111-111111111111"
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
	"name" : "Sportswear",
	"description" : "Sportswear description",
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

## Get

```js
GET {{host}}/category/{{id}}
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
	"name" : "Sportswear",
	"description" : "Sportswear description",
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


## Update

```js
PUT {{host}}/category/{{id}}
```

### Update request
```json
{
    "categoryId" : "b18ef197-7571-4d65-89e8-f4a6527e14e5",
	"name" : "Sportswear",
	"description" : "Sportswear description",
	"image" : { "url" : "00000000-0000-0000-0000-000000000000" },
	"parentCategoryId" :  "00000000-0000-0000-0000-000000000000",
	"childrenCategoryIds" : [
		"00000000-0000-0000-0000-000000000000",
		"11111111-1111-1111-1111-111111111111"
	]
}
```

### Update response
```js
200 OK
```

```json
{
    "id": "b18ef197-7571-4d65-89e8-f4a6527e14e5",
    "name": "Sportswear",
    "description": "Sportswear description",
    "image": {
        "url": "00000000-0000-0000-0000-000000000000"
    },
    "parentCategoryId": "00000000-0000-0000-0000-000000000000",
    "childrenCategoryIds": [
        "00000000-0000-0000-0000-000000000000",
        "11111111-1111-1111-1111-111111111111"
    ],
    "productIds": []
}
```

## Delete

```js
DELETE {{host}}/category/{{id}}
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