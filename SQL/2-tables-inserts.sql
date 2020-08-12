Create Table usuarios(
id Int Identity(1,1) Primary Key,
nome Varchar(100) Not Null,
usuario Varchar(100) Not Null,
senha Varchar(100) Not Null,
situacao BIT NOT NULL,
created_date DateTime Default(GetDate()) Not Null)
GO

Create unique index ix_nome on usuarios (nome)
GO

Create Table itens_leilao(
id Int Identity(1,1) Not null Primary Key,
nome_item Varchar(100) Not null,
valor_inicial Decimal(5,2) Not null,
flag_usado BIT NOT NULL,
responsavel int NOT NULL FOREIGN KEY REFERENCES usuarios(id),
data_abertura DateTime Not Null,
data_finalizacao DateTime Not Null,
created_date DateTime Default(GetDate()) Not Null)
GO

Create unique index ix_nome_item on itens_leilao (nome_item)
GO

Insert Into usuarios(nome, usuario, senha, situacao) 
Values ('Admin Leilao', 'admin', 'teste123', 1)

Insert Into itens_leilao(nome_item, valor_inicial, flag_usado, responsavel, data_abertura, data_finalizacao) 
Values ('Mesa', 100.80, 0, 1, '2020-08-08', '2020-09-08')