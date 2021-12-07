Use SPmedicals
GO

-- Seleciona o prontuario de uma pessoa:
Select Nome_Cliente, RG_Paciente, CPF_Paciente, End_Paciente, Data_Nasc, Tel_Paciente FROM Clientes WHERE Id_Clientes = 3
GO

-- Seleciona todos os prontuarios:
SELECT Nome_Cliente, data_Nasc, tel_Paciente, RG_Paciente, CPF_Paciente, End_Paciente FROM Clientes
GO


-- Seleciona todos os tipos de usuários
SELECT * FROM TipoUsuario
GO

-- Seleciona todos os usuários
SELECT * FROM Usuario
GO

-- Seleciona todos os administradores
SELECT * FROM Administrador
GO


-- Seleciona Todas as Consultas
SELECT * FROM Consulta
GO

-- Seleciona as consultas de um paciente especifico
SELECT * FROM Consulta WHERE Id_Clientes = 3
GO

Select* from Clientes
go