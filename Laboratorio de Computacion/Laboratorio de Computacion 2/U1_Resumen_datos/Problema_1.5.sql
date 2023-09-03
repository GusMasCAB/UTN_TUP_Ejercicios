/*Problema 1.5: Vistas*/
--2. Cree una vista que liste la fecha, la factura, el código y nombre del vendedor, el 
--artículo, la cantidad e importe, para lo que va del año. Rotule como FECHA, 
--NRO_FACTURA, CODIGO_VENDEDOR, NOMBRE_VENDEDOR, ARTICULO, 
--CANTIDAD, IMPORTE.
create view facturacion
as
select fecha FECHA, f.nro_factura NRO_FACTURA, f.cod_vendedor CODIGO_VENDEDOR, 
nom_vendedor NOMBRE, descripcion ARTICULO, cantidad CANTIDAD, d.pre_unitario PRECIO,
sum(d.pre_unitario*cantidad) IMPORTE 
from vendedores v
join facturas f on f.cod_vendedor=v.cod_vendedor
join detalle_facturas d on d.nro_factura=f.nro_factura
join articulos a on a.cod_articulo=d.cod_articulo
where year(fecha)=year(getdate())
group by fecha, f.nro_factura, f.cod_vendedor, 
nom_vendedor, descripcion, cantidad, d.pre_unitario

--3. Modifique la vista creada en el punto anterior, agréguele la condición de que 
--solo tome el mes pasado (mes anterior al actual) y que también muestre la 
--dirección del vendedor.
alter view facturacion
as
select fecha FECHA, f.nro_factura NRO_FACTURA, f.cod_vendedor CODIGO_VENDEDOR, 
nom_vendedor NOMBRE, concat(v.calle,' ',altura) DIRECCION, descripcion ARTICULO, cantidad CANTIDAD, 
d.pre_unitario PRECIO, sum(d.pre_unitario*cantidad) IMPORTE 
from vendedores v
join facturas f on f.cod_vendedor=v.cod_vendedor
join detalle_facturas d on d.nro_factura=f.nro_factura
join articulos a on a.cod_articulo=d.cod_articulo
where month(fecha)=month(getdate())-1 and year(fecha)=year(getdate())
group by fecha, f.nro_factura, f.cod_vendedor, 
nom_vendedor, concat(v.calle,' ',altura), descripcion, cantidad, d.pre_unitario

--4. Consulta las vistas según el siguiente detalle:
--a. Llame a la vista creada en el punto anterior pero filtrando por importes 
--inferiores a $120.
select NRO_FACTURA, NOMBRE, ARTICULO, CANTIDAD, PRECIO ,IMPORTE 
from facturacion
where IMPORTE<120

--b. Llame a la vista creada en el punto anterior filtrando para el vendedor 
--Miranda.
select NRO_FACTURA, NOMBRE, ARTICULO, CANTIDAD, IMPORTE 
from facturacion
where NOMBRE like '%miranda%' 

--c. Llama a la vista creada en el punto 4 filtrando para los importes 
--menores a 10.000.
select NRO_FACTURA, NOMBRE, ARTICULO, CANTIDAD, PRECIO, IMPORTE 
from facturacion
where IMPORTE<10000

--5. Elimine las vistas creadas en el punto 3 
drop view facturacion