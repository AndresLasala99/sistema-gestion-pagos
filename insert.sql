USE [BaseObligatorio];
GO

/* ========= 1) EQUIPOS (10) ========= */
INSERT INTO [dbo].[Equipos] ([Nombre]) VALUES
('Equipo Artigas'),
('Equipo Salto'),
('Equipo Paysandú'),
('Equipo Colonia'),
('Equipo Maldonado'),
('Equipo Rocha'),
('Equipo Rivera'),
('Equipo Tacuarembó'),
('Equipo Canelones'),
('Equipo Flores');



/* ========= 2) USUARIOS (10) ========= */
/* Rol: 0=ADMINISTRADOR, 1=GERENTE, 2=EMPLEADO */
INSERT INTO [dbo].[Usuarios] ([Nombre],[Apellido],[Pass],[Mail],[Rol],[IdEquipo]) VALUES
('Ana','Pérez','gerente1','anaper@laempresa.com',1,1),
('Bruno','García','admin123','brugar@laempresa.com',0,2),
('Carla','Rodríguez','emple123','carrod@laempresa.com',2,3),
('Diego','Fernández','emple1234','diefer@laempresa.com',2,4),
('Elena','Martínez','gerente12','elemar@laempresa.com',1,5),
('Facundo','Suárez','admin1234','facsua@laempresa.com',0,6),
('Gisela','López','emple12345','gislop@laempresa.com',2,7),
('Hernán','Silva','emple123456','hersil@laempresa.com',2,8),
('Irene','Castro','admin12345','irecas@laempresa.com',0,9),
('Joaquín','Ramos','emple1234567','joaram@laempresa.com',2,10);


--anaper@laempresa.com
--brugar@laempresa.com
--carrod@laempresa.com


/* ========= 3) GASTOS (10) ========= */
INSERT INTO [dbo].[Gastos] ([Nombre],[Descripcion]) VALUES
('Internet','Servicio mensual de internet oficina'),
('Luz','Factura de UTE'),
('Agua','Factura de OSE'),
('Transporte','Traslados del equipo'),
('Viáticos','Viáticos por reuniones'),
('Suministros','Artículos de oficina y limpieza'),
('Publicidad','Campañas en redes'),
('Mantenimiento','Mantenimiento de equipos'),
('Capacitación','Cursos y talleres'),
('Alquiler','Alquiler de oficina');



/* ========= 4) PAGOS (10) ========= */
/* MetodoPago: 0=CREDITO, 1=EFECTIVO
   TipoPago 'Unico' -> usa [Fecha] y [NroRecibo]; [FechaInicio]/[FechaFinal]=NULL
   TipoPago 'Recurrente' -> usa [FechaInicio]/[FechaFinal]; [Fecha]/[NroRecibo]=NULL
   Nota: aquí asumo FKs como [IdGasto] y [IdUsuario] (según tu OnModelCreating).
*/
-- 5 pagos Unico
INSERT INTO [dbo].[Pagos] ([MetodoPago],[IdGasto],[IdUsuario],[Descripcion],[Monto],[TipoPago],[FechaInicio],[FechaFin],[Fecha],[NroRecibo]) VALUES
(1, 1, 1,  'Pago internet agosto',        1800.00, 'Unico',      NULL,        NULL,        '2025-08-05', 10001),
(0, 2, 2,  'Pago luz agosto',             4200.50, 'Unico',      NULL,        NULL,        '2025-08-10', 10002),
(1, 4, 3,  'Traslado reunión cliente',     950.00, 'Unico',      NULL,        NULL,        '2025-09-01', 10003),
(1, 6, 5,  'Compra resmas y lapiceras',   1350.75, 'Unico',      NULL,        NULL,        '2025-09-12', 10004),
(0,10, 9,  'Alquiler setiembre',         35000.00, 'Unico',      NULL,        NULL,        '2025-09-03', 10005);

-- 5 pagos Recurrente
INSERT INTO [dbo].[Pagos] ([MetodoPago],[IdGasto],[IdUsuario],[Descripcion],[Monto],[TipoPago],[FechaInicio],[FechaFin],[Fecha],[NroRecibo]) VALUES
(0, 3, 4,  'Agua trimestral',             3000.00, 'Recurrente', '2025-07-01','2025-09-30', NULL, NULL),
(1, 5, 6,  'Viáticos sprint Q3',          8000.00, 'Recurrente', '2025-08-01','2025-10-31', NULL, NULL),
(0, 7, 7,  'Ads redes sociales',         12000.00, 'Recurrente', '2025-08-15','2025-12-15', NULL, NULL),
(0, 8, 8,  'Mantenimiento PCs',           6000.00, 'Recurrente', '2025-09-01','2025-11-30', NULL, NULL),
(1, 9,10,  'Cursos equipo',               5000.00, 'Recurrente', '2025-07-10','2025-10-10', NULL, NULL);


select *
from gastos

select * from Auditorias

INSERT INTO Auditorias (Accion, Fecha, IdUsuario, IdGasto)
VALUES (0, '2025-08-01 09:00:00', 6, 1);

-- Gasto 2 (usuario 2)
INSERT INTO Auditorias (Accion, Fecha, IdUsuario, IdGasto)
VALUES (0, '2025-08-01 10:00:00', 7, 2),
       (2, '2025-08-05 15:30:00', 9, 2);

-- Gasto 3 (usuario 3)
INSERT INTO Auditorias (Accion, Fecha, IdUsuario, IdGasto)
VALUES (0, '2025-08-02 11:15:00', 3, 3),
       (2, '2025-08-06 09:45:00', 4, 3);

-- Gasto 4 (usuario 4)
INSERT INTO Auditorias (Accion, Fecha, IdUsuario, IdGasto)
VALUES (0, '2025-08-03 09:00:00', 5, 4);

-- Gasto 5 (usuario 5)
INSERT INTO Auditorias (Accion, Fecha, IdUsuario, IdGasto)
VALUES (0, '2025-08-03 10:30:00', 9, 5),
       (2, '2025-08-07 14:10:00', 8, 5);

-- Gasto 6 (usuario 6)
INSERT INTO Auditorias (Accion, Fecha, IdUsuario, IdGasto)
VALUES (0, '2025-08-04 08:45:00', 7, 6);

-- Gasto 7 (usuario 7)
INSERT INTO Auditorias (Accion, Fecha, IdUsuario, IdGasto)
VALUES (0, '2025-08-04 16:00:00', 5, 7),
       (2, '2025-08-08 19:30:00', 6, 7);

-- Gasto 8 (usuario 8)
INSERT INTO Auditorias (Accion, Fecha, IdUsuario, IdGasto)
VALUES (0, '2025-08-05 12:00:00', 4, 8);

-- Gasto 9 (usuario 9)
INSERT INTO Auditorias (Accion, Fecha, IdUsuario, IdGasto)
VALUES (0, '2025-08-05 13:20:00', 3, 9),
       (2, '2025-08-09 17:05:00', 2, 9);

-- Gasto 10 (usuario 10)
INSERT INTO Auditorias (Accion, Fecha, IdUsuario, IdGasto)
VALUES (0, '2025-08-06 09:30:00', 1, 10);