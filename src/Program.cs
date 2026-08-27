using TaskQueueFactoryMethod.Tasks;
using TaskQueueFactoryMethod.Factories;

string taskType = args[0];

if (args.Length == 0)
{
    Console.WriteLine("Debe especificar un tipo de tarea.");
    return;
}

TaskFactoryBase factory = taskType switch
{
    "billing" => new BillingTaskFactory(),
    "report" => new ReportTaskFactory(),
    "mass-query" => new MassQueryTaskFactory(),
    _ => throw new ArgumentException("Tipo de tarea no válido.")
};

ITask task = factory.CreateTask();

task.Execute();