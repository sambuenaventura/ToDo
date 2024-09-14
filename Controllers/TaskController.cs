using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Task;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tasks = _context.Tasks.ToList();

            return Ok(tasks);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var taskModel = _context.Tasks.FirstOrDefault(x => x.Id == id);

            if (taskModel == null)  
            {
                return NotFound();
            }
            
            return Ok(taskModel.ToTaskDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateTaskDto createTaskDto)
        {
            var taskModel = createTaskDto.ToTaskFromCreateDto();

            _context.Tasks.Add(taskModel);
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(GetById),
                new { id = taskModel.Id },
                taskModel.ToTaskDto()
                );
        }

        [HttpPost]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateTaskDto updateTaskDto)
        {
            var existingTask = _context.Tasks.Find(id);

            if (existingTask == null)
            {
                return NotFound();
            }

            existingTask.Name = updateTaskDto.Name;
            existingTask.Description = updateTaskDto.Description;
            existingTask.Due = updateTaskDto.Due;
            existingTask.Priority = updateTaskDto.Priority;
            existingTask.Status = updateTaskDto.Status;
            existingTask.Tag = updateTaskDto.Tag;
            existingTask.Attachment = updateTaskDto.Attachment;
            
            _context.SaveChanges();

            return Ok(existingTask.ToTaskDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var existingTask = _context.Tasks.FirstOrDefault(x => x.Id == id);
            
            if (existingTask == null)
            {
                return NotFound();
            }

            _context.Remove(existingTask);
            _context.SaveChanges();
            
            return Ok(existingTask);

        }

    }
}