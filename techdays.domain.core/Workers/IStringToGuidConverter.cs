using System;

namespace techdays.domain.core.Workers
{
    public interface IStringToGuidConverter
    {
        Guid ToGuid(string id);
    }
}