using System;

using NUnit.Framework;
using Moq;
using TaskManager.BusinessLayer;
using TaskManager.DataLayer;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TaskManager.BusinessLayer.Models;

namespace TaskManager.UnitTest
{
   [TestFixture]
    public class TaskManagerTest
    {
       [Test]
        public void Test_GetAllTasks()
        {
            IEnumerable<TaskManager.DataLayer.Task> lstTask = new List<TaskManager.DataLayer.Task>
               {
                new TaskManager.DataLayer.Task(){ Task1="Task1" ,Start_Date=new DateTime(2018,08,14),End_Date=new DateTime(2018,08,20),Priority=10, ParentTask=new ParentTask(){Parent_Task="ParentTask1" } },
                new TaskManager.DataLayer.Task(){ Task1="Task2" ,Start_Date=new DateTime(2018,08,16),End_Date=new DateTime(2018,08,22),Priority=15, ParentTask=new ParentTask(){Parent_Task="ParentTask2" } },
                new TaskManager.DataLayer.Task(){ Task1="Task3" ,Start_Date=new DateTime(2018,08,18),End_Date=new DateTime(2018,08,24),Priority=20, ParentTask=new ParentTask(){Parent_Task="ParentTask3" } },
                new TaskManager.DataLayer.Task(){ Task1="Task4" ,Start_Date=new DateTime(2018,08,20),End_Date=new DateTime(2018,08,26),Priority=25, ParentTask=new ParentTask(){Parent_Task="ParentTask4" } },
                new TaskManager.DataLayer.Task(){ Task1="Task5" ,Start_Date=new DateTime(2018,08,22),End_Date=new DateTime(2018,08,28),Priority=30, ParentTask=new ParentTask(){Parent_Task="ParentTask5" } },
                };

            Mock<ITaskDbService> mockDb = new Mock<ITaskDbService>();
            TaskManagerBL obj = new TaskManagerBL(mockDb.Object);
            mockDb.Setup(c => c.GetAllTasks()).Returns(lstTask.AsQueryable());
            var expectedCount = 5;
            var result = obj.GetAllTasks();
            Assert.AreEqual(expectedCount, result.Count());            
        }
        [Test]
        public void Test_GetTaskById()
        {
            DataLayer.Task objTsk = new DataLayer.Task()
            {
                Task1 = "Task1",
                Start_Date = new DateTime(2018, 08, 14),
                End_Date = new DateTime(2018, 08, 20),
                Priority = 10,
                ParentTask = new ParentTask() { Parent_Task = "ParentTask1" }
            };

            Mock<ITaskDbService> mockDb = new Mock<ITaskDbService>();
            TaskManagerBL obj = new TaskManagerBL(mockDb.Object);
            mockDb.Setup(c => c.GetTaskById(It.IsAny<Int32>())).Returns(objTsk);
            var expectedTaskName = "Task1";
            var result = obj.GetTaskById(1);
            Assert.AreEqual(expectedTaskName, result.TaskName);
        }

        [Test]
        public void Test_AddTask()
        {
            TaskModel objTsk = new TaskModel()
            {
                TaskName = "Task7",
                ParentTaskName = "ParentTask7",
                StartDate = new DateTime(2018, 09, 10),
                EndDate = new DateTime(2018, 09, 15),
                Priority = 11
            };
            Mock<ITaskDbService> mockDb = new Mock<ITaskDbService>();
            TaskManagerBL obj = new TaskManagerBL(mockDb.Object);
            obj.AddTask(objTsk);
            mockDb.Verify(c => c.AddTask(It.IsAny<Task>()), Times.Once);
        }

        [Test]
        public void Test_UpdateTask()
        {
            TaskModel objTsk = new TaskModel()
            {
                TaskID = 19,
                TaskName = "Task7_Updt",
                ParentTaskID = 12,
                ParentTaskName = "ParentTask7_Updt",
                StartDate = new DateTime(2018, 09, 11),
                EndDate = new DateTime(2018, 09, 16),
                Priority = 21
            };
            Mock<ITaskDbService> mockDb = new Mock<ITaskDbService>();
            TaskManagerBL obj = new TaskManagerBL(mockDb.Object);
            obj.UpdateTask(objTsk);
            mockDb.Verify(c => c.UpdateTask(It.IsAny<Task>()), Times.Once);
        }
        [Test]
        public void Test_SearchTask()
        {
            IEnumerable<TaskManager.DataLayer.Task> lstTask = new List<TaskManager.DataLayer.Task>
               {
                new TaskManager.DataLayer.Task(){ Task1="Task1" ,Start_Date=new DateTime(2018,08,14),End_Date=new DateTime(2018,08,20),Priority=10, ParentTask=new ParentTask(){Parent_Task="ParentTask1" } } ,
                new TaskManager.DataLayer.Task(){ Task1="Task2" ,Start_Date=new DateTime(2018,08,16),End_Date=new DateTime(2018,08,22),Priority=15, ParentTask=new ParentTask(){Parent_Task="ParentTask2" } }
               };
            Mock<ITaskDbService> mockDb = new Mock<ITaskDbService>();
            TaskManagerBL obj = new TaskManagerBL(mockDb.Object);
            mockDb.Setup(c => c.SearchTasksByParams
                                (It.IsAny<String>(),
                                It.IsAny<String>(),
                                It.IsAny<Nullable<Int32>>(),
                                It.IsAny<Nullable<Int32>>(),
                                It.IsAny<Nullable<DateTime>>(),
                                It.IsAny<Nullable<DateTime>>()))
                                .Returns(lstTask.AsQueryable());
            var result = obj.SearchByTaskParams();
            var expectedCount = 2;
            Assert.AreEqual(expectedCount, result.Count());
        }
    }
}
