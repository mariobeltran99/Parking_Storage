
use master;
go
/*crear base de datos*/
create database parkingbdd;
go
use parkingbdd;


/*añadir tabla usurios*/
create table Usuarios(
[id] integer identity (1,1) not null,
[nombre] varchar(150) not null,
[username] varchar(150) not null unique,
[password] varchar(300) not null,
[tipo_user] char(1) not null,
[estado] bit not null,
constraint [PK_Usuarios] primary key ([id])
)
go

/*añadir tabla Carnet_tranajadores*/
create table Carnet_trabajadores(
[id] integer identity (1,1) not null,
[nombre] varchar(150) not null,
[apellido] varchar(150) not null,
[dui] varchar(11) not null unique,
[fecha_registro] varchar(50) not null,
[fecha_vencimiento] varchar(50) not null,
[cod_parqueo] varchar(150) not null unique,
[tipo_trabajador] varchar(150) not null,
[estado] bit not null,
[imagen_cod] image not null
constraint [PK_Carnet_trabajadores] primary key([id])
)
go

/*añadir tabla tipo estacionamiento*/
create table Tipo_estacionamiento(
[id] integer identity (1,1) not null,
[nombre] varchar(150) not null,
[descripcion] varchar(300) not null,
constraint [PK_Tipo_estacionamiento] primary key([id])
)
go

/*añadir tabla secciones de estacionamiento*/
create table Secciones_estacion(
[id] integer identity (1,1) not null,
[nombre] varchar (150) not null,
[descripcion] varchar (300) not null,
constraint [PK_Secciones_estacion] primary key([id])
)
go

/*añadir tabla estacionamiento*/
create table Estacion(
[id] integer identity (1,1) not null,
[correlativo] varchar (50) not null,
[id_seccion] integer not null,
[id_tipo_estacion] integer not null,
[estado] bit not null,
constraint [PK_estacion] primary key([id]),
constraint [FK_seccion] foreign key ([id_seccion]) references [Secciones_estacion] ([id]),
constraint [FK_tipo_estacion] foreign key ([id_tipo_estacion]) references [Tipo_estacionamiento] ([id])
)
go

/*añadir ticket*/
create table Ticket(
[id] integer identity (1,1) not null,
[cod_QR] varchar(100) not null unique,
[fecha] varchar(50) not null,
[hora_entrada] varchar(50) not null,
[hora_salida] varchar(50) null,
[id_estacion] integer not null,
[estado] bit not null,
[img_QR] image not null,
constraint [PK_Ticket] primary key([id]),
constraint [FK_estacion] foreign key ([id_estacion]) references [Estacion] ([id])
)
go

/*añadir tabla ticket_carnet*/
create table Detalle_ticket_trabajador(
[id] integer identity (1,1) not null,
[id_trabajador] integer not null,
[id_ticket] integer not null,
constraint[PK_Detalle_ticket_trabajador] primary key([id]),
constraint [FK_trabajador] foreign key ([id_trabajador]) references [Carnet_trabajadores] ([id]),
constraint [FK_ticket] foreign key ([id_ticket]) references [Ticket] ([id])
)
go

/*Constraints*/

alter table Carnet_trabajadores 
add constraint CK_fechas
check (fecha_registro < fecha_vencimiento)
go
CREATE PROCEDURE carnet
@numer int 
AS
select CONCAT(ct.nombre,' ',ct.apellido) as nombre_completo, ct.dui,ct.fecha_vencimiento,ct.cod_parqueo,ct.tipo_trabajador,ct.imagen_cod from Carnet_trabajadores ct where ct.id = @numer
go

CREATE PROCEDURE tickets
@num int 
AS
select ti.img_QR as Imagen, es.correlativo as Espacio, sec.nombre as Seccion,est.nombre as Tipo from Ticket ti INNER JOIN Estacion es ON es.id = ti.id_estacion INNER JOIN Secciones_estacion sec ON es.id_seccion = sec.id INNER JOIN Tipo_estacionamiento est ON es.id_tipo_estacion = est.id where ti.id = @num
go

/*Agregar usuario admin por defecto en el sistema password = 123456*/ 
Insert Into Usuarios (nombre,username,password,tipo_user,estado) Values ('Master','admin','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92','A','1');
Insert Into Usuarios (nombre,username,password,tipo_user,estado) Values ('Carlos','carlitos','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92','A','0');
--select * from Usuarios;

