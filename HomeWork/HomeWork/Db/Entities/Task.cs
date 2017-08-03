namespace HomeWork.Db.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore.Metadata.Internal;

    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DeadLine { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public int Priority { get; set; }

        public List List { get; set; }
    }
}