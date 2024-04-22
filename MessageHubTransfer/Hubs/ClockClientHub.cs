using MessageHubTransfer.Model;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.VisualBasic;

namespace MessageHubTransfer.Hubs
{
    public class ClockClientHub : IClock, IHostedService
    {
        private readonly ILogger<ClockClientHub> _logger;
        private HubConnection _connection;

        public ClockClientHub(ILogger<ClockClientHub> logger)
        {
            _logger = logger;
            _connection = new HubConnectionBuilder()
              .WithUrl("https://localhost:7138/clockData").WithAutomaticReconnect()
              //.WithUrl("http://localhost:5133/clockData").WithAutomaticReconnect()

              .Build();
            _connection.StartAsync();
        }

        public Task broadCastTimeServer(DateTime datetime)
        {
            DateTime serverTime = DateTime.Now;
            _logger.LogInformation("{CurrentTime}", serverTime);
            return Task.CompletedTask;
        }

        #region StartAsync
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // Loop is here to wait until the server is running
            while (true)
            {
                try
                {
                    await _connection.StartAsync(cancellationToken);

                    break;
                }
                catch
                {
                    await Task.Delay(1000, cancellationToken);
                }
            }
        }
        #endregion
        #region StopAsync
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _connection.DisposeAsync();
        }
        #endregion
    }

}
