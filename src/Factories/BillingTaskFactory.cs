using TaskQueueFactoryMethod.Tasks;

namespace TaskQueueFactoryMethod.Factories;

public class BillingTaskFactory : TaskFactory
{
    public override ITask CreateTask()
    {
        return new BillingTask();
    }
}