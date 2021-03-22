using Microsoft.Extensions.Logging;
using System.Threading;

namespace DependencyInjectionFeature.Services
{
    public class MyRequestContext : IScopedService
    {
        private readonly ILogger<MyRequestContext> _logger;
        private bool _disposed;
        private static int id = 0;

        public MyRequestContext(ILogger<MyRequestContext> logger)
        {
            Interlocked.Increment(ref id);
            OperationId = $"Scoped object(Id:{id}) - {nameof(MyRequestContext)}";
            this._logger = logger;
            _logger.LogInformation($"Created:\t{OperationId}");
        }

        public string OperationId { get; }

        public void Dispose()
        {
            if (_disposed)
                return;

            _logger.LogInformation($"Disposed:\t{OperationId}\n");
            _disposed = true;
        }
    }
}
