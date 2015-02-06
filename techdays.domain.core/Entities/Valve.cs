using System;

namespace techdays.domain.core.Entities
{
    public class Valve
    {
        public int Id { get; set; }

        public Guid plantId { get; set; }

        public string Name { get; set; }
    }
}