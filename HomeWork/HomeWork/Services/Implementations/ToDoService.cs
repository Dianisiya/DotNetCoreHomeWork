namespace HomeWork.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;

    using HomeWork.Db;
    using HomeWork.Db.Entities;
    using HomeWork.Services.Interfaces;

    using Microsoft.EntityFrameworkCore;

    public class ToDoService : IToDoService
    {
        private readonly ToDoListDbContext context;

        public ToDoService(ToDoListDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<List> GetLists()
        {
            return this.context.Lists.ToArray();
        }

        public List GetList(string name)
        {
            return this.context.Lists.FirstOrDefault(l => l.Name == name);
        }

        public IEnumerable<Task> GetTasks(string listName)
        {
            return this.context.Lists.Include(l => l.Tasks).FirstOrDefault(l => l.Name == listName)?.Tasks.ToArray();
        }

        public IEnumerable<Task> GetTasks()
        {
            return this.context.Tasks.ToArray();
        }

        public Task GetTask(string listName, string taskTitle)
        {
            return GetTasks(listName).FirstOrDefault(t => t.Title == taskTitle);
        }

        public void DeleteTask(string listName, string taskTitle)
        {
            this.context.Tasks.Remove(this.GetTask(listName, taskTitle));
            this.context.SaveChanges();
        }

        public void DeleteList(string listName)
        {
            var entity = this.context.Lists.Include(l => l.Tasks).FirstOrDefault(l => l.Name == listName);
            this.context.Tasks.RemoveRange(entity.Tasks);
            this.context.Lists.Remove(entity);
            this.context.SaveChanges();
        }

        public void AddList(List list)
        {
            this.context.Lists.Add(list);
            this.context.SaveChanges();
        }

        public void AddTask(Task task, string listName)
        {
            this.context.Lists.Include(l => l.Tasks).FirstOrDefault(l => l.Name == listName)?.Tasks.Add(task);
            this.context.SaveChanges();
        }
    }
}