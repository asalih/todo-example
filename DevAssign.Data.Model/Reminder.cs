using System;

namespace DevAssign.Data.Model
{
    public class Reminder : EntityBase
    {
        public DateTime When { get; set; }
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }
    }
}
