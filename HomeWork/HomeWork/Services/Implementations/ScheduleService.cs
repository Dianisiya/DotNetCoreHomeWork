namespace HomeWork.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using HomeWork.Db.Entities;
    using HomeWork.Services.Interfaces;

    public class ScheduleService
    {
        private readonly IToDoService toDoService;

        public ScheduleService(IToDoService toDoService)
        {
            this.toDoService = toDoService;
        }

        public IEnumerable<Task> GetNearestTasks(TimeSpan? time = null, string listName = null)
        {
            return string.IsNullOrEmpty(listName)
                       ? this.toDoService.GetTasks().Where(t => t.DeadLine - (time ?? new TimeSpan(1, 0, 0, 0)) <= DateTime.Now)
                       : this.toDoService.GetTasks(listName).Where(t => t.DeadLine - (time ?? new TimeSpan(1, 0, 0, 0)) <= DateTime.Now);
        }
    }
}