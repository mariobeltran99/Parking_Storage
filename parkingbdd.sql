use master;
go
/*crear base de datos*/
create database parkingbdd;
go
use parkingbdd;


/*a�adir tabla usurios*/
create table Usuarios(
[id] integer identity (1,1) not null,
[nombre] varchar(150) not null,
[username] varchar(150) not null unique,
[password] varchar(150) not null,
[tipo_user] char(1) not null,
[estado] bit not null,
constraint [PK_Usuarios] primary key ([id])
)
go

/*a�adir tabla Carnet_tranajadores*/
create table Carnet_trabajadores(
[id] integer identity (1,1) not null,
[nombre] varchar(150) not null,
[apellido] varchar(150) not null,
[dui] varchar(11) not null unique,
[fecha_registro] date not null,
[fecha_vencimiento] date not null,
[cod_parqueo] varchar(150) not null unique,
[tipo_trabajador] varchar(150) not null,
[estado] bit not null,
[imagen_cod] image not null
constraint [PK_Carnet_trabajadores] primary key([id])
)
go

/*a�adir tabla tipo estacionamiento*/
create table Tipo_estacionamiento(
[id] integer identity (1,1) not null,
[nombre] varchar(150) not null,
[descripcion] varchar(300) not null,
constraint [PK_Tipo_estacionamiento] primary key([id])
)
go

/*a�adir tabla secciones de estacionamiento*/
create table Secciones_estacion(
[id] integer identity (1,1) not null,
[nombre] varchar (150) not null,
[descripcion] varchar (300) not null,
constraint [PK_Secciones_estacion] primary key([id])
)
go

/*a�adir tabla estacionamiento*/
create table Estacion(
[id] integer identity (1,1) not null,
[correlativo] varchar (50) not null,
[id_seccion] integer not null,
[id_tipo_estacion] integer not null,
constraint [PK_estacion] primary key([id]),
constraint [FK_seccion] foreign key ([id_seccion]) references [Secciones_estacion] ([id]),
constraint [FK_tipo_estacion] foreign key ([id_tipo_estacion]) references [Tipo_estacionamiento] ([id])
)
go

/*a�adir ticket*/
create table Ticket(
[id] integer identity (1,1) not null,
[cod_QR] varchar(100) not null unique,
[hora_entrada] time(0) not null,
[hora_salida] time (0) not null,
[id_estacion] integer not null,
[estado] bit not null,
[img_QR] image not null,
constraint [PK_Ticket] primary key([id]),
constraint [FK_estacion] foreign key ([id_estacion]) references [Estacion] ([id])
)
go

/*a�adir tabla ticket_carnet*/
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