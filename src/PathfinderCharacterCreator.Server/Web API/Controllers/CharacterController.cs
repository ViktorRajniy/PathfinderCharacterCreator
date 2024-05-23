namespace Web_API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Web_API.Servicies;

    /// <summary>
    /// Контроллер управляющий страницей Создание персонажа - Характеристики.
    /// </summary>
    [Route("api/[controller]")]
    public class CharacterController : Controller
    {
        /// <summary>
        /// Сервис для создания персонажа.
        /// </summary>
        private CreationService _service;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="service">Сервис для создания персонажа.</param>
        public CharacterController(CreationService service)
        {
            _service = service;
        }

        /// <summary>
        /// Инициализирует персонажа.
        /// </summary>
        /// <returns>Код сервера.</returns>
        [HttpGet]
        [Route("InitCharacter")]
        public ActionResult InitCharacter()
        {
            try
            {
                int characterID = _service.InitialiseCharacter();

                if (characterID != null)
                {
                    return Ok(_service.GetCharacter(characterID));
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
