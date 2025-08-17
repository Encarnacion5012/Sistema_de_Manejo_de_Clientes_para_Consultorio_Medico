

<h1>🏥 Sistema de Gestión de Consultorio Médico</h1>

Creado por:
Estainlin Encarnacion 2024-0181
UNICDA
---
Aplicación de escritorio en **C# (.NET Windows Forms)** con **Microsoft Access** como base de datos, diseñada para administrar de forma integral un consultorio médico.  
El sistema integra módulos para **usuarios, pacientes, médicos, citas, diagnósticos y pagos**, con un enfoque en código limpio, modularidad y facilidad de uso.

<h3>Usuarios:</h3> 
<p>Nombre: admin  Clave: 1234 Rol: admin</p>
<p>Nombre: recepcionista1 Clave: recep1 Rol:Recepcionista</p>
<p>Nombre: medico1 Clave: medico Rol: medico</p>

## 📌 Características principales

- **Gestión de Usuarios**  
  Crear, editar, buscar y eliminar usuarios con control de roles (`Admin`, `Médico`, `Recepcionista`).

- **Pacientes**  
  Registro completo de datos personales y contacto.

- **Médicos**  
  Administración de profesionales con datos y especialidad.

- **Citas médicas**  
  Agenda vinculada entre pacientes y médicos, con estados configurables.

- **Diagnósticos y tratamientos**  
  Detalle de síntomas, diagnóstico y plan de tratamiento por cita.

- **Pagos**  
  Registro de pagos realizados, método de pago y fecha.

- **UI consistente y moderna**  
  Colores semánticos para acciones, campos alineados y uso de `TableLayoutPanel` y `FlowLayoutPanel`.

##Como Usar
<p>El regitras cualquier elemto debe dejar el campo id vacio puesta que esta configurado como autonum en la base da datos, es decir ella misma genera el id colocar el campo id al registras lanzara un error</p>

<p>Al Bucar poner el campo id y luego dar al boton de buscar</p>
<p>Al querer eliminar un paciende debe ingresar el id usar el boton bucar y cuando se traigan los datos ahi precionar el boton eliminar</p>
<p>Para editar algun registro debe traerlo primero por el boton de buscar y luego editar los campos que desee y precionar el boton editar/actuazar</p>
---

## 🛠️ Tecnologías y arquitectura

- **Lenguaje:** C# (.NET Framework, Windows Forms)  
- **Base de datos:** Microsoft Access (`.accdb`) con **OleDb**  
- **Arquitectura:**  
  - Separación de **Modelos**, **Servicios** y **Formularios**  
  - CRUD centralizado en servicios  
  - Clase de utilidades (`LimpiarCampos`) para funciones comunes

---
## 📂 Estructura del proyecto
📦 Gestion_Consultorio_Medico 
┣ 📂 Formularios 
┣ 📂 Modelos 
┣ 📂 Servicios 
┗ 📂 Utilidades
