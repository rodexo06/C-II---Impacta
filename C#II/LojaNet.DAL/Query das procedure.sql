use LojaNet
go

--Create Table Cliente(
--	Id varchar(50) Primary Key,
--	Nome varchar(100),
--	Email varchar(100),
--	Telefone varchar(100),
--)

--Create Procedure ClienteIncluir(
--	@Id varchar(50),
--	@Nome varchar(100),
--	@Email varchar(100),
--	@Telefone varchar(100)
--)
--	as

--	Insert Into Cliente(Id, Nome, Email, Telefone)values(@Id,@Nome ,@Email ,@Telefone)

--Create Procedure ClienteListar
--	as
--	select Id, Nome, Email, Telefone From Cliente

--Create Procedure ClienteExcluir(@id varchar(50))
--as
--Delete from Cliente where id=@id

--Create Procedure ClienteObterPorId(@Id varchar(50))
--as select Id, Nome, Email, Telefone From Cliente where Id=@id


--Create Procedure ClienteAlterar(
--	@Id varchar(50),
--	@Nome varchar(100),
--	@Email varchar(100),
--	@Telefone varchar(100)
--	) as
--	Update Cliente Set Nome=@Nome, Email=@Email, Telefone=@Telefone
--	where Id=@id
