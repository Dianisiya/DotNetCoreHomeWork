namespace HomeWork.Db
{
    using HomeWork.Db.Entities;

    using Microsoft.EntityFrameworkCore;
    public class ToDoListDbContext: DbContext
    {
        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options)
        {
        }

        public virtual DbSet<List> Lists { get; set; }
       
        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<List>().ToTable("List");
            modelBuilder.Entity<Task>().ToTable("Task");
        }
    }
}