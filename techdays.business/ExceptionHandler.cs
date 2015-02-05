using System;
using techdays.domain.core.Entities;
using techdays.domain.core.Workers;

namespace techdays.business
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly ILogger _logger;

        public ExceptionHandler(ILogger logger)
        {
            _logger = logger;
        }


        public T GetFromUnsafeMethod<T>(string callingMethodName, Func<T> unsafeFunction)
        {
            try
            {
                return unsafeFunction.Invoke();
            }
            catch(Exception ex)
            {
                _logger.LogException(callingMethodName, ex);
            }
            return default(T);
        }


        public void RunAction(string callingMethodName, Func<SensorReading> unsafeAction)
        {
            try
            {
                unsafeAction.Invoke();
            }
            catch(Exception ex)
            {
                _logger.LogException(callingMethodName, ex);
            }
        }
    }
}