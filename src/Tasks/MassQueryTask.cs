namespace TaskQueueFactoryMethod.Tasks;

public class MassQueryTask : ITask
{
    public void Execute()
    {
        Console.WriteLine("[MassQueryTask] Ejecutando consulta masiva de datos...");
    }
}