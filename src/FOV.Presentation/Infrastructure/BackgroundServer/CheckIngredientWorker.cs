namespace FOV.Presentation.Infrastructure.BackgroundServer;

public class CheckIngredientWorker : BackgroundService
{
    private readonly ILogger<CheckIngredientWorker> _logger;

    public CheckIngredientWorker(
        ILogger<CheckIngredientWorker> logger)
    {
        _logger = logger;
    }
    protected override  async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogDebug("SendEmailService is starting.");
        await DoWork(stoppingToken);
    }

    private async Task DoWork(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogDebug($"SendEmail task doing background work.");

       
               // var sendEmailsCommand = new SendEmailMessagesCommand();

                //using (var scope = _services.CreateScope())
                //{
                //    var dispatcher = scope.ServiceProvider.GetRequiredService<Dispatcher>();

                //}

                //if (sendEmailsCommand.SentMessagesCount == 0)
                //{
                    await Task.Delay(10000, stoppingToken);
                //}
           
        }

        _logger.LogDebug($"SendEmail background task is stopping.");
    }
}
