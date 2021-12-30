using System.Collections.Generic;
using System.Linq;
using TODOListDDD.api.Data.Converter.Contract;
using TODOListDDD.api.Data.VO;
using TODOListDDD.domain.Entities;

namespace TODOListDDD.api.Data.Converter.Implementations
{
    public class TaskListConverter : IParse<TaskList, TaskListVO>, IParse<TaskListVO, TaskList>
    {
        protected CategoryConverter categoryConverter = new CategoryConverter();
        protected UserTaskConverter userTaskConverter = new UserTaskConverter();
        
        public TaskList Parse(TaskListVO origin)
        {
            if (origin == null) return null;

            return new TaskList()
            {
                CategoryId = origin.CategoriaId,
                Completed = origin.Completed,
                Id = origin.Id,
                Name = origin.Name
            };
        }

        public TaskListVO Parse(TaskList origin)
        {
            if (origin == null) return null;

            return new TaskListVO()
            {
                CategoriaId = origin.CategoryId,
                Category = categoryConverter.Parse(origin.Category),
                Completed = origin.Completed,
                Id = origin.Id,
                Name = origin.Name,
                UserTasks = userTaskConverter.Parse(origin.UserTasks),
            };
        }

        public IEnumerable<TaskList> Parse(IEnumerable<TaskListVO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public IEnumerable<TaskListVO> Parse(IEnumerable<TaskList> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
