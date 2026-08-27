using TaskQueueFactoryMethod.Tasks;

namespace TaskQueueFactoryMethod.Factories;

public class ReportTaskFactory : TaskFactory
{
    public override ITask CreateTask()
    {
        return new ReportTask();
    }
}