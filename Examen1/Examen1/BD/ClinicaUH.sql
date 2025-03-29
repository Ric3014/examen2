create database ClinicaUH
GO
use ClinicaUH
go

create table Pacientes
(Cedula INT PRIMARY KEY,
    Nombre VARCHAR(50),
    PrimerApellido VARCHAR(50),
    FechaNacimiento DATE,
    Edad INT,
    Telefono VARCHAR(20)
);

CREATE TABLE Medicos (
    ID_Medico INT PRIMARY KEY,
    Nombre VARCHAR(50),
    Especialidad VARCHAR(50)
);

CREATE TABLE Consultas (
    ID_Consulta INT PRIMARY KEY ,
    Cedula INT,
    ID_Medico INT,
    FechaAtencion DATE,
    HoraAtencion TIME,
    Consultorio INT,
    FOREIGN KEY (Cedula) REFERENCES Pacientes(Cedula),
    FOREIGN KEY (ID_Medico) REFERENCES Medicos(ID_Medico)
);