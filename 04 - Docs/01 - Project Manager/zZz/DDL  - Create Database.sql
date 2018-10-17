-------------------------------------------------------------------------------------
-- Trabalho Prático de Avaliação da UFCD 5411 – Base de Dados – Sistemas de Gestão --
-- Módulo User_Profile															   --
-- Bruno Ferreira 17/10/2018													   --
-------------------------------------------------------------------------------------


-- criação da base de dados
create database TrabalhoSQL
go

-- preset databse
use TrabalhoSQL
go

-- criação da tabela user
create table [user]
(
	userId					int					identity(1,1),
	firstName				varchar(30)			not null,
	lastName				varchar(30)			not null,
	email					varchar(60)			not null,
	username				varchar(15)			not null,
	password				varchar(15)			not null,
	active					bit					not null,
	profileImg				varchar(128)		not null,
	createdBy				varchar(15)			not null,
	createdOn				datetime			not null,

	constraint pk_user primary key(userId)
)
-- criação da tabela permission
create table permission
(
	permissionId			int					identity(1,1),
	name					varchar(60)			not null,
	description				varchar(200)		null,
	createdBy				varchar(15)			not null,
	createdOn				datetime			not null,

	constraint pk_permission primary key(permissionId)
)
-- criação da tabela role
create table role
(
	roleId					int					identity(1,1),
	name					varchar(60)			not null,
	description				varchar(200)		null,
	createdBy				varchar(15)			not null,
	createdOn				datetime			not null,

	constraint pk_role primary key(roleId)
)
go
-- criação da tabela user_session
create table userSession
(
	userSessionId			int					identity(1,1),
	userId					int					not null,
	logOnUser				datetime			not null,
	logOffUser				datetime			not null,
	ipAddress				varchar(15)			not null,
	userAgent				varchar(50)			not null,
	createdBy				varchar(15)			not null,
	createdOn				datetime			not null,
		
	constraint pk_userSession primary key(userSessionId),
	constraint fk_userSession_user foreign key(userId) references [user](userId) on delete cascade
)
-- criação da tabela permissionAssignment
create table permissionAssignament
(
	permissionId			int					identity(1,1),
	roleId					int					not null,
	userId					int					not null,
	createdBy				varchar(15)			not null,
	createdOn				datetime			not null,
			
	constraint pk_permissionAssignament primary key(permissionId),
	constraint fk_permissionAssignament_role foreign key(roleId) references role(roleId) on delete cascade,
	constraint fk_permissionAssignament_user foreign key(userId) references [user](userId) on delete cascade
)
-- criação da tabela logs
create table log
(
	logId					int					identity(1,1),
	tableName				varchar(25)			not null,
	actionType				varchar(20)			not null,
	contents				varchar(max)		not null,
	userId					int					not null,
	createdOn				datetime			not null,

	constraint pk_logUser primary key(logId),
	constraint fk_logUser_user foreign key(userId) references [user](userId) on delete cascade
)