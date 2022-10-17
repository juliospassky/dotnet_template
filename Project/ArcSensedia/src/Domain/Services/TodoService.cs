using Domain.Entities;
using Domain.Interfaces;
using Domain.Services.Interfaces;

namespace Domain.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;

    public TodoService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<List<Todo>> GetPages(int skipSize, int limitSize)
    {
        return await _todoRepository.GetPages(skipSize, limitSize);
    }

    public async Task<Todo> GetById(string id) =>
        await _todoRepository.GetById(id);

    public async Task Create(Todo newTodo) =>
        await _todoRepository.Create(newTodo);

    public async Task Update(string id, Todo updateTodo) =>
        await _todoRepository.Update(id, updateTodo);

    public async Task Delete(string id) =>
        await _todoRepository.Delete(id);
}
