using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork.Controllers
{
    using HomeWork.Db;
    using HomeWork.Db.Entities;
    using HomeWork.Services.Implementations;
    using HomeWork.Services.Interfaces;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    [Route("api/[controller]")]
    public class ListsController : Controller
    {
        private readonly IToDoService toDoService;

        private readonly ILogger logger;

        public ListsController(IToDoService toDoService, ILogger<ListsController> logger )
        {
            this.toDoService = toDoService;
            this.logger = logger;
        }


        [HttpGet]
        public IEnumerable<List> Get(string listName)
        {
            this.logger.LogInformation(Environment.NewLine + $"Get Lists request. List name: {listName}. IP: {HttpContext.Connection.RemoteIpAddress}" + Environment.NewLine);
            return string.IsNullOrEmpty(listName)
                       ? this.toDoService.GetLists()
                       : new[] { this.toDoService.GetList(listName) };
        }

        [HttpDelete]
        public void DeleteList(string listName)
        {
            this.logger.LogInformation(Environment.NewLine + $"Delete List request. List name: {listName}. IP: {HttpContext.Connection.RemoteIpAddress}" + Environment.NewLine);
            this.toDoService.DeleteList(listName);
        }

        [HttpPost]
        public void AddList(List list)
        {
            this.logger.LogInformation(Environment.NewLine + $"Add List request. List name: {list.Name}. IP: {HttpContext.Connection.RemoteIpAddress}" + Environment.NewLine);
            this.toDoService.AddList(list);
        }
    }
}
