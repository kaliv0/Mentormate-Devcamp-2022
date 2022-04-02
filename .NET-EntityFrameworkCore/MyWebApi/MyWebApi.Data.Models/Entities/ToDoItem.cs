namespace MyWebApi.Data.Models.Entities
{
    public class ToDoItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int? PriorityId { get; set; }

        public Priority? Priority { get; set; }

        public int? StatusId { get; set; }

        public Status? Status { get; set; }
    }
}
