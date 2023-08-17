-- Storegame.sql

-- Objectivo : Crear las tablas de la base de datos
-- Fecha: 08/08/2022

-- 1. Tabla Genre
---------------------------------------
CREATE TABLE Genre (
    Genre_id serial PRIMARY KEY,
    Name varchar(50) NOT NULL
);

-- 2. Tabla Developer
---------------------------------------
CREATE TABLE Developer (
    Developer_id serial PRIMARY KEY,
    Name varchar(50) NOT NULL,
    Website varchar(100)
);

-- 3. Tabla Platform
---------------------------------------
CREATE TABLE Platform (
    Platform_id serial PRIMARY KEY,
    Name varchar(50) NOT NULL
);

-- 4. Tabla Game
---------------------------------------
CREATE TABLE Game (
    Game_id serial PRIMARY KEY,
    Title varchar(100) NOT NULL,
    Description varchar(500),
    Developer_id int,
    Platform_id int,
    Release_date date,
    Price numeric(10, 2) NOT NULL,
    Stock int NOT NULL,
    CONSTRAINT fk_developer foreign key (Developer_id) references Developer(Developer_id),
    CONSTRAINT fk_platform foreign key (Platform_id) references Platform(Platform_id)
);

-- 5. Tabla Customer
---------------------------------------
CREATE TABLE Customer (
    Customer_id serial PRIMARY KEY,
    First_name varchar(50) NOT NULL,
    Last_name varchar(50) NOT NULL,
    Email varchar(100) NOT NULL,
    Phone varchar(20),
    Address varchar(200)
);

-- 6. Tabla Transaction
---------------------------------------
CREATE TABLE Transaction (
    Transaction_id serial PRIMARY KEY,
    Customer_id int,
    Game_id int,
    Transaction_date date,
    Total_amount numeric(10, 2) NOT null,
    CONSTRAINT fk_customer foreign key (Customer_id) references Customer(Customer_id),
    CONSTRAINT fk_game foreign key (Game_id) references Game(Game_id)
);

-- 7. Tabla Cart
---------------------------------------
CREATE TABLE Cart (
    Cart_id serial PRIMARY KEY,
    Customer_id int,
    Game_id int,
    Quantity int NOT NULL,
    constraint fk_customer foreign key (Customer_id) references Customer(Customer_id),
    constraint fk_game foreign key (Game_id) references Game(Game_id)
);

---------------------------------------

-- 1. Catalogo de Juegos
insert into public.game(title, description,developer_id,platform_id,release_date,price,stock,imagen)
values('S.T.A.L.K.E.R.: Shadow of Chernobyl
','S.T.A.L.K.E.R.: Shadow of Chernobyl tells a story about survival in the Zone – a very dangerous place, where you fear not only the radiation, anomalies and deadly creatures, but other S.T.A.L.K.E.R.s, who have their own goals and wishes.
',1,1,'2007-03-20',2450,10,'STALKER_Shadow_of_Chernobly');

SELECT 
	g.title, 
	d.name AS developer_name,
	p.name AS platform_name, 
	g.release_date, 
	g.price, 
	g.stock, 
	g.imagen
FROM 
	game g
JOIN 
    platform p ON g.platform_id = p.platform_id
JOIN
	developer d ON g.developer_id = d.developer_id











