/*Problema 1.2: Consultas agrupadas: Cláusula GROUP BY*/
--2. Por cada factura emitida mostrar la cantidad total de artículos vendidos 
--(suma de las cantidades vendidas), la cantidad ítems que tiene cada factura
--en el detalle (cantidad de registros de detalles) y el Importe total de la 
--facturación de este año.
select d.nro_factura Factura, sum(cantidad) 'Unidades', 
count(distinct cod_articulo) 'Cantidad articulos', sum(pre_unitario*cantidad) 'Importe total'
from detalle_facturas d
join facturas f on f.nro_factura=d.nro_factura
where year(fecha)=year(getdate())
group by d.nro_factura

--3. Se quiere saber en este negocio, cuánto se factura:
--a. Diariamente
SELECT fecha, sum(pre_unitario*cantidad) 'Facturacion por dia'
FROM facturas f
JOIN detalle_facturas d ON d.nro_factura = f.nro_factura
GROUP BY fecha

--b. Mensualmente 
SELECT month(fecha) Mes, year(fecha) Año, sum(pre_unitario*cantidad) 'Facturacion por mes'
FROM facturas f
JOIN detalle_facturas d ON d.nro_factura = f.nro_factura
GROUP BY year(fecha), month(fecha)
order by 2, 1

--c. Anualmente 
SELECT  year(fecha) Año, sum(pre_unitario*cantidad) 'Facturacion por año'
FROM facturas f
JOIN detalle_facturas d ON d.nro_factura = f.nro_factura
GROUP BY year(fecha)
order by 1

--4. Emitir un listado de la cantidad de facturas confeccionadas diariamente, 
--correspondiente a los meses que no sean enero, julio ni diciembre. Ordene 
--por la cantidad de facturas en forma descendente y fecha.
select fecha, count(*) 'Cantidad facturas'
from facturas
where month(fecha) not in(1,7,12)
group by fecha
order by 2 desc

--5. Se quiere saber la cantidad y el importe promedio vendido por fecha y 
--cliente, para códigos de vendedor superiores a 2. Ordene por fecha y 
--cliente.
select sum(cantidad) 'Unidades vendidas',
	   sum(pre_unitario*cantidad)/count(distinct d.nro_factura) 'Promedio importe total', fecha,
	   nom_cliente+' '+ ape_cliente 'Cliente'
from detalle_facturas d
join facturas f on f.nro_factura=d.nro_factura
join clientes c on c.cod_cliente=f.cod_cliente
join vendedores v on v.cod_vendedor=f.cod_vendedor
where v.cod_vendedor>2
group by fecha,f.cod_cliente ,nom_cliente+' '+ ape_cliente 
order by fecha, 'Cliente'

--6. Se quiere saber el importe promedio vendido y la cantidad total vendida por 
--fecha y artículo, para códigos de cliente inferior a 3. Ordene por fecha y 
--artículo.
select sum(cantidad) 'Unidades vendidas',
	   sum(d.pre_unitario*cantidad)/count(distinct d.nro_factura) 'Promedio vendido', fecha,
	   descripcion
from detalle_facturas d
join facturas f on f.nro_factura=d.nro_factura
join clientes c on c.cod_cliente=f.cod_cliente
join articulos a on a.cod_articulo=d.cod_articulo
where c.cod_cliente<3
group by fecha,a.cod_articulo, descripcion
order by fecha, descripcion

--7. Listar la cantidad total vendida, el importe total vendido y el importe 
--promedio total vendido por número de factura, siempre que la fecha no 
--oscile entre el 13/2/2007 y el 13/7/2010.
select d.nro_factura, sum(cantidad) 'Cantidad total vendida',sum(d.pre_unitario*cantidad) 'Importe total',
	   sum(d.pre_unitario*cantidad)/count(distinct d.nro_factura) 'Promedio vendido'
from detalle_facturas d
join facturas f on f.nro_factura=d.nro_factura
where fecha between '13/2/2007' and '13/7/2010'
group by d.nro_factura

--8. Emitir un reporte que muestre la fecha de la primer y última venta y el 
--importe comprado por cliente. Rotule como CLIENTE, PRIMER VENTA, 
--ÚLTIMA VENTA, IMPORTE.
select nom_cliente+' '+ape_cliente Cliente, min(fecha) 'Primer Venta',
max(fecha) 'Ultima Venta', sum(pre_unitario*cantidad) 'Importe'
from detalle_facturas d 
join facturas f on f.nro_factura=d.nro_factura
join clientes c on c.cod_cliente=f.cod_cliente
group by f.cod_cliente, nom_cliente+' '+ape_cliente

--9. Se quiere saber el importe total vendido, la cantidad total vendida y el precio 
--unitario promedio por cliente y artículo, siempre que el nombre del cliente 
--comience con letras que van de la a a la m. Ordene por cliente, precio 
--unitario promedio en forma descendente y artículo. Rotule como IMPORTE 
--TOTAL, CANTIDAD TOTAL, PRECIO PROMEDIO.
select nom_cliente Cliente,cod_articulo, sum(pre_unitario*cantidad) 'Importe total',
sum(cantidad) 'Cantidad total', avg(pre_unitario) 'Precio promedio'
from detalle_facturas d 
join facturas f on f.nro_factura=d.nro_factura
join clientes c on c.cod_cliente=f.cod_cliente
where nom_cliente like '[a-m]%'
group by c.cod_cliente, nom_cliente, cod_articulo
order by Cliente, 'Precio promedio' desc, cod_articulo

--10.Se quiere saber la cantidad de facturas y la fecha la primer y última factura 
--por vendedor y cliente, para números de factura que oscilan entre 5 y 30. 
--Ordene por vendedor, cantidad de ventas en forma descendente y cliente.
select nom_vendedor+' '+ape_vendedor Vendedor, nom_cliente Cliente, count(nro_factura) 'Cantidad facturas',
min(fecha) 'Primera factura', max(fecha) 'Ultima factura'
from facturas f
join vendedores v on v.cod_vendedor=f.cod_vendedor
join clientes c on c.cod_cliente=f.cod_cliente
where nro_factura between 5 and 30
group by v.cod_vendedor, nom_vendedor+' '+ape_vendedor, c.cod_cliente, nom_cliente
order by Vendedor desc, 'Cantidad facturas' desc, Cliente