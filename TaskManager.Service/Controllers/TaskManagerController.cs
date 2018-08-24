using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.BusinessLayer;
using TaskManager.BusinessLayer.Models;

namespace TaskManager.Service.Controllers
{
    [RoutePrefix("api")]
    public class TaskManagerController : ApiController
    {
        internal ITaskManagerBL _manager;
        public TaskManagerController(ITaskManagerBL manager)
        {
            _manager = manager;
        }
        
        [Route("getall")]
        [HttpGet]
        public IHttpActionResult GetAllTasks()
        {
            return Json<IEnumerable<TaskModel>>(_manager.GetAllTasks());
        }

        [Route("get/{Id}")]
        [HttpGet]
        public IHttpActionResult GetTaskById(int Id)
        {
            return Json<TaskModel>(_manager.GetTaskById(Id));
        }
        [Route("add")]
        [HttpPost]
        public IHttpActionResult AddTask(TaskModel task)
        {
            _manager.AddTask(task);
            return Ok("Task added Successfully");
        }
        [Route("update")]
        [HttpPost]
        public IHttpActionResult UpdateTask(TaskModel task)
        {
            _manager.UpdateTask(task);
            return Ok("Task updated Successfully");
        }

        [Route("search")]
        [HttpGet]
        public IHttpActionResult SearchTaskByParams(
            string n = "",
            string pn = "",
            int? pf = null,
            int? pt = null,
            DateTime? df = null,
            DateTime? dt = null)
        {
            return Json<IEnumerable<TaskModel>>(
                _manager.SearchByTaskParams(
                TaskName: n,
                parentTaskName: pn,
                priFrom: pf,
                priTo: pt,
                dtFrm: df,
                dtTo: dt
                ));
        }


    }
}
