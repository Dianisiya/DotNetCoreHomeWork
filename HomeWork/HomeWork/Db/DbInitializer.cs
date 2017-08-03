namespace HomeWork.Db
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using HomeWork.Db.Entities;

    public class DbInitializer
    {
        public static void Initialize(ToDoListDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Lists.Any())
            {
                return;   // DB has been seeded
            }

            var lists = new[] { new List
                                    {
                                        Name = "List1",
                                        ListInfo = "Test Info",
                                        Tasks = new List<Task>
                                                    {
                                                        new Task
                                                            {
                                                                DeadLine = new DateTime(2017, 12, 31, 0,0,0),
                                                                Body = "Test Task 1",
                                                                Title = "Test Task 1",
                                                                Priority = 1
                                                            },
                                                        new Task
                                                            {
                                                                DeadLine = new DateTime(2017, 12, 31, 0,0,0),
                                                                Body = "Test Task 2",
                                                                Title = "Test Task 2",
                                                                Priority = 2
                                                            },
                                                        new Task
                                                            {
                                                                DeadLine = new DateTime(2017, 12, 31, 0,0,0),
                                                                Body = "Test Task 3",
                                                                Title = "Test Task 3",
                                                                Priority = 3
                                                            }
                                                    }
                                    }};

            context.Lists.AddRange(lists);
            context.SaveChanges();
        }
    }
}