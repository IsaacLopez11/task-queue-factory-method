# Especificación SDD

## Sistema de gestión de tareas empresariales

**Lenguaje:** C#
**Tipo de aplicación:** Aplicación de consola
**Patrón creacional:** Factory Method

---

## 1. Problema

La empresa cuenta con un aplicativo interno utilizado por sus empleados para gestionar diferentes actividades relacionadas con la operatividad y facturación de la organización.

Dentro de las funcionalidades del aplicativo existen operaciones que pueden requerir una cantidad considerable de procesamiento, como:

* Facturación masiva.
* Consultas masivas de datos.
* Generación de reportes.

Estas operaciones pueden consumir una cantidad importante de recursos y tomar un tiempo considerable en completarse. Ejecutarlas directamente durante la solicitud realizada por el usuario puede provocar que este tenga que esperar hasta que la operación termine.

Como solución, se plantea un sistema de gestión de tareas pendientes. Cuando un empleado solicita una operación que requiere un procesamiento considerable, el sistema registra una tarea indicando el tipo de operación que debe realizarse.

Posteriormente, un componente encargado del procesamiento podrá tomar las tareas pendientes y ejecutarlas de forma asíncrona, permitiendo que el usuario continúe utilizando el aplicativo mientras la operación se procesa. Una vez finalizada, el sistema podría notificar al usuario sobre el resultado de la operación.

Para este ejercicio no se implementará una cola persistente ni un procesamiento asíncrono real. Se realizará una versión simplificada que permita representar la llegada de una tarea, crearla según su tipo y ejecutar su comportamiento desde una aplicación de consola.

El problema principal que se busca resolver en la implementación es **cómo crear diferentes tipos de tareas sin que el código principal tenga que depender directamente de cada una de sus clases concretas**.

---

## 2. Objetivo

Diseñar una solución sencilla que permita representar diferentes tareas empresariales y demostrar cómo pueden ser creadas y ejecutadas utilizando el patrón Factory Method.

El sistema deberá representar las siguientes tareas:

* `BillingTask`: representa una tarea de facturación masiva.
* `MassQueryTask`: representa una tarea de consulta masiva de datos.
* `ReportTask`: representa una tarea de generación de reportes.

Todas las tareas deberán compartir una abstracción común que permita tratarlas de manera uniforme.

---

## 3. Alcance

La implementación realizada para este ejercicio será una versión simplificada del sistema planteado.

El programa será una aplicación de consola desarrollada en C# que simulará la llegada de una tarea al sistema.

El flujo será:

```text
Tarea recibida
      ↓
Identificación del tipo
      ↓
Factory Method
      ↓
Creación de la tarea
      ↓
Ejecución de la tarea
```

La aplicación demostrará únicamente el concepto de creación y ejecución de las tareas.

### Fuera del alcance

No se implementarán en esta versión:

* Base de datos.
* PostgreSQL.
* Persistencia de las tareas.
* API REST.
* Procesamiento asíncrono real.
* Sistema de notificaciones.
* Procesamiento real de facturas.
* Generación real de reportes.
* Consultas reales sobre grandes cantidades de datos.
* Múltiples trabajadores o `Workers`.

Estas funcionalidades corresponden a una posible evolución del sistema, pero no son necesarias para demostrar el patrón Factory Method.

---

# 4. Requisitos

## 4.1 Requisitos funcionales

### RF-01 — Representación de una tarea

El sistema deberá definir una abstracción `ITask` que represente una tarea que pueda ser ejecutada.

La abstracción deberá definir un método `Execute()`.

---

### RF-02 — Tipos de tareas

El sistema deberá implementar como mínimo tres tipos de tareas:

* `BillingTask`.
* `MassQueryTask`.
* `ReportTask`.

Cada una deberá implementar la interfaz `ITask`.

---

### RF-03 — Comportamiento de las tareas

Cada tipo de tarea deberá tener una implementación propia del método `Execute()`.

La ejecución deberá mostrar en consola un mensaje que permita identificar la tarea que está siendo procesada.

Por ejemplo:

```text
[BillingTask] Procesando facturación masiva...
```

---

### RF-04 — Fábrica de tareas

El sistema deberá definir una clase abstracta `TaskFactory` que contenga un método encargado de crear una tarea.

El método será:

```text
CreateTask()
```

---

### RF-05 — Fábricas concretas

El sistema deberá implementar una fábrica concreta para cada tipo de tarea:

* `BillingTaskFactory`.
* `MassQueryTaskFactory`.
* `ReportTaskFactory`.

