using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TODOListDDD.domain.Entities.Base;

namespace TODOListDDD.domain.Entities
{
    public class Category : BaseEntity
    {
        [Key]
        [Column("categoryId")]
        public override long? Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual IEnumerable<TaskList> TaskLists { get; set; }
    }
}
