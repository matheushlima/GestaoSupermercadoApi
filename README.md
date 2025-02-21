# 🚀 Gestão Supermercado API

📖 API destinada ao controle, gerenciamento de produtos e vendas, contendo também cadastro de usuarios.

## 🛠️ Tecnologias Utilizadas

- 🔵 **.NET 8** (Back-end)
- 🗄️ **SQL Server** (Banco de Dados)
- 🔗 **Dapper** (ORM)
- 🔐 **JWT** (Autenticação)

## Funcionalidades
- ✅ Cadastro e login com senha criptografada (AES)
- ✅ API RESTful utilizando .NET 8 + Dapper
- ✅ Integração com Vue.js para exibição dos dados

## Scripts para Banco de Dados

- Criação tabela Produtos
  
CREATE TABLE PRODUTOS(
    ID INT NOT NULL IDENTITY(1,1),
    NOME VARCHAR(250),
    QUANTIDADE INT NOT NULL,
    PESO FLOAT NULL,
    UNIDADE_MEDIDA VARCHAR(10),
    STATUS INT NOT NULL,
    DATA_ULTIMA_VENDA DATETIME
    
    CONSTRAINT PK_PRODUTOS PRIMARY KEY (ID)
)

- Criação tabela Usuarios

CREATE TABLE USUARIOS(
    ID INT NOT NULL IDENTITY(1,1),
    USUARIO VARCHAR(250),
    SENHA VARCHAR(250)

    CONSTRAINT PK_USUARIOS PRIMARY KEY (ID)
)

- Criação tabela Vendas

CREATE TABLE VENDAS(
    ID INT NOT NULL IDENTITY(1,1),
    ID_PRODUTO INT NOT NULL,
    QUANTIDADE_VENDIDA INT NOT NULL,
    DATA DATETIME

    CONSTRAINT PK_VENDAS PRIMARY KEY (ID)
)
