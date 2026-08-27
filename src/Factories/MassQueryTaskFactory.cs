using TaskQueueFactoryMethod.Tasks;

namespace TaskQueueFactoryMethod.Factories;

public class MassQueryTaskFactory : TaskFactoryBase
{
    public override ITask CreateTask()
    {
        return new MassQueryTask();
    }
}