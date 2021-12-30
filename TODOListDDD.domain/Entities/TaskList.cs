using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TODOListDDD.domain.Entities.Base;

namespace TODOListDDD.domain.Entities
{
    public class TaskList : BaseEntity
    {
        [Key]
        [Column("taskListId")]
        public override long? Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual IEnumerable<UserTask> UserTasks { get; set; }
    }
}
