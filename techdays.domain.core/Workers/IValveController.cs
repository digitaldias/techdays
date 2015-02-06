using System;

namespace techdays.domain.core.Workers
{
    public interface IValveController
    {
        void Open(int valveId);

        void Close(int valveId);

        void OperateOnTarget(Guid plantId);
    }
}