using TaskQueueFactoryMethod.Tasks;

namespace TaskQueueFactoryMethod.Factories;

public class MassQueryTaskFactory : TaskFactory
{
    public override ITask CreateTask()
    {
        return new MassQueryTask();
    }
}