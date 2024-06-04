namespace Web_API.Controllers.Creation.Character
{
    using Microsoft.AspNetCore.Mvc;
    using Web_API.Entities.DTO;
    using Web_API.Servicies;

    /// <summary>
    /// Контроллер управляющий страницей Создание персонажа - Характеристики.
    /// </summary>
    [Route("api/[controller]")]
    public class CreationAbilityController : Controller
    {
        /// <summary>
        /// Сервис для создания персонажа.
        /// </summary>
        private CreationService _creationService;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="service">Сервис для создания персонажа.</param>
        public CreationAbilityController(CreationService service)
        {
            _creationService = service;
        }

        /// <summary>
        /// Возвращает текущее значение характеристик персонажа.
        /// </summary>
        /// <param name="characterID">ID персонажа в БД.</param>
        /// <returns>Код сервера.</returns>
        [HttpGet]
        [Route("Get")]
        public ActionResult<AbilitiesBack> GetCurrentAbilities(int characterID)
        {
            return Ok(_creationService.GetCurrentAbilities(characterID));
        }

        /// <summary>
        /// Пост запрос, отправляющий конечные значения характеристик персонажа.
        /// </summary>
        /// <param name="abilities">Конечные значения характеристик персонажа.</param>
        /// <returns>Код сервера.</returns>
        [HttpPost]
        [Route("Set")]
        public ActionResult<AbilitiesView> SetAbilities([FromBody] AbilitiesView abilities)
        {
            _creationService.SetAbilities(abilities);
            return Ok();
        }
    }
}
