USE [master]
GO

--drop database [FriendsTripDB]
/*Creacion DB FriendsTrip*/
CREATE DATABASE [FriendsTripDB_Test]
GO

/*Al momento de implementar el proyecto averiguar que compatibility level 
conviene mas, en ambiente de desarrollo usamos 100 sql server 2008 o + */
ALTER DATABASE [FriendsTripDB_Test] SET COMPATIBILITY_LEVEL = 100
GO

USE [FriendsTripDB_Test]
GO

/*Para consultas que contengan null, activo ansi_nulls*/
SET ANSI_NULLS ON
GO

/*Ordena de manera predeterminada por claves de identidad*/
SET QUOTED_IDENTIFIER ON
GO

/*Tabla Usuario*/
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [bigint] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nvarchar](100) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Apellido] [nvarchar](100) NULL,
	[Edad] [int] NULL,
	[Password] [nvarchar](256) NOT NULL,
	[Email] [nvarchar](300) NOT NULL,
	[IdRol] [bigint] NOT NULL,
	[MatriculaGuia] [nvarchar](100) NULL,
	[Descripcion] [nvarchar](300) NULL,
	[Nacionalidad] [bigint] NOT NULL,
	[UrlFotoPerfil] [nvarchar](200) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*Tabla Viaje*/
CREATE TABLE [dbo].[Viaje](
	[IdViaje] [bigint] IDENTITY(1,1) NOT NULL,
	[Alojamiento] [nvarchar](200) NULL,	
	[Aerolinea] [nvarchar](200) NULL,
	[NumeroVuelo] [nvarchar](50) NULL,
	[FechaDesde] [datetime] NOT NULL,
	[FechaHasta] [datetime] NULL,
	[IdUsuario] [bigint] NULL,
	[IdOrigen] [bigint] NOT NULL,
	[IdDestino] [bigint] NOT NULL,
	[InteresActividades] [bit] NULL,
	[InteresExcursiones] [bit] null,
	[InteresTraslados] [bit] NULL,
	[InteresAmistades] [bit] NULL,
	[InteresAlojamiento] [bit] NULL,
	[InteresOtros] [bit] NULL,
 CONSTRAINT [PK_Viaje] PRIMARY KEY CLUSTERED 
(
	[IdViaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*Tabla Publicacion*/

CREATE TABLE [dbo].[Publicacion](
	[IdPublicacion] [bigint] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](300) NOT NULL,
	[UrlFoto] [nvarchar](200) NULL,
	[FechaDesde] [datetime] NOT NULL,
	[FechaHasta] [datetime] NULL,
	[IdUsuario] [bigint] NOT NULL,
 CONSTRAINT [PK_Publicacion] PRIMARY KEY CLUSTERED 
(
	[IdPublicacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*Tabla Ciudad*/
CREATE TABLE [dbo].[Ciudad](
	[IdCiudad] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](200) NULL,
	[IdProvincia] [bigint] NOT NULL,
 CONSTRAINT [IdCiudad] PRIMARY KEY CLUSTERED 
(
	[IdCiudad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*Tabla Provincia*/
CREATE TABLE [dbo].[Provincia](
	[IdProvincia] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](200) NULL,
	[IdPais] [bigint] NOT NULL,
 CONSTRAINT [IdProvincia] PRIMARY KEY CLUSTERED 
(
	[IdProvincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*Tabla Pais*/
CREATE TABLE [dbo].[Pais](
	[IdPais] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](200) NULL,
 CONSTRAINT [IdPais] PRIMARY KEY CLUSTERED 
(
	[IdPais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*Tabla usuario usuario, donde se guardaran las coincidencias*/
CREATE TABLE [dbo].[AmistadUsuario](
	[IdResponsable] [bigint] NOT NULL,
	[IdSeguido] [bigint] NOT NULL,
	[Estado] [nvarchar](200) NOT NULL,
	[FechaCoincidencia] [datetime] NOT NULL,
 CONSTRAINT [PK_AmistadUsuario] PRIMARY KEY CLUSTERED 
(
	[IdResponsable] ASC,
	[IdSeguido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*Tabla usuario viaje*/
CREATE TABLE [dbo].[UsuarioViaje](
	[IdUsuario] [bigint] NOT NULL,
	[IdViaje] [bigint] NOT NULL,
 CONSTRAINT [PK_UsuarioViaje] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC,
	[IdViaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*RELACIONES*/

/*Creo la relacion n a n usuario usuaro*/
ALTER TABLE [dbo].[AmistadUsuario]  WITH CHECK ADD  CONSTRAINT [FK_Amistad_UsuarioUno] FOREIGN KEY([IdResponsable])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO

ALTER TABLE [dbo].[AmistadUsuario]  WITH CHECK ADD  CONSTRAINT [FK_Amistad_UsuarioDos] FOREIGN KEY([IdSeguido])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO


/*Creo la relacion n a n usuario viaje*/
ALTER TABLE [dbo].[UsuarioViaje]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioViaje] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[UsuarioViaje]  WITH CHECK ADD  CONSTRAINT [FK_Viaje_Usuario] FOREIGN KEY([IdViaje])
REFERENCES [dbo].[Viaje] ([IdViaje])
GO

/*relacion 1 a n usuario publicacion*/

ALTER TABLE [dbo].[Publicacion]  WITH CHECK ADD  CONSTRAINT [FK_Publicacion_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO

/*relacion 1 a n viaje destino (ciudad)*/
ALTER TABLE [dbo].[Viaje]  WITH CHECK ADD  CONSTRAINT [FK_Viaje_Destino] FOREIGN KEY([IdDestino])
REFERENCES [dbo].[Ciudad] ([IdCiudad])
GO

/*relacion 1 a n ciudad provincia*/
ALTER TABLE [dbo].[Ciudad]  WITH CHECK ADD  CONSTRAINT [FK_Ciudad_Provincia] FOREIGN KEY([IdProvincia])
REFERENCES [dbo].[Provincia] ([IdProvincia])

/*relacion 1 a n provincia pais*/
ALTER TABLE [dbo].[Provincia]  WITH CHECK ADD  CONSTRAINT [FK_Provincia_Pais] FOREIGN KEY([IdPais])
REFERENCES [dbo].[Pais] ([IdPais])
GO

/*relacion 1 a n viaje origen (ciudad)*/
ALTER TABLE [dbo].[Viaje]  WITH CHECK ADD  CONSTRAINT [FK_Viaje_Origen] FOREIGN KEY([IdOrigen])
REFERENCES [dbo].[Ciudad] ([IdCiudad])
GO

/*relacion 1 a n usuario nacionalidad*/
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Nacionalidad] FOREIGN KEY([Nacionalidad])
REFERENCES [dbo].[Ciudad] ([IdCiudad])
GO