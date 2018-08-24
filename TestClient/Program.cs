using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.BusinessLayer;
using TaskManager.BusinessLayer.Models;
using TaskManager.DataLayer;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Seed Data into database
            // SeedData();

            //Test getalltask() function
            //TaskDbService _dbSvc = new TaskDbService();
            //IEnumerable<TaskManager.DataLayer.Task> allTasks = _dbSvc.GetAllTasks().ToList();

            //Test Add Task function
            //TaskDbService _dbSvc = new TaskDbService();
            //TaskManager.DataLayer.Task newtask = new TaskManager.DataLayer.Task()
            //{
            //    Task1 = "Task6",
            //    Start_Date = new DateTime(2018, 09, 01),
            //    End_Date = new DateTime(2018, 09, 10),
            //    Priority = 17,
            //    ParentTask = new ParentTask() { Parent_Task = "ParentTask6" }
            //};
            //_dbSvc.AddTask(newtask);

            //Test Update Task function
            //TaskDbService _dbSvc = new TaskDbService();
            //TaskManager.DataLayer.Task updateTask = new TaskManager.DataLayer.Task();
            //updateTask = _dbSvc.GetTaskById(16);
            //updateTask.ParentTask.Parent_Task = "ParentTask6_Updt";
            //_dbSvc.UpdateTask(updateTask);

            //TestSearch functionality
            //TaskDbService _dbSvc = new TaskDbService();
            //IEnumerable<TaskManager.DataLayer.Task> filteredTasks =
            //    _dbSvc.SearchTasksByParams(dtFrm: new DateTime(2018, 08, 14), dtTo: new DateTime(2018, 08, 22));


            //Test BL functionality
            //Test GetAllTasks function
            //TaskManagerBL _blSvc = new TaskManagerBL(new TaskDbService());
            //IEnumerable<TaskModel> lst = _blSvc.GetAllTasks();

            //Add Task functionality
            //TaskManagerBL _blSvc = new TaskManagerBL(new TaskDbService());
            //_blSvc.AddTask(new TaskModel() { TaskName = "Task7", ParentTaskName = "ParentTask7", StartDate = new DateTime(2018, 09, 10), EndDate = new DateTime(2018, 09, 15), Priority = 11 });
            //_blSvc.AddTask(new TaskModel() { TaskName = "Task8", StartDate = new DateTime(2018, 09, 15), EndDate = new DateTime(2018, 09, 20), Priority = 13 });

            //Update task functionality
            //TaskManagerBL _blSvc = new TaskManagerBL(new TaskDbService());
            //_blSvc.UpdateTask(new TaskModel() { TaskID = 19, TaskName = "Task7_Updt", ParentTaskID = 12, ParentTaskName = "ParentTask7_Updt", StartDate = new DateTime(2018, 09, 11), EndDate = new DateTime(2018, 09, 16), Priority = 21 });
            //Search functionality
            TaskManagerBL _blSvc = new TaskManagerBL(new TaskDbService());
            IEnumerable<TaskModel> filteredTasks = _blSvc.SearchByTaskParams(dtFrm: new DateTime(2018, 08, 14), dtTo: new DateTime(2018, 09, 10));

        }
        
        static void SeedData()
        {
            using (var context = new TaskDbContext())
            {

                List<TaskManager.DataLayer.Task> lstTask = new List<TaskManager.DataLayer.Task>
               {
                new TaskManager.DataLayer.Task(){ Task1="Task1" ,Start_Date=new DateTime(2018,08,14),End_Date=new DateTime(2018,08,20),Priority=10, ParentTask=new ParentTask(){Parent_Task="ParentTask1" } },
                new TaskManager.DataLayer.Task(){ Task1="Task2" ,Start_Date=new DateTime(2018,08,16),End_Date=new DateTime(2018,08,22),Priority=15, ParentTask=new ParentTask(){Parent_Task="ParentTask2" } },
                new TaskManager.DataLayer.Task(){ Task1="Task3" ,Start_Date=new DateTime(2018,08,18),End_Date=new DateTime(2018,08,24),Priority=20, ParentTask=new ParentTask(){Parent_Task="ParentTask3" } },
                new TaskManager.DataLayer.Task(){ Task1="Task4" ,Start_Date=new DateTime(2018,08,20),End_Date=new DateTime(2018,08,26),Priority=25, ParentTask=new ParentTask(){Parent_Task="ParentTask4" } },
                new TaskManager.DataLayer.Task(){ Task1="Task5" ,Start_Date=new DateTime(2018,08,22),End_Date=new DateTime(2018,08,28),Priority=30, ParentTask=new ParentTask(){Parent_Task="ParentTask5" } },
                };

                context.Tasks.AddRange(lstTask);
                context.SaveChanges();
            }
        }


    }
}
