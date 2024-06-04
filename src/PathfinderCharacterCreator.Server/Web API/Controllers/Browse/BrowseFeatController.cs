namespace Web_API.Controllers.Browse
{
    using Microsoft.AspNetCore.Mvc;
    using Web_API.Servicies;

    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    public class BrowseFeatController : Controller
    {
        /// <summary>
        /// Сервис для просмотра персонажа.
        /// </summary>
        private BrowseService _browseService;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="browseService">Сервис для просмотра персонажа.</param>
        public BrowseFeatController(BrowseService browseService)
        {
            _browseService = browseService;
        }

        /// <summary>
        /// Возвращает общую информацию о персонаже.
        /// </summary>
        /// <param name="characterID">ID персонажа.</param>
        /// <returns>Общая информация о персонаже.</returns>
        [HttpGet]
        [Route("GetFeats")]
        public ActionResult GetCharacterFeats(int characterID)
        {
            return Ok(_browseService.GetFeats(characterID));
        }

        [HttpGet]
        [Route("GetEquipment")]
        public ActionResult GetCharacterEquipment(int characterID)
        {
            return Ok(_browseService.GetEquipment(characterID));
        }
    }
}
