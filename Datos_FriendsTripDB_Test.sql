USE [FriendsTripDB_Test]
GO

SET IDENTITY_INSERT [dbo].[Pais] ON
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (1, N'Argentina')
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (2, N'Brasil')
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (3, N'Chile')
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (4, N'Uruguay')
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (5, N'Paraguay')
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (6, N'Colombia')
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (7, N'Ecuador')
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (8, N'Peru')
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (9, N'Estados Unidos')
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (10, N'Mexico')
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (11, N'Alemania')
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (12, N'Italia')
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (13, N'España')
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (14, N'Francia')
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (15, N'Inglaterra')
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (16, N'Portugal')
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (17, N'Holanda')
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (18, N'Rusia')
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (19, N'China')
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (20, N'Japon')
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (21, N'Corea del Sur')
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (22, N'Corea del Norte')
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (23, N'Nueva Zelanda')
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (24, N'Australia')
SET IDENTITY_INSERT [dbo].[Pais] OFF 

SET IDENTITY_INSERT [dbo].[Provincia] ON
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre],[IdPais]) VALUES (1, N'Buenos Aires',1)
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre],[IdPais]) VALUES (2, N'Cordoba',1)
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre],[IdPais]) VALUES (3, N'Mendoza',1)
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre],[IdPais]) VALUES (4, N'Misiones',1)
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre],[IdPais]) VALUES (5, N'Santa Cruz',1)
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre],[IdPais]) VALUES (6, N'Tierra del Fuego',1)
SET IDENTITY_INSERT [dbo].[Provincia] OFF 

SET IDENTITY_INSERT [dbo].[Ciudad] ON
INSERT [dbo].[Ciudad] ([IdCiudad], [Nombre],[IdProvincia]) VALUES (1, N'CABA',1)
INSERT [dbo].[Ciudad] ([IdCiudad], [Nombre],[IdProvincia]) VALUES (2, N'El Calafate',5)
INSERT [dbo].[Ciudad] ([IdCiudad], [Nombre],[IdProvincia]) VALUES (3, N'Usuahia',6)
INSERT [dbo].[Ciudad] ([IdCiudad], [Nombre],[IdProvincia]) VALUES (4, N'Iguazu',4)
INSERT [dbo].[Ciudad] ([IdCiudad], [Nombre],[IdProvincia]) VALUES (5, N'Cordoba',2)
SET IDENTITY_INSERT [dbo].[Ciudad] OFF 


--Usuarios Nuevos
SET IDENTITY_INSERT [dbo].[Usuario] ON
INSERT [dbo].[Usuario] ([IdUsuario],[NombreUsuario],[Nombre],[Apellido],[Edad],[Password],[Email],[IdRol],[MatriculaGuia],[Descripcion],[Nacionalidad],[UrlFotoPerfil],[Calificacion])
 VALUES (1,N'Admin',N'Admin',N'Admin',31,N'�gB��\v��U�g�6#ȳ��E��x��F�',N'admin@friendstrip.com.ar',1,NULL,NULL,1,'/Content/img/avatar/avatar_2x.png',NULL)
--Viajeros, Rol 3
INSERT [dbo].[Usuario] ([IdUsuario],[NombreUsuario],[Nombre],[Apellido],[Edad],[Password],[Email],[IdRol],[MatriculaGuia],[Descripcion],[Nacionalidad],[UrlFotoPerfil],[Calificacion])
 VALUES (2,N'Maria',N'Maria',N'Rodriguez',30,N'�gB��\v��U�g�6#ȳ��E��x��F�',N'maria@gmail.com',3,NULL,NULL,1,'/Content/img/avatar/maria.jpg',NULL)
 INSERT [dbo].[Usuario] ([IdUsuario],[NombreUsuario],[Nombre],[Apellido],[Edad],[Password],[Email],[IdRol],[MatriculaGuia],[Descripcion],[Nacionalidad],[UrlFotoPerfil],[Calificacion])
 VALUES (3,N'Juan',N'Juan',N'Perez',30,N'�gB��\v��U�g�6#ȳ��E��x��F�',N'juan@gmail.com',3,NULL,NULL,1,'/Content/img/avatar/juan.jpg',NULL)
