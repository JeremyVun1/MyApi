using MyApi.Models;
using SQLite;

namespace MyApi.Handlers;

public interface IDatabaseHandler
{
    Task<List<Counter>> GetCounters();
    Task<Counter> GetCounter(int counterId = 1);
    Task ChangeCounter(int value, int counterId = 1);
    Task DeleteCounter(int counterId);
    Task CreateCounter();
}

public class DatabaseHandler : IDatabaseHandler {

    private SQLiteConnection _db;

    private string _dbPath;
    
    public DatabaseHandler(IConfiguration config)
    {
        _dbPath = config.GetValue<string>("Database:Path");
        _db = new SQLiteConnection(_dbPath, SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex | SQLiteOpenFlags.ReadWrite);
        _db.CreateTable<Counter>();
    }

    public async Task<List<Counter>> GetCounters()
    {
        return _db.Query<Counter>("SELECT * FROM Counter");
    }

    public async Task<Counter> GetCounter(int counterId = 1)
    {
        return _db.Get<Counter>(counterId);
    }

    public async Task ChangeCounter(int value, int counterId = 1)
    {
        _db.Execute("UPDATE Counter SET Value = Value + ? WHERE Id = ?", value, counterId);
    }

    public async Task DeleteCounter(int counterId)
    {
        _db.Delete<Counter>(counterId);
    }

    public async Task CreateCounter()
    {
        _db.Insert(new Counter
        {
            Value = 0
        });
    }
}	