Cada fábrica deberá ser responsable de crear su correspondiente tipo de tarea.

---

### RF-06 — Creación mediante Factory Method

Las tareas deberán ser creadas utilizando el método `CreateTask()` definido por las fábricas.

El código principal no deberá crear directamente las tareas mediante expresiones como:

```text
new BillingTask()
new MassQueryTask()
new ReportTask()
```

La responsabilidad de crear cada objeto deberá estar delegada a su fábrica correspondiente.

---

### RF-07 — Simulación de una tarea recibida

El programa deberá permitir representar la llegada de una tarea indicando su tipo.

Por ejemplo:

```text
report
```

A partir de este valor, el sistema deberá seleccionar la fábrica correspondiente, crear la tarea y ejecutarla.

---

### RF-08 — Ejecución mediante la abstracción

Una vez creada una tarea, el programa deberá trabajar con la abstracción `ITask` para ejecutar su comportamiento.

El código que ejecuta la tarea no deberá necesitar conocer la clase concreta que fue creada.

---

### RF-09 — Incorporación de nuevos tipos de tareas

El diseño deberá permitir agregar nuevos tipos de tareas mediante la creación de:

1. Una nueva clase que implemente `ITask`.
2. Una nueva fábrica que herede de `TaskFactory`.

Las clases existentes de tareas no deberán necesitar ser modificadas para incorporar el nuevo tipo.

---

# 5. Requisitos no funcionales

### RNF-01 — Lenguaje

La solución deberá desarrollarse utilizando C#.

### RNF-02 — Programación orientada a objetos

La solución deberá utilizar interfaces, herencia y polimorfismo.

### RNF-03 — Bajo acoplamiento

El código encargado de ejecutar las tareas deberá depender de la abstracción `ITask` y no directamente de las implementaciones concretas.

### RNF-04 — Extensibilidad

La solución deberá facilitar la incorporación de nuevos tipos de tareas.

### RNF-05 — Simplicidad

La implementación deberá mantenerse pequeña y enfocada en demostrar el funcionamiento del patrón Factory Method.

---

# 6. Patrón seleccionado

## Factory Method

El patrón seleccionado para la solución es **Factory Method**, un patrón de diseño creacional que permite delegar la creación de objetos a métodos especializados de clases concretas.

En el sistema existen diferentes tipos de tareas empresariales:

```text
                 ITask
                   ▲
        ┌──────────┼──────────┐
        │          │          │
 BillingTask  MassQueryTask  ReportTask
```

Aunque las tareas realizan operaciones diferentes, todas representan el mismo concepto general: una tarea que puede ser ejecutada.

Por esta razón, se define una abstracción común `ITask`.

Sin utilizar Factory Method, el código principal podría tener que decidir directamente qué clase instanciar:

```text
Si tipo = "billing"
    crear BillingTask

Si tipo = "mass-query"
    crear MassQueryTask

Si tipo = "report"
    crear ReportTask
```

Esto hace que el código principal conozca las clases concretas y tenga que modificarse cuando se agregue un nuevo tipo de tarea.

Con Factory Method, la responsabilidad de creación se delega a fábricas especializadas:

```text
                 TaskFactory
                      ▲
          ┌───────────┼────────────┐
          │           │            │
 BillingTaskFactory  MassQueryTaskFactory  ReportTaskFactory
          │           │            │
          ▼           ▼            ▼
     BillingTask  MassQueryTask  ReportTask
```

De esta manera, el código que utiliza las tareas puede trabajar con `ITask`, mientras que cada fábrica se encarga de saber qué objeto concreto debe crear.

### Ventajas de utilizar Factory Method

El patrón proporciona principalmente:

* **Separación de responsabilidades:** la creación de una tarea queda separada de su ejecución.
* **Menor acoplamiento:** el código que utiliza las tareas no necesita crear directamente cada implementación.
* **Extensibilidad:** se pueden agregar nuevos tipos de tareas mediante nuevas clases y fábricas.
* **Polimorfismo:** todas las tareas pueden ser tratadas mediante la interfaz `ITask`.

---

# 7. Diseño propuesto

La solución estará compuesta por dos grupos principales de clases y un punto de entrada.

## 7.1 Tareas

La interfaz `ITask` definirá el comportamiento común:

```text
ITask
 └── Execute()
```

Las implementaciones serán:

```text
ITask
 ├── BillingTask
 ├── MassQueryTask
 └── ReportTask
```

