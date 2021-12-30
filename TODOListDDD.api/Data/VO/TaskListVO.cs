using System.Collections.Generic;

namespace TODOListDDD.api.Data.VO
{
    public class TaskListVO
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
        public long CategoriaId { get; set; }
        public CategoryVO Category { get; set; }

        public virtual IEnumerable<UserTaskVO> UserTasks { get; set; }
    }
}
