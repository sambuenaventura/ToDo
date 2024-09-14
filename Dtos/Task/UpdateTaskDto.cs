using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.Task
{
    public class UpdateTaskDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Due { get; set; }
        public PriorityLevel Priority { get; set; }
        public Status Status { get; set; }
        public string Tag { get; set; } = string.Empty;
        public string Attachment { get; set; } = string.Empty;
    }
}