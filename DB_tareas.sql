CREATE DATABASE[Gtareas]
GO
USE[Gtareas]
GO

--Tabla de las tareas
CREATE TABLE Tareas(
idTarea int primary key identity(1,1),
titulo varchar(100),
estado bit default 1,  --1 es para incompleta y 0 para completada
estadoEli bit default 1  --0 es eliminado
)
Go

