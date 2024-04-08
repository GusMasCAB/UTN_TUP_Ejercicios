/*Problema 3.1: Introducci�n a la Programaci�n en SQL Server
Utilizando la base de datos Librer�a realizar las consignas detalladas a 
continuaci�n.
1. Declarar 3 variables que se llamen codigo, stock y stockMinimo 
respectivamente. A la variable codigo setearle un valor. Las variables stock y 
stockMinimo almacenar�n el resultado de las columnas de la tabla art�culos 
stock y stockMinimo respectivamente filtradas por el c�digo que se 
corresponda con la variable codigo.*/
go

declare @codigo int, @stock int , @stockMinimo int;
set @codigo=22;

select @stock=stock, @stockMinimo= stock_minimo
from articulos
where cod_articulo=@codigo;

/* 2. Utilizando el punto anterior, verificar si la variable stock o stockMinimo tienen 
alg�n valor. Mostrar un mensaje indicando si es necesario realizar reposici�n 
de art�culos o no.*/

if(@stock is null or @stockMinimo is null)
	select 'Las variables no tienen valor' Informaci�n
else if (@stock<@stockMinimo)
	select 'Es necesario realizar una reposicion' Informaci�n
else 
	select 'No es necesario realizar una reposcion' Informaci�n

go
/* 3. Modificar el ejercicio 1 agregando una variable m�s donde se almacene el precio 
del art�culo. En caso que el precio sea menor a $500, aplicarle un incremento del 
10%. En caso de que el precio sea mayor a $500 notificar dicha situaci�n y 
mostrar el precio del art�culo.*/

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
	select 'El precio es mayor a $500' Informaci�n, @precio Precio

go

/* 4. Declarar dos variables enteras, y mostrar la suma de todos los n�meros 
comprendidos entre ellos. En caso de ser ambos n�meros iguales mostrar un 
mensaje informando dicha situaci�n*/

create function f_suma_numeros(@num1 int, @num2 int)
returns varchar(20) 
as
begin
declare @resultado int = 0;
if(@num1=@num2)
	return 'N�meros iguales';
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

select dbo.f_suma_numeros(-3,-1) 'Suma de los n�meros';

/* 5. Mostrar nombre y precio de todos los art�culos. Mostrar en una tercer columna 
la leyenda �Muy caro� para precios mayores a $500, �Accesible� para precios 
entre $300 y $500, �Barato� para precios entre $100 y $300 y �Regalado� para 
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
art�culos por una excepci�n.