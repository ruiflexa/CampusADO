CREATE TABLE Clientes
( ClienteId int identity(1,1) not null,
  Nome varchar(100) not null,
  CPF varchar(11) not null 
  PRIMARY KEY CLUSTERED (ClienteId ASC) 
)



CREATE TABLE Produtoes
(
ProdutoId int identity(1,1) NOT NULL,
Nome varchar(100) NOT NULL,
Preco numeric(9,2) NULL,
Estoque int NULL
PRIMARY KEY CLUSTERED (ProdutoId ASC)
)