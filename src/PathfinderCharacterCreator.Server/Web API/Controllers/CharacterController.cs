namespace Web_API.Controllers
{
    using DataBaseAccess;
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
        private CreationService _creationService;

        /// <summary>
        /// Сервис для создания персонажа.
        /// </summary>
        private DataAccessService _dataAccessService;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="service">Сервис для создания персонажа.</param>
        public CharacterController(CreationService service, DataAccessService dataAccess)
        {
            _creationService = service;
            _dataAccessService = dataAccess;
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
                int characterID = _creationService.InitialiseCharacter();

                if (characterID != null)
                {
                    return Ok(_dataAccessService.GetDBCharacter(characterID));
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Инициализирует персонажа.
        /// </summary>
        /// <returns>Код сервера.</returns>
        [HttpGet]
        [Route("GetCharacterList")]
        public ActionResult GetCharacterList()
        {
            try
            {
                return Ok(_dataAccessService.GetDBCharactersList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteCharacter")]
        public ActionResult DeleteCharacter([FromBody] int id)
        {
            _creationService.DeleteCharacter(id);

            return Ok(_dataAccessService.GetDBCharactersList());

        }
    }
}
