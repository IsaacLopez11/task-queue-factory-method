namespace TaskQueueFactoryMethod.Tasks;

public class ReportTask : ITask
{
    public void Execute()
    {
        Console.WriteLine("[ReportTask] Generando reporte...");
    }
}