--Agencias, Rol 2
INSERT [dbo].[Usuario] ([IdUsuario],[NombreUsuario],[Nombre],[Apellido],[Edad],[Password],[Email],[IdRol],[MatriculaGuia],[Descripcion],[Nacionalidad],[UrlFotoPerfil],[Calificacion]) 
VALUES (4,N'Sunway',N'Sunway',N'srl',5,N'�gB��\v��U�g�6#ȳ��E��x��F�',N'sunway@gmail.com',2,NULL,'Ofrecemos viajes hace mas de 20 años',1,'/Content/img/avatar/sunway.jpg',NULL)
INSERT [dbo].[Usuario] ([IdUsuario],[NombreUsuario],[Nombre],[Apellido],[Edad],[Password],[Email],[IdRol],[MatriculaGuia],[Descripcion],[Nacionalidad],[UrlFotoPerfil],[Calificacion]) 
VALUES (5,N'Altus',N'Altus',N'srl',10,N'�gB��\v��U�g�6#ȳ��E��x��F�',N'altus@gmail.com',2,NULL,'Tu proxima aventura esta en Altus',1,'/Content/img/avatar/altus.jpg',NULL)
INSERT [dbo].[Usuario] ([IdUsuario],[NombreUsuario],[Nombre],[Apellido],[Edad],[Password],[Email],[IdRol],[MatriculaGuia],[Descripcion],[Nacionalidad],[UrlFotoPerfil],[Calificacion]) 
VALUES (6,N'TerraMar',N'TerraMar',N'srl',2,N'�gB��\v��U�g�6#ȳ��E��x��F�',N'terramar@gmail.com',2,NULL,'Las mejores ofertas y asesoramiento',1,'/Content/img/avatar/terramar.jpg',NULL)
--Guia turistico, Rol 4
INSERT [dbo].[Usuario] ([IdUsuario],[NombreUsuario],[Nombre],[Apellido],[Edad],[Password],[Email],[IdRol],[MatriculaGuia],[Descripcion],[Nacionalidad],[UrlFotoPerfil],[Calificacion])
 VALUES (7,N'Pedro',N'Pedro',N'Gonzales',27,N'�gB��\v��U�g�6#ȳ��E��x��F�',N'pedro@gmail.com',4,NULL,NULL,1,'/Content/img/avatar/pedro.jpg',NULL)
 INSERT [dbo].[Usuario] ([IdUsuario],[NombreUsuario],[Nombre],[Apellido],[Edad],[Password],[Email],[IdRol],[MatriculaGuia],[Descripcion],[Nacionalidad],[UrlFotoPerfil],[Calificacion])
 VALUES (8,N'Ana',N'Ana',N'Vasquez',27,N'�gB��\v��U�g�6#ȳ��E��x��F�',N'ana@gmail.com',4,NULL,NULL,1,'/Content/img/avatar/ana.jpg',NULL)
SET IDENTITY_INSERT [dbo].[Usuario] OFF

--Usuarios de antes
SET IDENTITY_INSERT [dbo].[Usuario] ON
INSERT [dbo].[Usuario] ([IdUsuario],[NombreUsuario],[Nombre],[Apellido],[Edad],[Password],[Email],[IdRol],[MatriculaGuia],[Descripcion],[Nacionalidad],[UrlFotoPerfil],[Calificacion]) 
VALUES (9,N'lucho',N'Luis',N'Cabrera',31,N'�gB��\v��U�g�6#ȳ��E��x��F�',N'lucho@friendstrip.com.ar',1,NULL,NULL,1,'/Content/img/avatar/lucho.jpg',NULL)
INSERT [dbo].[Usuario] ([IdUsuario],[NombreUsuario],[Nombre],[Apellido],[Edad],[Password],[Email],[IdRol],[MatriculaGuia],[Descripcion],[Nacionalidad],[UrlFotoPerfil],[Calificacion]) 
VALUES (10,N'laura',N'Laura',N'Ramos',30,N'�gB��\v��U�g�6#ȳ��E��x��F�',N'laura@friendstrip.com.ar',1,NULL,NULL,1,'/Content/img/avatar/laura.jpg',NULL)
INSERT [dbo].[Usuario] ([IdUsuario],[NombreUsuario],[Nombre],[Apellido],[Edad],[Password],[Email],[IdRol],[MatriculaGuia],[Descripcion],[Nacionalidad],[UrlFotoPerfil],[Calificacion]) 
VALUES (11,N'nico',N'Nicolas',N'Cardozo',28,N'�gB��\v��U�g�6#ȳ��E��x��F�',N'nico@friendstrip.com.ar',3,NULL,NULL,1,'/Content/img/avatar/nico.jpg',NULL)
INSERT [dbo].[Usuario] ([IdUsuario],[NombreUsuario],[Nombre],[Apellido],[Edad],[Password],[Email],[IdRol],[MatriculaGuia],[Descripcion],[Nacionalidad],[UrlFotoPerfil],[Calificacion]) 
VALUES (12,N'gaston',N'Gaston',N'DAdamo',27,N'�gB��\v��U�g�6#ȳ��E��x��F�',N'gaston@friendstrip.com.ar',3,NULL,NULL,1,'/Content/img/avatar/gaston.jpg',NULL)
SET IDENTITY_INSERT [dbo].[Usuario] OFF

