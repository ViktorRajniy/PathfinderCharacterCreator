namespace Web_API.Controllers.Creation.Character
{
    using Microsoft.AspNetCore.Mvc;
    using Web_API.Entities.DTO;
    using Web_API.Servicies;

    /// <summary>
    /// Контроллер управляющий страницей Создание персонажа - Навыки.
    /// </summary>
    [Route("api/[controller]")]
    public class CreationSkillController : Controller
    {
        /// <summary>
        /// Сервис для создания персонажа.
        /// </summary>
        private CreationService _creationService;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="service">Сервис для создания персонажа.</param>
        public CreationSkillController(CreationService service)
        {
            _creationService = service;
        }

        [HttpGet]
        [Route("Get")]
        public ActionResult GetCurrentSkills(int characterID)
        {
            return Ok(_creationService.GetCurrentSkills(characterID));
        }

        /// <summary>
        /// Пост запрос, отправляющий конечные значения навыков персонажа.
        /// </summary>
        /// <param name="skills">Конечные значения навыков персонажа.</param>
        /// <returns>Код сервера.</returns>
        [HttpPost]
        [Route("Set")]
        public ActionResult<SkillsView> SetSkills([FromBody] SkillsView skills)
        {
            try
            {
                _creationService.SetSkills(skills);

                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
