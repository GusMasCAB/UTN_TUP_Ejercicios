/*1. Cree los siguientes SP:
a. Detalle_Ventas: liste la fecha, la factura, el vendedor, el cliente, el 
artículo, cantidad e importe. Este SP recibirá como parámetros de E un 
rango de fechas.*/

go

create procedure Detalle_ventas
@fecha1 datetime,
@fecha2 datetime
as
select Fecha , f.nro_factura Factura, ape_vendedor Vendedor, ape_cliente Cliente
		,descripcion Articulo, cantidad, cantidad*df.pre_unitario Importe
from facturas f
join clientes c on c.cod_cliente=f.cod_cliente
join  vendedores v on v.cod_vendedor=f.cod_vendedor
join detalle_facturas df on df.nro_factura=f.nro_factura
join articulos a on a.cod_articulo=df.cod_articulo
where Fecha between @fecha1 and @fecha2

execute detalle_ventas '2022/03/01','2022/12/31';
go

/* b. CantidadArt_Cli : este SP me debe devolver la cantidad de artículos o 
clientes (según se pida) que existen en la empresa.*/

create procedure CantidadArt_Cli
@tipo varchar(10)
as
begin
if(@tipo='clientes')
	select count(*) Cantidad_Clientes
	from clientes;
else
	select count(*) Cantidad_articulos
	from articulos;
end 

exec CantidadArt_Cli 'CLIENTES';

exec CantidadArt_Cli 'articulos';
go

/* c. INS_Vendedor: Cree un SP que le permita insertar registros en la tabla 
vendedores.*/

create proc INS_Vendedor
@nombre varchar(50), @apellido varchar(50),
@calle varchar(50), @altura int, @cod_barrio int, @tel int,
@mail varchar(50), @nacimiento datetime
as
insert into vendedores(nom_vendedor,ape_vendedor,calle,altura,cod_barrio,nro_tel,[e-mail],fec_nac)
values(@nombre, @apellido, @calle, @altura, @cod_barrio,@tel,@mail,@nacimiento)

exec INS_Vendedor 'Javier', 'Morale', 'Belgrano', 
				2055,3,34175659,'javier2023@gmail.com',
				'1997/02/03';

select * from vendedores

go

/* d. UPD_Vendedor: cree un SP que le permita modificar un vendedor 
cargado.*/

create proc UPD_Vendedor
@cod int, @nombre varchar(50), @apellido varchar(50),
@calle varchar(50), @altura int, @cod_barrio int, @tel int,
@mail varchar(50), @nacimiento datetime
as
update vendedores
set nom_vendedor =@nombre ,ape_vendedor=@apellido
,calle=@calle,altura=@altura,cod_barrio=@cod_barrio
,nro_tel=@tel,[e-mail]=@mail,fec_nac=@nacimiento
where cod_vendedor=@cod;

exec UPD_Vendedor 8,'Martin', 'Masera', 'Belgrano', 
				2055,3,34175659,'marmas@gmail.com',
				'2007/02/28';

go

/* e. DEL_Vendedor: cree un SP que le permita eliminar un vendedor 
ingresado.*/

Create proc DEL_Vendedor
@cod int
as
delete vendedores
where cod_vendedor=@cod

exec DEL_Vendedor 9;
go

/* 2. Modifique el SP 1-a, permitiendo que los resultados del SP puedan filtrarse por 
una fecha determinada, por un rango de fechas y por un rango de vendedores; 
según se pida.*/

alter procedure Detalle_ventas
@fecha_desde datetime = '1500/01/01',
@fecha_hasta datetime = getdate,
@fecha datetime = null,
@vendedor_desde int = null,
@vendedor_hasta int = null
as
select Fecha , f.nro_factura Factura, v.cod_vendedor, ape_vendedor Vendedor, ape_cliente Cliente
		,descripcion Articulo, cantidad, cantidad*df.pre_unitario Importe
from facturas f
join clientes c on c.cod_cliente=f.cod_cliente
join  vendedores v on v.cod_vendedor=f.cod_vendedor
join detalle_facturas df on df.nro_factura=f.nro_factura
join articulos a on a.cod_articulo=df.cod_articulo
where (fecha between @fecha_desde and @fecha_hasta)
or fecha=@fecha
or v.cod_vendedor between @vendedor_desde and  @vendedor_hasta

execute detalle_ventas @fecha_desde='2022/03/01',@fecha_hasta= '2022/12/31',
		@fecha='2021/03/01',@vendedor_desde=1,@vendedor_hasta=3;

/* 3. Ejecute los SP creados en el punto 1 (todos).
4. Elimine los SP creados en el punto 1.*/

drop procedure Detalle_ventas;

/*5. Programar procedimientos almacenados que permitan realizar las siguientes 
tareas:
a. Mostrar los artículos cuyo precio sea mayor o igual que un valor que se 
envía por parámetro.*/

go
create procedure Articulos_precio
	@precio decimal(10,2)
as
select descripcion, stock, pre_unitario, observaciones 
from articulos
where pre_unitario>=@precio;
go

exec Articulos_precio 99.5;

/*b. Ingresar un artículo nuevo, verificando que la cantidad de stock que se 
pasa por parámetro sea un valor mayor a 30 unidades y menor que 100. 
Informar un error caso contrario.*/
go
create proc INS_Articulo
@descripcion varchar(50),
@stock_min int,
@stock int,
@precio decimal(10,2),
@observaciones varchar(50)
as
begin
if(@stock>30 and @stock<100)
	begin
	insert into articulos(descripcion,stock_minimo,stock,pre_unitario,observaciones)
	values(@descripcion,@stock_min, @stock, @precio, @observaciones)

	select 'Articulo ingresado correctamente' Información
	end
else
	select 'Error ingrese una cantidad de stock entre 30 y 100' Información
end

go

exec INS_Articulo 'Galletas de agua',20,60,120,'Media Tarde';

/*c. Mostrar un mensaje informativo acerca de si hay que reponer o no stock 
de un artículo cuyo código sea enviado por parámetro*/

go
create proc Reponer_Stock
	@cod int
as
begin

declare @stock int, @stock_min int;
select @stock=stock, @stock_min = stock_minimo
from articulos
where cod_articulo=@cod;

if(@stock<@stock_min)
	select concat('Hay que reponer el articulo de Codigo:',' ',@cod) Información
else
	select 'No hay que reponer' Información
end
go
exec Reponer_Stock 13;

/*d. Actualizar el precio de los productos que tengan un precio menor a uno 
ingresado por parámetro en un porcentaje que también se envíe por 
parámetro. Si no se modifica ningún elemento informar dicha situación*/

go
create proc UPD_Articulos_precio
	@precio decimal(10,2),
	@porcentaje decimal(6,2)
as
begin
	update articulos
	set pre_unitario = pre_unitario*@porcentaje
	where pre_unitario<@precio;
end
go

exec UPD_Articulos_precio 100,1.1;

/*e. Mostrar el nombre del cliente al que se le realizó la primer venta en un 
parámetro de salida.*/
go
create proc Primer_Venta
	@nombre varchar(50) output
as
	select @nombre = nom_cliente
	from facturas f
	join clientes c on c.cod_cliente=f.cod_cliente
	where fecha = (select min(fecha)
					from facturas)
go

declare @cliente varchar(50);
exec Primer_Venta @cliente output;

select @cliente Cliente;

/*f. Realizar un select que busque el artículo cuyo nombre empiece con un 
valor enviado por parámetro y almacenar su nombre en un parámetro de 
salida. En caso que haya varios artículos ocurrirá una excepción que 
deberá ser manejada con try catch.*/