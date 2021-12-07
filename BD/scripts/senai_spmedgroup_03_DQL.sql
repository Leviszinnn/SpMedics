Use SPmedicals
GO

-- Seleciona o prontuario de uma pessoa:
Select Nome_Cliente, RG_Paciente, CPF_Paciente, End_Paciente, Data_Nasc, Tel_Paciente FROM Clientes WHERE Id_Clientes = 3
GO

-- Seleciona todos os prontuarios:
SELECT Nome_Cliente, data_Nasc, tel_Paciente, RG_Paciente, CPF_Paciente, End_Paciente FROM Clientes
GO

-- Fun��o para calcular a quantidade de m�dicos de cada especialidade
CREATE FUNCTION CalcMedic (@Id int) RETURNS TABLE AS RETURN
SELECT count (Id_Medico) AS quantMed FROM Medicos WHERE Id_Especialidade = @Id
GO
SELECT * FROM CalcMedic(2)
GO

-- Fun��o para calcular a idade dos pacientes
CREATE PROCEDURE CalcIdade AS Select Id_Clientes, Nome_Cliente, DATEDIFF(YEAR, (data_Nasc), GETDATE()) from Clientes
GO
EXEC CalcIdade

-- Seleciona as consultas de um paciente especifico
SELECT * FROM Consulta WHERE Id_Clientes = 3
GO


-- Seleciona todos os tipos de usu�rios
SELECT * FROM TipoUsuario
GO

-- Seleciona todos os usu�rios
SELECT * FROM Usuario
GO

-- Seleciona todos os administradores
SELECT * FROM Administrador
GO

-- Seleciona todos os clientes 
SELECT * FROM Clientes
GO

-- Seleciona todas as cl�nicas
SELECT * FROM Clinica
GO

-- Seleciona todas as especialidades
SELECT * FROM Especialidade
GO

-- Seleciona todos os m�dicos
SELECT * FROM Medicos
GO

-- Seleciona as situa��es 
SELECT * FROM Situacao
GO

-- Seleciona Todas as Consultas
SELECT * FROM Consulta
GO