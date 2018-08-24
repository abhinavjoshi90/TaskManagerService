using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.BusinessLayer.Models;
using TaskManager.DataLayer;

namespace TaskManager.BusinessLayer
{
    public class TaskManagerBL : ITaskManagerBL
    {
        public ITaskDbService _dbService;
        public TaskManagerBL(ITaskDbService dbService)
        {
            _dbService = dbService;
        }

        public IEnumerable<TaskModel> GetAllTasks()
        {
            var allTasks = from item in _dbService.GetAllTasks()
                           select new TaskModel()
                           {
                               TaskID = item.Task_ID,
                               TaskName = item.Task1,
                               ParentTaskID = item.ParentTask != null ? (int?)(item.ParentTask.Parent_ID) : null,
                               ParentTaskName = item.ParentTask != null ? item.ParentTask.Parent_Task : null,
                               StartDate = item.Start_Date,
                               EndDate = item.End_Date,
                               Priority = item.Priority
                           };
            return allTasks.ToList();
        }
        public TaskModel GetTaskById(int Id)
        {
            var item = _dbService.GetTaskById(Id);
            var task =  new TaskModel()
                           {
                               TaskID = item.Task_ID,
                               TaskName = item.Task1,
                               ParentTaskID = item.ParentTask != null ? (int?)(item.ParentTask.Parent_ID) : null,
                               ParentTaskName = item.ParentTask != null ? item.ParentTask.Parent_Task : null,
                               StartDate = item.Start_Date,
                               EndDate = item.End_Date,
                               Priority = item.Priority
                           };
            return task;
        }
        public void AddTask(TaskModel newTask)
        {
            DataLayer.Task newObj = new DataLayer.Task()
            {
                Task1 = newTask.TaskName,
                ParentTask = newTask.ParentTaskName == null ? null : new ParentTask() { Parent_Task = newTask.ParentTaskName },
                Start_Date = newTask.StartDate,
                End_Date = newTask.EndDate,
                Priority = newTask.Priority
            };

            _dbService.AddTask(newObj);
        }

        public void UpdateTask(TaskModel updTask)
        {
            DataLayer.Task updObj = new DataLayer.Task()
            {
                Task_ID = updTask.TaskID,
                Task1 = updTask.TaskName,
                Parent_ID = updTask.ParentTaskName == null ? null : updTask.ParentTaskID,
                ParentTask = updTask.ParentTaskName == null ? null : new ParentTask() { Parent_ID = updTask.ParentTaskID.Value, Parent_Task = updTask.ParentTaskName },
                Start_Date = updTask.StartDate,
                End_Date = updTask.EndDate,
                Priority = updTask.Priority
            };

            _dbService.UpdateTask(updObj);
        }

        public IEnumerable<TaskModel> SearchByTaskParams(string TaskName = "", string parentTaskName = "", int? priFrom = null,
            int? priTo = null, DateTime? dtFrm = null, DateTime? dtTo = null)
        {
            var searchResults = _dbService.SearchTasksByParams(TaskName, parentTaskName, priFrom, priTo, dtFrm, dtTo);

            var filteredResults = from item in searchResults
                                  select new TaskModel()
                                  {
                                      TaskID = item.Task_ID,
                                      TaskName = item.Task1,
                                      ParentTaskID = item.ParentTask != null ? (int?)(item.ParentTask.Parent_ID) : null,
                                      ParentTaskName = item.ParentTask != null ? item.ParentTask.Parent_Task : null,
                                      StartDate = item.Start_Date,
                                      EndDate = item.End_Date,
                                      Priority = item.Priority
                                  };
            return filteredResults.ToList();
        }
    }
}
