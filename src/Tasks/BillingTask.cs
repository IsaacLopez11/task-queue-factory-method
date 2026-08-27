namespace TaskQueueFactoryMethod.Tasks;

public class BillingTask : ITask
{
    public void Execute ()
    {
        Console.WriteLine("[BillingTask] Procesando facturación masiva...");
    }
}