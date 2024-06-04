namespace Web_API.Controllers.Creation.Character
{
    using Microsoft.AspNetCore.Mvc;
    using Web_API.Entities.DTO;
    using Web_API.Servicies;

    /// <summary>
    /// Контроллер управляющий страницей Создание персонажа - Общее.
    /// </summary>
    [Route("api/[controller]")]
    public class CreationGeneralController : Controller
    {
        /// <summary>
        /// Сервис для создания персонажа.
        /// </summary>
        private CreationService _creationService;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="service">Сервис для создания персонажа.</param>
        public CreationGeneralController(CreationService service)
        {
            _creationService = service;
        }

        /// <summary>
        /// Пост запрос, отправляющий общие параметры персонажа.
        /// </summary>
        /// <param name="generalInfo">Общие параметры персонажа.</param>
        /// <returns>Код сервера.</returns>
        [HttpPost]
        [Route("Set")]
        public ActionResult<GeneralInfoView> SetGeneralParameters
            ([FromBody] GeneralInfoView generalInfo)
        {
            try
            {
                _creationService.SetGeneralParameters(generalInfo);

                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
