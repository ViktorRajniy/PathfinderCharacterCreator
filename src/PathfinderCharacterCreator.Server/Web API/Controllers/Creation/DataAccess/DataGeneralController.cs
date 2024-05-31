namespace Web_API.Controllers.Creation.DataAccess
{
    using DataBaseAccess;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Контроллер, дающий странице Создание персонажа - Общее, данные из БД.
    /// </summary>
    [Route("api/[controller]")]
    public class DataGeneralController : Controller
    {
        /// <summary>
        /// Сервис для создания персонажа.
        /// </summary>
        private DataAccessService _dataAccessService;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="service">Сервис для создания персонажа.</param>
        public DataGeneralController(DataAccessService dataAccess)
        {
            _dataAccessService = dataAccess;
        }

        /// <summary>
        /// Гет запрос описаний родословных.
        /// </summary>
        /// <returns>Код сервера.</returns>
        [HttpGet]
        [Route("GetAncestries")]
        public ActionResult GetAncestries()
        {
            try
            {
                return Ok(_dataAccessService.GetAncestries());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Гет запрос описаний наследий.
        /// </summary>
        /// <param name="ancestryID">Выбранная родословная.</param>
        /// <returns>Код сервера.</returns>
        [HttpGet]
        [Route("GetHaritages")]
        public ActionResult GetHaritages(int ancestryID)
        {
            try
            {
                return Ok(_dataAccessService.GetHaritages(ancestryID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Гет запрос описаний классов.
        /// </summary>
        /// <returns>Код сервера.</returns>
        [HttpGet]
        [Route("GetClasses")]
        public ActionResult GetClasses()
        {
            try
            {
                return Ok(_dataAccessService.GetClasses());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Гет запрос описаний подклассов.
        /// </summary>
        /// <param name="classID">Выбранный класс.</param>
        /// <returns>Код сервера.</returns>
        [HttpGet]
        [Route("GetSubclasses")]
        public ActionResult GetSubclasses( int classID)
        {
            try
            {
                return Ok(_dataAccessService.GetSubclasses(classID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Гет запрос описаний предысторий.
        /// </summary>
        /// <returns>Код сервера.</returns>
        [HttpGet]
        [Route("GetBackgrounds")]
        public ActionResult GetBackgrounds()
        {
            try
            {
                return Ok(_dataAccessService.GetBackgrounds());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Гет запрос описаний предысторий.
        /// </summary>
        /// <returns>Код сервера.</returns>
        [HttpGet]
        [Route("GetDeities")]
        public ActionResult GetDeities()
        {
            try
            {
                return Ok(_dataAccessService.GetDeities());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
