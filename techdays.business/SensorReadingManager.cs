using System.Collections.Generic;
using techdays.domain.core.Entities;
using techdays.domain.core.Managers;
using techdays.domain.core.Repositories;
using techdays.domain.core.Validators;
using techdays.domain.core.Workers;

namespace techdays.business
{
    public class SensorReadingManager : ISensorReadingManager
    {
        private const int MAX_RECORDS_TO_GET = 100;
        private readonly IExceptionHandler _exceptionHandler;
        private readonly ISensorReadingsRepository _sensorReadingsRepository;
        private readonly ISensorReadingValidator _sensorReadingValidator;
        private readonly IStringToGuidConverter _stringToGuidConverter;

        public SensorReadingManager(
            ISensorReadingValidator sensorReadingValidator, 
            ISensorReadingsRepository sensorReadingsRepository,
            IExceptionHandler exceptionHandler,
            IStringToGuidConverter stringToGuidConverter)
        {
            _sensorReadingValidator = sensorReadingValidator;
            _sensorReadingsRepository = sensorReadingsRepository;
            _exceptionHandler = exceptionHandler;
            _stringToGuidConverter = stringToGuidConverter;
        }

        public void Add(SensorReading sensorReading)
        {
            const string METHOD = "SensorReadingManager.Add(SensorReading)";

            if (_sensorReadingValidator.IsValid(sensorReading))
            {
                _exceptionHandler.RunAction(METHOD, 
                    () => _sensorReadingsRepository.Add(sensorReading));    
            }
        }

        public SensorReading Get(string readingId)
        {
            const string METHOD = "SensorReadingManager.Get(string)";

            var realId = _stringToGuidConverter.ToGuid(readingId);

            return _exceptionHandler.GetFromUnsafeMethod(METHOD,
                () => _sensorReadingsRepository.GetById(realId));
        }

        public IEnumerable<SensorReading> GetLatest(int count)
        {
            const string METHOD = "SensorReadingManager.GetLatest(int)";

            if(count >= 1 && count <= MAX_RECORDS_TO_GET)
            {
                return _exceptionHandler.GetFromUnsafeMethod(METHOD,
                    () => _sensorReadingsRepository.GetTop(count));
            }
            return new List<SensorReading>();
        }
    }
}