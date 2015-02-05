using System;
using System.Diagnostics;
using techdays.domain.core.Workers;

namespace techdays.data.fakes
{
    public class FakeLogger : ILogger
    {
        public void LogException(string callingMethod, Exception ex)
        {
            Debug.WriteLine("{0} failed: {1}", callingMethod, ex.Message);
        }
    }
}