CREATE DATABASE TICKETANDO4
GO

USE TICKETANDO4
GO

-- 1 - TABELA TIPOS 
CREATE TABLE tipos
(
	id        int           not null primary key identity,
	descricao varchar(200)		null
)
GO

-- 2 - TABELA PESSOAS
CREATE TABLE pessoas
(
	id   int          not null primary key identity,
	nome varchar(200) not null
)
GO

-- 3 - TABELA CONFERENTES
CREATE TABLE conferentes
( 
	pessoa_id	int				not null primary key references pessoas,
	assunto		varchar(100)	not null,
	conteudo	varchar(300)	not null
)
GO

-- 4 - TABELA DOS EVENTOS
CREATE TABLE eventos
(
	id			 int			not null	primary key	identity,
	nome		 varchar(200)	not null,
	valor		 decimal(10,2)		null
)
GO

-- 5 - TABELA ATIVIDADES
CREATE TABLE atividades
(
	id			  int			not null primary key identity,
	cargaHoraria  int			not null,
	data		  varchar(20)	not null, -- Alterado o tipo da variável para varchar para poder cadastrar
	horaInicio    varchar(5)	not null,
	horaFinal     varchar(5)	not null, 
	descricao     varchar(max)		null,
	conferente_id int			not null references conferentes,
	tipo_id       int			not null references tipos,
	evento_id     int			not null references eventos
)
GO

-- 6 - TABELA USUÁRIOS
CREATE TABLE usuarios
(
	pessoa_id	int				not null primary key references pessoas,
	rg			varchar(15)		not null unique,
	ra			varchar(20)			null unique,
	curso		varchar (200)		null,
	email		varchar(50)	not null unique,
	login		varchar(20)		not null unique,
	senha		varchar(20)		not null
)
GO

-- 7 - TABELA CHAMADAS
CREATE TABLE chamadas
(
	usuario_id		int not null references usuarios,
	atividade_id	int not null references atividades,
	primary key (usuario_id, atividade_id)
)
GO

-- 8 - TABELA DO STATUS
CREATE TABLE status
(
	id			int				not null	primary key	identity,
	descricao	varchar(100)		null
)
GO

-- 9 - TABELA - LIGAÇÃO EVENTOS E USUÁRIOS
CREATE TABLE eventos_usuarios
(
	evento_id		int				not null	references eventos,
	usuario_id		int				not null	references usuarios,	
	status_id		int				not null	references status,
	certificado	    varchar(3)			null,
	primary key (evento_id, usuario_id)
)	
GO

-- 10 - TABELA DA COMISSÃO
CREATE TABLE comissoes
(
	id				int				not null	primary key	identity,
	senha			varchar(20)		not null,
	login			varchar(100)	not null	unique,
	descricao		varchar(max)		null,
	perfil			varchar(20)		not null	default 'usuario',
	evento_id		int				not	null	references	eventos
)
GO

-- 11 - TABELA - LIGAÇÃO PESSOAS E COMISSÃO
CREATE TABLE pessoas_comissoes
(
	pessoa_id			int	not null	references	pessoas,
	comissoes_id		int	not null	references	comissoes,
	primary key	(pessoa_id,	comissoes_id)
)
GO


----------------------------- INSERT ------------------------------------

-- 1 -TABELA TIPOS
INSERT INTO tipos VALUES ('Palestra')
INSERT INTO tipos VALUES ('Minicurso')
INSERT INTO tipos VALUES ('Mesa Redonda')

-- 2- TABELA PESSOAS
INSERT INTO pessoas VALUES ('Roger')
INSERT INTO pessoas VALUES ('Batman')
INSERT INTO pessoas VALUES ('Beltrano')
INSERT INTO pessoas VALUES ('Isabela')
INSERT INTO pessoas VALUES ('Viviane')
INSERT INTO pessoas VALUES ('Vinicius')
INSERT INTO pessoas VALUES ('Lindinha')
INSERT INTO pessoas VALUES ('Florzinha')
INSERT INTO pessoas VALUES ('Docinho')
INSERT INTO pessoas VALUES ('Sergio')

