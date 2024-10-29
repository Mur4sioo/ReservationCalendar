using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Service.Services;

public class OutdatedAvailabilityCleanupService : BackgroundService
{
    private readonly ILogger<OutdatedAvailabilityCleanupService> _logger;
    private readonly Services.CalendarServices _calendarServices;
    private readonly TimeSpan _cleanupInterval = TimeSpan.FromHours(24); // Run daily

    public OutdatedAvailabilityCleanupService(ILogger<OutdatedAvailabilityCleanupService> logger, Services.CalendarServices calendarServices)
    {
        _logger = logger;
        _calendarServices = calendarServices;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("OutdatedAvailabilityCleanupService running at: {time}", DateTimeOffset.Now);
            await Task.Delay(_cleanupInterval, stoppingToken);
        }
    }
}
