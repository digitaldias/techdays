using System;
using System.Collections.Generic;
using techdays.domain.core.Entities;

namespace techdays.domain.core.Repositories
{
    public interface ISensorReadingsRepository
    {
        SensorReading Add(SensorReading sensorReading);

        IEnumerable<SensorReading> GetTop(int count);

        SensorReading GetById(Guid realId);
    }
}