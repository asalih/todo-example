using System.Collections.Generic;

namespace DevAssign.Data.Model
{
    public class Task : EntityBase
    {
        public int ToDoId{ get; set; }
        public string TaskBody { get; set; }
        public virtual ToDo ToDo { get; set; }

        public virtual ICollection<Reminder> Reminders { get; set; }
    }
}