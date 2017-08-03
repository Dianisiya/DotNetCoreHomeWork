using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HomeWork.Db;

namespace HomeWork.Migrations
{
    [DbContext(typeof(ToDoListDbContext))]
    [Migration("20170803121620_Second")]
    partial class Second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HomeWork.Db.Entities.List", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("List");
                });

            modelBuilder.Entity("HomeWork.Db.Entities.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTime>("DeadLine");

                    b.Property<int?>("ListId");

                    b.Property<int>("Priority");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ListId");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("HomeWork.Db.Entities.Task", b =>
                {
                    b.HasOne("HomeWork.Db.Entities.List", "List")
                        .WithMany("Tasks")
                        .HasForeignKey("ListId");
                });
        }
    }
}
