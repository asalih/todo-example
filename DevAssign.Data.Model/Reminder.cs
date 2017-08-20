using System;
using System.ComponentModel.DataAnnotations;

namespace DevAssign.Data.Model
{
    public class Reminder : EntityBase
    {
        [Required]
        public DateTime When { get; set; }
        public int TaskId { get; set; }
        public bool NotifyState { get; set; }
        public virtual Task Task { get; set; }
    }
}
