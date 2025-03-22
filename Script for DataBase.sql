-- Crear la base de datos FundamentosG2
CREATE DATABASE FundamentosG2;
GO

-- Usar la base de datos FundamentosG2
USE FundamentosG2;
GO

-- Crear las tablas
-- Table: Alergia_Cliente
CREATE TABLE Alergia_Cliente (
    Producto_Alergia_Id int  NOT NULL,
    Cliente_Username varchar(15)  NOT NULL,
    Nombre varchar(50)  NOT NULL,
    CONSTRAINT Alergia_Cliente_pk PRIMARY KEY  (Producto_Alergia_Id,Cliente_Username)
);

-- Table: Cita
CREATE TABLE Cita (
    Id int  IDENTITY(1,1) NOT NULL,
    Fecha datetime  NOT NULL,
    Sede varchar(50)  NOT NULL,
    Hora_Inicio time  NOT NULL,
    Precio_Final decimal(10,2)  NOT NULL,
    Metodo_Contacto varchar(50)  NOT NULL,
    Codigo_Metodo_Pago int  NOT NULL,
    Cliente_Username varchar(15)  NOT NULL,
    CONSTRAINT Cita_pk PRIMARY KEY  (Id)
);

-- Table: Cliente
CREATE TABLE Cliente (
    Username varchar(15)  NOT NULL,
    Contrasena varchar(50)  NOT NULL,
    Nombre varchar(50)  NOT NULL,
    Apellido varchar(50)  NOT NULL,
    Email varchar(100)  NOT NULL,
    Telefono varchar(10)  NOT NULL,
    Preferencias varchar(50)  NOT NULL,
    CONSTRAINT Cliente_pk PRIMARY KEY  (Username)
);

-- Table: Descripcion_Cita
CREATE TABLE Descripcion_Cita (
    Cita_Id int  NOT NULL,
    Tipo_Servicio_Id int  NOT NULL,
    Nombre_Servicio varchar(50)  NOT NULL,
    CONSTRAINT Descripcion_Cita_pk PRIMARY KEY  (Cita_Id,Tipo_Servicio_Id)
);

-- Table: Pago
CREATE TABLE Pago (
    Id int IDENTITY(1,1)  NOT NULL,
    Tipo_Pago varchar(40)  NOT NULL,
    Monto_Total decimal(10,2)  NOT NULL,
    Numero_Telefono char(9)  NOT NULL,
    Clave_Confirmacion varchar(6)  NOT NULL,
    Cita_Id int  NOT NULL,
    CONSTRAINT Pago_pk PRIMARY KEY  (Id)
);

-- Table: Pago_Tarjeta
CREATE TABLE Pago_Tarjeta (
    Id int  IDENTITY(1,1) NOT NULL,
    Tipo_Tarjeta varchar(30)  NOT NULL,
    Numero_Tarjeta varchar(20)  NOT NULL,
    Codigo_Autorizacion varchar(4)  NOT NULL,
    Nombre_Cliente varchar(50)  NOT NULL,
    Pago_id int  NOT NULL,
    CONSTRAINT Pago_Tarjeta_pk PRIMARY KEY  (Id)
);

-- Table: Producto_Alergia
CREATE TABLE Producto_Alergia (
    Id int  NOT NULL,
    Nombre varchar(50)  NOT NULL,
    Descripcion varchar(80)  NOT NULL,
    CONSTRAINT Producto_Alergia_pk PRIMARY KEY  (Id)
);

-- Table: Servicio
CREATE TABLE Servicio (
    Id int  NOT NULL,
    Nombre_Servicio varchar(50)  NOT NULL,
    Descripcion_Servicio varchar(80)  NOT NULL,
    Precio decimal(10,2)  NOT NULL,
    CONSTRAINT Servicio_pk PRIMARY KEY  (Id)
);

