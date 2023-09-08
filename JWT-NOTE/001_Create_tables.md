# TABLOLARIN OLUŞTURULMASI

## Users
|               |                 |
|:-------------:|:---------------:|
|Id             | int             | 
|FirstName      | varchar(50)     |
|LastName       | varchar(50)     |
|Email          | varchar(50)     |
|Status         | bit             |
|PasswordSalt   | varbinary(500)  |
|PasswordHash   | varbinary(500)  |
---
## OperationClaims
|       |              |
|:-----:|:------------:|
|Id     |int           |   
|Name   |varchar(500)  |
---
## UserOperationClaims
|                   |       |
|:-----------------:|:-----:|
|Id                 |int    |
|UserId             |int    |   
|OperationClaimId   |int    |