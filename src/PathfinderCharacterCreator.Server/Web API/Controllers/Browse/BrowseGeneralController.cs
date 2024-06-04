namespace Web_API.Controllers.Browse
{
    using Microsoft.AspNetCore.Mvc;
    using Web_API.Servicies;

    /// <summary>
    /// Контроллер, дающий странице Просмотр персонажа - Общее, данные о персонаже.
    /// </summary>
    [Route("api/[controller]")]
    public class BrowseGeneralController : Controller
    {
        /// <summary>
        /// Сервис для просмотра персонажа.
        /// </summary>
        private BrowseService _browseService;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="browseService">Сервис для просмотра персонажа.</param>
        public BrowseGeneralController(BrowseService browseService)
        {
            _browseService = browseService;
        }

        /// <summary>
        /// Возвращает общую информацию о персонаже.
        /// </summary>
        /// <param name="characterID">ID персонажа.</param>
        /// <returns>Общая информация о персонаже.</returns>
        [HttpGet]
        [Route("Get")]
        public ActionResult GetCharacterGeneralInfo(int characterID)
        {
            return Ok(_browseService.GetGeneralInfo(characterID));
        }
    }
}
