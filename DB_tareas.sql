CREATE DATABASE[Gtareas]
GO
USE[Gtareas]
GO

--Tabla de las tareas
CREATE TABLE Tareas(
idTarea int primary key identity(1,1),
titulo varchar (100) not null,
estado_no_Completado bit default 1,  --1 es para incompleta y 0 para completada
estadoEli bit default 1  --0 es eliminado
)
Go

CREATE TABLE Administrador(
id int primary key identity(1,1),
nombre varchar (100) not null,
correo varchar(100) not null,
Pwd varchar(100) not null,
AdminTipo varchar(50) not null
)
Go




insert into Tareas(titulo)
values
('Hacer la prueba'),
('Comprobar la prueba'),
('Revisar nuevamente la prueba'),
('enviar la prueba')
select * from Tareas

insert into Administrador (nombre,correo,Pwd,AdminTipo)
values
('josue','josue@gmail.com','1234','Super'),
('jeft','jef@gmail.com','1234','Viewer')
select * from Administrador