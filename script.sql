/*    ==Scripting Parameters==

    Source Database Engine Edition : Microsoft Azure SQL Database Edition
    Source Database Engine Type : Microsoft Azure SQL Database

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [master]
GO
/****** Object:  Database [db_modelo]    Script Date: 28/05/2019 16:55:57 ******/
CREATE DATABASE [db_modelo]
GO
ALTER DATABASE [db_modelo] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_modelo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_modelo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_modelo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_modelo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_modelo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_modelo] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_modelo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_modelo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_modelo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_modelo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_modelo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_modelo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_modelo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_modelo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_modelo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_modelo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_modelo] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [db_modelo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_modelo] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [db_modelo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_modelo] SET  MULTI_USER 
GO
ALTER DATABASE [db_modelo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_modelo] SET ENCRYPTION ON
GO
ALTER DATABASE [db_modelo] SET QUERY_STORE = ON
GO
ALTER DATABASE [db_modelo] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 100, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO)
GO
USE [db_modelo]
GO
ALTER DATABASE SCOPED CONFIGURATION SET BATCH_MODE_ADAPTIVE_JOINS = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET BATCH_MODE_MEMORY_GRANT_FEEDBACK = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET BATCH_MODE_ON_ROWSTORE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET DEFERRED_COMPILATION_TV = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET ELEVATE_ONLINE = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET ELEVATE_RESUMABLE = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET GLOBAL_TEMPORARY_TABLE_AUTO_DROP = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET INTERLEAVED_EXECUTION_TVF = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET ISOLATE_SECURITY_POLICY_CARDINALITY = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LIGHTWEIGHT_QUERY_PROFILING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET OPTIMIZE_FOR_AD_HOC_WORKLOADS = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET ROW_MODE_MEMORY_GRANT_FEEDBACK = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET VERBOSE_TRUNCATION_WARNINGS = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET XTP_PROCEDURE_EXECUTION_STATISTICS = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET XTP_QUERY_EXECUTION_STATISTICS = OFF;
GO
USE [db_modelo]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_diagramobjects]    Script Date: 28/05/2019 16:56:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE FUNCTION [dbo].[fn_diagramobjects]() 
	RETURNS int
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		declare @id_upgraddiagrams		int
		declare @id_sysdiagrams			int
		declare @id_helpdiagrams		int
		declare @id_helpdiagramdefinition	int
		declare @id_creatediagram	int
		declare @id_renamediagram	int
		declare @id_alterdiagram 	int 
		declare @id_dropdiagram		int
		declare @InstalledObjects	int

		select @InstalledObjects = 0

		select 	@id_upgraddiagrams = object_id(N'dbo.sp_upgraddiagrams'),
			@id_sysdiagrams = object_id(N'dbo.sysdiagrams'),
			@id_helpdiagrams = object_id(N'dbo.sp_helpdiagrams'),
			@id_helpdiagramdefinition = object_id(N'dbo.sp_helpdiagramdefinition'),
			@id_creatediagram = object_id(N'dbo.sp_creatediagram'),
			@id_renamediagram = object_id(N'dbo.sp_renamediagram'),
			@id_alterdiagram = object_id(N'dbo.sp_alterdiagram'), 
			@id_dropdiagram = object_id(N'dbo.sp_dropdiagram')

		if @id_upgraddiagrams is not null
			select @InstalledObjects = @InstalledObjects + 1
		if @id_sysdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 2
		if @id_helpdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 4
		if @id_helpdiagramdefinition is not null
			select @InstalledObjects = @InstalledObjects + 8
		if @id_creatediagram is not null
			select @InstalledObjects = @InstalledObjects + 16
		if @id_renamediagram is not null
			select @InstalledObjects = @InstalledObjects + 32
		if @id_alterdiagram  is not null
			select @InstalledObjects = @InstalledObjects + 64
		if @id_dropdiagram is not null
			select @InstalledObjects = @InstalledObjects + 128
		
		return @InstalledObjects 
	END
	
