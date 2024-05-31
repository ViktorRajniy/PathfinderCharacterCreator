namespace Web_API.Controllers.Creation.DataAccess
{
    using DataBaseAccess;
    using DataBaseAccess.CoreBook.Types;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Контроллер, дающий странице Создание персонажа - Общее, данные из БД.
    /// </summary>
    [Route("api/[controller]")]
    public class DataFeatController : Controller
    {
        /// <summary>
        /// Сервис для создания персонажа.
        /// </summary>
        private DataAccessService _dataAccessService;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="service">Сервис для создания персонажа.</param>
        public DataFeatController(DataAccessService dataAccess)
        {
            _dataAccessService = dataAccess;
        }

        /// <summary>
        /// Гет запрос описаний доступных персонажу черт определённого типа из базы данных.
        /// </summary>
        /// <returns>Код сервера.</returns>
        [HttpGet]
        [Route("GetByType")]
        public ActionResult GetAllowedFeatsDescriptionsByType(int type)
        {
            try
            {
                var feats = _dataAccessService.GetFeatsByType(type);
                if (feats != null)
                {
                    return Ok(feats);
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