-- Table: Auditoria_General
CREATE TABLE Auditoria_General (
    Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Tabla_Modificada varchar(50) NOT NULL,
    Tipo_Modificacion varchar(15) NOT NULL,
    Fecha datetime NOT NULL DEFAULT GETDATE()
);

-- foreign keys
-- Reference: Alergia_Cliente_Cliente (table: Alergia_Cliente)
ALTER TABLE Alergia_Cliente ADD CONSTRAINT Alergia_Cliente_Cliente
    FOREIGN KEY (Cliente_Username)
    REFERENCES Cliente (Username);

-- Reference: Alergia_Cliente_Producto_Alergia (table: Alergia_Cliente)
ALTER TABLE Alergia_Cliente ADD CONSTRAINT Alergia_Cliente_Producto_Alergia
    FOREIGN KEY (Producto_Alergia_Id)
    REFERENCES Producto_Alergia (Id);

-- Reference: Cita_Cliente (table: Cita)
ALTER TABLE Cita ADD CONSTRAINT Cita_Cliente
    FOREIGN KEY (Cliente_Username)
    REFERENCES Cliente (Username);

-- Reference: Descripcion_Cita_Cita (table: Descripcion_Cita)
ALTER TABLE Descripcion_Cita ADD CONSTRAINT Descripcion_Cita_Cita
    FOREIGN KEY (Cita_Id)
    REFERENCES Cita (Id);

-- Reference: Descripcion_Cita_Servicio (table: Descripcion_Cita)
ALTER TABLE Descripcion_Cita ADD CONSTRAINT Descripcion_Cita_Servicio
    FOREIGN KEY (Tipo_Servicio_Id)
    REFERENCES Servicio (Id);

-- Reference: Pago_Cita (table: Pago)
ALTER TABLE Pago ADD CONSTRAINT Pago_Cita
    FOREIGN KEY (Cita_Id)
    REFERENCES Cita (Id);

-- Reference: Pago_Tarjeta_Pago (table: Pago_Tarjeta)
ALTER TABLE Pago_Tarjeta ADD CONSTRAINT Pago_Tarjeta_Pago
    FOREIGN KEY (Pago_id)
    REFERENCES Pago (Id);

-- End of table creation and foreign keys.

-- Insert initial data into Servicio
INSERT INTO Servicio VALUES
    (1,'Corte de cabello','Transforma tu estilo con un corte de cabello que refleje tu personalidad.',35),
    (2,'Afeitado clásico (con navaja)','Experimenta la elegancia y la suavidad de un afeitado clásico con navaja.',21.50),
    (3,'Recorte y arreglo de barba','Define tu apariencia con un meticuloso recorte y arreglo de barba.',21),
    (4,'Diseño de barba','Logra un look distintivo diseñado con un servicio de diseño de barba.',25),
    (5,'Tratamientos capilares (hidratación, reparación)','Revitaliza tu cabello con tratamientos capilares especializados.',30),
    (6,'Tinte para barba y/o cabello','Renueva tu apariencia con un tinte para barba.',40),
    (7,'Peinado y estilismo','Define tu estilo con un peinado y estilismo que reflejen tu personalidad.',40),
    (8,'Depilación facial (cejas, orejas, nariz)','Refina tu aspecto con una depilación facial que incluye cejas, orejas y nariz.',20),
    (9,'Tratamientos para cuero cabelludo','Cuida tu cuero cabelludo con tratamientos especializados que combaten la caspa.',21);

-- Insert initial data into Producto_Alergia
INSERT INTO Producto_Alergia VALUES
    (1,'Tintes para el cabello: Parafenilendiamina','Algunas personas pueden desarrollar alergias, con síntomas como enrojecimiento.'),
    (2,'Productos de cuidado de la piel: Fragancias','Los productos de cuidado de piel pueden causar reacciones en algunas personas.'),
    (3,'Cera para el cabello: Fragancias sintéticas','La cera para el cabello puede causar alergias.'),
    (4,'Productos para el cuidado de la barba: Lanolina','Algunos productos para barba contienen lanolina y pueden causar alergias.'),
    (5,'Champú y acondicionador: Lauril sulfato de sodio','El SLS en champús puede causar alergias, sequedad e irritación.'),
    (6,'Gel de afeitar: Fragancias y alcoholes','Los geles de afeitar con fragancias y alcohol pueden causar alergias.'),
    (7,'Loción para después del afeitado: Fragancias','Las lociones para después del afeitado pueden causar alergias.'),
    (8,'Otro/s (Explicar el día de la cita)','Sin Descripción');
