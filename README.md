# Task Queue - Factory Method

## Descripción

Este proyecto presenta una solución sencilla para gestionar diferentes tipos de tareas que pueden generarse en un sistema interno empresarial.

En una empresa, el sistema puede necesitar realizar operaciones que requieren un procesamiento considerable, como:

* Facturación masiva.
* Consultas masivas de datos.
* Generación de reportes.

Para evitar que el código principal tenga que conocer cómo se crea cada tipo de tarea, se plantea utilizar el patrón de diseño **Factory Method**.

El ejemplo desarrollado es una aplicación de consola en **C#** que simula la llegada de una tarea al sistema y se encarga de crearla y ejecutarla según el tipo recibido.

> Este proyecto es una demostración académica del patrón Factory Method. No implementa una cola persistente ni un procesamiento asíncrono real.

## Patrón utilizado

### Factory Method

El patrón **Factory Method** permite delegar la creación de objetos a clases especializadas.

En este proyecto se define una clase abstracta `TaskFactoryBase`, que establece el método:

```csharp
CreateTask()
```

Las fábricas concretas se encargan de crear cada tipo de tarea:

```text
TaskFactoryBase
       ▲
       │
       ├── BillingTaskFactory
       ├── ReportTaskFactory
       └── MassQueryTaskFactory
```

Mientras que las tareas implementan la interfaz `ITask`:

```text
ITask
  ▲
  │
  ├── BillingTask
  ├── ReportTask
  └── MassQueryTask
```

De esta forma, el código principal solicita una tarea a una fábrica y trabaja con la abstracción `ITask`, sin tener que encargarse directamente de construir cada tarea.

## Estructura del proyecto

```text
task-queue-factory-method/
│
├── specs/
│   └── specification.md
│
├── src/
│   ├── Program.cs
│   ├── src.csproj
│   │
│   ├── Tasks/
│   │   ├── ITask.cs
│   │   ├── BillingTask.cs
│   │   ├── ReportTask.cs
│   │   └── MassQueryTask.cs
│   │
│   └── Factories/
│       ├── TaskFactoryBase.cs
│       ├── BillingTaskFactory.cs
│       ├── ReportTaskFactory.cs
│       └── MassQueryTaskFactory.cs
│
└── README.md
```

## Funcionamiento

El programa recibe desde la consola el tipo de tarea que debe procesar.

Por ejemplo:

```bash
dotnet run billing
```

El flujo es:

```text
billing
   │
   ▼
BillingTaskFactory
   │
   │ CreateTask()
   ▼
BillingTask
   │
   │ Execute()
   ▼
Procesando facturación masiva...
```

De forma similar, se pueden ejecutar los otros tipos de tareas.

## Requisitos

Para ejecutar el proyecto se necesita tener instalado:

* .NET 8.0 o superior.
* Git, si se desea clonar el repositorio.

## Ejecución

Clonar el repositorio:

```bash
git clone <URL_DEL_REPOSITORIO>
```

Entrar al proyecto:

```bash
cd task-queue-factory-method
```

Entrar a la carpeta del código:

```bash
cd src
```

Ejecutar una tarea de facturación:

```bash
dotnet run billing
```

Resultado esperado:

```text
[BillingTask] Procesando facturación masiva...
```

Ejecutar una tarea de reportes:

```bash
dotnet run report
```

Resultado esperado:

```text
[ReportTask] Generando reporte...
```

Ejecutar una consulta masiva:

```bash
dotnet run mass-query
```

Resultado esperado:

```text
[MassQueryTask] Ejecutando consulta masiva de datos...
```

Si no se proporciona un tipo de tarea:

```bash
dotnet run
```

el programa indica que se debe especificar el tipo de tarea.

## ¿Por qué utilizar Factory Method?

Sin el patrón, el programa principal tendría que conocer directamente cada clase concreta:

```csharp
ITask task;

if (taskType == "billing")
{
    task = new BillingTask();
}
else if (taskType == "report")
{
    task = new ReportTask();
}
```

Esto hace que el código principal sea responsable de conocer cómo se crean las diferentes tareas.

Con Factory Method, la creación se delega a una fábrica:

```csharp
ITask task = factory.CreateTask();
```

Cada fábrica conoce la implementación concreta que debe crear.

Por ejemplo:

```text
BillingTaskFactory → BillingTask
ReportTaskFactory → ReportTask
MassQueryTaskFactory → MassQueryTask
```

Esto permite separar la responsabilidad de **crear una tarea** de la responsabilidad de **ejecutarla**.

## Alcance del proyecto

El proyecto se limita a demostrar el funcionamiento del patrón Factory Method mediante una aplicación de consola.

La solución no incluye:

* Base de datos.
* Cola persistente.
* Procesamiento asíncrono real.
* Sistema de notificaciones.
* API.
* Interfaz gráfica.

Estos elementos podrían incorporarse en una implementación real del sistema, pero no son necesarios para demostrar el patrón de diseño seleccionado.
