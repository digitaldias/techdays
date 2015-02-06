using System;
using System.Linq;
using System.Collections.Generic;
using techdays.domain.core.Entities;
using techdays.domain.core.Workers;
using System.Diagnostics;

namespace techdays.data.fakes
{
    public class FakeValveController : IValveController
    {
        private static string SIGNAL_OPEN  = "open";
        private static string SIGNAL_CLOSE = "close";

        private IEnumerable<ValveGroup> _valveGroups { get; set; }

        private ValveGroup _selectedValveGroup { get; set; }

        public FakeValveController()
        {
            //TODO: Get plantId and associated Valves from configuration
            _valveGroups = new List<ValveGroup>();
        }

        public void Open(int valveId)
        {
            TransmitSignal(valveId, SIGNAL_OPEN);
        }

        public void Close(int valveId)
        {
               TransmitSignal(valveId, SIGNAL_CLOSE);
        }

        public void SetActivePlant(Guid plantId)
        {
            _selectedValveGroup = _valveGroups.FirstOrDefault(group => group.PlantId == plantId);

            if (_selectedValveGroup == null)
                throw new InvalidProgramException("Cannot find requested plant using that plantId");
        }

        private void TransmitSignal(int valveId, string signal)
        {
            if (_selectedValveGroup == null)
                throw new InvalidProgramException("Cannot transmit without selecting a valve group first");

            var valve = _selectedValveGroup.GetAt(valveId);
            if (valve == null)
                throw new ArgumentException("Valve ID was not found in group", "valveId");

            var url = valve.Url;
            if (string.IsNullOrEmpty(url))
                throw new InvalidProgramException("Error in valve configuration. Connection URL is missing");

            // Sample instruction only, this will probbaly use sockets once done. 
            string completeInstruction = string.Format("{0}/act?s={1}", url, signal);

            //TODO: Establish a conection and execute the instruction. 
            Debug.WriteLine("Sending signal '{0}' with instruction: {1}", signal, completeInstruction);
        }
    }
}