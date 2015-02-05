using System;
using techdays.domain.core.Entities;

namespace techdays.domain.core.Validators
{
    public interface ISensorReadingValidator
    {
        bool IsValid(SensorReading sensorReading);
    }
}