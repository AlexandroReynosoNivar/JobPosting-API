create database TareaProg3
use TareaProg3




create table Roles
(
	IDRol int identity Primary Key not null,
	Tipo varchar(20)
)

create table Categoria
(
	IdCategoria int identity Primary Key not null,
	NombreCategoria Varchar(50)
)

create table Vacantes
(
	IdVacante int identity Primary Key not null,
	idcategoria int not null,
	Empresa varchar(50),
	Posicion varchar(10),
	Descripcion varchar(300),
	Horario varchar(10),
	Ubicacion varchar(45),
	CONSTRAINT fk_idcategoria FOREIGN KEY (idcategoria) REFERENCES Categoria (IdCategoria)

)

create Table Usuario
(
	IdUsuario int identity Primary key not null,
	Nombre varchar(50),
	Apellido varchar (50),
	Correo varchar(50),
	idRol int not null,
	Cedula smallint,
	Telefono smallint,
	CONSTRAINT fk_Roles FOREIGN KEY (idRol) REFERENCES Roles (IDRol)


)

create table Solicitud
(
	IdSolicitud int identity Primary Key not null,
	idusuario int not null,
	idvacante int not null,
    CONSTRAINT fk_idusuario FOREIGN KEY (idusuario) REFERENCES Usuario (IdUsuario),
    CONSTRAINT fk_idvacante FOREIGN KEY (idvacante) REFERENCES Vacantes(IdVacante)
)











