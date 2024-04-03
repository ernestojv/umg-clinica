-- Tabla: Usuarios
CREATE TABLE Usuario (
    Nombre_de_usuario VARCHAR(50) PRIMARY KEY,
    Contrasena VARCHAR(50),
    Nombre VARCHAR(100)
);

-- Tabla: Clinica
CREATE TABLE Clinica (
    ID_Clinica INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Direccion VARCHAR(255),
    Telefono VARCHAR(20)
);

-- Tabla: Medicamento
CREATE TABLE Medicamento (
    ID_Medicamento INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Descripcion VARCHAR(255),
    Stock INT,
    Precio DECIMAL(10, 2)
);

-- Tabla: Enfermedad
CREATE TABLE Enfermedad (
    ID_Enfermedad INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Descripcion VARCHAR(255)
);

-- Tabla: Paciente
CREATE TABLE Paciente (
    ID_Paciente INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Edad INT,
    Sexo CHAR(1),
    Numero_de_telefono VARCHAR(20)
);

-- Tabla: Empleado
CREATE TABLE Empleado (
    ID_Empleado INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Puesto VARCHAR(100),
    Numero_de_telefono VARCHAR(20),
    dpi VARCHAR(20),
    Nombre_de_usuario VARCHAR(50),
    FOREIGN KEY (Nombre_de_usuario) REFERENCES Usuario(Nombre_de_usuario)
);

-- Tabla: Cita
CREATE TABLE Cita (
    ID_Cita INT PRIMARY KEY,
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
    ID_Consulta INT PRIMARY KEY,
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
    ID INT PRIMARY KEY,
    ID_Consulta INT,
    ID_Enfermedad INT,
    FOREIGN KEY (ID_Consulta) REFERENCES Consulta(ID_Consulta),
    FOREIGN KEY (ID_Enfermedad) REFERENCES Enfermedad(ID_Enfermedad)
);

-- Tabla: Consulta_Medicina
CREATE TABLE Consulta_Medicina (
    ID INT PRIMARY KEY,
    ID_Consulta INT,
    ID_Medicamento INT,
    Indicaciones TEXT,
    FOREIGN KEY (ID_Consulta) REFERENCES Consulta(ID_Consulta),
    FOREIGN KEY (ID_Medicamento) REFERENCES Medicamento(ID_Medicamento)
);