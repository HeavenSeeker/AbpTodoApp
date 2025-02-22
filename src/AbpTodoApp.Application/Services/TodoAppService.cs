using AbpTodoApp.DTO.TodoItem;
using AbpTodoApp.Entities;
using AbpTodoApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace AbpTodoApp.Application.Services
{
    public class TodoAppService : ApplicationService, ITodoAppService
    {
        private readonly IRepository<TodoItem, Guid> _todoItemRepository;

        public TodoAppService(IRepository<TodoItem, Guid> todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public async Task<TodoItemDto> CreateAsync(CreateTodoItemDto createTodoItemDto)
        {
            var todoItem = await _todoItemRepository.InsertAsync(
                new TodoItem
                {
                    Title = createTodoItemDto.Title,
                    Description = createTodoItemDto.Description,
                    IsCompleted = createTodoItemDto.IsCompleted
                }
            );

            return new TodoItemDto
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                Description = todoItem.Description,
                IsCompleted = todoItem.IsCompleted
            };
        }

        public async Task<TodoItemDto> UpdateAsync(UpdateTodoItemDto updateTodoItemDto)
        {
            var todoItem = await _todoItemRepository.FindAsync(updateTodoItemDto.Id.Value);
            if (todoItem is null)
            {
                return null;
            }
            todoItem.Title = updateTodoItemDto.Title;
            todoItem.Description = updateTodoItemDto.Description;
            todoItem.IsCompleted = updateTodoItemDto.IsCompleted;

            await _todoItemRepository.UpdateAsync(todoItem);

            return new TodoItemDto
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                Description = todoItem.Description,
                IsCompleted = todoItem.IsCompleted
            };
        }

        public async Task DeleteAsync(Guid id)
        {
            await _todoItemRepository.DeleteAsync(id);
        }

        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)] //cache response for 1 minute
        public async Task<List<TodoItemDto>> GetListAsync()
        {
            var items = await _todoItemRepository.GetListAsync();
            return items.Select(item => new TodoItemDto
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                IsCompleted = item.IsCompleted
            }).ToList();
        }

        public async Task<TodoItemDto> GetItemAsync(Guid id)
        {
            var item = await _todoItemRepository.FindAsync(id);
            if (item is null)
            {
                return null;
            }
            var todoItemDto = new TodoItemDto
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                IsCompleted = item.IsCompleted
            };
            return todoItemDto;
        }
    }
}
