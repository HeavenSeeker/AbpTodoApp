using AbpTodoApp.DTO.TodoItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpTodoApp.Services
{
    public interface ITodoAppService : IApplicationService
    {
        Task<List<TodoItemDto>> GetListAsync();
        Task<TodoItemDto> CreateAsync(CreateTodoItemDto createTodoItemDto);
        Task DeleteAsync(Guid id);
        Task<TodoItemDto> GetItemAsync(Guid id);
        Task<TodoItemDto> UpdateAsync(UpdateTodoItemDto updateTodoItemDto);
    }
}