GO
-- Triggers for Descripcion_Cita

-- Trigger para INSERT en Descripcion_Cita
CREATE TRIGGER trg_Descripcion_Cita_Insert
ON Descripcion_Cita
AFTER INSERT
AS
BEGIN
    INSERT INTO Auditoria_General (Tabla_Modificada, Tipo_Modificacion)
    VALUES ('Descripcion_Cita', 'Agregado');
END;
GO

-- Trigger para UPDATE en Descripcion_Cita
CREATE TRIGGER trg_Descripcion_Cita_Update
ON Descripcion_Cita
AFTER UPDATE
AS
BEGIN
    INSERT INTO Auditoria_General (Tabla_Modificada, Tipo_Modificacion)
    VALUES ('Descripcion_Cita', 'Actualizado');
END;
GO

-- Trigger para DELETE en Descripcion_Cita
CREATE TRIGGER trg_Descripcion_Cita_Delete
ON Descripcion_Cita
AFTER DELETE
AS
BEGIN
    INSERT INTO Auditoria_General (Tabla_Modificada, Tipo_Modificacion)
    VALUES ('Descripcion_Cita', 'Eliminado');
END;
GO

-- Trigger para INSERT en Cliente
CREATE TRIGGER trg_Cliente_Insert
ON Cliente
AFTER INSERT
AS
BEGIN
    INSERT INTO Auditoria_General (Tabla_Modificada, Tipo_Modificacion)
    VALUES ('Cliente', 'Agregado');
END;
GO

-- Trigger para UPDATE en Cliente
CREATE TRIGGER trg_Cliente_Update
ON Cliente
AFTER UPDATE
AS
BEGIN
    INSERT INTO Auditoria_General (Tabla_Modificada, Tipo_Modificacion)
    VALUES ('Cliente', 'Actualizado');
END;
GO

-- Trigger para DELETE en Cliente
CREATE TRIGGER trg_Cliente_Delete
ON Cliente
AFTER DELETE
AS
BEGIN
    INSERT INTO Auditoria_General (Tabla_Modificada, Tipo_Modificacion)
    VALUES ('Cliente', 'Eliminado');
END;
GO

-- Trigger para INSERT en Alergia_Cliente
CREATE TRIGGER trg_Alergia_Cliente_Insert
ON Alergia_Cliente
AFTER INSERT
AS
BEGIN
    INSERT INTO Auditoria_General (Tabla_Modificada, Tipo_Modificacion)
    VALUES ('Alergia_Cliente', 'Agregado');
END;
GO

-- Trigger para UPDATE en Alergia_Cliente
CREATE TRIGGER trg_Alergia_Cliente_Update
ON Alergia_Cliente
AFTER UPDATE
AS
BEGIN
    INSERT INTO Auditoria_General (Tabla_Modificada, Tipo_Modificacion)
    VALUES ('Alergia_Cliente', 'Actualizado');
END;
GO

-- Trigger para DELETE en Alergia_Cliente
CREATE TRIGGER trg_Alergia_Cliente_Delete
ON Alergia_Cliente
AFTER DELETE
AS
BEGIN
    INSERT INTO Auditoria_General (Tabla_Modificada, Tipo_Modificacion)
    VALUES ('Alergia_Cliente', 'Eliminado');
END;
GO

