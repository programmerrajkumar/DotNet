using Microsoft.Extensions.Logging;
using System.Threading;

namespace DependencyInjectionFeature.Services
{
    public class MyUniqueIdContext : ITransientService
    {
        private readonly ILogger<MyUniqueIdContext> _logger;
        private bool _disposed;
        private static int id = 0;

        public MyUniqueIdContext(ILogger<MyUniqueIdContext> logger)
        {
            Interlocked.Increment(ref id);
            OperationId = $"Transient object(Id:{id}) - {nameof(MyUniqueIdContext)}";
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
