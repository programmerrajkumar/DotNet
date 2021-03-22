using System;

namespace DependencyInjectionFeature.Services
{
    public interface IMyService : IDisposable
    {
        string OperationId { get; }
    }

    public interface ITransientService : IMyService { }
    public interface IScopedService : IMyService { }
    public interface ISingletonService : IMyService { }
}
