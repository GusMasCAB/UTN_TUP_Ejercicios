CREATE DATABASE Liga_Cordobesa
GO
USE Liga_Cordobesa
GO

create table equipos(
id_equipo int identity(1,1),
nombre varchar(50) not null,
tecnico varchar(50)
constraint pk_equipos primary key(id_equipo)
)

create table partidos(
id_partido int identity(1,1),
localidad int,
visitante int,
fecha date,
pendiente bit
constraint pk_partidos primary key(id_partido),
constraint fk_localidad foreign key(localidad)
		references equipos(id_equipo),
constraint fk_visitante foreign key(visitante)
		references equipos(id_equipo)
)

create table personas(
id_persona int identity(1,1),
apellido varchar(50) not null,
nombre varchar(50),
dni varchar(20) not null,
fecha_nac date
constraint pk_personas primary key(id_persona)
)

create table posiciones(
id_posicion int identity(1,1),
posicion varchar(20) not null
constraint pk_posiciones primary key(id_posicion)
)

create table jugadores(
id_jugador int identity(1,1),
id_equipo int,
id_persona int,
id_posicion int,
camiseta int
constraint pk_jugadores primary key(id_jugador),
constraint fk_equipos_jugadores foreign key(id_equipo)
		references equipos(id_equipo),
constraint fk_personas_jugadores foreign key(id_persona)
		references personas(id_persona),
constraint fk_posiciones_jugadores foreign key(id_posicion)
		references posiciones(id_posicion)
)

/*Ingreso de personas*/
INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('Pérez', 'Juan', '12345678', '1995-05-15');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('González', 'Luis', '98765432', '1998-02-22');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('López', 'Andrés', '56789012', '1997-07-10');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('Rodríguez', 'Carlos', '11223344', '1993-08-01');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('Martínez', 'Alejandro', '55667788', '1997-04-20');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('Díaz', 'Javier', '99001122', '1994-11-10');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('Fernández', 'Gustavo', '12131415', '1998-07-03');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('García', 'Luciano', '16171819', '1992-12-18');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('Hernández', 'Eduardo', '20212223', '1996-09-25');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('Sánchez', 'Gabriel', '32333435', '1993-09-15');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('Figueroa', 'Martín', '36373839', '1998-08-08');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('Torres', 'Agustín', '40414243', '1997-07-12');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('Mendoza', 'Lucas', '44454647', '1994-02-28');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('Cabrera', 'Joaquín', '52535455', '1991-12-03');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('Ríos', 'Tomás', '60616263', '1993-10-17');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('Martínez', 'Matías', '70717273', '1996-07-15');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('López', 'Lucio', '74757677', '1999-01-22');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('González', 'Nicolás', '78798081', '1997-06-10');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('Hernández', 'Ezequiel', '82838485', '1994-12-05');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('Pérez', 'Leandro', '86878889', '1991-09-18');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('Acosta', 'Julián', '90919293', '1993-08-14');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('Fernández', 'Iván', '94959697', '1998-05-20');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('Torres', 'Lautaro', '98991000', '1995-04-27');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('Rodríguez', 'Facundo', '101102103', '1992-03-08');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('Gómez', 'Gonzalo', '104105106', '1990-11-02');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('Díaz', 'Hugo', '107108109', '1997-09-17');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('Cabrera', 'Ismael', '110111112', '1993-06-25');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('Pérez', 'Joaquín', '113114115', '1996-01-12');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('Hernández', 'Kai', '116117118', '1995-07-30');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('López', 'Leonel', '119120121', '1998-04-21');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES ('Fernández', 'Manuel', '122123124', '1999-03-16');

INSERT INTO personas (apellido, nombre, dni, fecha_nac)
VALUES
    ('González', 'Juan', '12345678', '1990-05-15'),
    ('López', 'Carlos', '23456789', '1991-03-22'),
    ('Martínez', 'Pedro', '34567890', '1988-07-10'),
    ('Rodríguez', 'Luis', '45678901', '1995-11-01'),
    ('Fernández', 'Javier', '56789012', '1993-04-20'),
    ('Díaz', 'Andrés', '67890123', '1996-06-10'),
    ('Sánchez', 'Alejandro', '78901234', '1992-08-03'),
    ('Ramírez', 'Martín', '89012345', '1997-12-18'),
    ('Torres', 'Diego', '90123456', '1994-09-25'),
    ('Gómez', 'Lucas', '01234567', '1998-03-15');

-- Insertar posiciones 
INSERT INTO posiciones (posicion)
VALUES ('Portero');

INSERT INTO posiciones (posicion)
VALUES ('Defensor');

INSERT INTO posiciones (posicion)
VALUES ('Centrocampista');

INSERT INTO posiciones (posicion)
VALUES ('Delantero');

