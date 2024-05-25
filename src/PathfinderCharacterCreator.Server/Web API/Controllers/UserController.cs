using DataBaseAccess;
using Microsoft.AspNetCore.Mvc;
using Web_API.Servicies;

namespace Web_API.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        /// Сервис для создания персонажа.
        /// </summary>
        private DataAccessService _dataAccessService;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="service">Сервис для создания персонажа.</param>
        public UserController(DataAccessService dataAccess)
        {
            _dataAccessService = dataAccess;
        }

        /// <summary>
        /// Возвращает список пользователей.
        /// </summary>
        /// <returns>Код сервера.</returns>
        [HttpGet]
        [Route("GetUsersList")]
        public ActionResult GetUsersList()
        {
            try
            {
                return Ok(_dataAccessService.GetUsersList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
