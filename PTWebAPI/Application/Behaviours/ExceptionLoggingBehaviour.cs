using MediatR.Pipeline;
using MediatR;

namespace User.Microservice.Application.Behaviours
{
    public class ExceptionLoggingBehaviour<TRequest, TResponse, TException> : IRequestExceptionHandler<TRequest, TResponse, TException>
          where TRequest : IRequest<TResponse>
          where TException : Exception
    {
        private readonly ILogger<ExceptionLoggingBehaviour<TRequest, TResponse, TException>> _logger;

        public ExceptionLoggingBehaviour(ILogger<ExceptionLoggingBehaviour<TRequest, TResponse, TException>> logger)
        {
            _logger = logger;
        }

        public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "Error while handling request of type {@requestType}", typeof(TRequest));

            // TODO: Details of error handling, need to expand this .
            state.SetHandled(default!);

            return Task.CompletedTask;
        }
    }
}
