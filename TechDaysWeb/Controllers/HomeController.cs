using Microsoft.AspNet.Mvc;
using System;
using techdays.domain.core.Managers;
using TechDaysWeb.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TechDaysWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISensorReadingManager _sensorReadingManager;

        public HomeController(ISensorReadingManager sensorReadingManager)
        {
            _sensorReadingManager = sensorReadingManager;
        }

        /// <returns>The 10 last sensor readings</returns>
        public IActionResult Index()
        {
            var model = new MainPageModel
            {
                ObtainedTime = DateTime.Now,
                Readings = _sensorReadingManager.GetLatest(10)
            };
            return View(model);
        }
    }
}
