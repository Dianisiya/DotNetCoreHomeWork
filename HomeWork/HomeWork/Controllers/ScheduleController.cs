using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeWork.Controllers
{
    using HomeWork.Db.Entities;
    using HomeWork.Services.Implementations;
    using HomeWork.Services.Interfaces;

    using Microsoft.Extensions.Logging;

    [Route("api/[controller]")]
    public class ScheduleController : Controller
    {
        private readonly ScheduleService scheduleService;

        private readonly ILogger logger;

        public ScheduleController(ScheduleService scheduleService, ILogger<ListsController> logger)
        {
            this.scheduleService = scheduleService;
            this.logger = logger;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Task> Get(TimeSpan? dateTime, string listName)
        {
            return this.scheduleService.GetNearestTasks(dateTime, listName);
        }
    }
}

