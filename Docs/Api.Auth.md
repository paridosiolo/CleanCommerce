# Clean Commerce Api

Table of contents
- [Clean Commerce Api](#clean-commerce-api)
  - [Authentication](#authentication)
    - [Register](#register)
    - [Login](#login)



# Authentication

## Register

```js
POST {{host}}/auth/register
```

### Register request
```json
{
    "firstName" : "Bob",
    "lastName" : "Martin",
    "email" : "bob@martinhost.com",
    "password" : "bob11"
}
```

### Register response
```js
200 OK
```

## Login

```js
POST {{host}}/auth/login
```

### Login request
```json
{
    "email" : "bob@martinhost.com",
    "password" : "bob11"
}
```

### Login response
```json
{
    "id" : "5ce9198a-89ac-4da8-8542-5b7107bc2def",
    "firstName" : "Bob",
    "lastName" : "Martin",
    "email" : "bob@martinhost.com",
    "token" : "weoir..q3wero"
}
```