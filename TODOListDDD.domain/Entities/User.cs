using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TODOListDDD.domain.Entities.Base;

namespace TODOListDDD.domain.Entities
{
    public class User : BaseEntity
    {
        [Key]
        [Column("userId")]
        public override long? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public virtual IEnumerable<UserTask> Tasks { get; set; }
    }
}
