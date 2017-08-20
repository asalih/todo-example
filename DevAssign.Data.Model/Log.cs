using DevAssign.Data.Model.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAssign.Data.Model
{
    public class Log : EntityBase
    {
        [Required]
        public string Message { get; set; }
        [Required]
        public LogType Type { get; set; }
    }
}