-- 3- TABELA CONFERENTES 
INSERT INTO conferentes VALUES (1, 'Inteligência Artificial', 'O conferente irá falar sobre Inteligência Artificial')
INSERT INTO conferentes VALUES (2, 'Data Mining', 'O conferente irá falar conceitos de Data Mining')
INSERT INTO conferentes VALUES (3, 'Arduino', 'O conferente irá falar sobre Arduino')


--  4- TABELA EVENTOS
INSERT INTO eventos VALUES ('Inteligência Artificial: O que é?', 30)
INSERT INTO eventos VALUES ('Data Mining nas Empresas', 15)
INSERT INTO eventos VALUES ('Automação Residencial', 40)


-- 5 - TABELA ATIVIDADES
INSERT INTO atividades VALUES (3, '02/03/2018', '14:00', '17:00', null, 1, 1, 1)
INSERT INTO atividades VALUES (5, '19/06/2018', '13:00', '18:00', null, 2, 3, 2)
INSERT INTO atividades VALUES (8, '25/02/2018', '8:00', '16:00', null, 3, 1, 3)


-- 6 - TABELA USUARIOS
INSERT INTO usuarios VALUES ( 4, '1010', '1020', 'ADS', 'isabela@email.com', 'isabela', '123456')
INSERT INTO usuarios VALUES ( 5, '2020', '2030', 'ADS', 'viviane@email.com', 'viviane', '123456')
INSERT INTO usuarios VALUES ( 6, '3030', '3040', 'ADS', 'vinicius@email.com', 'vinicius', '123456')


-- 7 - TABELA CHAMADAS 
INSERT INTO chamadas VALUES (4, 1)
INSERT INTO chamadas VALUES (5, 2)
INSERT INTO chamadas VALUES (6, 3)


-- 8 - TABELA STATUS
INSERT INTO status VALUES ('Pagamento efetuado, compareceu 70%') 
INSERT INTO status VALUES ('Pagamento efetuado, compareceu menos que 70%')
INSERT INTO status VALUES ('Pagamento não efetuado')


-- 9 - TABELA EVENTOS USUARIOS
INSERT INTO eventos_usuarios VALUES (1, 4, 1, null)
INSERT INTO eventos_usuarios VALUES (2, 5, 2, null)
INSERT INTO eventos_usuarios VALUES (3, 6, 3, null)


-- 10 - TABELA COMISSOES
INSERT INTO comissoes VALUES ('!admsudo', 'Administrador', 'Conta do Administrador das Comissões', 'administrador', 1)
INSERT INTO comissoes VALUES ('123456', 'Comissao2', 'Comissão 2', 'usuario', 2)
INSERT INTO comissoes VALUES ('123456', 'Comissao3', 'Comissão 3', 'usuario', 3)


-- 11 - TABELA PESSOAS COMISSÕES 
INSERT INTO pessoas_comissoes VALUES (10, 1)
INSERT INTO pessoas_comissoes VALUES (9, 2)
INSERT INTO pessoas_comissoes VALUES (8, 3)



--------------------------------- SELECT ------------------------------------
SELECT * FROM tipos
SELECT * FROM pessoas
SELECT * FROM conferentes
SELECT * FROM eventos
SELECT * FROM atividades
SELECT * FROM usuarios
SELECT * FROM chamadas
SELECT * FROM status
SELECT * FROM eventos_usuarios
SELECT * FROM comissoes
SELECT * FROM pessoas_comissoes


--------------------------------- PROCEDURE (10) ---------------------------------------

-- ***************************** 1- TIPOS *******************************

--- Procedure de tipos para inserção (insert) ---
CREATE PROCEDURE tipoAdd
(
	@descricao varchar(max)
)
AS
BEGIN
	INSERT INTO tipos VALUES (@descricao)
END

-- teste execução --
EXECUTE tipoAdd 'Seminário' 

--- Procedure de tipos para atualização (update) ---
CREATE PROCEDURE tipoAlt
(
	@id        int,
	@descricao varchar(max)
)
AS
BEGIN
	UPDATE tipos SET 
		   descricao = @descricao
	WHERE  id		 = @id
END

-- teste execução --
EXECUTE tipoAlt 4, 'Seminário Interdisciplinar'


