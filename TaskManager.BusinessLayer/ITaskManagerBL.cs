using System;
using System.Collections.Generic;
using TaskManager.BusinessLayer.Models;

namespace TaskManager.BusinessLayer
{
    public interface ITaskManagerBL
    {
        void AddTask(TaskModel newTask);
        TaskModel GetTaskById(int Id);
        IEnumerable<TaskModel> GetAllTasks();
        IEnumerable<TaskModel> SearchByTaskParams(string TaskName = "", string parentTaskName = "", int? priFrom = default(int?), int? priTo = default(int?), DateTime? dtFrm = default(DateTime?), DateTime? dtTo = default(DateTime?));
        void UpdateTask(TaskModel updTask);
    }
}