Cada implementación tendrá su propio comportamiento de ejecución.

---

## 7.2 Fábricas

Se definirá una clase abstracta `TaskFactory`:

```text
TaskFactory
 └── CreateTask()
```

Las fábricas concretas serán:

```text
TaskFactory
 ├── BillingTaskFactory
 ├── MassQueryTaskFactory
 └── ReportTaskFactory
```

Cada fábrica implementará `CreateTask()` y devolverá una instancia de la tarea correspondiente.

---

## 7.3 Programa principal

`Program.cs` será el punto de entrada de la aplicación.

Su función será representar la llegada de una tarea al sistema.

El programa deberá:

1. Recibir el tipo de tarea.
2. Seleccionar la fábrica correspondiente.
3. Utilizar `CreateTask()` para crear la tarea.
4. Obtener la tarea como `ITask`.
5. Ejecutar `Execute()`.

El flujo será:

```text
Program
   │
   │ tipo de tarea
   ▼
TaskFactory
   │
   │ CreateTask()
   ▼
ITask
   │
   │ Execute()
   ▼
Resultado
```

---

# 8. Diagrama general

```text
                           <<interface>>
                               ITask
                                 ▲
                  ┌──────────────┼──────────────┐
                  │              │              │
            BillingTask    MassQueryTask    ReportTask
                  ▲              ▲              ▲
                  │              │              │
                  │              │              │
          BillingTaskFactory  MassQueryTaskFactory  ReportTaskFactory
                  ▲              ▲              ▲
                  │              │              │
                  └──────────────┼──────────────┘
                                 │
                          <<abstract>>
                          TaskFactory
                                 │
                                 ▼
                              Program
```

El punto principal del diseño es que `TaskFactory` define el método `CreateTask()`, mientras que las fábricas concretas determinan qué tipo de tarea crear.

---

# 9. Flujo de funcionamiento

Supongamos que al sistema llega una solicitud para generar un reporte.

La entrada será:

```text
report
```

El sistema realizará el siguiente proceso:

```text
1. Recibir "report"
          ↓
2. Seleccionar ReportTaskFactory
          ↓
3. Ejecutar CreateTask()
          ↓
4. Crear ReportTask
          ↓
5. Obtener objeto como ITask
          ↓
6. Ejecutar Execute()
          ↓
7. Mostrar resultado
```

El resultado esperado será similar a:

```text
Tarea recibida: report

Fábrica seleccionada: ReportTaskFactory

Tarea creada: ReportTask

Ejecutando tarea...
[ReportTask] Generando reporte...

Tarea finalizada correctamente.
```

---

# 10. Criterios de aceptación

### CA-01 — Interfaz de tareas

El sistema deberá contar con una interfaz `ITask` que defina el método `Execute()`.

### CA-02 — Tipos de tareas

Deberán existir `BillingTask`, `MassQueryTask` y `ReportTask`, todas implementando `ITask`.

### CA-03 — Fábrica abstracta

Deberá existir una clase `TaskFactory` que defina el método `CreateTask()`.

### CA-04 — Fábricas concretas

Deberán existir fábricas concretas para cada tipo de tarea y cada una deberá crear correctamente su tarea correspondiente.

### CA-05 — Factory Method

El código principal deberá utilizar las fábricas para crear las tareas y no deberá instanciar directamente las clases concretas.

### CA-06 — Ejecución

Una tarea creada deberá poder ejecutarse mediante el método `Execute()` de la interfaz `ITask`.

### CA-07 — Polimorfismo

El programa deberá poder almacenar y ejecutar una tarea utilizando una referencia de tipo `ITask`.

### CA-08 — Extensibilidad

Deberá ser posible agregar un nuevo tipo de tarea mediante una nueva implementación de `ITask` y una nueva fábrica sin modificar las tareas existentes.

### CA-09 — Ejecución desde consola

El proyecto deberá poder ejecutarse desde la consola y mostrar el proceso de recepción, creación y ejecución de una tarea.

---

# 11. Resultado esperado

La implementación final deberá demostrar de manera sencilla el uso del patrón Factory Method para resolver el problema de creación de diferentes tipos de tareas empresariales.

El sistema no pretende ser una implementación completa de una cola de tareas, sino una demostración del diseño necesario para crear diferentes tipos de tareas de forma desacoplada.

Una posible evolución del sistema podría incorporar posteriormente una cola persistente, una base de datos y procesamiento asíncrono real. Sin embargo, estas funcionalidades quedan fuera del alcance de esta implementación.
