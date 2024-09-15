using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Task;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TaskDto> CreateTaskAsync(CreateTaskDto createTaskDto)
        {
            var task = await _context.Tasks.AddAsync(createTaskDto.ToTaskFromCreateDto());
            var taskDto = task.Entity.ToTaskDto();
            
            await _context.SaveChangesAsync();
            
            return taskDto;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return false;
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<List<TaskDto>> GetAllTasksAsync()   
        {
            var tasks = await _context.Tasks.ToListAsync();

            var taskDtos =  tasks.Select(x => x.ToTaskDto()).ToList();

            return taskDtos;
        }
        public async Task<TaskDto?> GetTaskByIdAsync(int id)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);

            if (task == null)
            {
                return null;
            }

            return task.ToTaskDto();
        }

        public async Task<TaskDto?> UpdateTaskAsync(int id, UpdateTaskDto updateTaskDto)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);

            if (task == null)
            {
                return null;
            }

            task.Name = updateTaskDto.Name;
            task.Description = updateTaskDto.Description;
            task.Due = updateTaskDto.Due;
            task.Priority = updateTaskDto.Priority;
            task.Status = updateTaskDto.Status;
            task.Tag = updateTaskDto.Tag;
            task.Attachment = updateTaskDto.Attachment;

            await _context.SaveChangesAsync();

            return task.ToTaskDto();
        }
    }
}