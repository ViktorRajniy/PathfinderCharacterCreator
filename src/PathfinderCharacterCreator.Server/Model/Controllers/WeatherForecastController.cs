using DataBaseAccess.CoreBook.Equipment;
using Microsoft.AspNetCore.Mvc;

namespace Model.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DataBaseAccessService _dataBaseAccessService;

        public WeatherForecastController(DataBaseAccessService db)   
        {
            _dataBaseAccessService = db;
        }  

        [HttpGet]
        [Route("GetItems")]
        public ActionResult GetItems()
        {
            return Ok(_dataBaseAccessService.GetItems());
        }

        [HttpGet]
        [Route("GetWeapons")]
        public ActionResult GetWeapons()
        {
            return Ok(_dataBaseAccessService.GetWeapon());
        }
    }
}
