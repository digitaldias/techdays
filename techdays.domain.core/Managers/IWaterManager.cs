using System;

namespace techdays.domain.core.Managers
{
    public interface IWaterManager
    {
        /// <summary>
        /// Provide the designated amount of water to a specified plant
        /// </summary>
        /// <param name="deviceId">Id of the plant that is to be watered</param>
        /// <param name="waterAmountInMiliLiters">Amount of water to provide, in milliliters</param>
        void GiveWater(string plantId, int waterAmountInMiliLiters);
    }
}