using TaskQueueFactoryMethod.Tasks;

namespace TaskQueueFactoryMethod.Factories;

public class BillingTaskFactory : TaskFactoryBase
{
    public override ITask CreateTask()
    {
        return new BillingTask();
    }
}