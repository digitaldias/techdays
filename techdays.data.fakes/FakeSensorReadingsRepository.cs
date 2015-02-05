using System;
using System.Collections.Generic;
using techdays.domain.core.Entities;
using techdays.domain.core.Repositories;

namespace techdays.data.fakes
{
    public class FakeSensorReadingsRepository : ISensorReadingsRepository
    {
        public SensorReading Add(SensorReading sensorReading)
        {
            if (sensorReading.Id == Guid.Empty)
                sensorReading.Id = Guid.NewGuid();

            return sensorReading;
        }

        public SensorReading GetById(Guid realId)
        {
            return new SensorReading{
                Id = realId,
                DeviceId = Guid.NewGuid(),
                Value = 66.7,
                Time = DateTime.Now.AddMinutes(-30)
            };
        }

        public IEnumerable<SensorReading> GetTop(int count)
        {
            var deviceId = Guid.NewGuid();

            for(int i = 0; i < count; i++)
            {
                yield return new SensorReading
                {
                    Id = Guid.NewGuid(),
                    DeviceId = deviceId,
                    Value = (double) DateTime.Now.Ticks % 100,
                    Time = DateTime.Now.AddMinutes(-15.0 * i)
                };
            }
        }
    }
}