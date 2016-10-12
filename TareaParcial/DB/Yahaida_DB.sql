use Parcial1db
go

create table 
SolicitudMateriales(
IdMateriales int primary key identity(1,1) not null,
Materiales varchar(50) null,
Razon varchar(40) null,
)
go

create table 
MaterialesDetalle(
IdMatDetalle int primary key identity(1,1)not null,
IdMateriales int null,
Cantidad varchar(100) null,
)
go

alter table 
MaterialesDetalle
add constraint fk_solicitud_Detalle
foreign key (IdMateriales) references SolicitudMateriales(IdMateriales)
on delete cascade
on update cascade;
go


