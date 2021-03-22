using Microsoft.Extensions.Logging;
using System.Threading;

namespace DependencyInjectionFeature.Services
{
    public class MyCacheContext : ISingletonService
    {
        private readonly ILogger<MyCacheContext> _logger;
        private bool _disposed;
        private static int id = 0;

        public MyCacheContext(ILogger<MyCacheContext> logger)
        {
            Interlocked.Increment(ref id);
            OperationId = $"Singleton object(Id:{id}) - {nameof(MyCacheContext)}";
            this._logger = logger;
            _logger.LogInformation($"Created:\t{OperationId}");
        }

        public string OperationId { get; }

        public void Dispose()
        {
            if (_disposed)
                return;

            _logger.LogInformation($"Disposed:\t{OperationId}");
            _disposed = true;
        }
    }
}
