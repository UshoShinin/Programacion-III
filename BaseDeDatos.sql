CREATE TABLE Cliente(
	RUT varchar(12) primary key,
	FechaIngreso DateTime2,
	Nombre varchar(20)
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
	Precio int not null,
	Entregado varchar(20) check (Entregado in('Si','No'))
);

CREATE TABLE Usuario(
	CI int primary key,
	Pass varchar(6),
	rol varchar(20)
);

CREATE TABLE Gestion(
	descuento int not null,
	añosNecesarios int not null,
	comision int not null,
	fecha DateTime2,
);

INSERT INTO Usuario VALUES(1,1,'admin');
INSERT INTO Cliente VALUES(123456789102,'2011-03-12','Empresa de Pan')
INSERT INTO Producto VALUES(2,'Pansito',11,123456789102);
INSERT INTO Producto VALUES(1,'Pan',11,123456789102);
INSERT INTO Producto VALUES(3,'Pan Duro',13,123456789102),(4,'Pan con canela',15,123456789102),(5,'Pan dulzon',10,123456789102);
insert into Importacion values(4,'1999-05-01','1999-05-02',999999,6,'Si');
insert into Gestion values(6,4,20,GETDATE());
/*SELECT C.RUT FROM Importacion I JOIN Producto P on I.CodProd= P.Cod JOIN Cliente C ON P.RUT = C.RUT group by C.RUT
SELECT I.* FROM Importacion I JOIN Producto P on I.CodProd= P.Cod JOIN Cliente C ON P.RUT = C.RUT where C.RUT ='123456789102' and I.Entregado = 'No'*/
Select * FROM Gestion WHERE Fecha=(SELECT MAX(Fecha) FROM Gestion)

SELECT I.* FROM Importacion I JOIN Producto P on I.CodProd= P.Cod JOIN Cliente C ON P.RUT = C.RUT where C.RUT = '123456789102' AND I.Entregado='No'

