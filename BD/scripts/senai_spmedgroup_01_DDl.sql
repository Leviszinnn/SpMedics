CREATE DATABASE SPmedicals
GO

DROP database SPmedicals
GO

USE SPmedicals
GO


CREATE TABLE TipoUsuario(
	TipoUser_Id tinyint primary key identity (1,1),
	Tipo_Nome Varchar(30),
)
GO

CREATE TABLE Usuario(
	Usuario_Id tinyint primary key identity (1,1),
	TipoUser_Id tinyint foreign key references TipoUsuario (TipoUser_Id),
	Email Varchar(100),
	Senha Varchar(30),
)
GO

CREATE TABLE Administrador (
	Admin_Id tinyint primary key identity (1,1),
	Usuario_Id tinyint foreign key references Usuario (Usuario_Id),
	Nome_Admin varchar(30),
)
GO

CREATE TABLE Clientes(
	Id_Clientes tinyint primary key identity(1,1),
	Usuario_Id tinyint foreign key references Usuario (Usuario_Id),
	Nome_Cliente varchar(30),
	data_Nasc date,
	tel_Paciente varchar(30),
	RG_Paciente varchar(50),
	CPF_Paciente varchar(50),
	End_Paciente varchar(200),
)
GO

CREATE TABLE Clinica(
	Id_Clinica tinyint primary key identity(1,1),
	Admin_Id tinyint foreign key references Administrador(Admin_Id),
	Endereco_Clinica varchar(50),
	Razao_Social varchar(30),
	Horario_abrir time(7),
	Horario_fechar time(7),
)
GO

CREATE TABLE Especialidade(
	Id_Especialidade tinyint primary key identity (1,1),
	Nome_Especialidade varchar(50),
)
GO

CREATE TABLE Medicos(
	Id_Medico tinyint primary key identity(1,1),
	Id_Clinica tinyint foreign key references Clinica (Id_Clinica),
	Id_Especialidade Tinyint foreign key references Especialidade (Id_Especialidade),
	Id_Usuario tinyint foreign key references Usuario (Usuario_Id),
	CRM_Medico varchar(50),
	Nome_Medico varchar(30),
)
GO


CREATE TABLE Situacao(
	Id_Situacao tinyint primary key identity (1,1),
	descricao text,
)
GO

CREATE TABLE Consulta(
	Id_Consulta tinyint primary key identity (1,1),
	Id_Medico tinyint foreign key references Medicos (Id_Medico),
	Id_Clientes tinyint foreign key references Clientes (Id_Clientes),
	Data_Consulta date,
	desc_Consulta TEXT,
	Id_Situacao tinyint foreign key references Situacao (Id_Situacao)
)
GO

