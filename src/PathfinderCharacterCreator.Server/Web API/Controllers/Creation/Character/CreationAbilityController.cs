namespace Web_API.Controllers.Creation.Character
{
    using Microsoft.AspNetCore.Mvc;
    using Web_API.Entities;
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
        /// Пост запрос, отправляющий конечные значения характеристик персонажа.
        /// </summary>
        /// <param name="abilities">Конечные значения характеристик персонажа.</param>
        /// <returns>Код сервера.</returns>
        [HttpPost]
        [Route("Set")]
        public ActionResult<AbilitiesView> SetAbilities([FromBody] AbilitiesView abilities)
        {
            try
            {
                _creationService.SetAbilities(abilities);

                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
