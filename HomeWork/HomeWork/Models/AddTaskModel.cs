namespace HomeWork.Models
{
    using HomeWork.Db.Entities;

    public class AddTaskModel
    {
        public Task Task { get; set; }

        public string ListName { get; set; }
    }
}