-- ************************* 2 - CONFERENTES ****************************

--- Procedure de conferentes para inserção (insert) ---
CREATE PROCEDURE cadConf
(
	@nome		varchar(200),
	@assunto	varchar(200),
	@conteudo	varchar(max)
)
AS
BEGIN 
	
	INSERT INTO pessoas		VALUES	(@nome)
	INSERT INTO conferentes VALUES  (@@IDENTITY, @assunto, @conteudo)
END

-- teste execução --
EXECUTE cadConf 'Rebecca', 'Desmistificando Ubuntu', 'O conferente irá falar sobre' 

--- Procedure de conferentes para atualização (update) ---
CREATE PROCEDURE altConf
(
	@id			int,
	@nome		varchar(200),
	@assunto	varchar(200),
	@conteudo	varchar(max)
)
AS
BEGIN 
	UPDATE pessoas SET
		   @nome		= @nome
	WHERE  id	= @id

	UPDATE conferentes SET
		   @nome		= @nome,
		   assunto		= @assunto,
		   conteudo		= @conteudo
	WHERE  pessoa_id	= @id
END

-- teste execução --
EXECUTE altConf 11, 'Rebecca', 'Desmistificando Ubuntu', 'O conferente irá falar sobre Ubuntu 16.04.'


-- ******************************* 3 - EVENTOS **********************************

--- Procedure de eventos para inserção (insert) ---
CREATE PROCEDURE eventoAdd
(
	@nome	varchar(200),
	@valor	decimal(10,2)
)
AS 
BEGIN
	INSERT INTO eventos VALUES (@nome, @valor)
END

-- teste de execução --
EXECUTE eventoAdd 'Ubuntu 16.04', 20  

--- Procedure de eventos para atualização (update) ---
CREATE PROCEDURE eventoAlt
(
	@id		int,
	@nome	varchar(200),
	@valor	decimal(10,2)
)
AS
BEGIN
	UPDATE eventos SET
		   nome		= @nome,
		   valor	= @valor
	WHERE  id		= @id
END

-- teste de execução --
EXECUTE eventoAlt 4, 'Ubuntu 16.04 - LTS', 20  


-- *************************** 4 - ATIVIDADES ********************************

--- Procedure de atividades para inserção (insert) ---
CREATE PROCEDURE atividadeAdd
(
	@cargaHoraria  int,
	@data		   varchar(20),
	@horaInicio    varchar(5),
	@horaFinal     varchar(5), 
	@descricao     varchar(max),
	@conferente_id int,
	@tipo_id       int,
	@evento_id     int	
)
AS 
BEGIN
	INSERT INTO atividades VALUES (@cargaHoraria, @data, @horaInicio, @horaFinal,  @descricao, @conferente_id, @tipo_id ,@evento_id)
END

-- teste de execução --
EXECUTE atividadeAdd 3, '11/10/2018', '09:00', '12:00', null, 11, 1, 4  


--- Procedure de atividades para atualização (update) ---
CREATE PROCEDURE atividadeAlt
(
	@id			   int,
	@cargaHoraria  int,
	@data		   varchar(20),
	@horaInicio    varchar(5),
	@horaFinal     varchar(5), 
	@descricao     varchar(max),
	@conferente_id int,
	@tipo_id       int,
	@evento_id     int	
)
AS
BEGIN
	UPDATE atividades SET
		   cargaHoraria		= @cargaHoraria,
		   data				= @data,
		   horaInicio		= @horaInicio,
		   horaFinal		= @horaFinal, 
		   descricao		= @descricao,
		   conferente_id	= @conferente_id,
		   tipo_id			= @tipo_id,
	       evento_id		= @evento_id	
	WHERE  id				= @id
END

-- teste de execução --
EXECUTE atividadeAlt 4, 3, '22/06/2018', '13:00', '18:00', null, 11, 1, 4  



-- ************************************ 5 - USUARIOS **************************************