-- Trigger para INSERT en Cita
CREATE TRIGGER trg_Cita_Insert
ON Cita
AFTER INSERT
AS
BEGIN
    INSERT INTO Auditoria_General (Tabla_Modificada, Tipo_Modificacion)
    VALUES ('Cita', 'Agregado');
END;
GO

-- Trigger para UPDATE en Cita
CREATE TRIGGER trg_Cita_Update
ON Cita
AFTER UPDATE
AS
BEGIN
    INSERT INTO Auditoria_General (Tabla_Modificada, Tipo_Modificacion)
    VALUES ('Cita', 'Actualizado');
END;
GO

-- Trigger para DELETE en Cita
CREATE TRIGGER trg_Cita_Delete
ON Cita
AFTER DELETE
AS
BEGIN
    INSERT INTO Auditoria_General (Tabla_Modificada, Tipo_Modificacion)
    VALUES ('Cita', 'Eliminado');
END;
GO

-- Trigger para INSERT en Pago
CREATE TRIGGER trg_Pago_Insert
ON Pago
AFTER INSERT
AS
BEGIN
    INSERT INTO Auditoria_General (Tabla_Modificada, Tipo_Modificacion)
    VALUES ('Pago', 'Agregado');
END;
GO

-- Trigger para UPDATE en Pago
CREATE TRIGGER trg_Pago_Update
ON Pago
AFTER UPDATE
AS
BEGIN
    INSERT INTO Auditoria_General (Tabla_Modificada, Tipo_Modificacion)
    VALUES ('Pago', 'Actualizado');
END;
GO

-- Trigger para DELETE en Pago
CREATE TRIGGER trg_Pago_Delete
ON Pago
AFTER DELETE
AS
BEGIN
    INSERT INTO Auditoria_General (Tabla_Modificada, Tipo_Modificacion)
    VALUES ('Pago', 'Eliminado');
END;
GO

-- Trigger para INSERT en Pago_Tarjeta
CREATE TRIGGER trg_Pago_Tarjeta_Insert
ON Pago_Tarjeta
AFTER INSERT
AS
BEGIN
    INSERT INTO Auditoria_General (Tabla_Modificada, Tipo_Modificacion)
    VALUES ('Pago_Tarjeta', 'Agregado');
END;
GO

-- Trigger para UPDATE en Pago_Tarjeta
CREATE TRIGGER trg_Pago_Tarjeta_Update
ON Pago_Tarjeta
AFTER UPDATE
AS
BEGIN
    INSERT INTO Auditoria_General (Tabla_Modificada, Tipo_Modificacion)
    VALUES ('Pago_Tarjeta', 'Actualizado');
END;
GO

-- Trigger para DELETE en Pago_Tarjeta
CREATE TRIGGER trg_Pago_Tarjeta_Delete
ON Pago_Tarjeta
AFTER DELETE
AS
BEGIN
    INSERT INTO Auditoria_General (Tabla_Modificada, Tipo_Modificacion)
    VALUES ('Pago_Tarjeta', 'Eliminado');
END;
GO

-- Trigger para INSERT en Servicio
CREATE TRIGGER trg_Servicio_Insert
ON Servicio
AFTER INSERT
AS
BEGIN
    INSERT INTO Auditoria_General (Tabla_Modificada, Tipo_Modificacion)
    VALUES ('Servicio', 'Agregado');
END;
GO

-- Trigger para UPDATE en Servicio
CREATE TRIGGER trg_Servicio_Update
ON Servicio
AFTER UPDATE
AS
BEGIN
    INSERT INTO Auditoria_General (Tabla_Modificada, Tipo_Modificacion)
    VALUES ('Servicio', 'Actualizado');
END;
GO

-- Trigger para DELETE en Servicio
CREATE TRIGGER trg_Servicio_Delete
ON Servicio
AFTER DELETE
AS
BEGIN
    INSERT INTO Auditoria_General (Tabla_Modificada, Tipo_Modificacion)
    VALUES ('Servicio', 'Eliminado');
END;
GO