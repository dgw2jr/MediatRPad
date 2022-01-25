using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatRPad.Notifications.PipelineBehaviors
{
    public class DebugMessageTimingsBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public Task<TResponse> Handle(TRequest request, CancellationToken token, RequestHandlerDelegate<TResponse> next)
        {
            var messageType = request.GetType().Name;

            Debug.WriteLine($"{messageType} sent...");
            var stopWatch = Stopwatch.StartNew();

            var response = next();

            stopWatch.Stop();
            Debug.WriteLine($"Elapsed Time: {stopWatch.Elapsed} - {messageType} handled.");

            return response;
        }
    }
}