--- Procedure de usuarios para inserção (insert) ---
CREATE PROCEDURE cadUser
(
	@nome		varchar(200),
	@rg			varchar(15),	
	@ra			varchar(20),		
	@curso		varchar (max),		
	@email		varchar(100),	
	@login		varchar(50),		
	@senha		varchar(20)		
)
AS 
BEGIN 
	INSERT INTO pessoas VALUES (@nome)
	INSERT INTO usuarios VALUES (@@IDENTITY, @rg, @ra, @curso, @email, @login, @senha)
END

-- teste de execução --
EXECUTE cadUser 'Joaninha', '8030', '8040', 'ADS', 'joaninha@email.com', 'joaninha', '123456'

 --- Procedure de usuarios para atualização (update) ---
 CREATE PROCEDURE altUser
(
	@id			int,
	@nome		varchar(200),
	@rg			varchar(15),	
	@ra			varchar(20),		
	@curso		varchar (max),		
	@email		varchar(100),	
	@login		varchar(50),		
	@senha		varchar(20)		
)
AS 
BEGIN 
	UPDATE pessoas SET
		   @nome		= @nome
	WHERE  id	= @id

	UPDATE usuarios SET
		   rg			= @rg,	
		   ra			= @ra,		
		   curso		= @curso,		
		   email		= @email,	
		   login		= @login,		
		   senha		= @senha		
	WHERE  pessoa_id	= @id
END

-- teste de execução --
EXECUTE altUser 12, 'Joaninha', '1030', '1040', 'ADS', 'joaninha@email.com', 'joaninha', '1234'



 -- ***************************** 6 - CHAMADAS *****************************

--- Procedure de chamadas para inserção (insert) ---
CREATE PROCEDURE chamadaAdd
(
	@usuario_id		int,
	@atividade_id	int
)
AS 
BEGIN
	INSERT INTO chamadas VALUES (@usuario_id, @atividade_id)
END

-- teste de execução --
EXECUTE chamadaAdd 12, 4 

--- Procedure de chamadas para atualização (update) ---
--- NÃO EXISTE PROCEDURE PARA ATUALIZAÇÃO DE CHAMADAS, POIS TODAS AS CHAVE ESTRANGEIRAS SÃO PRIMÁRIAS ---


-- ******************************** 7 - STATUS *************************************

--- Procedure de status para inserção (insert) ---
CREATE PROCEDURE statusAdd
(
	@descricao varchar(max)
)
AS
BEGIN
	INSERT INTO status VALUES (@descricao)
END

-- teste execução --
EXECUTE statusAdd 'Pagamento efetuado, compareceu 70%???' 

--- Procedure de status para atualização (update) ---
CREATE PROCEDURE statusAlt
(
	@id int,
	@descricao varchar(max)
)
AS
BEGIN
	UPDATE status SET 
		   descricao = @descricao
	WHERE  id		 = @id
END

-- teste execução --
EXECUTE statusAlt 4, 'Pagamento efetuado, compareceu 70%!!!' 


-- ***************************** 8 - EVENTOS E USUÁRIOS ********************************

--- Procedure de eventos_usuarios para inserção (insert) ---
CREATE PROCEDURE eventoUsuarioAdd
(
	@evento_id		int,
	@usuario_id		int,	
	@status_id		int,
	@certificado	varchar(3)
)
AS
BEGIN
	INSERT INTO eventos_usuarios VALUES (@evento_id, @usuario_id, @status_id, @certificado)
END

-- teste execução --
EXECUTE eventoUsuarioAdd 4, 12, 4, null  


--- Procedure de eventos_usuarios para atualização (update) ---
CREATE PROCEDURE eventoUsuarioAlt
(
	@evento_id		int,
	@usuario_id		int,	
	@status_id		int,
	@certificado	varchar(3)
)
AS
BEGIN
	UPDATE eventos_usuarios SET 	
		   status_id	= @status_id,
		   certificado	= @certificado
	WHERE  evento_id    = @evento_id AND usuario_id   = @usuario_id
END

-- teste execução --
EXECUTE eventoUsuarioAlt 4, 12, 4, 'sim' 


-- ********************************* 9 - COMISSÃO *************************************

--- Procedure de comissoes para inserção (insert) ---
CREATE PROCEDURE comissaoAdd
(
	@senha			varchar(20),
	@login			varchar(100),
	@descricao		varchar(max),
	@perfil			varchar(20),
	@evento_id		int
)
AS
BEGIN
	INSERT INTO comissoes VALUES (@senha, @login, @descricao, @perfil, @evento_id)