GO
/****** Object:  Table [dbo].[Actividad]    Script Date: 28/05/2019 16:56:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actividad](
	[actividad_id] [int] IDENTITY(1,1) NOT NULL,
	[semestre_id] [int] NOT NULL,
	[criterio_id] [int] NOT NULL,
	[nombre] [varchar](250) NOT NULL,
	[descripcion] [text] NULL,
	[fecha] [date] NULL,
	[urlactividad] [varchar](250) NULL,
	[estado] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[actividad_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[Asignacion]    Script Date: 28/05/2019 16:56:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asignacion](
	[asignacion_id] [int] IDENTITY(1,1) NOT NULL,
	[semestre_id] [int] NOT NULL,
	[titulo] [varchar](250) NOT NULL,
	[fecharegistro] [date] NULL,
	[estado] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[asignacion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[Control]    Script Date: 28/05/2019 16:56:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Control](
	[control_id] [int] IDENTITY(1,1) NOT NULL,
	[semestre_id] [int] NOT NULL,
	[titulo] [varchar](250) NOT NULL,
	[fechacreacion] [date] NULL,
	[estado] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[control_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[ControlAsignacion]    Script Date: 28/05/2019 16:56:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ControlAsignacion](
	[controlasignacion_id] [int] IDENTITY(1,1) NOT NULL,
	[control_id] [int] NOT NULL,
	[docente_id] [int] NOT NULL,
	[criterio_id] [int] NOT NULL,
	[fechaasignacion] [date] NULL,
	[fechaculminacion] [date] NULL,
	[duracion] [varchar](30) NULL,
	[sustento] [char](2) NOT NULL,
	[porcentaje] [char](4) NOT NULL,
	[condicion] [varchar](30) NOT NULL,
	[archivo] [varchar](250) NOT NULL,
	[observacion] [text] NULL,
	[estado] [varchar](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[controlasignacion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[Criterio]    Script Date: 28/05/2019 16:56:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Criterio](
	[criterio_id] [int] IDENTITY(1,1) NOT NULL,
	[modelo_id] [int] NOT NULL,
	[nombre_spanish] [varchar](250) NOT NULL,
	[nombre_english] [varchar](250) NOT NULL,
	[urlcriterio] [varchar](250) NULL,
	[descripcion] [text] NULL,
	[estado] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[criterio_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[DetalleAsignacion]    Script Date: 28/05/2019 16:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleAsignacion](
	[detalleasignacion_id] [int] IDENTITY(1,1) NOT NULL,
	[asignacion_id] [int] NOT NULL,
	[docente_id] [int] NOT NULL,
	[criterio_id] [int] NOT NULL,
	[estado] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[detalleasignacion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[Docente]    Script Date: 28/05/2019 16:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Docente](
	[docente_id] [int] IDENTITY(1,1) NOT NULL,
	[docente_codigo] [int] NOT NULL,
	[dni] [varchar](8) NOT NULL,
	[apellido] [varchar](100) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[sexo] [char](1) NOT NULL,
	[email] [varchar](100) NULL,
	[celular] [varchar](15) NULL,
	[cargo] [varchar](250) NOT NULL,
	[condicion] [varchar](30) NOT NULL,
	[categoria] [varchar](50) NOT NULL,
	[foto] [varchar](250) NULL,
	[estado] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[docente_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
UNIQUE NONCLUSTERED 
(
	[docente_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
UNIQUE NONCLUSTERED 
(
	[dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[Estudiante]    Script Date: 28/05/2019 16:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudiante](
	[estudiante_id] [int] IDENTITY(1,1) NOT NULL,
	[estudiante_codigo] [int] NOT NULL,
	[dni] [varchar](8) NOT NULL,
	[apellido] [varchar](100) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[sexo] [char](1) NOT NULL,
	[email] [varchar](100) NULL,
	[direccion] [varchar](250) NOT NULL,
	[celular] [varchar](15) NULL,
	[foto] [varchar](250) NULL,
	[estado] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[estudiante_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
UNIQUE NONCLUSTERED 
(
	[estudiante_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
UNIQUE NONCLUSTERED 
(
	[dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[EvidenciaActividad]    Script Date: 28/05/2019 16:56:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EvidenciaActividad](
	[evidenciaactividad_id] [int] IDENTITY(1,1) NOT NULL,
	[actividad_id] [int] NOT NULL,
	[archivo] [varchar](250) NOT NULL,
	[tamanio] [varchar](10) NOT NULL,
	[tipo] [varchar](10) NOT NULL,
	[descripcion] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[evidenciaactividad_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[EvidenciaCriterio]    Script Date: 28/05/2019 16:56:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EvidenciaCriterio](
	[evidencia_id] [int] IDENTITY(1,1) NOT NULL,
	[criterio_id] [int] NOT NULL,
	[archivo] [varchar](250) NOT NULL,
	[tamanio] [varchar](10) NOT NULL,
	[tipo] [varchar](10) NOT NULL,
	[descripcion] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[criterio_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[Modelo]    Script Date: 28/05/2019 16:56:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modelo](
	[modelo_id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](250) NOT NULL,
	[descripcion] [text] NULL,
	[estado] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[modelo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[Semestre]    Script Date: 28/05/2019 16:56:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semestre](
	[semestre_id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](250) NOT NULL,
	[anio] [int] NULL,
	[estado] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[semestre_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[sysdiagrams]    Script Date: 28/05/2019 16:56:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sysdiagrams](
	[name] [sysname] NOT NULL,
	[principal_id] [int] NOT NULL,
	[diagram_id] [int] IDENTITY(1,1) NOT NULL,
	[version] [int] NULL,
	[definition] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[diagram_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
 CONSTRAINT [UK_principal_name] UNIQUE NONCLUSTERED 
(
	[principal_id] ASC,
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 28/05/2019 16:56:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[usuario_id] [int] IDENTITY(1,1) NOT NULL,
	[docente_id] [int] NOT NULL,
	[nombre] [varchar](30) NOT NULL,
	[clave] [varchar](50) NOT NULL,
	[nivel] [varchar](20) NOT NULL,
	[avatar] [varchar](250) NULL,
	[estado] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
UNIQUE NONCLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
ALTER TABLE [dbo].[Actividad]  WITH CHECK ADD FOREIGN KEY([criterio_id])
REFERENCES [dbo].[Criterio] ([criterio_id])
GO
ALTER TABLE [dbo].[Actividad]  WITH CHECK ADD FOREIGN KEY([semestre_id])
REFERENCES [dbo].[Semestre] ([semestre_id])
GO
ALTER TABLE [dbo].[Asignacion]  WITH CHECK ADD  CONSTRAINT [FK_Asignacion_Semestre] FOREIGN KEY([semestre_id])
REFERENCES [dbo].[Semestre] ([semestre_id])
GO
ALTER TABLE [dbo].[Asignacion] CHECK CONSTRAINT [FK_Asignacion_Semestre]
GO
ALTER TABLE [dbo].[Control]  WITH CHECK ADD  CONSTRAINT [FK_Control_Semestre] FOREIGN KEY([semestre_id])
REFERENCES [dbo].[Semestre] ([semestre_id])
GO
ALTER TABLE [dbo].[Control] CHECK CONSTRAINT [FK_Control_Semestre]
GO
ALTER TABLE [dbo].[ControlAsignacion]  WITH CHECK ADD FOREIGN KEY([criterio_id])
REFERENCES [dbo].[Criterio] ([criterio_id])
GO
ALTER TABLE [dbo].[ControlAsignacion]  WITH CHECK ADD  CONSTRAINT [FK__ControlAs__detal__6D0D32F4] FOREIGN KEY([control_id])
REFERENCES [dbo].[Control] ([control_id])
GO
ALTER TABLE [dbo].[ControlAsignacion] CHECK CONSTRAINT [FK__ControlAs__detal__6D0D32F4]
GO
ALTER TABLE [dbo].[ControlAsignacion]  WITH CHECK ADD FOREIGN KEY([docente_id])
REFERENCES [dbo].[Docente] ([docente_id])
GO
ALTER TABLE [dbo].[Criterio]  WITH CHECK ADD FOREIGN KEY([modelo_id])
REFERENCES [dbo].[Modelo] ([modelo_id])
GO
ALTER TABLE [dbo].[DetalleAsignacion]  WITH CHECK ADD  CONSTRAINT [FK_DetalleAsignacion_Asignacion] FOREIGN KEY([asignacion_id])
REFERENCES [dbo].[Asignacion] ([asignacion_id])
GO
ALTER TABLE [dbo].[DetalleAsignacion] CHECK CONSTRAINT [FK_DetalleAsignacion_Asignacion]
GO
ALTER TABLE [dbo].[DetalleAsignacion]  WITH CHECK ADD  CONSTRAINT [FK_DetalleAsignacion_Criterio] FOREIGN KEY([criterio_id])
REFERENCES [dbo].[Criterio] ([criterio_id])
GO
ALTER TABLE [dbo].[DetalleAsignacion] CHECK CONSTRAINT [FK_DetalleAsignacion_Criterio]
GO
ALTER TABLE [dbo].[DetalleAsignacion]  WITH CHECK ADD  CONSTRAINT [FK_DetalleAsignacion_Docente] FOREIGN KEY([docente_id])
REFERENCES [dbo].[Docente] ([docente_id])
GO
ALTER TABLE [dbo].[DetalleAsignacion] CHECK CONSTRAINT [FK_DetalleAsignacion_Docente]
GO
ALTER TABLE [dbo].[EvidenciaActividad]  WITH CHECK ADD FOREIGN KEY([actividad_id])
REFERENCES [dbo].[Criterio] ([criterio_id])
GO
ALTER TABLE [dbo].[EvidenciaActividad]  WITH CHECK ADD  CONSTRAINT [FK_EvidenciaActividad_Actividad] FOREIGN KEY([actividad_id])
REFERENCES [dbo].[Actividad] ([actividad_id])
GO
ALTER TABLE [dbo].[EvidenciaActividad] CHECK CONSTRAINT [FK_EvidenciaActividad_Actividad]
GO
ALTER TABLE [dbo].[EvidenciaCriterio]  WITH CHECK ADD FOREIGN KEY([evidencia_id])
REFERENCES [dbo].[Criterio] ([criterio_id])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([docente_id])
REFERENCES [dbo].[Docente] ([docente_id])
GO
/****** Object:  StoredProcedure [dbo].[sp_alterdiagram]    Script Date: 28/05/2019 16:56:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_alterdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null,
		@version 	int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId 			int
		declare @retval 		int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @ShouldChangeUID	int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid ARG', 16, 1)
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();	 
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		revert;
	
		select @ShouldChangeUID = 0
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		
		if(@DiagId IS NULL or (@IsDbo = 0 and @theId <> @UIDFound))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end
	
		if(@IsDbo <> 0)
		begin
			if(@UIDFound is null or USER_NAME(@UIDFound) is null) -- invalid principal_id
			begin
				select @ShouldChangeUID = 1 ;
			end
		end

		-- update dds data			
		update dbo.sysdiagrams set definition = @definition where diagram_id = @DiagId ;

		-- change owner
		if(@ShouldChangeUID = 1)
			update dbo.sysdiagrams set principal_id = @theId where diagram_id = @DiagId ;

		-- update dds version
		if(@version is not null)
			update dbo.sysdiagrams set version = @version where diagram_id = @DiagId ;

		return 0
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_creatediagram]    Script Date: 28/05/2019 16:56:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_creatediagram]
	(
		@diagramname 	sysname,
		@owner_id		int	= null, 	
		@version 		int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId int
		declare @retval int
		declare @IsDbo	int
		declare @userName sysname
		if(@version is null or @diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID(); 
		select @IsDbo = IS_MEMBER(N'db_owner');
		revert; 
		
		if @owner_id is null
		begin
			select @owner_id = @theId;
		end
		else
		begin
			if @theId <> @owner_id
			begin
				if @IsDbo = 0
				begin
					RAISERROR (N'E_INVALIDARG', 16, 1);
					return -1
				end
				select @theId = @owner_id
			end
		end
		-- next 2 line only for test, will be removed after define name unique
		if EXISTS(select diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @diagramname)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end
	
		insert into dbo.sysdiagrams(name, principal_id , version, definition)
				VALUES(@diagramname, @theId, @version, @definition) ;
		
		select @retval = @@IDENTITY 
		return @retval
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_dropdiagram]    Script Date: 28/05/2019 16:56:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_dropdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT; 
		
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		delete from dbo.sysdiagrams where diagram_id = @DiagId;
	
		return 0;
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_helpdiagramdefinition]    Script Date: 28/05/2019 16:56:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_helpdiagramdefinition]
	(
		@diagramname 	sysname,
		@owner_id	int	= null 		
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		set nocount on

		declare @theId 		int
		declare @IsDbo 		int
		declare @DiagId		int
		declare @UIDFound	int
	
		if(@diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner');
		if(@owner_id is null)
			select @owner_id = @theId;
		revert; 
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname;
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId ))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end

		select version, definition FROM dbo.sysdiagrams where diagram_id = @DiagId ; 
		return 0
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_helpdiagrams]    Script Date: 28/05/2019 16:56:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_helpdiagrams]
	(
		@diagramname sysname = NULL,
		@owner_id int = NULL
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		DECLARE @user sysname
		DECLARE @dboLogin bit
		EXECUTE AS CALLER;
			SET @user = USER_NAME();
			SET @dboLogin = CONVERT(bit,IS_MEMBER('db_owner'));
		REVERT;
		SELECT
			[Database] = DB_NAME(),
			[Name] = name,
			[ID] = diagram_id,
			[Owner] = USER_NAME(principal_id),
			[OwnerID] = principal_id
		FROM
			sysdiagrams
		WHERE
			(@dboLogin = 1 OR USER_NAME(principal_id) = @user) AND
			(@diagramname IS NULL OR name = @diagramname) AND
			(@owner_id IS NULL OR principal_id = @owner_id)
		ORDER BY
			4, 5, 1
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_renamediagram]    Script Date: 28/05/2019 16:56:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_renamediagram]
	(
		@diagramname 		sysname,
		@owner_id		int	= null,
		@new_diagramname	sysname
	
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @DiagIdTarg		int
		declare @u_name			sysname
		if((@diagramname is null) or (@new_diagramname is null))
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT;
	
		select @u_name = USER_NAME(@owner_id)
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		-- if((@u_name is not null) and (@new_diagramname = @diagramname))	-- nothing will change
		--	return 0;
	
		if(@u_name is null)
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @new_diagramname
		else
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @owner_id and name = @new_diagramname
	
		if((@DiagIdTarg is not null) and  @DiagId <> @DiagIdTarg)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end		
	
		if(@u_name is null)
			update dbo.sysdiagrams set [name] = @new_diagramname, principal_id = @theId where diagram_id = @DiagId
		else
			update dbo.sysdiagrams set [name] = @new_diagramname where diagram_id = @DiagId
		return 0
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_upgraddiagrams]    Script Date: 28/05/2019 16:56:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_upgraddiagrams]
	AS
	BEGIN
		IF OBJECT_ID(N'dbo.sysdiagrams') IS NOT NULL
			return 0;
	
		CREATE TABLE dbo.sysdiagrams
		(
			name sysname NOT NULL,
			principal_id int NOT NULL,	-- we may change it to varbinary(85)
			diagram_id int PRIMARY KEY IDENTITY,
			version int,
	
			definition varbinary(max)
			CONSTRAINT UK_principal_name UNIQUE
			(
				principal_id,
				name
			)
		);


		/* Add this if we need to have some form of extended properties for diagrams */
		/*
		IF OBJECT_ID(N'dbo.sysdiagram_properties') IS NULL
		BEGIN
			CREATE TABLE dbo.sysdiagram_properties
			(
				diagram_id int,
				name sysname,
				value varbinary(max) NOT NULL
			)
		END
		*/

		IF OBJECT_ID(N'dbo.dtproperties') IS NOT NULL
		begin
			insert into dbo.sysdiagrams
			(
				[name],
				[principal_id],
				[version],
				[definition]
			)
			select	 
				convert(sysname, dgnm.[uvalue]),
				DATABASE_PRINCIPAL_ID(N'dbo'),			-- will change to the sid of sa
				0,							-- zero for old format, dgdef.[version],
				dgdef.[lvalue]
			from dbo.[dtproperties] dgnm
				inner join dbo.[dtproperties] dggd on dggd.[property] = 'DtgSchemaGUID' and dggd.[objectid] = dgnm.[objectid]	
				inner join dbo.[dtproperties] dgdef on dgdef.[property] = 'DtgSchemaDATA' and dgdef.[objectid] = dgnm.[objectid]
				
			where dgnm.[property] = 'DtgSchemaNAME' and dggd.[uvalue] like N'_EA3E6268-D998-11CE-9454-00AA00A3F36E_' 
			return 2;
		end
		return 1;
	END
	
GO
EXEC sys.sp_addextendedproperty @name=N'microsoft_database_tools_support', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sysdiagrams'
GO
USE [master]
GO
ALTER DATABASE [db_modelo] SET  READ_WRITE 
GO
