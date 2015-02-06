using System;
using System.Threading;
using techdays.domain.core.Managers;
using techdays.domain.core.Workers;

namespace techdays.business
{
    public class WaterManager : IWaterManager
    {
        private const int UPPER_VALVE_ID = 0;
        private const int LOWER_VALVE_ID = 1;
        private static TimeSpan TWENTY_SECONDS = TimeSpan.FromSeconds(20);

        private readonly IExceptionHandler _exceptionHandler;
        private readonly IStringToGuidConverter _stringToGuidConverter;
        private readonly IValveController _valveController;

        public WaterManager(IValveController valveController, IExceptionHandler exceptionHandler, IStringToGuidConverter stringToGuidConverter)
        {
            _valveController = valveController;
            _exceptionHandler = exceptionHandler;
            _stringToGuidConverter = stringToGuidConverter;
        }
        
        /// <summary>
        /// There are two valves providing water to my plants. Between them is a hose that fits 10ml of water 
        /// so the method of watering the plants is to open the upper valve, to let water fill the hose, and then
        /// opening the lower valve to release the water from the hose onto the plant. 
        /// </summary>
        /// <param name="plantId">Id of the plant to water</param>
        /// <param name="waterAmountInMiliLiters">Amount of water to provide. Will be rounded to nearest 10ml</param>
        public void GiveWater(string plantId, int waterAmountInMiliLiters)
        {
            // not enough for a single watering session
            if (waterAmountInMiliLiters < 10)
                return;

            // Too much water - one liter is what I have in my jar!
            if (waterAmountInMiliLiters > 1000)
                return;

            // Figure out how many times to fill the hose
            var numberOfFillings = (int)waterAmountInMiliLiters / 10;

            // poor man's roundup :)
            if (waterAmountInMiliLiters % 10 != 0)
                numberOfFillings += 1;

            // Ensure that the ID is a valid Guid
            var plantGuid = _stringToGuidConverter.ToGuid(plantId);
            if (plantGuid == Guid.Empty)
                return;

            // Tell the valvecontroller which target system (plant) to operate on
            _valveController.SetActivePlant(plantGuid);

            // Rince, repeat - literally :)
            for (int i = 0; i < numberOfFillings; i++)
            {
                OpenAndCloseValve(UPPER_VALVE_ID, duration: TWENTY_SECONDS);
                OpenAndCloseValve(LOWER_VALVE_ID, duration: TWENTY_SECONDS);
            }
        }

        private void OpenAndCloseValve(int valveId, TimeSpan duration)
        {
            const string METHOD = "WaterManager.OpenAndCloseValve(int, TimeSpan)";

            _exceptionHandler.RunAction(METHOD, () =>
            {
                _valveController.Open(valveId);
                Thread.Sleep(duration);
                _valveController.Close(valveId);
            });
        }
    }
}