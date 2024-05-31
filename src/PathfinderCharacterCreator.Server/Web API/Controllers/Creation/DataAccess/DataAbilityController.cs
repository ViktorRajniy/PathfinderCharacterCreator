namespace Web_API.Controllers.Creation.DataAccess
{
    using DataBaseAccess;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Контроллер, дающий странице Создание персонажа - Общее, данные из БД.
    /// </summary>
    [Route("api/[controller]")]
    public class DataAbilityController : Controller
    {
        /// <summary>
        /// Сервис для создания персонажа.
        /// </summary>
        private DataAccessService _dataAccessService;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="service">Сервис для создания персонажа.</param>
        public DataAbilityController(DataAccessService dataAccess)
        {
            _dataAccessService = dataAccess;
        }

        /// <summary>
        /// Гет запрос описаний характеристик.
        /// </summary>
        /// <returns>Код сервера.</returns>
        [HttpGet]
        [Route("Get")]
        public ActionResult GetAbilities()
        {
            try
            {
                return Ok(_dataAccessService.GetAbilities());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
