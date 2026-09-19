                                             Análisis del Sistema Control Clínico Veterinario
<img width="1408" height="768" alt="Gemini_Generated_Image_vdleswvdleswvdle" src="https://github.com/user-attachments/assets/5de04590-fc31-4a48-9617-436fc6e6e027" />


Descripción General

El Sistema de Control Clínico Veterinario es una aplicación de software desarrollada en C# que permite gestionar de forma integral las operaciones de una clínica veterinaria: registro de clientes y mascotas, programación y cancelación de citas, atención médica por parte del veterinario, consulta de historial clínico, facturación y procesamiento de pagos.

El sistema está orientado a tres actores principales: Recepcionista, veterinario y cliente/dueño de la mascota, cada uno con su responsabilidad.

Objetivos Generales

Crear un sistema informático que permita gestionar de manera automatizada y centralizada las actividades clínicas, administrativas y financieras de una clínica veterinaria, optimizando los procesos, disminuyendo los errores y asegurando un registro completo y organizado del historial médico de cada mascota.

Objetivos Específicos

Registrar clientes, mascotas y veterinarios con validación de datos.
Gestionar la agenda de citas (crear, consultar, cancelar).
Documentar consultas médicas: diagnóstico, tratamiento y receta.
Mantener un historial clínico consultable por mascota.
Emitir facturas y procesar pagos con distintos métodos.
Controlar el acceso según el rol del usuario autenticado.

Alcance del sistema

El Sistema de Control Clínico Veterinario está compuesto por diferentes módulos que permiten gestionar de manera integrada las principales actividades de una clínica veterinaria.

El sistema está conformado por los siguientes módulos:

**Gestión de autenticación con roles (recepción, veterinario).
**Módulo de registro de clientes, mascotas y veterinarios.
**Módulo de citas (solicitud, creación, consulta y cancelación).
**Módulo de consulta médica (diagnóstico, tratamiento, receta).
**Módulo de historial clínico.
**Módulo de facturación y pago (efectivo, tarjeta, transferencia).
**Notificaciones internas al personal (recepción/veterinario).

Actores del sistema

Los actores del sistema son las personas que interactúan con el Sistema de Control Clínico Veterinario para realizar las diferentes actividades de acuerdo con sus funciones y permisos. Cada actor tiene responsabilidades específicas dentro del sistema, permitiendo controlar el acceso a la información y a las operaciones disponibles.

***Cliente / Dueño de la mascota: solicita y consulta citas, cancela citas y consulta la información e historial clínico de sus mascotas.
***Recepción: registra clientes, mascotas y veterinarios; gestiona las citas, facturación y pagos.
***Veterinario: consulta su agenda, atiende a las mascotas, registra diagnósticos, tratamientos y recetas, y consulta el historial clínico.
***Sistema: realiza procesos automáticos como validar datos, verificar disponibilidad, actualizar estados, generar identificadores y actualizar el historial clínico.

Reglas de negocio

1. Autenticación y seguridad
Todo usuario debe autenticarse antes de acceder a cualquier funcionalidad.
No pueden existir dos usuarios con el mismo nombre de usuario.
Tras 3 intentos fallidos, la cuenta se bloquea temporalmente.

2. Registro de datos
   
Solo la Recepción puede registrar clientes, mascotas y veterinarios.
No se puede registrar una mascota sin un propietario válido.
No pueden existir dos clientes con el mismo DPI.

4. Gestión de citas
   
Las citas canceladas liberan automáticamente el horario.
Una cita solo puede cancelarse si su estado es "Programada" o "Pendiente".
Un cliente debe tener al menos una mascota registrada para solicitar una cita.
Un veterinario no puede tener dos citas activas en la misma fecha y hora.
Las citas solicitadas por el cliente se registran con estado "Pendiente" hasta ser confirmadas por Recepción.

6. Atención médica
   
Un veterinario tiene acceso a la información de las mascotas asociadas a su agenda.
El historial clínico se actualiza automáticamente al finalizar cada consulta.

8. Facturación y pago
   
El cliente solo puede visualizar información de sus propias mascotas y citas.
Se notifica al cliente al confirmar o cancelar una cita.
No se puede emitir factura sin pago aprobado.