END

-- teste execução --
EXECUTE comissaoAdd '123456', 'Comissão3', 'Comissao 3', 'usuario', 4 


--- Procedure de comissoes para atualização (update) ---
CREATE PROCEDURE comissaoAlt
(
	@id				int,
	@senha			varchar(20),
	@login			varchar(100),
	@descricao		varchar(max),
	@perfil			varchar(20),
	@evento_id		int
)
AS
BEGIN
	UPDATE comissoes SET 
		   senha = @senha,
		   login = @login,
		   descricao = @descricao,
		   perfil = @perfil,
		   evento_id = @evento_id	
	WHERE  id		 = @id
END

-- teste execução --
EXECUTE comissaoAlt 4, '123', 'Comissão3', 'Comissao 3', 'usuario', 4


-- ***************************** 10 - PESSOAS COMISSOES ***********************************

--- Procedure de pessoas_comissoes para inserção (insert) ---
CREATE PROCEDURE pessoaComissaoAdd
(
	@pessoa_id			int,
	@comissoes_id		int	
)
AS 
BEGIN
	INSERT INTO pessoas_comissoes VALUES (@pessoa_id, @comissoes_id)
END

-- teste de execução --
EXECUTE pessoaComissaoAdd 7, 4

--- Procedure de pessoas_comissoes para atualização (update) ---
--- NÃO EXISTE PROCEDURE PARA ATUALIZAÇÃO DE PESSOAS_COMISSOE, POIS TODAS AS CHAVE ESTRANGEIRAS SÃO PRIMÁRIAS ---


--------------------------------- VIEW PARA CADA TABELA (COMUM 11) ---------------------------------------

--- 1- TIPOS ---
CREATE VIEW v_tipos
AS
	SELECT *
	FROM tipos t

-- teste execução --
SELECT * FROM v_tipos

--- 2- PESSOAS --- 
CREATE VIEW v_pessoas
AS
	SELECT * 
	FROM pessoas p

-- teste execução --
SELECT * FROM v_pessoas

--- 3- CONFERENTES  ---
CREATE VIEW v_conf
AS 
	SELECT *
	FROM conferentes c 

-- teste execução --
SELECT * FROM v_conf

--- 4- EVENTOS ---
CREATE VIEW v_eventos 
AS
	SELECT *
	FROM eventos e

-- teste execução --
SELECT * FROM v_eventos

--- 5- ATIVIDADES ---
CREATE VIEW v_atividades
AS 
	SELECT *
	FROM atividades a

-- teste execução --
SELECT * FROM v_atividades

--- 6- USUARIOS ---
CREATE VIEW v_user
AS
	SELECT u.pessoa_id, u.login, u.email, u.curso, u.ra, u.rg
	FROM usuarios u

-- teste execução --
SELECT * FROM v_user

--- 7- CHAMADAS ---
CREATE VIEW v_chamadas
AS 
	SELECT *
	FROM chamadas c

-- teste execução --
SELECT * FROM v_chamadas

--- 8- STATUS ---
CREATE VIEW v_status
AS
	SELECT *
	FROM status s

-- teste execução --
SELECT * FROM v_status

--- 9- EVENTOS USUARIOS ---
CREATE VIEW v_eventosUsuarios
AS
	SELECT *
	FROM eventos_usuarios eu

-- teste execução --
SELECT * FROM v_eventosUsuarios

--- 10- COMISSOES ---
CREATE VIEW v_comissoes
AS
	SELECT c.id, c.login, c.descricao, c.evento_id, c.perfil
	FROM comissoes c

-- teste execução --
SELECT * FROM v_comissoes

--- 11- PESSOAS COMISSOES ---
CREATE VIEW v_pessoasComissoes
AS 
	SELECT pc.pessoa_id, pc.comissoes_id
	FROM pessoas_comissoes pc 

-- teste execução --
SELECT * FROM v_pessoasComissoes

---------------------------------- VIEW E JOIN -------------------------------------------

