/*Problema 1.3: Consultas agrupadas: Cláusula HAVING*/
--3. Se quiere saber la fecha de la primera venta, la cantidad total vendida y el 
--importe total vendido por vendedor para los casos en que el promedio de 
--la cantidad vendida sea inferior o igual a 56.
select nom_vendedor+' '+ape_vendedor 'Vendedor', min(fecha) '1er Venta', 
sum(cantidad) 'Cantidad Vendida',
sum(pre_unitario*cantidad) 'Importe total'
from facturas f
join detalle_facturas d on d.nro_factura=f.nro_factura
join vendedores v on v.cod_vendedor=f.cod_vendedor
group by v.cod_vendedor, nom_vendedor+' '+ape_vendedor
having sum(cantidad)/count(distinct d.nro_factura)<=56

--4. Se necesita un listado que informe sobre el monto máximo, mínimo y total 
--que gastó en esta librería cada cliente el año pasado, pero solo donde el 
--importe total gastado por esos clientes esté entre 300 y 800.
select c.cod_cliente, nom_cliente,max(pre_unitario*cantidad) 'Importe maximo',
min(pre_unitario*cantidad) 'Importe minimo',
sum(pre_unitario*cantidad) 'Importe total'
from detalle_facturas d
join facturas f on f.nro_factura=d.nro_factura
join clientes c on c.cod_cliente=f.cod_cliente
where year(fecha)=year(getdate())-1
group by c.cod_cliente, nom_cliente
having sum(pre_unitario*cantidad) between 3000 and 8000

--5. Muestre la cantidad facturas diarias por vendedor; para los casos en que 
--esa cantidad sea 2 o más.
select cod_vendedor, fecha, count(*) 'Cantidad facuras diarias'
from facturas
group by fecha, cod_vendedor
having count(nro_factura)>=2

--6. Desde la administración se solicita un reporte que muestre el precio 
--promedio, el importe total y el promedio del importe vendido por artículo 
--que no comiencen con “c”, que su cantidad total vendida sea 100 o más o 
--que ese importe total vendido sea superior a 700.
select d.cod_articulo, a.descripcion, avg(d.pre_unitario) 'Precio promedio', sum(d.pre_unitario*cantidad) 'Importe total',
avg(d.pre_unitario*cantidad) 'Promedio importe vendido'
from detalle_facturas d
join articulos a on a.cod_articulo=d.cod_articulo
where a.descripcion not like 'c%'
group by d.cod_articulo, a.descripcion
having sum(cantidad)>=100 or sum(d.pre_unitario*cantidad)>700

select *
from detalle_facturas

--7. Muestre en un listado la cantidad total de artículos vendidos, el importe 
--total y la fecha de la primer y última venta por cada cliente, para lo 
--números de factura que no sean los siguientes: 2, 12, 20, 17, 30 y que el 
--promedio de la cantidad vendida oscile entre 2 y 6.
select c.cod_cliente, nom_cliente+' '+ape_cliente Cliente,
sum(cantidad) 'Cantidad articulos vendidos', 
sum(pre_unitario*cantidad) 'Importe total',
min(fecha) '1er venta', max(fecha) 'Ultima venta',
avg(cantidad)
from detalle_facturas d
join facturas f on d.nro_factura=f.nro_factura
join clientes c on c.cod_cliente=f.cod_cliente
where d.nro_factura not in(2,12,20,17,30)
group by c.cod_cliente, nom_cliente+' '+ape_cliente
having avg(cantidad) between 2 and 6

--8. Emitir un listado que muestre la cantidad total de artículos vendidos, el 
--importe total vendido y el promedio del importe vendido por vendedor y 
--por cliente; para los casos en que el importe total vendido esté entre 200 
--y 600 y para códigos de cliente que oscilen entre 1 y 5.
select nom_vendedor+' '+ape_vendedor Vendedor, nom_cliente+' '+ape_cliente Cliente,
sum(cantidad) 'Cantidad articulos', sum(pre_unitario*cantidad) 'Importe total',
sum(pre_unitario*cantidad)/count(distinct f.nro_factura) 'Promedio importe'
from detalle_facturas d
join facturas f on f.nro_factura=d.nro_factura
join clientes c on c.cod_cliente=f.cod_cliente
join vendedores v on v.cod_vendedor=f.cod_vendedor
where c.cod_cliente between 1 and 5
group by v.cod_vendedor,nom_vendedor+' '+ape_vendedor,c.cod_cliente,nom_cliente+' '+ape_cliente
having sum(pre_unitario*cantidad) between 200 and 3000

--9. ¿Cuáles son los vendedores cuyo promedio de facturación el mes pasado 
--supera los $ 800?
select nom_vendedor+' '+ape_vendedor Vendedor,
sum(pre_unitario*cantidad)/count(distinct d.nro_factura) 'Promedio facturacion'
from vendedores v
join facturas f on f.cod_vendedor=v.cod_vendedor
join detalle_facturas d on d.nro_factura=f.nro_factura
where month(fecha)=month(getdate())-1 and year(fecha)=year(getdate())
group by f.cod_vendedor, nom_vendedor+' '+ape_vendedor
having sum(pre_unitario*cantidad)/count(distinct d.nro_factura)>800

--esta sentencia me sirve para verificar
select v.cod_vendedor,nom_vendedor,f.nro_factura, fecha, cod_articulo,pre_unitario, cantidad 
from vendedores v
join facturas f on f.cod_vendedor=v.cod_vendedor
join detalle_facturas d on d.nro_factura=f.nro_factura
where month(fecha)=month(getdate())-1 and year(fecha)=year(getdate())

--10.¿Cuánto le vendió cada vendedor a cada cliente el año pasado siempre 
--que la cantidad de facturas emitidas (por cada vendedor a cada cliente) 
--sea menor a 5?
select nom_vendedor +''+ape_vendedor Vendedor,
nom_cliente+' '+ape_cliente Cliente,
sum(pre_unitario*cantidad) 'Importe Total',
count(distinct d.nro_factura) 'Cantidad Facturas'
from facturas f
join clientes c on c.cod_cliente=f.cod_cliente
join vendedores v on v.cod_vendedor=f.cod_vendedor
join detalle_facturas d on d.nro_factura=f.nro_factura
where year(fecha)=year(getdate())-1
group by f.cod_vendedor, nom_vendedor +''+ape_vendedor,f.cod_cliente,nom_cliente+' '+ape_cliente
having count(distinct d.nro_factura)<5

/*probar los promedios*/
select AVG(pre_unitario*cantidad) 'Promedio por detalle',
sum(pre_unitario*cantidad)/count(distinct d.nro_factura) 'Promedio por factura'
FROM detalle_facturas d, facturas f
WHERE d.nro_factura=f.nro_factura
And year(fecha)=year(getdate())-1