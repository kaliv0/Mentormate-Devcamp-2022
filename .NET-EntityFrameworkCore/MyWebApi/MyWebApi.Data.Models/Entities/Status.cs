namespace MyWebApi.Data.Models.Entities
{
    using MyWebApi.Data.Models.Entities.Enums;

    public class Status
    {
        public Status()
        {
            this.ToDoItems = new HashSet<ToDoItem>();
        }

        public int Id { get; set; }

        public StatusCode Title { get; set; }

        public virtual ICollection<ToDoItem> ToDoItems { get; set; }
    }
}
