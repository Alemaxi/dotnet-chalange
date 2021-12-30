using System.Collections.Generic;
using System.Linq;
using TODOListDDD.api.Data.Converter.Contract;
using TODOListDDD.api.Data.VO;
using TODOListDDD.domain.Entities;

namespace TODOListDDD.api.Data.Converter.Implementations
{
    public class UserTaskConverter : IParse<UserTask, UserTaskVO>, IParse<UserTaskVO, UserTask>
    {

        public UserTask Parse(UserTaskVO origin)
        {
            if (origin == null) return null;

            return new UserTask()
            {
                Completed = origin.Completed,
                Id = origin.Id,
                Name = origin.Name,
                TaskListId = origin.TaskListId,
                UserId = origin.UserId,
            };
        }

        public UserTaskVO Parse(UserTask origin)
        {
            if (origin == null) return null;

            return new UserTaskVO()
            {
                Completed = origin.Completed,
                Id = origin.Id,
                Name = origin.Name,
                TaskListId = origin.TaskListId,
                UserId = origin.UserId,
            };
        }

        public IEnumerable<UserTask> Parse(IEnumerable<UserTaskVO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public IEnumerable<UserTaskVO> Parse(IEnumerable<UserTask> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
