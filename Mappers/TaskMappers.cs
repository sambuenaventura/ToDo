using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Task;
using api.Models;
using Task = api.Models.Task; // Alias the Task model

namespace api.Mappers
{
    public static class TaskMappers
    {
        public static TaskDto ToTaskDto(this Task taskModel)
        {
            return new TaskDto
            {
                Id = taskModel.Id,
                Name = taskModel.Name,
                Description = taskModel.Description,
                Due = taskModel.Due,
                Priority = taskModel.Priority,
                Status = taskModel.Status,
                Tag = taskModel.Tag,
                Attachment = taskModel.Attachment,
                CreatedAt = taskModel.CreatedAt,
                UpdatedAt = taskModel.UpdatedAt,
            };
        }
    }
}