Create table ordenes_retiro(
	id_orden int identity(1,1),
	fecha date,
	responsable varchar(25)
	constraint pk_ordenes primary key(id_orden)
)

Create table materiales(
	codigo int identity(1,1),
	nombre varchar(50),
	stock int
	constraint pk_materiales primary key(codigo)
)

create table detalles_orden(
	id_detalle_orden int identity(1,1),
	id_orden int,
	id_material int,
	cantidad int
	constraint pk_detalles_orden primary key(id_detalle_orden),
	constraint fk_detalles_ordenes foreign key(id_orden)
					references ordenes_retiro(id_orden),
	constraint fk_detalles_materiales foreign key(id_material)
					references materiales(codigo)
)

-- Insertar un material con nombre y stock específicos
INSERT INTO materiales (nombre, stock)
VALUES ('Material 1', 100);

INSERT INTO materiales (nombre, stock)
VALUES ('Material 2', 50);

INSERT INTO materiales (nombre, stock)
VALUES ('Material 3', 75);

INSERT INTO materiales (nombre, stock)
VALUES ('Material 4', 120);

INSERT INTO materiales (nombre, stock)
VALUES ('Material 5', 90);

INSERT INTO materiales (nombre, stock)
VALUES ('Material 6', 200);

INSERT INTO materiales (nombre, stock)
VALUES ('Material 7', 60);

INSERT INTO materiales (nombre, stock)
VALUES ('Material 8', 150);

INSERT INTO materiales (nombre, stock)
VALUES ('Material 9', 80);

INSERT INTO materiales (nombre, stock)
VALUES ('Material 10', 110);

INSERT INTO materiales (nombre, stock)
VALUES ('Material 11', 70);

INSERT INTO materiales (nombre, stock)
VALUES ('Material 12', 130);

INSERT INTO materiales (nombre, stock)
VALUES ('Material 13', 95);

INSERT INTO materiales (nombre, stock)
VALUES ('Material 14', 40);

INSERT INTO materiales (nombre, stock)
VALUES ('Material 15', 85);

INSERT INTO materiales (nombre, stock)
VALUES ('Material 16', 105);

INSERT INTO materiales (nombre, stock)
VALUES ('Material 17', 55);

INSERT INTO materiales (nombre, stock)
VALUES ('Material 18', 170);

INSERT INTO materiales (nombre, stock)
VALUES ('Material 19', 75);

INSERT INTO materiales (nombre, stock)
VALUES ('Material 20', 125);

create procedure sp_consultar_materiales
as
begin 
	SELECT *
    FROM materiales
end

create procedure sp_insertar_ordenesPedidos
	@IdOrden int output,
	@fecha date,
	@responsable varchar(25)
as
begin 
	insert into ordenes_retiro(fecha,responsable) values(@fecha,@responsable);
	set @IdOrden=SCOPE_IDENTITY();
end

create procedure sp_insertar_detalles
	@IdOrden int,
	@IdMaterial int,
	@cantidad int
as
begin 
	insert into detalles_orden(id_orden,id_material,cantidad) values(@IdOrden,@IdMaterial,@cantidad);
end

SELECT * FROM detalles_orden
SELECT * FROM ordenes_retiro