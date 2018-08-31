using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBench;
using TaskManager.DataLayer;

namespace NBenchTests
{
    public class NBenchTest
    {
       // private Counter _opCounter;
        [PerfSetup]
        public void SetUp(BenchmarkContext context)
        {
           // _opCounter = context.GetCounter("MyCounter");
        }

        [PerfBenchmark(NumberOfIterations = 5, RunMode = RunMode.Throughput, RunTimeMilliseconds = 1000, TestMode = TestMode.Measurement)]
      //  [CounterMeasurement("MyCounter")]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, ByteConstants.SixtyFourKb)]
        public void BenchMarkMethod_GetAllTasks(BenchmarkContext context)
        {
            TaskDbService _dbSvc = new TaskDbService();
            IEnumerable<TaskManager.DataLayer.Task> allTasks = _dbSvc.GetAllTasks().ToList();
          //  _opCounter.Increment();
        }

        [PerfBenchmark(NumberOfIterations = 5, RunMode = RunMode.Throughput, RunTimeMilliseconds = 1000, TestMode = TestMode.Measurement)]
       // [CounterMeasurement("MyCounter")]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, ByteConstants.SixtyFourKb)]
        public void BenchMarkMethod_SaveTask(BenchmarkContext context)
        {
            TaskDbService _dbSvc = new TaskDbService();
            TaskManager.DataLayer.Task newtask = new TaskManager.DataLayer.Task()
            {
                Task1 = "Task6",
                Start_Date = new DateTime(2018, 09, 01),
                End_Date = new DateTime(2018, 09, 10),
                Priority = 17,
                ParentTask = new ParentTask() { Parent_Task = "ParentTask6" }
            };
            _dbSvc.AddTask(newtask);

          //  _opCounter.Increment();
        }

        [PerfBenchmark(NumberOfIterations = 5, RunMode = RunMode.Throughput, RunTimeMilliseconds = 1000, TestMode = TestMode.Measurement)]
      //  [CounterMeasurement("MyCounter")]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, ByteConstants.SixtyFourKb)]
        public void BenchMarkMethod_UpdateTask(BenchmarkContext context)
        {
            TaskDbService _dbSvc = new TaskDbService();
            TaskManager.DataLayer.Task updateTask = new TaskManager.DataLayer.Task();
            updateTask = _dbSvc.GetTaskById(16);
            updateTask.ParentTask.Parent_Task = "ParentTask6_Updt";
            _dbSvc.UpdateTask(updateTask);

           // _opCounter.Increment();
        }
        [PerfBenchmark(NumberOfIterations = 5, RunMode = RunMode.Throughput, RunTimeMilliseconds = 1000, TestMode = TestMode.Measurement)]
        //  [CounterMeasurement("MyCounter")]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, ByteConstants.SixtyFourKb)]
        public void BenchMarkMethod_SearchTask(BenchmarkContext context)
        {
            TaskDbService _dbSvc = new TaskDbService();
            IEnumerable<TaskManager.DataLayer.Task> filteredTasks =
                _dbSvc.SearchTasksByParams(dtFrm: new DateTime(2018, 08, 14), dtTo: new DateTime(2018, 08, 22));

        }


    }
}
