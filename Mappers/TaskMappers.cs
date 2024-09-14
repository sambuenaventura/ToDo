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

        public static Task ToTaskFromCreateDto(this CreateTaskDto createTaskDto)
        {
            return new Task
            {
                Name = createTaskDto.Name,
                Description = createTaskDto.Description,
                Due = createTaskDto.Due,
                Priority = createTaskDto.Priority,
                Status = createTaskDto.Status,
                Tag = createTaskDto.Tag,
                Attachment = createTaskDto.Attachment,
            };
        }

        public static Task ToTaskFromUpdateDto(this UpdateTaskDto updateTaskDto)
        {
            return new Task
            {
                Name = updateTaskDto.Name,
                Description = updateTaskDto.Description,
                Due = updateTaskDto.Due,
                Priority = updateTaskDto.Priority,
                Status = updateTaskDto.Status,
                Tag = updateTaskDto.Tag,
                Attachment = updateTaskDto.Attachment,
            };
        }
    }
}