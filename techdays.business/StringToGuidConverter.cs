using System;
using techdays.domain.core.Workers;

namespace techdays.business
{
    public class StringToGuidConverter : IStringToGuidConverter
    {
        public Guid ToGuid(string id)
        {
            Guid finalId = Guid.Empty;

            if (string.IsNullOrEmpty(id))
                return finalId;

            Guid.TryParse(id, out finalId);

            return finalId;
        }
    }
}