SET IDENTITY_INSERT [dbo].[Viaje] ON 
INSERT [dbo].[Viaje] ([IdViaje], [Alojamiento],[Aerolinea],[NumeroVuelo],[FechaDesde],[FechaHasta],[IdUsuario],[IdOrigen],[IdDestino],[InteresActividades],[InteresExcursiones],[InteresTraslados],[InteresAmistades],[InteresAlojamiento],[InteresOtros]) VALUES (1, N'Nuevo Hotel', N'Aerolineas Argentinas', N'ARG1732', '2018-01-01 00:00:00.000', NULL, 1, 1, 3, 1, 1, 0, 1, 0, 0)
INSERT [dbo].[Viaje] ([IdViaje], [Alojamiento],[Aerolinea],[NumeroVuelo],[FechaDesde],[FechaHasta],[IdUsuario],[IdOrigen],[IdDestino],[InteresActividades],[InteresExcursiones],[InteresTraslados],[InteresAmistades],[InteresAlojamiento],[InteresOtros]) VALUES (2, N'Viejo Hotel', N'Aerolineas Argentinas', N'ARG1824', '2019-06-09 23:21:31.000', NULL, 2, 1, 4, 0, 1, 0, 1, 1, 0)
INSERT [dbo].[Viaje] ([IdViaje], [Alojamiento],[Aerolinea],[NumeroVuelo],[FechaDesde],[FechaHasta],[IdUsuario],[IdOrigen],[IdDestino],[InteresActividades],[InteresExcursiones],[InteresTraslados],[InteresAmistades],[InteresAlojamiento],[InteresOtros]) VALUES (3, N'Gran Iguazu', N'Aerolineas Argentinas', N'ARG1852', '2019-06-09 23:21:31.000', NULL, 3, 1, 3, 1, 1, 0, 0, 0, 1)
INSERT [dbo].[Viaje] ([IdViaje], [Alojamiento],[Aerolinea],[NumeroVuelo],[FechaDesde],[FechaHasta],[IdUsuario],[IdOrigen],[IdDestino],[InteresActividades],[InteresExcursiones],[InteresTraslados],[InteresAmistades],[InteresAlojamiento],[InteresOtros]) VALUES (4, N'Gran Iguazu', N'Aerolineas Argentinas', N'ARG1852', '2018-01-01 00:00:00.000', NULL, 4, 1, 3, 0, 1, 0, 0, 1, 0)
SET IDENTITY_INSERT [dbo].[Viaje] OFF 

