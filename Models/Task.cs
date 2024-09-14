using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public enum PriorityLevel
    {
        Low,
        Medium,
        High
    }
        public enum Status
    {
        ToDo,
        InProgress,
        Done
    }
    public class Task : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateOnly Due { get; set; }
        public PriorityLevel Priority { get; set; }
        public Status Status { get; set; }
        public string Tag { get; set; } = string.Empty;
        public string Attachment { get; set; } = string.Empty;
    }
}