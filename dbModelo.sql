
--crear tablas

--Tabla Modelo
if (not exists(select 1 from sys.tables where name = 'Semestre'))
    CREATE TABLE dbo.Semestre (
       semestre_id  int identity(1,1) NOT NULL,
       nombre        varchar(250) NOT NULL,
       anio      	 int NULL,
	   estado        char(1)       
       PRIMARY KEY (semestre_id)
)
go

--Tabla Modelo
if (not exists(select 1 from sys.tables where name = 'Modelo'))
    CREATE TABLE dbo.Modelo (
       modelo_id  int identity(1,1) NOT NULL,
       nombre        varchar(250) NOT NULL,
       descripcion 	 text NULL,
	   estado        char(1)       
       PRIMARY KEY (modelo_id)
)
go
if (not exists(select 1 from sys.tables where name = 'Evidencia'))
    CREATE TABLE dbo.Evidencia (
       evidencia_id int identity(1,1) NOT NULL,       
	   descripcion            text NOT NULL,
	   categoria              varchar(250) NOT NULL,
       estado               varchar(1) NOT NULL,
       PRIMARY KEY (evidencia_id),
)
go
-- Tabla criterio
if (not exists(select 1 from sys.tables where name = 'Criterio'))
    CREATE TABLE dbo.Criterio (
       criterio_id     int identity(1,1) NOT NULL,
	   modelo_id       int NULL,
       nombre_spanish  varchar(250) NOT NULL,
	   nombre_english  varchar(250) NOT NULL,
	   urlcriterio     varchar(250) NULL,
       descripcion 	   text NULL,
	   estado          char(1)       
       PRIMARY KEY (criterio_id),
	   FOREIGN KEY (modelo_id)  REFERENCES Modelo,
)
go
-- Tabla Evidencia
if (not exists(select 1 from sys.tables where name = 'EvidenciaCriterio'))
    CREATE TABLE dbo.EvidenciaCriterio (
       evidenciaCriterio_id  int identity(1,1) NOT NULL,
	   evidencia_id  int NOT NULL,
	   criterio_id   int NOT NULL, 
	   semestre_id	 int not null,
	   modelo_id	 int not null,
	   archivo       varchar(250) NOT NULL,
	   tamanio       varchar(10) NOT NULL,
       tipo          varchar(10) NOT NULL,	   
       descripcion 	 text NULL	       
       PRIMARY KEY (evidenciaCriterio_id),
	   FOREIGN KEY (criterio_id)  REFERENCES Criterio,
	   FOREIGN KEY (semestre_id)  REFERENCES Semestre,
	   FOREIGN KEY (modelo_id)  REFERENCES Modelo
)
go



-- Tabla actividad
if (not exists(select 1 from sys.tables where name = 'Actividad'))
    CREATE TABLE dbo.Actividad (
       actividad_id int identity(1,1) NOT NULL,
	   semestre_id  int NOT NULL,
	   criterio_id  int NOT NULL, 
       nombre       varchar(250) NOT NULL,
	   descripcion 	text NULL,
	   fecha        date NULL,
	   urlactividad    varchar(250) NULL,       
	   estado         char(1)       
       PRIMARY KEY (actividad_id),
	   FOREIGN KEY (semestre_id)  REFERENCES Semestre,
	   FOREIGN KEY (criterio_id)  REFERENCES Criterio
)
go


-- Tabla Evidencia Actividad
if (not exists(select 1 from sys.tables where name = 'EvidenciaActividad'))
    CREATE TABLE dbo.EvidenciaActividad (
       evidenciaactividad_id  int identity(1,1) NOT NULL,	
	   evidencia_id int not null,  
	   actividad_id  int NOT NULL,
	   archivo       varchar(250) NOT NULL,
	   tamanio       varchar(10) NOT NULL,
       tipo          varchar(10) NOT NULL,	   
       descripcion 	 text NULL	       
       PRIMARY KEY (evidenciaactividad_id),
	   FOREIGN KEY (evidencia_id)  REFERENCES Evidencia,
	   FOREIGN KEY (actividad_id)  REFERENCES Criterio,
)
go

