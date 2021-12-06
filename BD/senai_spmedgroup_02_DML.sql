USE SPmedicals
GO


INSERT INTO TipoUsuario(Tipo_Nome)
VALUES ('Admin'), ('Cliente'), ('Médico')
GO

INSERT INTO Usuario(TipoUser_Id, Email, Senha)
VALUES  (1, 'Admin@Admin.com', 'Admin'), (3, 'ricardo.lemos@spmedicalgroup.com.br', 'ricardo'), (3, 'roberto.possarle@spmedicalgroup.com.br', 'possarle'), (3, 'helena.souza@spmedicalgroup.com.br', 'helena'), (2,'ligia@gmail.com','ligia'), (2,'alexandre@gmail.com','alexandre'), (2,'fernando@gmail.com','fernando'), (2,'henrique@gmail.com','henrique'), (2,'joao@hotmail.com','joao'), (2,'bruno@gmail.com','bruno'), (2,'mariana@outlook.com','mariana')
GO

INSERT INTO Administrador(Usuario_Id, Nome_Admin)
VALUES (1, 'Claudio')
GO

INSERT INTO Clientes(Usuario_Id, Nome_Cliente, data_Nasc, tel_Paciente, RG_Paciente, CPF_Paciente, End_Paciente)
VALUES (5, 'Ligia', '10/13/1983', '11 3456-7654', '43522543-5', '94839859000', 'Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000'), (6, 'Alexandre', '7/23/2001', '11 98765-6543', '32654345-7', '73556944057', 'Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200'), (7, 'Fernando', '10/10/1978', '11 97208-4453', '54636525-3', '16839338002', 'Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200'), (8, 'Henrique', '10/13/1985', '11 3456-6543', '54366362-5', '14332654765', 'R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030'), (9, 'João', '8/27/1975', '11 7656-6377', '53254444-1', '91305348010', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380'), (10, 'Bruno', '3/21/1972','11 95436-8769','54566266-7','79799299004','Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001' ), (11, 'Mariana','3/5/2018','','54566266-8','13771913039','R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140' )
GO

INSERT INTO Clinica (Admin_Id, Endereco_Clinica, Razao_Social, Horario_abrir, Horario_fechar)
VALUES (1, 'Av. Barão Limeira, 532, São Paulo, SP', 'SP Medical Group', '10:30', '10:30')
GO

INSERT INTO Especialidade(Nome_Especialidade)
VALUES ('Acupuntura'), ('Anestesiologia'), ('Angiologia'), ('Cardiologia'), ('Cirurgia Cardiovascular'), ('Cirurgia de Mão'), ('Cirurgia do Aparelho Digestivo'), ('Cirurgia Geral'), ('Cirurgia Pediatrica'), ('Cirurgia Plastica'), ('Cirurgia Torácica'), ('Cirurgia Vascular'), ('Dermatologia'), ('Radioterapia'), ('Urologia'), ('Pediatria'), ('Psiquiatria')
GO

INSERT INTO Medicos(Id_Clinica, Id_Especialidade, Id_Usuario, CRM_Medico, Nome_Medico)
VALUES (1,2,2, '54356-SP', 'Ricardo Lemos'), (1,17,3, '53452-SP', 'Roberto Possarle'), (1,16,4, '65463-SP', 'Helena Strada')
GO

INSERT INTO Consulta(Id_Medico, Id_Clientes, Data_Consulta, desc_Consulta)
VALUES (3, 7, '20/01/20',  'Dor na barriga' ), (2, 2, '06/01/20', 'Sonhos estranhos'), (2, 3, '07/02/2020', 'Vê vultos'), (2, 2, '06/02/2018', 'Medo de escuro'), (2, 4, '07/02/2019', 'Depressão'), (3, 7, '08/03/2020', 'Consulta rotineira'), (1, 4, '09/03/2020', 'Dor na Coluna')
GO
