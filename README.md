# Sistema de Gestión de Pagos – Programación 3

Proyecto académico desarrollado para la materia **Programación 3** (ORT Uruguay).

## Descripción
Aplicación web desarrollada en **C# y .NET 8** que permite gestionar pagos realizados por usuarios
pertenecientes a distintos equipos de trabajo, aplicando roles y reglas de negocio.

El sistema implementa una arquitectura en capas siguiendo principios de **Clean Architecture** y **DDD**.

## Funcionalidades principales
- Login de usuarios con control de roles (Administrador, Gerente, Empleado)
- Gestión de tipos de gasto (CRUD con auditoría)
- Alta de pagos únicos y recurrentes
- Listado mensual de pagos con cálculo de saldo pendiente
- Alta de usuarios
- Consulta de pagos vía Web API (sin autenticación)

## Tecnologías utilizadas
- C#
- .NET 8
- ASP.NET MVC
- ASP.NET Web API
- Entity Framework Core
- LINQ
- SQL Server

## Arquitectura
- Capa Web (MVC)
- Capa API
- Dominio (lógica de negocio)
- Infraestructura (persistencia de datos)

## Contexto
Proyecto realizado como obligatorio académico, cumpliendo requerimientos funcionales,
validaciones de negocio y buenas prácticas de desarrollo.

---
Proyecto con fines académicos.
