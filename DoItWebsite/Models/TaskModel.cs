using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoItWebsite.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public int CompletionID { get; set; }
        public string Status { get; set; }
        


    }
}
