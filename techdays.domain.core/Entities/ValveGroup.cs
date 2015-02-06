using System;
using System.Linq;
using System.Collections.Generic;

namespace techdays.domain.core.Entities
{
    public class ValveGroup
    {
        public List<Valve> _valves { get; set; };

        public Guid PlantId { get; set; }

        public ValveGroup()
        {

        }

        public ValveGroup(IEnumerable<Valve> valves)
        {
            _valves = new List<Valve>();

            if (!valves.Any())
                throw new InvalidProgramException("Cannot create valve group without a single valve!");

            // Assign first plantId
            plantId = valves.First().plantId;

            foreach (var valve in valves)
            {
                if (valve.plantId != plantId)
                    throw new InvalidProgramException("Valve group contains different plant Id's. Each group must target the same plant");

                _valves.Add(valve);
            }
        }

        public Valve GetAt(int index)
        {
            if (index == 0 || index >= _valves.Count)
                return null;

            return _valves[index];
        }
    }
}