using MyApi.Handlers;
using MyApi.Models;

namespace MyApi.Services;

public interface ICounterService
{
    Task ChangeCount(Counter counter);
    Task<Counter> GetCounter(int counterId = 1);
    Task<List<Counter>> GetCounters();
    Task DeleteCounter(int counterId);
    Task CreateCounter();
}

public class CounterService : ICounterService
{
    private readonly IDatabaseHandler _dbHandler;

    public CounterService(IDatabaseHandler dbHandler)
    {
        _dbHandler = dbHandler;
    }

    public async Task ChangeCount(Counter counter)
    {
        await _dbHandler.ChangeCounter(counter.Value, counter.Id);
    }

    public async Task<List<Counter>> GetCounters()
    {
        return await _dbHandler.GetCounters();
    }

    public async Task<Counter> GetCounter(int counterId = 1)
    {
        return await _dbHandler.GetCounter(counterId);
    }

    public async Task DeleteCounter(int counterId)
    {
        await _dbHandler.DeleteCounter(counterId);
    }

    public async Task CreateCounter()
    {
        await _dbHandler.CreateCounter();
    }
}