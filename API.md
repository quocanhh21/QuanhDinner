# Quanh Dinner API

Table of Contents (up to date)
- [Quanh Dinner API](#quanh-dinner-api) 
	- [Auth](#auth)
		- [Register](#register)
			- [Register Request](#register-request) 
			- [Register Response](#register-response) 
		- [Login](#login)
			- [Login Request](#login-request) 
			- [Login Response](#login-response)

## Auth

### Register
```js
POST {{host}}/api/authentication/register
```

#### Register Request
```json
}
"firstName": "Le",
"lastName": "Anh",
"email": "quanh@yopmail.com", 
"password": "quanh12345"
}
```

#### Register Response
```json
	200 OK
```


### Login Response

```json
{
	"id": "60340f40f403403403403403",
	"firstName": "Le",
	"lastName": "Anh",
	"email": "quanh@yopmail.com"
	"token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjYwMzQwZjQwZjQwMzQwMzQwMzQwMzQwZiIsImlhdCI6MTYxNjIwNjIwOCwiZXhwIjoxNjE2MjA5ODA4fQ.7"
}
```