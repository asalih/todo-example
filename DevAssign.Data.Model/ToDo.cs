using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevAssign.Data.Model
{
    public class ToDo : EntityBase
    {
        [Required]
        public string ToDoName { get; set; }
        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
