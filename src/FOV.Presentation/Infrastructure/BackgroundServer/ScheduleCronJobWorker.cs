
namespace FOV.Presentation.Infrastructure.BackgroundServer;

public class ScheduleCronJobWorker : CronJobBackgroundService
{
    private readonly ILogger<ScheduleCronJobWorker> _logger;

    public ScheduleCronJobWorker(ILogger<ScheduleCronJobWorker> logger
        )
    {
        _logger = logger;
        Cron = "0 0/1 * 1/1 * ? *"; // every minute
    }

    protected override async Task DoWork(CancellationToken stoppingToken)
    {
        try
        {
            _logger.LogInformation("Worker running at: {Time}", DateTimeOffset.Now);

            //using var scope = _serviceProvider.CreateScope();
            //   var notification = scope.ServiceProvider.GetRequiredService<IWebNotification<SendTaskStatusMessage>>();

            //await notification.SendAsync(new SendTaskStatusMessage { Step = "Step 1", Message = "Begining xxx" }, stoppingToken);

            await Task.Delay(2000, stoppingToken);

            //await notification.SendAsync(new SendTaskStatusMessage { Step = "Step 1", Message = "Finished xxx" }, stoppingToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, string.Empty);
        }
    }
}
