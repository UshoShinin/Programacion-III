CREATE TABLE Cliente(
	RUT varchar(12) primary key,
	FechaIngreso DateTime2
);

CREATE TABLE Producto(
	Cod int primary key,
	Nombre varchar(20) not null,
	Peso int not null,
	RUT varchar(12) foreign key references Cliente(RUT) not null
);

CREATE TABLE Importacion(
	Id int primary key identity(1,1),
	CodProd int not null foreign key references Producto(Cod),
	FechaIngreso DateTime2,
	FechaSalida DateTime2,
	Cantidad int not null,
	Precio int not null
);

CREATE TABLE Usuario(
	CI int primary key,
	Pass varchar(6),
	rol varchar(20)
);

CREATE TABLE Gestion(
	descuento int not null,
	añosNecesarios int not null
);

INSERT INTO Usuario VALUES(1,1,'admin');