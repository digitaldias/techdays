using System;
using System.Collections.Generic;
using techdays.domain.core.Entities;

namespace techdays.domain.core.Workers
{
    public interface IExceptionHandler
    {
        void RunAction(string callingMethodName, Action unsafeAction);

        T GetFromUnsafeMethod<T>(string callingMethodName, Func<T> unsafeFunction);
    }
}