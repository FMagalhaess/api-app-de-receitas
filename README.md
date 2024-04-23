# Project: Recipes-API
# 📁 Collection: Recipes 


## End-point: All
Sem parametro nenhum a API retorna todas as receitas
### Method: GET
>```
>https://localhost:7233/recipe/
>```
### Response: 200
```json
[
    {
        "recipeId": 1,
        "name": "Coxinha",
        "recipeType": 1,
        "preparationTime": 1,
        "ingredients": [
            "frango",
            "paprica",
            "sal",
            "Leite",
            "Farinha de triho"
        ],
        "directions": "Bla, bla",
        "rating": 10
    }
]
```


⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃

## End-point: Coxinha
Adicionando um novo paramentro com o nome correto de uma receita, a mesma sera exibida
### Method: GET
>```
>https://localhost:7233/recipe/coxinha
>```
### Response: 200
```json
{
    "recipeId": 1,
    "name": "Coxinha",
    "recipeType": 1,
    "preparationTime": 1,
    "ingredients": [
        "frango",
        "paprica",
        "sal",
        "Leite",
        "Farinha de triho"
    ],
    "directions": "Bla, bla",
    "rating": 10
}
```


⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃

## End-point: Wrong Name
Caso seja fornecido um nome errado um erro de codigo 404 aparecera
### Method: GET
>```
>https://localhost:7233/recipe/coxinh
>```
### Body (**raw**)

```json

```

### Response: 404
```json
{
    "message": "Nao Encontrado"
}
```


⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃

## End-point: New Recipe
### Method: POST
>```
>https://localhost:7233/recipe/
>```
### Headers

|Content-Type|Value|
|---|---|
|Authorization|Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Imp1bGFzQGVtYWlsLmNvbSIsInJvbGUiOiJVc2VyIiwibmJmIjoxNzEzODgxMDg3LCJleHAiOjE3MTM5Njc0ODcsImlhdCI6MTcxMzg4MTA4N30.1oqwvEkobwqtv6d2GBBa4skuN6_4-jR0A-nPxj8rXJE|


### Body (**raw**)

```json
{
    "Name":"Coxinha 3",
    "RecipeType": 1,
    "PreparationTime": 1,
    "Ingredients": ["frango", "paprica", "sal", "Leite", "Farinha de triho"],
    "Directions": "Bla, bla",
    "Rating": 10
}
```


⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃

## End-point: Edit Recipe
### Method: PUT
>```
>https://localhost:7233/recipe/1
>```
### Body (**raw**)

```json
{
    "Name":"Coxinhaaa",
    "Ingredients": ["frango"],
    "Directions": "Bla, bla"
}
```

### Response: 204
```json
null
```


⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃

## End-point: Delete Recipe
### Method: DELETE
>```
>https://localhost:7233/recipe/2
>```
### Response: 204
```json
null
```


⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃
# 📁 Collection: Comments 


## End-point: New Request
### Method: GET
>```
>https://localhost:7233/comment/
>```

⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃
# 📁 Collection: Users 


## End-point: User
### Method: GET
>```
>https://localhost:7233/user/julas@email.com
>```
### Response: 200
```json
{
    "userId": 3,
    "email": "julas@email.com",
    "name": "Juliana",
    "role": "User",
    "password": "superSenhaSegura"
}
```


⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃

## End-point: User SignUp
### Method: POST
>```
>https://localhost:7233/user/signup
>```
### Body (**raw**)

```json
{
  "Email" : "julaas@email.com",
  "Name" : "Juliana",
  "Password" : "superSenhaSegura"
}
```

### Response: 201
```json
{
    "userId": 1002,
    "email": "julaas@email.com",
    "name": "Juliana",
    "role": "User",
    "password": "superSenhaSegura"
}
```


⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃

## End-point: User Login
### Method: POST
>```
>https://localhost:7233/user/login
>```
### Body (**raw**)

```json
{
    "Email" : "julas@email.com",
    "Password" : "superSenhaSegura"
}
```

### Response: 200
```json
{
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Imp1bGFzQGVtYWlsLmNvbSIsInJvbGUiOiJVc2VyIiwibmJmIjoxNzEzODgxMDg3LCJleHAiOjE3MTM5Njc0ODcsImlhdCI6MTcxMzg4MTA4N30.1oqwvEkobwqtv6d2GBBa4skuN6_4-jR0A-nPxj8rXJE"
}
```

