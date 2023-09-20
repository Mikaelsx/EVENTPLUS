 DDL Data definition language

-- Criar banco de dados
create database EventPlus

-- Usar banco
use EventPlus

-- Criar as tabelas

create table TipoDeUsuarios
(
	IdTiposDeUsuario int primary key identity,
	TituloTipoUsuario varchar(50) not null
)

create table TiposDeEvento
(
	IdTipoDeEvento int primary key identity,
	TituloTipoEvento varchar(50) not null
)

-- Drop table
alter table TiposDeEvento add unique (TituloTipoEvento)

-- Atualizar tabela
alter table TiposDeEventos
add constraint Eventos unique (TituloTipoEvento)

create table Instituição
(
	IdInstituição int primary key identity,
	CNPJ char(14) not null unique,
	Endereco varchar(200) not null,
	NomeFantasia varchar(200) not null
)

create table Usuario
(
	IdUsuario int primary key identity,
	IdTiposDeUsuario int foreign key references TipoDeUsuarios(IdTiposDeUsuario) not null,
	Nome varchar(50) not null,
	Email varchar(80) not null unique,
)

create table Evento 
(
	IdEvento int primary key identity,
	IdTipoDeEvento int foreign key references TiposDeEvento(IdTipoDeEvento) not null,
	IdInstituição int foreign key references Instituição(IdInstituição) not null,
	Nome varchar(100) not null,
	Descricao varchar(100) not null,
	DataEvento date not null,
	Horario Time not null
)

alter table Evento alter column Descricao varchar(300) 

create table PresencaEvento
(
	IdPresencaEvento int primary key identity,
	IdUsuario int foreign key references Usuario(IdUsuario) not null,
	IdEvento int foreign key references Evento(IdEvento) not null,
	Situacao bit default(0)
)

create table ComentarioEvento
(
	IdComentarioEvento int primary key identity,
	IdUsuario int foreign key references Usuario(IdUsuario) not null,
	IdEvento int foreign key references Evento(IdEvento) not null,
	Descricao varchar(200) not null,
	Exibe bit default(0) 
)

-- DML Data manipulation language

-- Inserir dados nas tabelas 

insert into TipoDeUsuarios (TituloTipoUsuario) values ('Administrador');
insert into TipoDeUsuarios (TituloTipoUsuario) values ('Comum');

insert into TiposDeEvento (TituloTipoEvento) values ('SQL Server'); 

insert into Instituição (CNPJ,Endereco,NomeFantasia) values ('95723146084253','Rua Niterói, 180 São Caetano','DevSchool')

insert into Usuario (IdTiposDeUsuario,Nome,Email) values (1,'Mika','Mikael@gmail.com')

insert into Evento (IdTipoDeEvento,IdInstituição,Nome,Descricao,DataEvento,Horario) values (1,1,'Desvendando o SQL','Nesse evento estaremos aprendendo sobre os fundamentos do SQL Server, As aulas serão ministradas por grandes professores da aréa da tecnologia.','09/10/2023','18:00')

insert into PresencaEvento (IdUsuario,IdEvento,Situacao) values (3,3,1)

insert into ComentarioEvento (IdUsuario,IdEvento,Descricao,Exibe) values (3,3,'Palestra otima.',1)

-- DQL Data query language

select * from TipoDeUsuarios
select * from TiposDeEvento
select * from Instituição
select * from Usuario
select * from Evento
select * from PresencaEvento
select * from ComentarioEvento

-- Criar script para consulta exibindo os seguintes dados

/*Usar JOIN

Nome do usuário
Tipo do usuário
Data do evento
Local do evento (Instituição)
Titulo do evento
Nome do evento
Descrição do evento
Situação do evento
Comentário do evento
*/

select 
	Usuario.Nome as UserName,
	TipoDeUsuarios.TituloTipoUsuario as Conta,
	Evento.DataEvento,
	CONCAT (Instituição.NomeFantasia, ' - ', Instituição.Endereco) as Endereço,

	--Instituição.Endereco,

	Evento.Nome as Evento,
	Evento.Descricao as Descrição,
	CASE WHEN PresencaEvento.Situacao = 1 THEN 'Confirmado' ELSE 'Não Comfirmado' END AS [Situação],

	--PresencaEvento.Situacao,

	ComentarioEvento.Descricao as Descrição
from PresencaEvento
inner join Usuario on PresencaEvento.IdUsuario = Usuario.IdUsuario
inner join Evento on PresencaEvento.IdEvento = Evento.IdEvento
inner join Instituição on Evento.IdInstituição = Instituição.IdInstituição
inner join ComentarioEvento on Usuario.IdUsuario = ComentarioEvento.IdUsuario
inner join TipoDeUsuarios on Usuario.IdTiposDeUsuario = TipoDeUsuarios.IdTiposDeUsuario


--CONCAT (Instituição.NomeFantasia, ' - ', Instituição.Endereco) as Endereço

--Instituição.NomeFantasia+ ', ' + Instituicao.Endereco as [Endereço]

--CASE WHEN PresencaEvento.Situacao = 1 THEN 'Confirmado' ELSE 'Não Comfirmado' END,