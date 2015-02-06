using System;
using techdays.domain.core.Entities;

namespace techdays.domain.core.Workers
{
    public interface IValveController
    {
        void Open(int valveId);

        void Close(int valveId);

        void SetActivePlant(Guid plantId);
    }
}