using System;
using techdays.domain.core.Entities;
using techdays.domain.core.Validators;

namespace TechDaysWeb
{
    public class SensorReadingValidator : ISensorReadingValidator
    {
        public bool IsValid(SensorReading sensorReading)
        {
            return true;
        }
    }
}