INSERT INTO equipos (nombre, tecnico)
VALUES
    ('Atlético Cordobés', 'Jorge Sánchez'),
    ('Deportivo Bellavista', 'Martín González'),
    ('Club San Martín', 'Jorge Pérez'),
    ('Real Los Pinos', 'Carlos Rodríguez'),
    ('Club Atlético Río Grande', 'Lionel Martínez'),
    ('Deportivo Alameda', 'Diego López'),
    ('Sporting del Norte', 'Pedro Fernández'),
    ('Club Estrellas del Sur', 'Eduardo Ramírez'),
    ('Villa del Sol FC', 'Milei García'),
    ('Atlético Los Laureles', 'Alejandro Torres'),
    ('Unidos de Córdoba', 'Roque Díaz'),
    ('Deportivo Las Palmas', 'Javier Vargas'),
    ('Club Aurora', 'San Ruiz'),
    ('Sporting de la Montaña', 'Andrés Herrera'),
    ('Club Deportivo Cordillera', 'Pujato Castro'),
    ('Real Vallarta', 'Ricardo Morales'),
    ('Club Río Celeste', 'Victor López'),
    ('Deportivo Los Tilos', 'Manuel Silva'),
    ('Unión Juventud', 'Indio Ramírez'),
    ('Club Atlético Los Pájaros', 'Juan González');

/*PROCEDIMIENTOS ALMACENADOS*/
/*CONSULTAR POSICIONES*/
create procedure sp_consultar_posiciones
as
begin
	select * from posiciones
end

/*CONSULTAR PERSONAS*/
create procedure sp_consultar_personas
as
begin
	select id_persona,nombre+' '+apellido Nombre_Completo,dni,fecha_nac from personas
end

/*INGRESAR EQUIPOS*/
create procedure sp_ingresar_equipos
		@nombre varchar(50),
		@tecnico varchar(50),
		@newId int output
as
begin
	insert into equipos(nombre,tecnico)
	values (@nombre,@tecnico)

	set @newId = SCOPE_IDENTITY()
end

/*INGRESAR JUGADORES*/
create procedure sp_ingresar_jugadores
		@idEquipo int,
		@idPersona int,
		@idPosicion int,
		@Camiseta int
as
begin
	insert into jugadores(id_equipo,id_persona,id_posicion,camiseta)
	values (@idEquipo,@idPersona,@idPosicion,@Camiseta)
end

/*PROXIMO ID*/
CREATE PROCEDURE sp_proximo_id
@next int OUTPUT
AS
BEGIN
	SET @next = (SELECT COALESCE(MAX(id_equipo), 0) + 1 FROM equipos);
END

/*CONSULTAR EQUIPOS*/
CREATE PROCEDURE sp_consultar_equipos
	@nombre varchar(50) = NULL,
	@tecnico varchar(50) = NULL
AS
BEGIN
	SELECT * 
	FROM equipos
	WHERE (@nombre IS NULL OR nombre LIKE '%' + @nombre + '%')
	   or (@tecnico IS NULL OR tecnico LIKE '%' + @tecnico + '%')
END

/*MODIFICAR EQUIPOS*/
CREATE PROCEDURE sp_modificar_equipo
	@equipo_id INT,
	@nuevo_nombre VARCHAR(50) = NULL,
	@nuevo_tecnico VARCHAR(50) = NULL
AS
BEGIN
	UPDATE equipos
	SET
		nombre = ISNULL(@nuevo_nombre, nombre), -- Actualiza nombre si se proporciona, de lo contrario, mantén el valor existente
		tecnico = ISNULL(@nuevo_tecnico, tecnico) -- Actualiza técnico si se proporciona, de lo contrario, mantén el valor existente
	WHERE id_equipo = @equipo_id;
END

/*CONSULTAR JUGADORES*/
create procedure sp_consultar_jugadores
		@id_equipo int,
		@nombreCompleto varchar(100) = NULL,
		@edad_desde int = NULL,
		@edad_hasta int = NULL,
		@edad int = NULL
as
begin
	select id_jugador, apellido+' '+nombre Nombre_Completo,
	DATEDIFF(YEAR, fecha_nac, GETDATE()) edad,
	posicion
	from jugadores j
	join personas p on j.id_persona=p.id_persona
	join posiciones po on po.id_posicion=j.id_posicion
	where id_equipo = @id_equipo
	and ((@nombreCompleto is null or apellido+' '+nombre like '%' +@nombreCompleto+ '%')
	and (@edad_desde is null OR DATEDIFF(YEAR, fecha_nac, GETDATE()) >= @edad_desde)
	and (@edad_hasta is null OR DATEDIFF(YEAR, fecha_nac, GETDATE()) <= @edad_hasta))
	and (@edad is null or DATEDIFF(YEAR, fecha_nac, GETDATE()) = @edad)
end