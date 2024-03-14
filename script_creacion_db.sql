-- Creación de la base de datos
CREATE DATABASE Mitologia;

-- Uso de la base de datos recién creada
USE Mitologia;

-- Creación de la tabla "logias"
CREATE TABLE logias (
    logia_id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(100),
    description VARCHAR(255)
);

-- Creación de la tabla "creatures"
CREATE TABLE creatures (
    creature_id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(100),
    description VARCHAR(255),
    logia_id INT,
    FOREIGN KEY (logia_id) REFERENCES logias(logia_id)
);

-- Creación de la tabla "masones"
CREATE TABLE masones (
    masone_id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(100),
    description VARCHAR(255),
    logia_id INT,
    FOREIGN KEY (logia_id) REFERENCES logias(logia_id)
);


-- Inserciones de ejemplo en la tabla "logias"
INSERT INTO logias (logia_id, name, description) VALUES 
(1, 'Logia de los Elementales', 'Logia que agrupa a criaturas relacionadas con los elementos naturales'),
(2, 'Logia de las Sombras', 'Logia que reúne a criaturas nocturnas y oscuras'),
(3, 'Logia de Ibai', 'Logia que venera al ser supremo Ibai'),
(4, 'Logia de los Espíritus', 'Logia que estudia y convoca espíritus ancestrales');

-- Inserciones de ejemplo en la tabla "creatures"
INSERT INTO creatures (creature_id, name, description, logia_id) VALUES 
(1, 'Cerbero', 'Perro de tres cabezas guardián del inframundo', 1),
(2, 'Minotauro', 'Criatura con cuerpo de humano y cabeza de toro', 1),
(3, 'Hidra', 'Serpiente acuática con múltiples cabezas', 1),
(4, 'Quimera', 'Criatura con cabeza de león, cuerpo de cabra y cola de serpiente', 3),
(5, 'Vampiro', 'Criatura que se alimenta de la sangre de los vivos', 2),
(6, 'Licántropo', 'Humano que se transforma en lobo en las noches de luna llena', 2),
(7, 'Súcubo', 'Demonio femenino que seduce a los hombres en sueños', 4),
(8, 'Kraken', 'Monstruo marino de enormes proporciones', 3),
(9, 'Fénix', 'Ave legendaria que renace de sus cenizas', 1),
(10, 'Grifo', 'Criatura con cuerpo de león y cabeza de águila', 1);

-- Inserciones de ejemplo en la tabla "masones"
INSERT INTO masones (masone_id, name, description, logia_id) VALUES 
(1, 'John Doe', 'Mason perteneciente a la Logia de los Elementales', 3),
(2, 'Jane Smith', 'Mason perteneciente a la Logia de las Sombras', 2),
(3, 'Michael Johnson', 'Mason perteneciente a la Logia de los Elementales', 1),
(4, 'Emily Brown', 'Mason perteneciente a la Logia de las Sombras', 2),
(5, 'David Williams', 'Mason perteneciente a la Logia de los Elementales', 1),
(6, 'Emma Jones', 'Mason perteneciente a la Logia de las Sombras', 4),
(7, 'James Miller', 'Mason perteneciente a la Logia de los Elementales', 3),
(8, 'Olivia Davis', 'Mason perteneciente a la Logia de las Sombras', 2),
(9, 'William Wilson', 'Mason perteneciente a la Logia de los Elementales', 1),
(10, 'Sophia Taylor', 'Mason perteneciente a la Logia de las Sombras', 3);
