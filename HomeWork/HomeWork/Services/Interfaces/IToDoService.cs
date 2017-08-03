namespace HomeWork.Services.Interfaces
{
    using System.Collections.Generic;

    using HomeWork.Db.Entities;

    using Newtonsoft.Json.Linq;

    public interface IToDoService
    {
        IEnumerable<List> GetLists();

        List GetList(string name);

        IEnumerable<Task> GetTasks(string listName);

        IEnumerable<Task> GetTasks();

        Task GetTask(string listName, string taskTitle);

        void DeleteTask(string listName, string taskTitle);

        void DeleteList(string listName);

        void AddList(List list);

        void AddTask(Task task, string listName);
    }
}