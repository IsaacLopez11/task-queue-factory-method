// using System.Threading.Tasks.Sources;
using TaskQueueFactoryMethod.Tasks;

ITask BillingTask = new BillingTask();
ITask ReportTask = new ReportTask();
ITask MassQueryTask = new MassQueryTask();

BillingTask.Execute();
ReportTask.Execute();
MassQueryTask.Execute();