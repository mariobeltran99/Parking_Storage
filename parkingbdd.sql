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
[fecha] date not null,
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

alter table Ticket
add constraint CK_horas
check (hora_entrada < hora_salida)
go

/*Agregar usuario admin por defecto en el sistema password = 123456*/ 
Insert Into Usuarios (nombre,username,password,tipo_user,estado) Values ('Master','admin','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92','A','1');
Insert Into Usuarios (nombre,username,password,tipo_user,estado) Values ('Carlos','carlitos','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92','A','0');
select * from Usuarios;

/*secciones estacion*/
delete from Secciones_estacion;
insert into Secciones_estacion (nombre,descripcion) values ('EDIFICIO ESTE','ubicado en la primera planta del edificio');
select * from Secciones_estacion;

/*tipos de estacionamiento*/
delete from Tipo_estacionamiento;
insert into Tipo_estacionamiento (nombre,descripcion) values('EMPLEADOS', 'Estacionamiento para los trabajadores');
select * from Tipo_estacionamiento

/*Estacion*/
select * from Estacion;
insert into Estacion (correlativo,id_seccion,id_tipo_estacion,estado) values ('0001P','1','1',1);
insert into Estacion (correlativo,id_seccion,id_tipo_estacion,estado) values ('0002P','1','1',1);
insert into Estacion (correlativo,id_seccion,id_tipo_estacion,estado) values ('0003P','1','1',1);
insert into Estacion (correlativo,id_seccion,id_tipo_estacion,estado) values ('0004P','1','1',1);
select es.id,es.correlativo, sec.nombre as 'Seccion', est.nombre as 'Tipo',es.estado as 'Estado' From Estacion es INNER JOIN Secciones_estacion sec ON es.id_seccion = sec.id INNER JOIN Tipo_estacionamiento est ON es.id_tipo_estacion = est.id