namespace Web_API.Controllers.Browse
{
    using Microsoft.AspNetCore.Mvc;
    using Web_API.Servicies;

    public class BrowseSkillController : Controller
    {
        /// <summary>
        /// Сервис для просмотра персонажа.
        /// </summary>
        private BrowseService _browseService;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="browseService">Сервис для просмотра персонажа.</param>
        public BrowseSkillController(BrowseService browseService)
        {
            _browseService = browseService;
        }

        /// <summary>
        /// Возвращает общую информацию о персонаже.
        /// </summary>
        /// <param name="characterID">ID персонажа.</param>
        /// <returns>Общая информация о персонаже.</returns>
        [HttpGet]
        [Route("GetSkills")]
        public ActionResult GetCharacterSkills(int characterID)
        {
            return Ok(_browseService.GetFeats(characterID));
        }
    }
}
