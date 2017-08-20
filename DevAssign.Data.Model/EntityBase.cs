using System;

namespace DevAssign.Data.Model
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
