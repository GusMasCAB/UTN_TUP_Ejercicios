/*Problema 1.4: Combinación de resultados de consultas. UNION*/
--2. Se quiere saber qué vendedores y clientes hay en la empresa; para los casos en 
--que su teléfono y dirección de e-mail sean conocidos. Se deberá visualizar el 
--código, nombre y si se trata de un cliente o de un vendedor. Ordene por la columna 
--tercera y segunda.
select cod_vendedor Codigo,nom_vendedor+' '+ape_vendedor 'Nombre Completo', 
[e-mail] Email,nro_tel Telefono,'Vendedor' Tipo
from vendedores
where ([e-mail] is not null) and (nro_tel is not null)  
union
select cod_cliente,nom_cliente+' '+ape_cliente, [e-mail], nro_tel, 'Cliente'
from clientes
where ([e-mail] is not null) and (nro_tel is not null)

--3. Emitir un listado donde se muestren qué artículos, clientes y vendedores hay en 
--la empresa. Determine los campos a mostrar y su ordenamiento.
select cod_articulo Codigo, descripcion Nombre, 'Articulo' Tipo
from articulos
union
select cod_cliente, nom_cliente+' 'ape_cliente, 'Cliente'  
from clientes
union
select cod_vendedor, nom_vendedor+' '+ape_vendedor, 'Vendedor'
from vendedores
order by 3

--4. Se quiere saber las direcciones (incluido el barrio) tanto de clientes como de 
--vendedores. Para el caso de los vendedores, códigos entre 3 y 12. En ambos casos 
--las direcciones deberán ser conocidas. Rotule como NOMBRE, DIRECCION, 
--BARRIO, INTEGRANTE (en donde indicará si es cliente o vendedor). Ordenado por 
--la primera y la última columna.
select nom_cliente+' '+ape_cliente NOMBRE,concat(calle,' ',altura) DIRECCIÓN, barrio BARRIO, 'Cliente' INTEGRANTE
from clientes c join barrios b on b.cod_barrio=c.cod_barrio
where concat(calle,' ',altura) is not null
union
select nom_vendedor+' '+ape_vendedor,concat(calle,' ',altura), barrio , 'Vendedor'
from vendedores v join barrios b on b.cod_barrio=v.cod_barrio
where concat(calle,' ',altura) is not null 
and cod_vendedor between 3 and 12
order by 1,4

--5. Ídem al ejercicio anterior, sólo que además del código, identifique de donde 
--obtiene la información (de qué tabla se obtienen los datos).
select cod_cliente Codigo, nom_cliente+' '+ape_cliente NOMBRE,concat(calle,' ',altura) DIRECCIÓN, 
barrio BARRIO, 'Cliente' INTEGRANTE, 'Clientes' Tabla
from clientes c join barrios b on b.cod_barrio=c.cod_barrio
where concat(calle,' ',altura) is not null
union
select cod_vendedor, nom_vendedor+' '+ape_vendedor,concat(calle,' ',altura), 
barrio , 'Vendedor', 'Vendedores'
from vendedores v join barrios b on b.cod_barrio=v.cod_barrio
where concat(calle,' ',altura) is not null 
and cod_vendedor between 3 and 12
order by 1,4

--6. Listar todos los artículos que están a la venta cuyo precio unitario oscile entre 10 
--y 50; también se quieren listar los artículos que fueron comprados por los clientes 
--cuyos apellidos comiencen con “M” o con “P”.
select cod_articulo, descripcion Descripción, stock Stock, pre_unitario Precio
from articulos
where (stock!=0) and (pre_unitario between 10 and 150)
union
select  a.cod_articulo, descripcion, stock, a.pre_unitario
from articulos a
join detalle_facturas d on d.cod_articulo=a.cod_articulo
join facturas f on f.nro_factura=d.nro_factura
join clientes c on c.cod_cliente=f.cod_cliente
where ape_cliente like '[m,p]%'

--7. El encargado del negocio quiere saber cuánto fue la facturación del año pasado. 
--Por otro lado, cuánto es la facturación del mes pasado, la de este mes y la de hoy 
--(Cada pedido en una consulta distinta, y puede unirla en una sola tabla de 
--resultado)
select sum(pre_unitario*cantidad) Facturación, 'Año Pasado' Tiempo
from facturas f join detalle_facturas d on d.nro_factura=f.nro_factura
where year(fecha)=year(getdate())-1
union
select sum(pre_unitario*cantidad), 'Mes pasado'
from facturas f join detalle_facturas d on d.nro_factura=f.nro_factura
where month(fecha)=month(getdate())-1 and year(fecha)=year(getdate())
union
select sum(pre_unitario*cantidad), 'Mes actual'
from facturas f join detalle_facturas d on d.nro_factura=f.nro_factura
where month(fecha)=month(getdate()) and year(fecha)=year(getdate())
union
select sum(pre_unitario*cantidad), 'Hoy'
from facturas f join detalle_facturas d on d.nro_factura=f.nro_factura
where convert(date,fecha)=convert(date,getdate())