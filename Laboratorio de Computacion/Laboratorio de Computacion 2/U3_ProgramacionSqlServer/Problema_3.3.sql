/* Problema 3.3: Funciones definidas por el usuario
6. Cree las siguientes funciones:
a. Hora: una función que les devuelva la hora del sistema en el formato 
HH:MM:SS (tipo carácter de 8).*/
go
create function Hora()
returns varchar(8)
as
begin
	declare @hora varchar(8) = cast(format(getdate(),'HH:mm:ss') as varchar(8));
	return @hora;
end
go

select dbo.Hora() Hora_Sistema;

/* b. Fecha: una función que devuelva la fecha en el formato AAAMMDD (en 
carácter de 8), a partir de una fecha que le ingresa como parámetro 
(ingresa como tipo fecha).*/
go
create function f_fecha(@fecha date)
returns varchar(10)
as
begin
	declare @f varchar(10) = cast(format(@fecha,'yyyy/MM/dd') as varchar(10));
	return @f;
end
go

select dbo.f_fecha('28-10-2023') Fecha;

/* c. Dia_Habil: función que devuelve si un día es o no hábil (considere como 
días no hábiles los sábados y domingos). Debe devolver 1 (hábil), 0 (no 
hábil)*/
go
create function f_Dia_Habil(@fecha date)
returns bit
as
begin
	declare @dia varchar(15) = datename(weekday,@fecha);

	if(@dia in('saturday','sunday'))
		return 0;
	
	return 1;
end
go

select dbo.f_Dia_Habil('29/10/2023') Dia_Habil;
select dbo.f_Dia_Habil('30/10/2023') Dia_Habil;

/* 7. Modifique la f(x) 1.c, considerando solo como día no hábil el domingo.*/
go
alter function f_Dia_Habil(@fecha date)
returns bit
as
begin
	declare @dia varchar(15) = datename(weekday,@fecha);

	if(@dia='sunday')
		return 0;
	
	return 1;
end
go

select dbo.f_Dia_Habil('29/10/2023') Dia_Habil;
select dbo.f_Dia_Habil('28/10/2023') Dia_Habil;

/*8. Ejecute las funciones creadas en el punto 1 (todas). Listo
9. Elimine las funciones creadas en el punto 1.*/
drop function dbo.Hora;
drop function dbo.f_Dia_Habil;

/*10. Programar funciones que permitan realizar las siguientes tareas:
a. Devolver una cadena de caracteres compuesto por los siguientes datos: 
Apellido, Nombre, Telefono, Calle, Altura y Nombre del Barrio, de un 
determinado cliente, que se puede informar por codigo de cliente o 
email.*/
go
create function f_cadena_informacion(@codigo int)
returns varchar(100)
as
begin 
	declare @resultado varchar(100); 
	
	select @resultado=concat(ape_cliente,' ',nom_cliente,' |Telefono: ',nro_tel,' |Direccion: ',calle,' ',altura,', ',barrio)
	from clientes c
	join barrios b on b.cod_barrio=c.cod_barrio
	where cod_cliente = @codigo;

	return @resultado;
end
go

select dbo.f_cadena_informacion(12) Cliente;

/*b. Devolver todos los artículos, se envía un parámetro que permite ordenar 
el resultado por el campo precio de manera ascendente (‘A’), o 
descendente (‘D’).*/
go
create proc pa_articulos 
@orden varchar(1)='A'
as
if @orden='A'
select cod_articulo,descripcion,pre_unitario from articulos
order by pre_unitario
else
select cod_articulo,descripcion,pre_unitario from articulos
order by pre_unitario desc
go

exec pa_articulos'A';

/* c. Crear una función que devuelva el precio al que quedaría un artículo en 
caso de aplicar un porcentaje de aumento pasado por parámetro.*/

go
create function f_precio_articulo(@cod int, @porcentaje decimal(5,2))
returns table

as return(
	select descripcion, pre_unitario * (@porcentaje/100 +1) Precio_actualizado
	from articulos
	where cod_articulo=@cod
)
go

select *
from dbo.f_precio_articulo(12,10)
