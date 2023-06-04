--CREACION DE UNA BASE DE DATOS
CREATE DATABASE PTDB
GO
--INDICAMOS QUE TRABAJAREMOS SOBRE LA BASE DE DATOS QUE ACABAMOS DE CREAR
USE [PTDB]

--CREACION DE LA TABLA PROVEEDOR
CREATE TABLE proveedor(
	id_proveedor int primary key identity(1, 1),
	descripcionProveedor varchar(100) not null
);

--CREACION DE LA TABLA PRESENTACION E INSERCION DE 4 DATOS
CREATE TABLE presentacion(
	id_presentacion int primary key identity(1, 1),
	descripcionPresentacion varchar(50) not null
);

--INSERSION DE 4 PRESENTACIONES
insert into presentacion(descripcionPresentacion)
select ('Edicion Normal')
union all
select ('Edicion Premium')
union all
select ('Edicion coleccionista')

select * from presentacion


--CREACION DE LA TABLA MARCA E INSERCION DE 3 DATOS
create table marca(
	id_marca int primary key identity(1, 1),
	descripcionMarca varchar(100) not null
);

--INSERSION DE 3 MARCAS
insert into marca(descripcionMarca)
select ('Nike')
union all
select ('Adidas')
union all
select ('Puma')

select * from marca

--CREACION DE LA TABLA ZONA Y SUS INSERCIONES
create table zona(
	id_zona int primary key identity(1, 1),
	descripcionZona varchar(50) not null
);

--INSERCION DE 6 ZONAS
insert into zona(descripcionZona)
select ('Metropolitana')
union all
select ('Central')
union all
select ('Occidental')
union all
select ('Oriental')
union all
select ('Norte')
union all
select ('Sur')

select * from proveedor

--CREACION DE LA TABLA PRODUCTO
create table producto(
	id_producto int primary key identity(1, 1),
	id_marca int,
	id_presentacion int,
	id_proveedor int,
	id_zona int,
	codigo int not null,
	descripcionProducto varchar(1000) not null,
	precio float not null,
	stock int not null,
	iva int not null,
	peso float not null

	--RELACIONES
	constraint relacionMarca foreign key (id_marca) references marca(id_marca),
	constraint relacionProveedor foreign key (id_proveedor) references proveedor(id_proveedor),
	constraint relacionPresentacion foreign key (id_presentacion) references presentacion(id_presentacion),
	constraint relacionZona foreign key (id_zona) references zona(id_zona)
);

insert into producto(id_marca, id_presentacion, id_proveedor, id_zona, codigo, descripcionProducto, precio, stock, iva, peso) values
(1, 1, 1, 1, 12, 'Zapatillas', 249.99, 25, 12, 5.9)