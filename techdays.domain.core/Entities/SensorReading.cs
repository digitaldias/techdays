using System;

namespace techdays.domain.core.Entities
{
    public class SensorReading
    {
        public Guid Id { get; set; }

        public Guid DeviceId { get; set; }

        public double Value { get; set; }

        public DateTime Time { get; set; }
    }
}