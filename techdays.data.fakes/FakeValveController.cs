using System;
using techdays.domain.core.Workers;

namespace techdays.data.fakes
{
    public class FakeValveController : IValveController
    {
        public void Close(int valveId)
        {
            throw new NotImplementedException();
        }

        public void Open(int valveId)
        {
            throw new NotImplementedException();
        }

        public void OperateOnTarget(Guid plantId)
        {
            throw new NotImplementedException();
        }
    }
}