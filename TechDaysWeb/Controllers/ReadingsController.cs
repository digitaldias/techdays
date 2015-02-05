using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using techdays.domain.core.Entities;
using techdays.domain.core.Managers;

namespace TechDaysWeb.Controllers.Controllers
{
    [Route("api/[controller]")]
    public class ReadingsController : Controller
    {
        private readonly ISensorReadingManager _sensorReadingManager;

        public ReadingsController(ISensorReadingManager sensorReadingManager)
        {
            _sensorReadingManager = sensorReadingManager;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<SensorReading> Get()
        {
            return _sensorReadingManager.GetLatest(100);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public SensorReading Get(string id)
        {
            return _sensorReadingManager.Get(id) ;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]SensorReading sensorReading)
        {
            _sensorReadingManager.Add(sensorReading);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
