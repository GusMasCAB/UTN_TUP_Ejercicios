﻿/*Problema 1.1: Consultas Sumarias*/
--7. Se quiere saber la cantidad de ventas que hizo el vendedor de código 3.
select 'Vendedor cod 3' Vendedor,count(*) 'Cantidad de ventas'
from facturas
where cod_vendedor=3

--8. ¿Cuál fue la fecha de la primera y última venta que se realizó en este 
--negocio?
select min(fecha) '1ra Venta', max(fecha) 'Ultima Venta'
from facturas

--9. Mostrar la siguiente información respecto a la factura nro.: 450: cantidad 
--total de unidades vendidas, la cantidad de artículos diferentes vendidos y 
--el importe total.
select sum(cantidad) 'Cantidad unidades vendidas', 
count(distinct cod_articulo) 'Cantidad de articulos',
sum(pre_unitario*cantidad) 'Importe total'
from detalle_facturas
where nro_factura=450

--10.¿Cuál fue la cantidad total de unidades vendidas, importe total y el importe 
--promedio para vendedores cuyos nombres comienzan con letras que van 
--de la d a la l?
select sum(cantidad) 'Cantidad unidades vendidas', 
sum(pre_unitario*cantidad) 'Importe total',
sum(pre_unitario*cantidad)/(count(distinct d.nro_factura)) 'Importe promedio'
from detalle_facturas d
join facturas f on f.nro_factura=d.nro_factura
join vendedores v on v.cod_vendedor=f.cod_vendedor
where nom_vendedor like '[d-l]%'

--11.Se quiere saber el importe total vendido, el promedio del importe vendido y 
--la cantidad total de artículos vendidos para el cliente Roque Paez.
select sum(pre_unitario*cantidad) 'Importe total',
sum(pre_unitario*cantidad)/(count(distinct d.nro_factura)) 'Importe promedio',
sum(cantidad) 'Cantidad articulos vendidos'
from detalle_facturas d
join facturas f on f.nro_factura=d.nro_factura
join clientes c on c.cod_cliente=f.cod_cliente
where nom_cliente='roque'
and ape_cliente='paez'

--12.Mostrar la fecha de la primera venta, la cantidad total vendida y el importe 
--total vendido para los artículos que empiecen con C.
select min(fecha) '1ra Venta',sum(cantidad) 'Cantidad total',
sum(d.pre_unitario*cantidad) 'Importe total'
from detalle_facturas d
join articulos a on a.cod_articulo=d.cod_articulo
join facturas f on f.nro_factura=d.nro_factura
where a.descripcion like 'c%'

--13.Se quiere saber la cantidad total de artículos vendidos y el importe total 
--vendido para el periodo del 15/06/2011 al 15/06/2017.
select count(distinct cod_articulo) 'Articulos vendidos',
sum(cantidad) 'Unidades vendidas', sum(pre_unitario*cantidad) 'Importe total' 
from detalle_facturas d
join facturas f on f.nro_factura=d.nro_factura 
where fecha between '15/06/2011' and '15/06/2017'

--14.Se quiere saber la cantidad de veces y la última vez que vino el cliente de 
--apellido Abarca y cuánto gastó en total.
select count(distinct d.nro_factura) 'Cantidad de veces',
max(fecha) 'Ultima vez', sum(pre_unitario*cantidad) 'Gasto total'
from detalle_facturas d
join facturas f on f.nro_factura=d.nro_factura
join clientes c on c.cod_cliente=f.cod_cliente
where ape_cliente='abarca'

--15.Mostrar el importe total y el promedio del importe para los clientes cuya 
--dirección de mail es conocida.
select sum(pre_unitario*cantidad) 'Importe total',
sum(pre_unitario*cantidad)/count(distinct d.nro_factura) 'Promedio importe total'
from detalle_facturas d
join facturas f on f.nro_factura=d.nro_factura
join clientes c on c.cod_cliente=f.cod_cliente
where  c.[e-mail] is not null

--16.Obtener la siguiente información: el importe total vendido y el importe 
--promedio vendido para números de factura que no sean los siguientes: 13, 
--5, 17, 33, 24
select sum(pre_unitario*cantidad) 'Importe total',
sum(pre_unitario*cantidad)/count(distinct d.nro_factura) 'Importe promedio'
from detalle_facturas d
join facturas f on f.nro_factura=d.nro_factura
where d.nro_factura not in (13,5,17,33,24)