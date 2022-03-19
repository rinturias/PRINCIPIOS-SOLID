create database  BDlogin
go
use BDlogin

create table usuarios(
codUsuario int not null identity primary key,
usuario varchar(100) not null,
clave varchar(1000) not null,
activo int default 0,
);

select * from usuarios