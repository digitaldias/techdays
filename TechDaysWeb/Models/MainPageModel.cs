using System;
using System.Collections.Generic;
using techdays.domain.core.Entities;

namespace TechDaysWeb.Models
{
    public class MainPageModel
    {
        public DateTime ObtainedTime { get; set; }

        public IEnumerable<SensorReading> Readings { get; set; }
    }
}