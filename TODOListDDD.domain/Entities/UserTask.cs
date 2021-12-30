using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TODOListDDD.domain.Entities.Base;

namespace TODOListDDD.domain.Entities
{
    public class UserTask : BaseEntity
    {
        [Key]
        [Column("userTaskId")]
        public override long? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Completed { get; set; }
        [Required]
        public long? UserId { get; set; }
        public long? TaskListId { get; set; }
        public virtual TaskList Tasklist { get; set; }
    }
}
