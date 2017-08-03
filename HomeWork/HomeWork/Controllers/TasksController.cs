using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeWork.Controllers
{
    using HomeWork.Db.Entities;
    using HomeWork.Models;
    using HomeWork.Services.Interfaces;

    using Microsoft.Extensions.Logging;

    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private readonly IToDoService toDoService;

        private readonly ILogger logger;

        public TasksController(IToDoService toDoService, ILogger<TasksController> logger)
        {
            this.toDoService = toDoService;
            this.logger = logger;
        }


        [HttpGet]
        public IEnumerable<Task> Get(string listName)
        {
            this.logger.LogInformation(Environment.NewLine + $"Get Tasks request. List name: {listName}. IP: {HttpContext.Connection.RemoteIpAddress}" + Environment.NewLine);
            return string.IsNullOrEmpty(listName) ? this.toDoService.GetTasks() : this.toDoService.GetTasks(listName);
        }

        [HttpDelete]
        public void DeleteTask(string listName, string taskTitle)
        {
            this.logger.LogInformation(Environment.NewLine + $"Delete Task request. List name: {listName}. Task title. {taskTitle} IP: {HttpContext.Connection.RemoteIpAddress}" + Environment.NewLine);
            this.toDoService.DeleteTask(listName, taskTitle);
        }

        [HttpPost]
        public void AddTask([FromBody] AddTaskModel model)
        {
            this.logger.LogInformation(Environment.NewLine + $"Add Task request. List name: {model.ListName}. Task title. {model.Task.Title} IP: {HttpContext.Connection.RemoteIpAddress}" + Environment.NewLine);
            this.toDoService.AddTask(model.Task, model.ListName);
        }
    }
}
