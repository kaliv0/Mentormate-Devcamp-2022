namespace MyWebApi.Data.Models.Entities
{
    using MyWebApi.Data.Models.Entities.Enums;

    public class Priority
    {
        public Priority()
        {
            this.ToDoItems = new HashSet<ToDoItem>();
        }

        public int Id { get; set; }

        public PriorityLevel Title { get; set; }

        public virtual ICollection<ToDoItem> ToDoItems { get; set; }
    }
}
