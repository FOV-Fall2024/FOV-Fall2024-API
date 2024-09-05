
using MediatR;

namespace FOV.Presentation.Infrastructure.BackgroundServer;

public class ScheduleCheckIngredientDailyWorker : CronJobBackgroundService
{
    private readonly ILogger _logger;
    private readonly IMediator _mediator;

    public ScheduleCheckIngredientDailyWorker(ILogger<ScheduleCheckIngredientDailyWorker> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
        Cron = "0 3 * * * ? *"; // Every day at 3 AM
    }

    protected override async Task DoWork(CancellationToken stoppingToken)
    {
        try
        {
            _logger.LogInformation("Worker running at: {Time}", DateTimeOffset.Now);

            await Task.Delay(2000, stoppingToken);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, string.Empty);
        }
    }
}
