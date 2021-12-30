namespace TODOListDDD.api.Data.VO
{
    public class UserTaskVO
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
        public long? UserId { get; set; }
        public long? TaskListId { get; set; }
    }
}
