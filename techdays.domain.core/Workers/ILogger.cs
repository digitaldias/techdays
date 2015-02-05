using System;

namespace techdays.domain.core.Workers
{
    public interface ILogger
    {
        void LogException(string callingMethod, Exception ex);
    }
}