using System;
using techdays.domain.core.Entities;
using techdays.domain.core.Validators;

namespace techdays.business
{
    public class SensorReadingValidator : ISensorReadingValidator
    {
        public bool IsValid(SensorReading sensorReading)
        {
            if (sensorReading == null)
                return false;

            if (sensorReading.Id == Guid.Empty)
                return false;

            if (sensorReading.DeviceId == Guid.Empty)
                return false;

            if (sensorReading.Value <= 0 || sensorReading.Value > 100)
                return false;

            return sensorReading.Time > DateTime.MinValue && sensorReading.Time < DateTime.MaxValue;
        }
    }
}