namespace Web_API.Controllers.Creation.Character
{
    using Microsoft.AspNetCore.Mvc;
    using Web_API.Entities;
    using Web_API.Servicies;

    /// <summary>
    /// Контроллер управляющий страницей Создание персонажа - Черты.
    /// </summary>
    [Route("api/[controller]")]
    public class CreationFeatController : Controller
    {
        /// <summary>
        /// Сервис для создания персонажа.
        /// </summary>
        private CreationService _creationService;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="service">Сервис для создания персонажа.</param>
        public CreationFeatController(CreationService service)
        {
            _creationService = service;
        }

        /// <summary>
        /// Пост запрос отправляющий список названий выбранных пользователем черт.
        /// </summary>
        /// <param name="feats">Названия выбранных черт.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Set")]
        public ActionResult<FeatsView> SetFeats([FromBody] FeatsView feats)
        {
            try
            {
                _creationService.SetFeats(feats);

                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
