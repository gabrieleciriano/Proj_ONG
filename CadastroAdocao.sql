CREATE DATABASE ControleAdocao;
USE ControleAdocao;

CREATE TABLE Adotante (
Nome varchar(50) NOT NULL,
CPF varchar(11) NOT NULL,
Sexo char(1) NOT NULL,
DataNascimento date NOT NULL,
Logradouro varchar(50) NOT NULL,
Numero int NOT NULL,
CEP int,
Bairro varchar(20) NOT NULL,
Complemento varchar(30) NOT NULL,
Cidade varchar(30) NOT NULL,
UF char(2) NOT NULL,
Telefone varchar(11) NOT NULL,
CONSTRAINT PK_CPF PRIMARY KEY (CPF)
);


CREATE TABLE Animal (
CHIP int NOT NULL,
Familia varchar(50) NOT NULL,
Raca varchar(20) NOT NULL,
Sexo char(1) NOT NULL,
Nome varchar(50) NOT NULL,
CONSTRAINT PK_CHIP PRIMARY KEY (CHIP)

);


CREATE TABLE RegistroAdocao(
CPF varchar(11) NOT NULL,
CHIP int NOT NULL,
DataAdocao datetime NOT NULL,
FOREIGN KEY (CPF) REFERENCES Adotante(CPF),
FOREIGN KEY (CHIP) REFERENCES Animal(CHIP),
CONSTRAINT PK_RegistroAdocao PRIMARY KEY(CPF, CHIP)

);

select * from Adotante
select * from Animal
select * from RegistroAdocao

