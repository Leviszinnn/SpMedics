CREATE DATABASE SPmedicals
GO

USE SPmedicals
GO


CREATE TABLE TipoUsuario(
	TipoUser_Id tinyint primary key identity (1,1),
	Tipo_Nome TEXT,
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
	Nome_Admin TEXT,
)
GO

CREATE TABLE Clientes(
	Id_Clientes tinyint primary key identity(1,1),
	Usuario_Id tinyint foreign key references Usuario (Usuario_Id),
	Nome_Cliente TEXT,
	data_Nasc TEXT,
	tel_Paciente TEXT,
	RG_Paciente TEXT,
	CPF_Paciente TEXT,
	End_Paciente TEXT,
)
GO

CREATE TABLE Clinica(
	Id_Clinica tinyint primary key identity(1,1),
	Admin_Id tinyint foreign key references Administrador(Admin_Id),
	Endereco_Clinica TEXT,
	Razao_Social TEXT,
	Horario_abrir TEXT,
	Horario_fechar TEXT,
)
GO

CREATE TABLE Especialidade(
	Id_Especialidade tinyint primary key identity (1,1),
	Nome_Especialidade text,
)
GO

CREATE TABLE Medicos(
	Id_Medico tinyint primary key identity(1,1),
	Id_Clinica tinyint foreign key references Clinica (Id_Clinica),
	Id_Especialidade Tinyint foreign key references Especialidade (Id_Especialidade),
	Id_Usuario tinyint foreign key references Usuario (Usuario_Id),
	CRM_Medico TEXT,
	Nome_Medico varchar(30),
)
GO

CREATE TABLE Consulta(
	Id_Consulta tinyint primary key identity (1,1),
	Id_Medico tinyint foreign key references Medicos (Id_Medico),
	Id_Clientes tinyint foreign key references Clientes (Id_Clientes),
	Data_Consulta TEXT,
	desc_Consulta TEXT,
)
GO