INSERT [dbo].[AmistadUsuario] ([IdResponsable], [IdSeguido], [Estado], [FechaCoincidencia]) VALUES (1, 2, 'ACEPTADO','2019-01-01 00:00:00.000')
INSERT [dbo].[AmistadUsuario] ([IdResponsable], [IdSeguido], [Estado], [FechaCoincidencia]) VALUES (2, 4, 'ACEPTADO','2019-01-05 00:00:00.000')
INSERT [dbo].[AmistadUsuario] ([IdResponsable], [IdSeguido], [Estado], [FechaCoincidencia]) VALUES (3, 1, 'ACEPTADO','2019-06-01 00:00:00.000')
INSERT [dbo].[AmistadUsuario] ([IdResponsable], [IdSeguido], [Estado], [FechaCoincidencia]) VALUES (1, 3, 'PENDIENTE','2019-06-05 00:00:00.000')
INSERT [dbo].[AmistadUsuario] ([IdResponsable], [IdSeguido], [Estado], [FechaCoincidencia]) VALUES (3, 2, 'ACEPTADO','2019-06-05 00:00:00.000')
INSERT [dbo].[AmistadUsuario] ([IdResponsable], [IdSeguido], [Estado], [FechaCoincidencia]) VALUES (4, 2, 'PENDIENTE','2019-06-05 00:00:00.000')
INSERT [dbo].[AmistadUsuario] ([IdResponsable], [IdSeguido], [Estado], [FechaCoincidencia]) VALUES (7, 2, 'PENDIENTE','2019-06-05 00:00:00.000')

INSERT [dbo].[UsuarioViaje] ([IdUsuario], [IdViaje]) VALUES (1, 1)
INSERT [dbo].[UsuarioViaje] ([IdUsuario], [IdViaje]) VALUES (2, 2)
INSERT [dbo].[UsuarioViaje] ([IdUsuario], [IdViaje]) VALUES (3, 3)
INSERT [dbo].[UsuarioViaje] ([IdUsuario], [IdViaje]) VALUES (4, 4)
INSERT [dbo].[UsuarioViaje] ([IdUsuario], [IdViaje]) VALUES (1, 2)


--Publicaciondes de las agencias
SET IDENTITY_INSERT [dbo].[Publicacion] ON
INSERT [dbo].[Publicacion] ([IdPublicacion],[Titulo],[Descripcion],[UrlFoto],[FechaDesde] ,[FechaHasta],[IdUsuario])
				VALUES (1,N'BSAS en grupo ',N'Conocé una Buenos Aires Diferente.Recorre todo el centro porteño en un solo dia','/Content/img/avatar/bsas.jpg','2019-01-01 00:00:00.000',NULL,5)				
INSERT [dbo].[Publicacion] ([IdPublicacion],[Titulo],[Descripcion],[UrlFoto],[FechaDesde] ,[FechaHasta],[IdUsuario])
				VALUES (2,N'Conoce La Boca ',N' Caminito es un callejón museo y un pasaje tradicional, de gran valor cultural y turístico, ubicado en el barrio de La Boca de la ciudad de Buenos Aires, Argentina. El lugar adquirió significado cultural debido a que inspiró la música de Tango','/Content/img/avatar/laboca.jpg','2019-01-01 00:00:00.000',NULL,5)
INSERT [dbo].[Publicacion] ([IdPublicacion],[Titulo],[Descripcion],[UrlFoto],[FechaDesde] ,[FechaHasta],[IdUsuario])
				VALUES (4,N'Viaje a las Cataratas ',N'Recorrido por el parque nacional Iguazu del lado argentino y Foz Iguazu del lado brasilero. Veni a conocer una de las maravillas del mundo','/Content/img/avatar/cataratas.jpg','2019-01-01 00:00:00.000',NULL,4)
INSERT [dbo].[Publicacion] ([IdPublicacion],[Titulo],[Descripcion],[UrlFoto],[FechaDesde] ,[FechaHasta],[IdUsuario])
				VALUES (5,N'Cordoba-Mina Clavero',N'Excursiones y hospedaje para vos y toda tu familia. El mejor precio encontralo con nosotros.Mina Clavero es un pueblo de la Provincia de Córdoba, Argentina','/Content/img/avatar/minaclavero.jpg','2019-01-01 00:00:00.000',NULL,6)
INSERT [dbo].[Publicacion] ([IdPublicacion],[Titulo],[Descripcion],[UrlFoto],[FechaDesde] ,[FechaHasta],[IdUsuario])
				VALUES (3,N'Termas de Colon',N'Veni a conocer Colon Entre Rios.Estos baños termales son altamente positivos para el agotamiento nervioso y psíquico (stress). La piel resulta altamente tonificada y rejuvenecida dándole suavidad y elasticidad.','/Content/img/avatar/termascolon.jpg','2019-01-01 00:00:00.000',NULL,4)
 SET IDENTITY_INSERT [dbo].[Publicacion] OFF

