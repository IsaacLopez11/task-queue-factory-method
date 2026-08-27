using TaskQueueFactoryMethod.Task;

namespace TaskQueueFactoryMethod.Factories;

public abstract class TaskFactory
{
    public abstract ITask CreateTask();
}