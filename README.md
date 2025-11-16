# Gestión_RH

📌 Descripción del proyecto

Este proyecto es una aplicación de escritorio desarrollada en C# con Windows Forms, cuyo propósito es gestionar la información de los empleados de una organización. La aplicación se conecta a una base de datos SQL Server y permite realizar operaciones de CRUD (Crear, Leer, Actualizar y Eliminar) de manera sencilla y eficiente.

El diseño del sistema se basa en principios de programación orientada a objetos, utilizando clases separadas para el acceso a datos, la lógica de negocio y la interfaz gráfica, lo que facilita la escalabilidad y el mantenimiento del código.

🏗️ Características principales
✔ Conexión a SQL Server mediante patrón Singleton

La clase Conexion implementa un patrón Singleton para asegurar que la cadena de conexión sea gestionada correctamente a lo largo de toda la aplicación.

✔ CRUD completo sobre la tabla empleados

La aplicación permite:

Agregar nuevos empleados

Listar todos los empleados en un DataGridView

Actualizar datos existentes

Eliminar registros

Visualizar la información en una tabla interactiva

✔ Validaciones integradas

Incluye validaciones fundamentales antes de enviar datos a la base:

Campos obligatorios (la base de datos no admite valores nulos)

Validación de correo electrónico mediante expresión regular

Validación de ID numérico

Prevención de errores de PK repetida

✔ Interfaz gráfica intuitiva

El formulario frmEmpleados presenta:

Campos de texto para ID, nombres, apellidos, dirección y email

Botones para cada operación (Listar, Agregar, Actualizar, Eliminar)

Un DataGridView donde se muestran los registros cargados

Carga de datos al hacer clic en Listar

Doble vinculación: al seleccionar una fila del DataGridView, los datos se llenan automáticamente en los campos

🛠️ Tecnologías utilizadas

C# (.NET Framework / Windows Forms)

SQL Server Express

ADO.NET (System.Data.SqlClient)

Programación Orientada a Objetos

Visual Studio

🧪 Funcionamiento general

El programa inicia la conexión a la base de datos.

El usuario puede listar los empleados almacenados.

Puede agregar nuevos registros mediante el formulario.

Puede seleccionar una fila para actualizar o eliminar.

Después de cada operación, los campos se limpian y la tabla se actualiza.

🎯 Objetivo académico

Este proyecto fue desarrollado como ejercicio para:

Aplicar principios de POO

Separar adecuadamente las capas: datos, negocio y presentación

Resolver un caso real de gestión administrativa

Utilizar SQL Server desde aplicaciones WinForms

Implementar validaciones robustas en C#

Presentar un sistema funcional apto para ampliación futura

📌 Posibles mejoras a futuro


Paginación en el DataGridView

Exportación a Excel o PDF

Búsqueda avanzada por campos

Integración con Entity Framework

Módulo de roles de usuario
