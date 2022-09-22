namespace MyApi.Services;

public interface ICounterService
{
    public Task ChangeCount(int value);
    public Task<int> GetCount();
}

public class CounterService : ICounterService
{
    private int _count = 0;

    private readonly ILogger<ICounterService> _logger;

    public CounterService(ILogger<ICounterService> logger)
    {
        _logger = logger;
    }

    public async Task ChangeCount(int value)
    {
        _logger.LogInformation($"Changed Counter by {value}");
        _count += value;
    }

    public async Task<int> GetCount()
    {
        return _count;
    }
}