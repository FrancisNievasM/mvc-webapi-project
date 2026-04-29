# Inventory Management System (MVC + Web API)

## 📌 Descripción
Aplicación web desarrollada con arquitectura MVC y Web API para la gestión de artículos y control de movimientos de stock.

El sistema permite registrar movimientos (entradas/salidas), consultar información filtrada y generar resúmenes de actividad.

## 🏗️ Arquitectura
El proyecto está dividido en dos componentes principales:

- MVCObligatorio2 → Aplicación web (interfaz + lógica de presentación)
- WebApiObligatorio2 → API REST para manejo de datos y lógica de negocio

La comunicación se realiza mediante HTTP utilizando tokens de autenticación.

## 🚀 Funcionalidades
- Autenticación de usuarios con manejo de sesión
- Registro de movimientos de stock
- Consulta de artículos con filtros por fecha
- Visualización de movimientos por artículo y tipo
- Paginación de resultados
- Generación de resúmenes anuales de movimientos

## 🔐 Seguridad
- Autenticación mediante token (Bearer)
- Control de acceso por rol (Encargado)

## 🛠️ Tecnologías
- C#
- ASP.NET MVC
- ASP.NET Web API
- SQL Server

## 🗄️ Base de datos
Script disponible en:
- `database/Datos_De_Prueba.sql`

## 📁 Estructura del proyecto
- `MVCObligatorio2/` → frontend MVC
- `WebApiObligatorio2/` → backend API
- `DTOs/` → transferencia de datos entre capas
- `database/` → scripts SQL
- `docs/` → documentación y diagramas

## ▶️ Cómo ejecutar
1. Configurar la base de datos con el script SQL  
2. Ejecutar la Web API  
3. Ejecutar el proyecto MVC  
4. Acceder desde el navegador  

## 🧠 Notas
Proyecto enfocado en la separación de responsabilidades, consumo de APIs y manejo de datos en aplicaciones web.

## 👤 Autor
Francis Nievas
