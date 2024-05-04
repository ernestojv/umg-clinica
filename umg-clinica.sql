-- Tabla: Usuarios
CREATE TABLE Usuario (
    Nombre_de_usuario VARCHAR(50) PRIMARY KEY,
    Contrasena VARCHAR(50),
    Nombre VARCHAR(100)
);

-- Tabla: Clinica
CREATE TABLE Clinica (
    ID_Clinica INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100),
    Direccion VARCHAR(255),
    Telefono VARCHAR(20)
);

-- Tabla: Medicamento
CREATE TABLE Medicamento (
    ID_Medicamento INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100),
    Descripcion VARCHAR(255),
    Stock INT,
    Precio DECIMAL(10, 2)
);

-- Tabla: Enfermedad
CREATE TABLE Enfermedad (
    ID_Enfermedad INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100),
    Descripcion VARCHAR(255)
);

-- Tabla: Paciente
CREATE TABLE Paciente (
    ID_Paciente INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100),
    Edad INT,
    Sexo CHAR(1),
    Numero_de_telefono VARCHAR(20)
);

-- Tabla: Empleado
CREATE TABLE Empleado (
    ID_Empleado INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100),
    Puesto VARCHAR(100),
    Numero_de_telefono VARCHAR(20),
    dpi VARCHAR(20),
    Nombre_de_usuario VARCHAR(50),
    FOREIGN KEY (Nombre_de_usuario) REFERENCES Usuario(Nombre_de_usuario)
);

-- Tabla: Cita
CREATE TABLE Cita (
    ID_Cita INT PRIMARY KEY IDENTITY(1,1),
    Fecha_hora DATETIME,
    Estado VARCHAR(50),
    ID_Clinica INT,
    ID_Paciente INT,
    ID_Empleado INT,
    FOREIGN KEY (ID_Clinica) REFERENCES Clinica(ID_Clinica),
    FOREIGN KEY (ID_Paciente) REFERENCES Paciente(ID_Paciente),
    FOREIGN KEY (ID_Empleado) REFERENCES Empleado(ID_Empleado)
);

-- Tabla: Consulta
CREATE TABLE Consulta (
    ID_Consulta INT PRIMARY KEY IDENTITY(1,1),
    Observaciones TEXT,
    Fecha DATE,
    ID_Clinica INT,
    ID_Paciente INT,
    ID_Empleado INT,
    ID_Cita INT,
    FOREIGN KEY (ID_Clinica) REFERENCES Clinica(ID_Clinica),
    FOREIGN KEY (ID_Paciente) REFERENCES Paciente(ID_Paciente),
    FOREIGN KEY (ID_Empleado) REFERENCES Empleado(ID_Empleado),
    FOREIGN KEY (ID_Cita) REFERENCES Cita(ID_Cita)
);

-- Tabla: Consulta_Enfermedad
CREATE TABLE Consulta_Enfermedad (
    ID INT PRIMARY KEY IDENTITY(1,1),
    ID_Consulta INT,
    ID_Enfermedad INT,
    FOREIGN KEY (ID_Consulta) REFERENCES Consulta(ID_Consulta),
    FOREIGN KEY (ID_Enfermedad) REFERENCES Enfermedad(ID_Enfermedad)
);

-- Tabla: Consulta_Medicina
CREATE TABLE Consulta_Medicina (
    ID INT PRIMARY KEY IDENTITY(1,1),
    ID_Consulta INT,
    ID_Medicamento INT,
    Indicaciones TEXT,
    FOREIGN KEY (ID_Consulta) REFERENCES Consulta(ID_Consulta),
    FOREIGN KEY (ID_Medicamento) REFERENCES Medicamento(ID_Medicamento)
);


-- Inserts
-- Insertar registros en la tabla Usuario
INSERT INTO Usuario (Nombre_de_usuario, Contrasena, Nombre) VALUES
('usuario1', 'contrasena1', 'Juan Perez'),
('usuario2', 'contrasena2', 'Maria Garcia');

-- Insertar registros en la tabla Clinica
INSERT INTO Clinica (Nombre, Direccion, Telefono) VALUES
('Clinica A', 'Calle Principal 123', '123-456-7890'),
('Clinica B', 'Avenida Central 456', '987-654-3210');

-- Insertar registros en la tabla Medicamento
INSERT INTO Medicamento (Nombre, Descripcion, Stock, Precio) VALUES
('Medicamento 1', 'Descripción del medicamento 1', 100, 10.99),
('Medicamento 2', 'Descripción del medicamento 2', 50, 20.50);

-- Insertar registros en la tabla Enfermedad
INSERT INTO Enfermedad (Nombre, Descripcion) VALUES
('Enfermedad 1', 'Descripción de la enfermedad 1'),
('Enfermedad 2', 'Descripción de la enfermedad 2');

-- Insertar registros en la tabla Paciente
INSERT INTO Paciente (Nombre, Edad, Sexo, Numero_de_telefono) VALUES
('Paciente 1', 30, 'M', '111-222-3333'),
('Paciente 2', 25, 'F', '444-555-6666');

-- Insertar registros en la tabla Empleado
INSERT INTO Empleado (Nombre, Puesto, Numero_de_telefono, dpi, Nombre_de_usuario) VALUES
('Empleado 1', 'Doctor', '777-888-9999', '1234567890123', 'usuario1'),
('Empleado 2', 'Enfermero', '999-888-7777', '9876543210987', 'usuario2');

-- Insertar registros en la tabla Cita
INSERT INTO Cita (Fecha_hora, Estado, ID_Clinica, ID_Paciente, ID_Empleado) VALUES
('2024-05-03 10:00:00', 'Programada', 1, 1, 1),
('2024-05-04 11:00:00', 'Cancelada', 2, 2, 2);

-- Insertar registros en la tabla Consulta
INSERT INTO Consulta (Observaciones, Fecha, ID_Clinica, ID_Paciente, ID_Empleado, ID_Cita) VALUES
('Observaciones de la consulta 1', '2024-05-03', 1, 1, 1, 1),
('Observaciones de la consulta 2', '2024-05-04', 2, 2, 2, 2);

-- Insertar registros en la tabla Consulta_Enfermedad
INSERT INTO Consulta_Enfermedad (ID_Consulta, ID_Enfermedad) VALUES
(1, 1),
(2, 2);

-- Insertar registros en la tabla Consulta_Medicina
INSERT INTO Consulta_Medicina (ID_Consulta, ID_Medicamento, Indicaciones) VALUES
(1, 1, 'Indicaciones del medicamento 1'),
(2, 2, 'Indicaciones del medicamento 2');

