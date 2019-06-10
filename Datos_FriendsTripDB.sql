USE [FriendsTripDB]
GO

SET IDENTITY_INSERT [dbo].[Pais] ON
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (1, N'Argentina')
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (2, N'Brasil')
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (3, N'Chile')
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (4, N'Uruguay')
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
INSERT [dbo].[Ciudad] ([IdCiudad], [Nombre],[IdProvincia]) VALUES (3, N'Ushuahia',6)
INSERT [dbo].[Ciudad] ([IdCiudad], [Nombre],[IdProvincia]) VALUES (4, N'Iguazu',4)
INSERT [dbo].[Ciudad] ([IdCiudad], [Nombre],[IdProvincia]) VALUES (5, N'Cordoba',2)
SET IDENTITY_INSERT [dbo].[Ciudad] OFF 

SET IDENTITY_INSERT [dbo].[Usuario] ON
INSERT [dbo].[Usuario] ([IdUsuario],[NombreUsuario],[Nombre],[Apellido],[Edad],[Password],[Email],[IdRol],[MatriculaGuia],[Descripcion],[Nacionalidad]) VALUES (1,N'lucho',N'Luis',N'Cabrera',31,N'lucho1234',N'lucho@friendstrip.com.ar',1,NULL,NULL,1)
INSERT [dbo].[Usuario] ([IdUsuario],[NombreUsuario],[Nombre],[Apellido],[Edad],[Password],[Email],[IdRol],[MatriculaGuia],[Descripcion],[Nacionalidad]) VALUES (2,N'laura',N'Laura',N'Ramos',30,N'laura1234',N'laura@friendstrip.com.ar',1,NULL,NULL,1)
INSERT [dbo].[Usuario] ([IdUsuario],[NombreUsuario],[Nombre],[Apellido],[Edad],[Password],[Email],[IdRol],[MatriculaGuia],[Descripcion],[Nacionalidad]) VALUES (3,N'nico',N'Nicolas',N'Cardozo',28,N'nico1234',N'nico@friendstrip.com.ar',2,NULL,NULL,1)
INSERT [dbo].[Usuario] ([IdUsuario],[NombreUsuario],[Nombre],[Apellido],[Edad],[Password],[Email],[IdRol],[MatriculaGuia],[Descripcion],[Nacionalidad]) VALUES (4,N'gaston',N'Gaston',N'DAdamo',27,N'gaston1234',N'gaston@friendstrip.com.ar',3,NULL,NULL,1)
SET IDENTITY_INSERT [dbo].[Usuario] OFF

SET IDENTITY_INSERT [dbo].[Viaje] ON 
INSERT [dbo].[Viaje] ([IdViaje], [Alojamiento],[Aerolinea],[NumeroVuelo],[FechaDesde],[FechaHasta],[IdUsuario],[IdOrigen],[IdDestino],[InteresActividades],[InteresExcursiones],[InteresTraslados],[InteresAmistades],[InteresAlojamiento],[InteresOtros]) VALUES (1, N'Nuevo Hotel', N'Aerolineas Argentinas', N'ARG1732', '2018-01-01 00:00:00.000', NULL, 1, 1, 3, 1, 1, 0, 1, 0, 0)
INSERT [dbo].[Viaje] ([IdViaje], [Alojamiento],[Aerolinea],[NumeroVuelo],[FechaDesde],[FechaHasta],[IdUsuario],[IdOrigen],[IdDestino],[InteresActividades],[InteresExcursiones],[InteresTraslados],[InteresAmistades],[InteresAlojamiento],[InteresOtros]) VALUES (2, N'Viejo Hotel', N'Aerolineas Argentinas', N'ARG1824', '2019-06-09 23:21:31.000', NULL, 2, 1, 4, 0, 1, 0, 1, 1, 0)
INSERT [dbo].[Viaje] ([IdViaje], [Alojamiento],[Aerolinea],[NumeroVuelo],[FechaDesde],[FechaHasta],[IdUsuario],[IdOrigen],[IdDestino],[InteresActividades],[InteresExcursiones],[InteresTraslados],[InteresAmistades],[InteresAlojamiento],[InteresOtros]) VALUES (3, N'Gran Iguazu', N'Aerolineas Argentinas', N'ARG1852', '2019-06-09 23:21:31.000', NULL, 3, 1, 3, 1, 1, 0, 0, 0, 1)
INSERT [dbo].[Viaje] ([IdViaje], [Alojamiento],[Aerolinea],[NumeroVuelo],[FechaDesde],[FechaHasta],[IdUsuario],[IdOrigen],[IdDestino],[InteresActividades],[InteresExcursiones],[InteresTraslados],[InteresAmistades],[InteresAlojamiento],[InteresOtros]) VALUES (4, N'Gran Iguazu', N'Aerolineas Argentinas', N'ARG1852', '2018-01-01 00:00:00.000', NULL, 4, 1, 3, 0, 1, 0, 0, 1, 0)
SET IDENTITY_INSERT [dbo].[Viaje] OFF 


INSERT [dbo].[AmistadUsuario] ([IdUsuarioUno], [IdUsuarioDos]) VALUES (1, 2)
INSERT [dbo].[AmistadUsuario] ([IdUsuarioUno], [IdUsuarioDos]) VALUES (2, 1)
INSERT [dbo].[AmistadUsuario] ([IdUsuarioUno], [IdUsuarioDos]) VALUES (3, 1)
INSERT [dbo].[AmistadUsuario] ([IdUsuarioUno], [IdUsuarioDos]) VALUES (1, 3)

INSERT [dbo].[UsuarioViaje] ([IdUsuario], [IdViaje]) VALUES (1, 1)
INSERT [dbo].[UsuarioViaje] ([IdUsuario], [IdViaje]) VALUES (2, 2)
INSERT [dbo].[UsuarioViaje] ([IdUsuario], [IdViaje]) VALUES (3, 3)
INSERT [dbo].[UsuarioViaje] ([IdUsuario], [IdViaje]) VALUES (4, 4)
INSERT [dbo].[UsuarioViaje] ([IdUsuario], [IdViaje]) VALUES (1, 2)
