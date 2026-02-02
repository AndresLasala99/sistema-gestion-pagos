
SET IDENTITY_INSERT [dbo].[Equipos] ON 
GO
INSERT [dbo].[Equipos] ([Id], [Nombre]) VALUES (1, N'Equipo Artigas')
GO
INSERT [dbo].[Equipos] ([Id], [Nombre]) VALUES (2, N'Equipo Salto')
GO
INSERT [dbo].[Equipos] ([Id], [Nombre]) VALUES (3, N'Equipo Paysandú')
GO
INSERT [dbo].[Equipos] ([Id], [Nombre]) VALUES (4, N'Equipo Colonia')
GO
INSERT [dbo].[Equipos] ([Id], [Nombre]) VALUES (5, N'Equipo Maldonado')
GO
INSERT [dbo].[Equipos] ([Id], [Nombre]) VALUES (6, N'Equipo Rocha')
GO
INSERT [dbo].[Equipos] ([Id], [Nombre]) VALUES (7, N'Equipo Rivera')
GO
INSERT [dbo].[Equipos] ([Id], [Nombre]) VALUES (8, N'Equipo Tacuarembó')
GO
INSERT [dbo].[Equipos] ([Id], [Nombre]) VALUES (9, N'Equipo Canelones')
GO
INSERT [dbo].[Equipos] ([Id], [Nombre]) VALUES (10, N'Equipo Flores')
GO
SET IDENTITY_INSERT [dbo].[Equipos] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 
GO
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Pass], [Mail], [Rol], [IdEquipo]) VALUES (1, N'Ana', N'Pérez', N'gerente1', N'anaper@laempresa.com', 1, 1)
GO
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Pass], [Mail], [Rol], [IdEquipo]) VALUES (2, N'Bruno', N'García', N'admin123', N'brugar@laempresa.com', 0, 2)
GO
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Pass], [Mail], [Rol], [IdEquipo]) VALUES (3, N'Carla', N'Rodríguez', N'emple123', N'carrod@laempresa.com', 2, 3)
GO
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Pass], [Mail], [Rol], [IdEquipo]) VALUES (4, N'Diego', N'Fernández', N'emple1234', N'diefer@laempresa.com', 2, 4)
GO
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Pass], [Mail], [Rol], [IdEquipo]) VALUES (5, N'Elena', N'Martínez', N'gerente12', N'elemar@laempresa.com', 1, 5)
GO
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Pass], [Mail], [Rol], [IdEquipo]) VALUES (6, N'Facundo', N'Suárez', N'admin1234', N'facsua@laempresa.com', 0, 6)
GO
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Pass], [Mail], [Rol], [IdEquipo]) VALUES (7, N'Gisela', N'López', N'emple12345', N'gislop@laempresa.com', 2, 7)
GO
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Pass], [Mail], [Rol], [IdEquipo]) VALUES (8, N'Hernán', N'Silva', N'emple123456', N'hersil@laempresa.com', 2, 8)
GO
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Pass], [Mail], [Rol], [IdEquipo]) VALUES (9, N'Irene', N'Castro', N'admin12345', N'irecas@laempresa.com', 0, 9)
GO
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Pass], [Mail], [Rol], [IdEquipo]) VALUES (10, N'Joaquín', N'Ramos', N'5h22F5jYYJ', N'joaram@laempresa.com', 2, 10)
GO
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Pass], [Mail], [Rol], [IdEquipo]) VALUES (11, N'Andres', N'Lasala', N'empleado123', N'andlas@laempresa.com', 2, 5)
GO
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Pass], [Mail], [Rol], [IdEquipo]) VALUES (12, N'Bruno', N'Lasala', N'bruno123', N'brulas@laempresa.com', 1, 6)
GO
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Pass], [Mail], [Rol], [IdEquipo]) VALUES (13, N'anamaria', N'pereira', N'gerente2', N'anaper1630@laempresa.com', 1, 10)
GO
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Pass], [Mail], [Rol], [IdEquipo]) VALUES (14, N'Anderson', N'Lassaro', N'gerente9', N'andlas8485@laempresa.com', 1, 9)
GO
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Pass], [Mail], [Rol], [IdEquipo]) VALUES (15, N'ultima', N'prueba', N'ultimaprueba', N'ultpru@laempresa.com', 2, 1)
GO
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Pass], [Mail], [Rol], [IdEquipo]) VALUES (16, N'ultima prueba2', N'ultima prueba2', N'ultimaprueba2', N'ultult@laempresa.com', 2, 1)
GO
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Pass], [Mail], [Rol], [IdEquipo]) VALUES (17, N'Fernando', N'Nuñez', N'empleado1', N'fernun@laempresa.com', 2, 1)
GO
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Pass], [Mail], [Rol], [IdEquipo]) VALUES (18, N'Fernanda', N'Nuñez', N'empleado1', N'fernun1824@laempresa.com', 2, 1)
GO
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
SET IDENTITY_INSERT [dbo].[Gastos] ON 
GO
INSERT [dbo].[Gastos] ([Id], [Nombre], [Descripcion]) VALUES (1, N'Internet', N'Servicio mensual de internet oficina')
GO
INSERT [dbo].[Gastos] ([Id], [Nombre], [Descripcion]) VALUES (2, N'Luz', N'Factura de UTE')
GO
INSERT [dbo].[Gastos] ([Id], [Nombre], [Descripcion]) VALUES (3, N'Agua', N'Factura de OSE')
GO
INSERT [dbo].[Gastos] ([Id], [Nombre], [Descripcion]) VALUES (4, N'Transporte', N'Traslados del equipo')
GO
INSERT [dbo].[Gastos] ([Id], [Nombre], [Descripcion]) VALUES (5, N'Viáticos', N'Viáticos por reuniones')
GO
INSERT [dbo].[Gastos] ([Id], [Nombre], [Descripcion]) VALUES (6, N'Suministros', N'Artículos de oficina y limpieza')
GO
INSERT [dbo].[Gastos] ([Id], [Nombre], [Descripcion]) VALUES (7, N'Publicidad', N'Campañas en redes')
GO
INSERT [dbo].[Gastos] ([Id], [Nombre], [Descripcion]) VALUES (8, N'Mantenimiento', N'Mantenimiento de equipos')
GO
INSERT [dbo].[Gastos] ([Id], [Nombre], [Descripcion]) VALUES (9, N'Capacitación', N'Cursos y talleres')
GO
INSERT [dbo].[Gastos] ([Id], [Nombre], [Descripcion]) VALUES (10, N'Alquiler', N'Alquiler de oficina')
GO
SET IDENTITY_INSERT [dbo].[Gastos] OFF
GO
SET IDENTITY_INSERT [dbo].[Pagos] ON 
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (1, 1, 1, 1, N'Pago internet agosto', 1800, N'Unico', NULL, NULL, CAST(N'2025-08-05T00:00:00.0000000' AS DateTime2), 10001)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (2, 0, 2, 2, N'Pago luz agosto', 4200.5, N'Unico', NULL, NULL, CAST(N'2025-08-10T00:00:00.0000000' AS DateTime2), 10002)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (3, 1, 4, 3, N'Traslado reunión cliente', 950, N'Unico', NULL, NULL, CAST(N'2025-09-01T00:00:00.0000000' AS DateTime2), 10003)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (4, 1, 6, 5, N'Compra resmas y lapiceras', 1350.75, N'Unico', NULL, NULL, CAST(N'2025-09-12T00:00:00.0000000' AS DateTime2), 10004)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (5, 0, 10, 9, N'Alquiler setiembre', 35000, N'Unico', NULL, NULL, CAST(N'2025-09-03T00:00:00.0000000' AS DateTime2), 10005)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (6, 0, 3, 4, N'Agua trimestral', 3000, N'Recurrente', CAST(N'2025-07-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-09-30T00:00:00.0000000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (7, 1, 5, 6, N'Viáticos sprint Q3', 8000, N'Recurrente', CAST(N'2025-08-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-10-31T00:00:00.0000000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (8, 0, 7, 7, N'Ads redes sociales', 12000, N'Recurrente', CAST(N'2025-08-15T00:00:00.0000000' AS DateTime2), CAST(N'2025-12-15T00:00:00.0000000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (9, 0, 8, 8, N'Mantenimiento PCs', 6000, N'Recurrente', CAST(N'2025-09-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-11-30T00:00:00.0000000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (10, 1, 9, 10, N'Cursos equipo', 5000, N'Recurrente', CAST(N'2025-07-10T00:00:00.0000000' AS DateTime2), CAST(N'2025-10-10T00:00:00.0000000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (11, 1, 1, 1, N'PLAY5', 10000, N'Unico', NULL, NULL, CAST(N'2025-10-16T00:00:00.0000000' AS DateTime2), 123)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (12, 1, 1, 1, N'PLAY5', 1000, N'Recurrente', CAST(N'2025-10-15T00:00:00.0000000' AS DateTime2), CAST(N'2025-10-31T00:00:00.0000000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (13, 1, 1, 1, N'fdsadsa', 321312, N'Recurrente', CAST(N'2025-10-24T00:00:00.0000000' AS DateTime2), CAST(N'2025-10-30T00:00:00.0000000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (14, 0, 5, 1, N'Pagos', 1000, N'Recurrente', CAST(N'2025-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-12-01T00:00:00.0000000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (15, 1, 1, 1, N'auto', 100000, N'Unico', NULL, NULL, CAST(N'2025-10-17T00:00:00.0000000' AS DateTime2), 123)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (16, 1, 1, 11, N'434234', 5000, N'Unico', NULL, NULL, CAST(N'2025-10-09T00:00:00.0000000' AS DateTime2), 12312)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (17, 1, 6, 2, N'PC', 1000, N'Recurrente', CAST(N'2025-05-18T00:00:00.0000000' AS DateTime2), CAST(N'2026-10-18T00:00:00.0000000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (18, 1, 8, 2, N'PELOTA', 5000, N'Unico', NULL, NULL, CAST(N'2025-10-15T00:00:00.0000000' AS DateTime2), 789)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (19, 1, 1, 2, N'PLAY5', 12345, N'Unico', NULL, NULL, CAST(N'2025-10-17T00:00:00.0000000' AS DateTime2), 123)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (20, 1, 1, 2, N'PLAY5', 12345, N'Unico', NULL, NULL, CAST(N'2025-10-08T00:00:00.0000000' AS DateTime2), 123)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (21, 1, 8, 1, N'Mantenimiento PC', 8000, N'Unico', NULL, NULL, CAST(N'2025-10-17T00:00:00.0000000' AS DateTime2), 12345)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (22, 1, 1, 1, N'gdgdfsgd', 1000, N'Recurrente', CAST(N'2025-12-10T00:00:00.0000000' AS DateTime2), CAST(N'2026-11-10T00:00:00.0000000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (23, 0, 1, 1, N'WI-FI', 2000, N'Recurrente', CAST(N'2025-07-10T00:00:00.0000000' AS DateTime2), CAST(N'2025-12-10T00:00:00.0000000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (24, 1, 1, 1, N'PLAY5', 1000, N'Unico', NULL, NULL, CAST(N'2025-10-16T00:00:00.0000000' AS DateTime2), 123)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (25, 1, 6, 1, N'Papeleria', 500, N'Recurrente', CAST(N'2025-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2025-12-10T00:00:00.0000000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (26, 0, 5, 1, N'viaticos', 500, N'Recurrente', CAST(N'2025-09-30T00:00:00.0000000' AS DateTime2), CAST(N'2025-10-30T00:00:00.0000000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (27, 1, 3, 1, N'Agua', 500, N'Unico', NULL, NULL, CAST(N'2025-10-08T00:00:00.0000000' AS DateTime2), 52)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (28, 1, 1, 1, N'ultima prueba', 2000, N'Unico', NULL, NULL, CAST(N'2025-10-16T00:00:00.0000000' AS DateTime2), 123)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (29, 1, 1, 1, N'ultima prueba', 1500, N'Recurrente', CAST(N'2025-08-06T00:00:00.0000000' AS DateTime2), CAST(N'2025-12-06T00:00:00.0000000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (30, 1, 1, 1, N'ultima prueba2', 1000, N'Unico', NULL, NULL, CAST(N'2025-10-08T00:00:00.0000000' AS DateTime2), 123)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (31, 1, 1, 1, N'ultima prueba2', 2000, N'Recurrente', CAST(N'2025-07-16T00:00:00.0000000' AS DateTime2), CAST(N'2025-10-16T00:00:00.0000000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (32, 1, 1, 1, N'wifi', 11555, N'Recurrente', CAST(N'2025-10-14T00:00:00.0000000' AS DateTime2), CAST(N'2025-10-24T00:00:00.0000000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (33, 1, 1, 2, N'PAGO UNO', 200000, N'Unico', NULL, NULL, CAST(N'2025-08-01T00:00:00.0000000' AS DateTime2), 123)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (34, 0, 1, 1, N'abcdefghij', 140000, N'Unico', NULL, NULL, CAST(N'2025-11-21T00:00:00.0000000' AS DateTime2), 456)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (35, 0, 1, 1, N'afdsfasdf', 1222, N'Unico', NULL, NULL, CAST(N'2025-11-26T16:14:15.7292327' AS DateTime2), 456)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (36, 0, 1, 1, N'fdsafads', 1222, N'Unico', NULL, NULL, CAST(N'2025-11-26T23:04:43.0172646' AS DateTime2), 213121)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (37, 0, 1, 1, N'fdsfads', 122, N'Unico', NULL, NULL, CAST(N'2025-11-26T23:15:22.2420704' AS DateTime2), 12313)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (38, 0, 1, 1, N'fsdfdasd', 213123, N'Unico', NULL, NULL, CAST(N'2025-11-19T00:00:00.0000000' AS DateTime2), 12333)
GO
INSERT [dbo].[Pagos] ([Id], [MetodoPago], [IdGasto], [IdUsuario], [Descripcion], [Monto], [TipoPago], [FechaInicio], [FechaFin], [Fecha], [NroRecibo]) VALUES (39, 0, 1, 1, N'fsdadfadsf', 123233, N'Recurrente', CAST(N'2025-11-12T00:00:00.0000000' AS DateTime2), CAST(N'2025-11-20T00:00:00.0000000' AS DateTime2), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Pagos] OFF
GO
SET IDENTITY_INSERT [dbo].[Auditorias] ON 
GO
INSERT [dbo].[Auditorias] ([Id], [Accion], [Fecha], [IdUsuario], [idGasto]) VALUES (1, 0, CAST(N'2025-08-01T09:00:00.0000000' AS DateTime2), 6, 1)
GO
INSERT [dbo].[Auditorias] ([Id], [Accion], [Fecha], [IdUsuario], [idGasto]) VALUES (2, 0, CAST(N'2025-08-01T10:00:00.0000000' AS DateTime2), 7, 2)
GO
INSERT [dbo].[Auditorias] ([Id], [Accion], [Fecha], [IdUsuario], [idGasto]) VALUES (3, 2, CAST(N'2025-08-05T15:30:00.0000000' AS DateTime2), 9, 2)
GO
INSERT [dbo].[Auditorias] ([Id], [Accion], [Fecha], [IdUsuario], [idGasto]) VALUES (4, 0, CAST(N'2025-08-02T11:15:00.0000000' AS DateTime2), 3, 3)
GO
INSERT [dbo].[Auditorias] ([Id], [Accion], [Fecha], [IdUsuario], [idGasto]) VALUES (5, 2, CAST(N'2025-08-06T09:45:00.0000000' AS DateTime2), 4, 3)
GO
INSERT [dbo].[Auditorias] ([Id], [Accion], [Fecha], [IdUsuario], [idGasto]) VALUES (6, 0, CAST(N'2025-08-03T09:00:00.0000000' AS DateTime2), 5, 4)
GO
INSERT [dbo].[Auditorias] ([Id], [Accion], [Fecha], [IdUsuario], [idGasto]) VALUES (7, 0, CAST(N'2025-08-03T10:30:00.0000000' AS DateTime2), 9, 5)
GO
INSERT [dbo].[Auditorias] ([Id], [Accion], [Fecha], [IdUsuario], [idGasto]) VALUES (8, 2, CAST(N'2025-08-07T14:10:00.0000000' AS DateTime2), 8, 5)
GO
INSERT [dbo].[Auditorias] ([Id], [Accion], [Fecha], [IdUsuario], [idGasto]) VALUES (9, 0, CAST(N'2025-08-04T08:45:00.0000000' AS DateTime2), 7, 6)
GO
INSERT [dbo].[Auditorias] ([Id], [Accion], [Fecha], [IdUsuario], [idGasto]) VALUES (10, 0, CAST(N'2025-08-04T16:00:00.0000000' AS DateTime2), 5, 7)
GO
INSERT [dbo].[Auditorias] ([Id], [Accion], [Fecha], [IdUsuario], [idGasto]) VALUES (11, 2, CAST(N'2025-08-08T19:30:00.0000000' AS DateTime2), 6, 7)
GO
INSERT [dbo].[Auditorias] ([Id], [Accion], [Fecha], [IdUsuario], [idGasto]) VALUES (12, 0, CAST(N'2025-08-05T12:00:00.0000000' AS DateTime2), 4, 8)
GO
INSERT [dbo].[Auditorias] ([Id], [Accion], [Fecha], [IdUsuario], [idGasto]) VALUES (13, 0, CAST(N'2025-08-05T13:20:00.0000000' AS DateTime2), 3, 9)
GO
INSERT [dbo].[Auditorias] ([Id], [Accion], [Fecha], [IdUsuario], [idGasto]) VALUES (14, 2, CAST(N'2025-08-09T17:05:00.0000000' AS DateTime2), 2, 9)
GO
INSERT [dbo].[Auditorias] ([Id], [Accion], [Fecha], [IdUsuario], [idGasto]) VALUES (15, 0, CAST(N'2025-08-06T09:30:00.0000000' AS DateTime2), 1, 10)
GO
SET IDENTITY_INSERT [dbo].[Auditorias] OFF
GO