-- Tabla docente
if (not exists(select 1 from sys.tables where name = 'Docente'))
    CREATE TABLE dbo.Docente (
       docente_id      int identity(1,1) NOT NULL,       
	   docente_codigo  int NOT NULL UNIQUE,
       dni             varchar(8) NOT NULL UNIQUE,       
       apellido        varchar(100) NOT NULL,
	   nombre          varchar(50) NOT NULL,
	   sexo			   char(1) NOT NULL,	   
       email           varchar(100) NULL UNIQUE,
       celular	       varchar(15) NULL,
	   cargo           varchar(250) NOT NULL,
	   condicion       varchar(30) NOT NULL,
	   categoria       varchar(50) NOT NULL,
	   foto            varchar(250) NULL,
       estado          varchar(1) NULL,
       PRIMARY KEY (docente_id)       
)
go

-- Tabla Usuario
if (not exists(select 1 from sys.tables where name = 'Usuario'))
    CREATE TABLE dbo.Usuario (
       usuario_id      int identity(1,1) NOT NULL,
       docente_id      int NOT NULL,         
       nombre          varchar(30) NOT NULL UNIQUE,
       clave           varchar(50) NOT NULL,
	   nivel		   varchar(20) NOT NULL,      
       avatar          varchar(250) NULL,
       estado          char(1) NOT NULL,       
       PRIMARY KEY (usuario_id),
       FOREIGN KEY (docente_id)  REFERENCES Docente
)
go

-- Tabla Estudiante
if (not exists(select 1 from sys.tables where name = 'Estudiante'))
    CREATE TABLE dbo.Estudiante (
       estudiante_id     int identity(1,1) NOT NULL,       
	   estudiante_codigo int NOT NULL UNIQUE,
       dni              varchar(8) NOT NULL UNIQUE,       
       apellido         varchar(100) NOT NULL,
	   nombre           varchar(50) NOT NULL,
	   sexo			    char(1) NOT NULL,	   
       email            varchar(100) NULL UNIQUE,
	   direccion        varchar(250) NOT NULL,
       celular	        varchar(15) NULL,	   
	   foto             varchar(250) NULL,
       estado           varchar(1) NULL,
       PRIMARY KEY (estudiante_codigo)       
)
go


if (not exists(select 1 from sys.tables where name = 'Asignacion'))
    CREATE TABLE dbo.Asignacion (
       asignacion_id    int identity(1,1) NOT NULL,       
	   semestre_id      int NOT NULL,
	   titulo           varchar(250) NOT NULL,
	   fecharegistro    date NULL,       
       estado           varchar(1) NULL,
       PRIMARY KEY (asignacion_id)       
)
go

if (not exists(select 1 from sys.tables where name = 'DetalleAsignacion'))
    CREATE TABLE dbo.DetalleAsignacion (
       detalleasignacion_id     int identity(1,1) NOT NULL,       
	   asignacion_id     int NOT NULL,
	   docente_id		 int NOT NULL,
	   criterio_id       int NOT NULL,
       estado           varchar(1) NULL,
       PRIMARY KEY (detalleasignacion_id)       
)
go


if (not exists(select 1 from sys.tables where name = 'Control'))
    CREATE TABLE dbo.Control (
       control_id    int identity(1,1) NOT NULL,       
	   semestre_id      int NOT NULL,
	   titulo           varchar(250) NOT NULL,
	   fechacreacion    date NULL,       
       estado           varchar(1) NULL,
       PRIMARY KEY (control_id)       
)
go

if (not exists(select 1 from sys.tables where name = 'ControlAsignacion'))
    CREATE TABLE dbo.ControlAsignacion (
       controlasignacion_id int identity(1,1) NOT NULL,       
	   detalleasignacion_id int NOT NULL,
	   docente_id		    int NOT NULL,
	   criterio_id          int NOT NULL,
	   fechaasignacion      date NULL,
	   fechaculminacion     date NULL,
	   duracion             varchar(30) NULL,
	   sustento             char(2) NOT NULL,
	   porcentaje           char(4) NOT NULL,
	   condicion            varchar(30) NOT NULL,
	   archivo              varchar(250) NOT NULL,
	   observacion          text NULL,
       estado               varchar(1) NOT NULL,
       PRIMARY KEY (controlasignacion_id),
	   FOREIGN KEY (detalleasignacion_id) REFERENCES DetalleAsignacion,
	   FOREIGN KEY (docente_id) REFERENCES Docente,
	   FOREIGN KEY (criterio_id) REFERENCES Criterio
)
go

