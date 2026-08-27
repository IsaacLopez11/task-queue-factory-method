using TaskQueueFactoryMethod.Tasks;

namespace TaskQueueFactoryMethod.Factories;

public abstract class TaskFactoryBase
{
    public abstract ITask CreateTask();
}