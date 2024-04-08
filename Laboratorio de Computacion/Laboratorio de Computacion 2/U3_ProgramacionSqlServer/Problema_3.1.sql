/*Problema 3.1: Introducción a la Programación en SQL Server
Utilizando la base de datos Librería realizar las consignas detalladas a 
continuación.
1. Declarar 3 variables que se llamen codigo, stock y stockMinimo 
respectivamente. A la variable codigo setearle un valor. Las variables stock y 
stockMinimo almacenarán el resultado de las columnas de la tabla artículos 
stock y stockMinimo respectivamente filtradas por el código que se 
corresponda con la variable codigo.*/
go

declare @codigo int, @stock int , @stockMinimo int;
set @codigo=22;

select @stock=stock, @stockMinimo= stock_minimo
from articulos
where cod_articulo=@codigo;

/* 2. Utilizando el punto anterior, verificar si la variable stock o stockMinimo tienen 
algún valor. Mostrar un mensaje indicando si es necesario realizar reposición 
de artículos o no.*/

if(@stock is null or @stockMinimo is null)
	select 'Las variables no tienen valor' Información
else if (@stock<@stockMinimo)
	select 'Es necesario realizar una reposicion' Información
else 
	select 'No es necesario realizar una reposcion' Información

go
/* 3. Modificar el ejercicio 1 agregando una variable más donde se almacene el precio 
del artículo. En caso que el precio sea menor a $500, aplicarle un incremento del 
10%. En caso de que el precio sea mayor a $500 notificar dicha situación y 
mostrar el precio del artículo.*/

declare @codigo int, @stock int , @stockMinimo int, @precio decimal(8,2);
set @codigo=3;

select @stock=stock, @stockMinimo= stock_minimo, @precio=pre_unitario
from articulos
where cod_articulo=@codigo;

if(@precio<=500)
	begin
	set @precio = @precio * 1.1;
	select @codigo Codigo, @stock Stock, @stockMinimo Stock_Minimo, @precio Precio_Actualizado;
	end
else
	select 'El precio es mayor a $500' Información, @precio Precio

go

/* 4. Declarar dos variables enteras, y mostrar la suma de todos los números 
comprendidos entre ellos. En caso de ser ambos números iguales mostrar un 
mensaje informando dicha situación*/

create function f_suma_numeros(@num1 int, @num2 int)
returns varchar(20) 
as
begin
declare @resultado int = 0;
if(@num1=@num2)
	return 'Números iguales';
else
	begin
	while (@num1<=@num2)
		begin
		set @resultado += @num1;
		set @num1 += 1;
		end
	end
	return cast(@resultado as varchar) 
end

go

select dbo.f_suma_numeros(-3,-1) 'Suma de los números';

/* 5. Mostrar nombre y precio de todos los artículos. Mostrar en una tercer columna 
la leyenda ‘Muy caro’ para precios mayores a $500, ‘Accesible’ para precios 
entre $300 y $500, ‘Barato’ para precios entre $100 y $300 y ‘Regalado’ para 
precios menores a $100.*/

select descripcion Articulo, pre_unitario Precio, Leyenda = 
	case 
	when pre_unitario>500 then 'Muy caro'
	when pre_unitario between 300 and 500 then 'Accesible'
	when pre_unitario between 100 and 299 then 'Barato'
	else 'Regalado'
	end
from articulos
order by Precio desc;

/* 6. Modificar el punto 2 reemplazando el mensaje de que es necesario reponer 
artículos por una excepción.