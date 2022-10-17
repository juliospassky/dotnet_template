using Domain.Interfaces;
using Infrastructure.Repository.Config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Repository;

public class TodoRepository : ITodoRepository
{
    private readonly IMongoCollection<Todo> _service;

    public TodoRepository(IOptions<MongoDbConfig> options)
    {
        var mongoDb = new MongoClient(options.Value.ConnectionString);
        _service = mongoDb.GetDatabase(options.Value.DatabaseName)
            .GetCollection<Todo>(options.Value.Todo);
    }

    public async Task<List<Todo>> GetPages(int skipSize, int limitSize)
    {
        return await _service
            .Find(o => true)
            .Skip(skipSize)
            .Limit(limitSize)
            .ToListAsync();
    }

    public async Task<Todo> GetById(string id) =>
        await _service.Find(o => o.Id == id).FirstOrDefaultAsync();

    public async Task Create(Todo newTodo) =>
        await _service.InsertOneAsync(newTodo);

    public async Task Update(string id, Todo updateTodo) =>
        await _service.ReplaceOneAsync(o => o.Id == id, updateTodo);

    public async Task Delete(string id) =>
        await _service.DeleteOneAsync(o => o.Id == id);
}
