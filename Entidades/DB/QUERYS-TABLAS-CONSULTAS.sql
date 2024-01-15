CREATE TABLE Roles(
	IDRol INT IDENTITY (1,1) PRIMARY KEY,
	Rol VARCHAR(25)
);

CREATE TABLE Personas(
	IDPersona INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(100),
	Apellido VARCHAR(100),
	Direccion VARCHAR(50),
	Telefono VARCHAR(30),
	DNI VARCHAR (20),
	FechaNacimiento DATETIME,
	Genero VARCHAR(12)
);

CREATE TABLE Clientes(
	IDCliente INT IDENTITY(1,1) PRIMARY KEY,
	ConTarjeta BIT NOT NULL,
	EfectivoDisponible FLOAT,
	TarjetaVencimiento DATETIME,
	TarjetaEntidadEmisora VARCHAR(40),
	TarjetaTitular VARCHAR(70),
	TarjetaNumTarjeta VARCHAR(20),
	TarjetaCVV VARCHAR(10),
	TarjetaDineroDisponible FLOAT,
	TarjetaEsDebito BIT
);

CREATE TABLE Usuarios(
	IDUsuario INT IDENTITY(1,1) PRIMARY KEY,
	Email VARCHAR(100) NOT NULL,
	Clave VARCHAR(100) NOT NULL
);

CREATE TABLE Empleados(
	IDEmpleado INT IDENTITY(1,1) PRIMARY KEY,
	FechaAlta DATETIME,
	FechaBaja DATETIME
);

CREATE TABLE EmpleadosClientes(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	IDPersona INT NOT NULL,
		FOREIGN KEY (IDPersona) REFERENCES Personas(IDPersona),
	IDCliente INT,
		FOREIGN KEY(IDCliente) REFERENCES Clientes(IDCliente),
	IDEmpleado INT,
		FOREIGN KEY (IDEmpleado) REFERENCES Empleados(IDEmpleado),
	IDUsuario INT NOT NULL,
		FOREIGN KEY(IDUsuario) REFERENCES Usuarios(IDUsuario),
	IDRol INT NOT NULL,
		FOREIGN KEY (IDRol) REFERENCES Roles(IDRol)
);

/****************************************** INSERTS ************************************************************************/

/*Primero se hace un INSERT de una persona para asi conseguir su ID.*/
INSERT INTO Personas (Nombre,Apellido,Direccion,Telefono,DNI,FechaNacimiento,Genero)
VALUES ('Rocio','Bessio','Formosa 244','1109302123','45.013.997','2003-08-13 12:30:00','Femenino');

/*Segundo se da de alta el Usuario, Si es Cliente se dará de alta con todos sus datos, sino se da de alta al Empleado*/
INSERT INTO Usuarios (Email,Clave) 
VALUES ('rocibessio@gmail.com','123Rocio');

INSERT INTO Empleados (FechaAlta,FechaBaja)
VALUES ('2023-12-12 00:00:00',NULL);

/*INSERT DE LA TABLA INTERMEDIA SIN INNER JOIN PARA PROBAR*/
INSERT INTO EmpleadosClientes (IDPersona, IDCliente, IDEmpleado, IDUsuario, IDRol)
VALUES (1, NULL, 1, 1, 2); 

INSERT INTO Roles (Rol) VALUES('Cervecero');