--- 1 - CONFERENTES PESSOAS ---
---PARA ANALIZAR COM MAIS CLAREZA OS CONFERENTES ---

CREATE VIEW v_conferente
AS
	SELECT c.pessoa_id as conferenteId, p.nome as nomeConferente, c.assunto, c.conteudo
	FROM conferentes c, pessoas p 
	WHERE c.pessoa_id = p.id

-- teste execução --
SELECT * FROM v_conferente


--- 2 - ATIVIDADES - CONFERENTE - PESSOAS - EVENTOS - TIPOS ---
--- ANALIZAR COM MAIS CLAREZA OS EVENTOS QUE SERÃO REALIZADOS ---

CREATE VIEW v_nEvento
AS
	SELECT a.id as eventoId, e.nome as nome_evento, a.descricao, c.nomeConferente, c.assunto, c.conteudo, t.descricao as tipoEvento, e.valor, a.data, a.horaInicio, a.horaFinal, a.cargaHoraria
	FROM eventos e, atividades a, v_conferente c, v_tipos t 
	WHERE e.id = a.evento_id AND c.conferenteId = a.conferente_id AND t.id = a.tipo_id 
	
-- teste execução --
SELECT * FROM v_nEvento

--- 3 - USUARIOS - PESSOAS ---
--- ANALIZAR COM MAIS CLAREZA OS USUARIOS ---

CREATE VIEW v_usuario
AS 
	SELECT p.id as usuarioId, p.nome as nomeUsuario,u.senha, u.email, u.login, u.curso, u.rg, u.ra
	FROM usuarios u, pessoas p 
	WHERE u.pessoa_id = p.id

-- teste execução --
SELECT * FROM v_usuario

--- 4 - CHAMADAS - V_USUARIOS - V_NEVENTO ---
--- ANALIZAR COM MAIS CLAREZA AS CHAMADAS QUE SERÃO REALIZADAS ---

CREATE VIEW v_nChamada
AS
	SELECT u.*, e.nome_evento, e.descricao, e.nomeConferente, e.assunto, e.conteudo,  e.tipoEvento, e.valor, e.data, e.horaInicio, e.horaFinal, e.cargaHoraria
	FROM v_usuario u, v_nEvento e, chamadas c
	WHERE c.usuario_id = u.usuarioId AND c.atividade_id = e.eventoId

-- teste execução --
SELECT * FROM v_nChamada


--- 5 - PESSOAS_COMISSOES - PESSOA - COMISSOES ---
--- ANALIZAR COM MAIS CLAREZA AS PESSOAS QUE ESTÃO EM TAL COMISSÃO ---

CREATE VIEW v_pessoaComissao
AS
	SELECT p.id as pessoaId, p.nome as nomeParticipanteComissao, c.id as comissaoId, c.login, c.descricao, c.perfil, e.nome as nomeEvento
	FROM pessoas_comissoes pc, pessoas p, comissoes c, eventos e
	WHERE pc.comissoes_id = c.id AND pc.pessoa_id = p.id AND c.evento_id = e.id

-- teste execução --
SELECT * FROM v_pessoaComissao

--- 6 - EVENTOS_USUARIOS - V_NCHAMADA - STATUS ---
--- VIEW FEITA PARA ANALISAR SE O CERTIFICADO PODERA SER FEITO PARA O PARTICIPANTE ---- 

CREATE VIEW v_certificado
AS
	SELECT c.*, s.id as statusId, s.descricao as statusParticipante
	FROM eventos_usuarios eu, v_nChamada c, status s
	WHERE eu.usuario_id = c.usuarioId AND eu.status_id = s.id

-- teste execução --
SELECT * FROM v_certificado

--- 7 - COMISSÃO - V_NEVENTO --------	
--- VIEW PARA ESPECIFICAR EM QUAL EVENTO TAL COMISSÃO ESTÁ RESPONSÁVEL ---

CREATE VIEW v_comissaoResponsavel
AS
	SELECT c.id as comissaoId, c.login, c.descricao as descricaoComissao, c.perfil, e.*
	FROM comissoes c, v_nEvento e
	WHERE c.evento_id = e.eventoId

-- teste execução --
SELECT * FROM v_comissaoResponsavel

