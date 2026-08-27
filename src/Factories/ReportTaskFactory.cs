using TaskQueueFactoryMethod.Tasks;

namespace TaskQueueFactoryMethod.Factories;

public class ReportTaskFactory : TaskFactoryBase
{
    public override ITask CreateTask()
    {
        return new ReportTask();
    }
}