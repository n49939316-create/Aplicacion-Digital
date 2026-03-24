-- SQL Script for creating database tables

CREATE TABLE Colegios (
    ColegioID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255) NOT NULL,
    Dirección NVARCHAR(255),
    Ciudad NVARCHAR(100),
    CONSTRAINT UQ_ColegioNombre UNIQUE (Nombre)
);

CREATE TABLE Estudiantes (
    EstudianteID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255) NOT NULL,
    ColegioID INT,
    FechaNacimiento DATE,
    CONSTRAINT FK_Estudiante_Colegio FOREIGN KEY (ColegioID) REFERENCES Colegios(ColegioID)
);

CREATE TABLE Trimestres (
    TrimesterID INT PRIMARY KEY IDENTITY(1,1),
    Año INT NOT NULL,
    Número INT NOT NULL,
    ColegioID INT,
    CONSTRAINT FK_Trimester_Colegio FOREIGN KEY (ColegioID) REFERENCES Colegios(ColegioID)
);

CREATE TABLE Documentos (
    DocumentoID INT PRIMARY KEY IDENTITY(1,1),
    EstudianteID INT,
    Tipo NVARCHAR(255) NOT NULL,
    FechaDocumento DATE,
    CONSTRAINT FK_Documento_Estudiante FOREIGN KEY (EstudianteID) REFERENCES Estudiantes(EstudianteID)
);

-- Indexes
CREATE INDEX IDX_Estudiante_Colegio ON Estudiantes (ColegioID);
CREATE INDEX IDX_Trimester_Colegio ON Trimestres (ColegioID);
CREATE INDEX IDX_Documento_Estudiante ON Documentos (EstudianteID);