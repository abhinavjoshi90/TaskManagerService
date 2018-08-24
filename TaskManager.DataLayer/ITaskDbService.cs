using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManager.DataLayer
{
    public interface ITaskDbService
    {
        void AddTask(Task obj);
        IQueryable<Task> GetAllTasks();
        Task GetTaskById(int Id);
        IQueryable<Task> SearchTasksByParams(string TaskName = "", string parentTaskName = "", int? priFrom = default(int?), int? priTo = default(int?), DateTime? dtFrm = default(DateTime?), DateTime? dtTo = default(DateTime?));
        void UpdateTask(Task obj);
    }
}