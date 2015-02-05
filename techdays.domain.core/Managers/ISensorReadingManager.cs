using System.Collections.Generic;
using techdays.domain.core.Entities;

namespace techdays.domain.core.Managers
{
    public interface ISensorReadingManager
    {
        void Add(SensorReading sensorReading);

        IEnumerable<SensorReading> GetLatest(int count);

        SensorReading Get(string readingId);
    }
}