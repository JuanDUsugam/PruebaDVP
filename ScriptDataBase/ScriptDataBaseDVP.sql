CREATE DATABASE PruebaDVPDB
GO


USE PruebaDVPDB
GO


CREATE TABLE Usuarios
(
	Identificador varchar(36) PRIMARY KEY NOT NULL,
	NombreUsuario varchar(30),
	Pass varchar(8),
	FechaCreacion date
);
GO


CREATE TABLE Personas
(
	Identificador VARCHAR(36) NOT NULL PRIMARY KEY,
	Nombres varchar(25),
	Apellidos varchar(40),
	NumeroIdentificacion int,
	Email varchar(30),
	TipoIdentificacion varchar(15),
	FechaCreacion date,
	IdentificacionTipoIde as (CONVERT(nvarchar(100), NumeroIdentificacion) + ' ' + TipoIdentificacion),
	NombreCompleto as (Nombres + ' ' + Apellidos),
	UsuarioId varchar(36) FOREIGN KEY REFERENCES Usuarios(Identificador)
);
GO


CREATE PROCEDURE BuscarPersonasCreadas AS
SELECT * FROM Personas AS p INNER JOIN Usuarios AS u 
	ON p.UsuarioId = u.Identificador






