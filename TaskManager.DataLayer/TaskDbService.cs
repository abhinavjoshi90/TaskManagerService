using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DataLayer
{
    public class TaskDbService : ITaskDbService
    {
        TaskDbContext _dbContext = new TaskDbContext();        
        public IQueryable<Task> GetAllTasks()
        {
            return _dbContext.Tasks;
        }

        public Task GetTaskById(int Id)
        {
            return _dbContext.Tasks.Find(Id);
        }
        public void AddTask(Task obj)
        {
            _dbContext.Tasks.Add(obj);
            _dbContext.SaveChanges();
        }
        public void UpdateTask(Task obj)
        {
            _dbContext.Entry(obj).State = EntityState.Modified;
            if (obj.ParentTask != null)
            {
                _dbContext.Entry(obj.ParentTask).State = EntityState.Modified;
            }
            //var existobj = _dbContext.Tasks.Find(obj.Task_ID);
            //existobj = obj;
            _dbContext.SaveChanges();
        }

        public IQueryable<Task> SearchTasksByParams(string TaskName = "", string parentTaskName = "", int? priFrom = null,
            int? priTo = null, DateTime? dtFrm = null, DateTime? dtTo = null)
        {
            IQueryable<TaskManager.DataLayer.Task> allTasks = GetAllTasks();
           
            if (!String.IsNullOrEmpty(TaskName))
            {
                allTasks = allTasks.Where(c => c.Task1.ToUpper().Contains(TaskName.ToUpper())).Select(x => x);
            }
            if (!String.IsNullOrEmpty(parentTaskName))
            {
                allTasks = allTasks.Where(c => c.ParentTask.Parent_Task.ToUpper().Contains(parentTaskName.ToUpper())).Select(x => x);
            }
            if (priFrom.HasValue)
            {
                allTasks = allTasks.Where(c => c.Priority >= priFrom.Value).Select(x => x);
            }
            if (priTo.HasValue)
            {
                allTasks = allTasks.Where(c => c.Priority <= priTo.Value).Select(x => x);
            }
            if (dtFrm.HasValue)
            {
                allTasks = allTasks.Where(c => c.Start_Date >= dtFrm.Value).Select(x => x);
            }
            if (dtTo.HasValue)
            {
                allTasks = allTasks.Where(c => c.End_Date <= dtTo.Value).Select(x => x);
            }

            return allTasks;
        }

    }
}