/*secciones estacion*/
--delete from Secciones_estacion;
insert into Secciones_estacion (nombre,descripcion) values ('PLAZA ESTE','ubicado en la primera planta del edificio');
insert into Secciones_estacion (nombre,descripcion) values ('AVENIDA OESTE','ubicado en la primera planta del edificio');
insert into Secciones_estacion (nombre,descripcion) values ('PABELLÓN CENTRAL','ubicado en la segunda planta del edificio');
--select * from Secciones_estacion;

/*tipos de estacionamiento*/
--delete from Tipo_estacionamiento;
insert into Tipo_estacionamiento (nombre,descripcion) values('CLIENTES', 'Estacionamiento para los clientes o visitantes');
insert into Tipo_estacionamiento (nombre,descripcion) values('ESPECIALES', 'Estacionamiento para personas con condiciones físicas especiales');
insert into Tipo_estacionamiento (nombre,descripcion) values('EMPLEADOS', 'Estacionamiento para los trabajadores');
--select * from Tipo_estacionamiento where not nombre = 'empleados'

/*Estacion*/
--select id from Estacion;
insert into Estacion (correlativo,id_seccion,id_tipo_estacion,estado) values ('0001P','1','1',1);
insert into Estacion (correlativo,id_seccion,id_tipo_estacion,estado) values ('0002P','1','1',1);
insert into Estacion (correlativo,id_seccion,id_tipo_estacion,estado) values ('0003P','1','1',1);
insert into Estacion (correlativo,id_seccion,id_tipo_estacion,estado) values ('0004P','1','1',1);
insert into Estacion (correlativo,id_seccion,id_tipo_estacion,estado) values ('0005P','2','2',1);
insert into Estacion (correlativo,id_seccion,id_tipo_estacion,estado) values ('0006P','2','2',1);
insert into Estacion (correlativo,id_seccion,id_tipo_estacion,estado) values ('0007P','2','2',1);
insert into Estacion (correlativo,id_seccion,id_tipo_estacion,estado) values ('0008P','2','2',1);
insert into Estacion (correlativo,id_seccion,id_tipo_estacion,estado) values ('0009P','3','3',1);
insert into Estacion (correlativo,id_seccion,id_tipo_estacion,estado) values ('0010P','3','3',1);
insert into Estacion (correlativo,id_seccion,id_tipo_estacion,estado) values ('0011P','3','3',1);
insert into Estacion (correlativo,id_seccion,id_tipo_estacion,estado) values ('0012P','3','3',1);
--select es.id,es.correlativo, sec.nombre as 'Seccion', est.nombre as 'Tipo',es.estado as 'Estado' From Estacion es INNER JOIN Secciones_estacion sec ON es.id_seccion = sec.id INNER JOIN Tipo_estacionamiento est ON es.id_tipo_estacion = est.id
--select * from Carnet_trabajadores
/*select CONCAT(nombre,' ',apellido) as nombre_completo, dui,fecha_vencimiento,cod_parqueo,tipo_trabajador,imagen_cod from Carnet_trabajadores ct where id = 1*/
--select COUNT(nombre) as dato from Carnet_trabajadores
--select COUNT(username) as dato from Usuarios
--select COUNT(nombre) as dato from Secciones_estacion
--select COUNT(correlativo) as dato from Estacion
--SELECT TOP (1)  sec.nombre as 'seccion' FROM Estacion es INNER JOIN Secciones_estacion sec ON es.id_seccion = sec.id INNER JOIN Tipo_estacionamiento est ON es.id_tipo_estacion = est.id WHERE est.nombre = 'CLIENTES' AND es.estado = 1
--SELECT TOP (1)  es.correlativo FROM Estacion es INNER JOIN Secciones_estacion sec ON es.id_seccion = sec.id INNER JOIN Tipo_estacionamiento est ON es.id_tipo_estacion = est.id WHERE est.nombre = 'CLIENTES' AND es.estado = 1 AND sec.nombre = 'EDIFICIO OESTE' AND es.id = 6
--select * from Estacion
--select * from Ticket
--select ti.img_QR, es.correlativo, sec.nombre,est.nombre from Ticket ti INNER JOIN Estacion es ON es.id = ti.id_estacion INNER JOIN Secciones_estacion sec ON es.id_seccion = sec.id INNER JOIN Tipo_estacionamiento est ON es.id_tipo_estacion = est.id where ti.id = 1
--select * from Detalle_ticket_trabajador
--select * from Ticket
--SELECT id FROM Carnet_trabajadores WHERE cod_parqueo = 'MBG808466' AND estado = 1
--SELECT COUNT(cod_QR) as dato FROM Ticket
--SELECT ti.cod_QR ,ti.fecha, ti.hora_entrada,ti.hora_salida,ti.estado, est.correlativo, ty.nombre as tipo, sec.nombre as seccion from Ticket ti INNER JOIN Estacion est ON ti.id_estacion = est.id INNER JOIN Tipo_estacionamiento ty ON est.id_tipo_estacion = ty.id INNER JOIN Secciones_estacion sec ON est.id_seccion = sec.id WHERE ti.estado = 1
--SELECT CONCAT(cart.nombre,' ',cart.apellido) as nombrecompleto,cart.cod_parqueo,ti.cod_QR ,ti.fecha, ti.hora_entrada,ti.hora_salida,ti.estado, est.correlativo, ty.nombre as tipo, sec.nombre as seccion from Ticket ti INNER JOIN Estacion est ON ti.id_estacion = est.id INNER JOIN Tipo_estacionamiento ty ON est.id_tipo_estacion = ty.id INNER JOIN Secciones_estacion sec ON est.id_seccion = sec.id INNER JOIN Detalle_ticket_trabajador det ON ti.id = det.id_ticket INNER JOIN Carnet_trabajadores cart ON det.id_trabajador = cart.id WHERE ti.estado = 1
--SELECT ti.cod_QR ,ti.fecha, ti.hora_entrada,ti.hora_salida,ti.estado, est.correlativo, ty.nombre as tipo, sec.nombre as seccion from Ticket ti INNER JOIN Estacion est ON ti.id_estacion = est.id INNER JOIN Tipo_estacionamiento ty ON est.id_tipo_estacion = ty.id INNER JOIN Secciones_estacion sec ON est.id_seccion = sec.id WHERE ty.nombre LIKE '%emple%' OR sec.nombre LIKE '%pabe%' OR ti.fecha like '' OR ti.cod_QR like ''
--select id from Estacion where correlativo = '0012P'
--SELECT  COUNT(ti.cod_QR) as dato from Ticket ti INNER JOIN Estacion est ON ti.id_estacion = est.id INNER JOIN Tipo_estacionamiento ty ON est.id_tipo_estacion = ty.id INNER JOIN Secciones_estacion sec ON est.id_seccion = sec.id INNER JOIN Detalle_ticket_trabajador det ON ti.id = det.id_ticket INNER JOIN Carnet_trabajadores cart ON det.id_trabajador = cart.id WHERE ti.estado = 1 AND cart.cod_parqueo = 'MBG823835'
--select * from Usuarios
--SELECT COUNT(ti.cod_QR) as dato from Ticket ti INNER JOIN Estacion est ON ti.id_estacion = est.id INNER JOIN Tipo_estacionamiento ty ON est.id_tipo_estacion = ty.id INNER JOIN Secciones_estacion sec ON est.id_seccion = sec.id INNER JOIN Detalle_ticket_trabajador det ON ti.id = det.id_ticket INNER JOIN Carnet_trabajadores cart ON det.id_trabajador = cart.id WHERE ti.estado = 1 AND cart.cod_parqueo = 'DNE974394'
--SELECT COUNT(cod_QR) as dato from Ticket WHERE cod_QR = 'EP61765649' AND estado = 0

--select * from Ticket
--SELECT id_estacion FROM Ticket WHERE cod_QR = 'EP43407498' AND estado = 1
--UPDATE Ticket SET hora_salida = '02:01:32', estado = 0 WHERE id = 5
--SELECT CONCAT(cart.nombre,' ',cart.apellido) as nombrecompleto,cart.cod_parqueo,ti.cod_QR ,ti.fecha, ti.hora_entrada,ti.hora_salida,ti.estado, est.correlativo, ty.nombre as tipo, sec.nombre as seccion from Ticket ti INNER JOIN Estacion est ON ti.id_estacion = est.id INNER JOIN Tipo_estacionamiento ty ON est.id_tipo_estacion = ty.id INNER JOIN Secciones_estacion sec ON est.id_seccion = sec.id INNER JOIN Detalle_ticket_trabajador det ON ti.id = det.id_ticket INNER JOIN Carnet_trabajadores cart ON det.id_trabajador = cart.id WHERE ti.estado = 0 AND ti.cod_QR LIKE '' OR ti.fecha LIKE '17/03/2020' OR cart.cod_parqueo LIKE ''

--SELECT COUNT(correlativo) as dato FROM Estacion WHERE estado = 1
--select * from Estacion where estado = 1