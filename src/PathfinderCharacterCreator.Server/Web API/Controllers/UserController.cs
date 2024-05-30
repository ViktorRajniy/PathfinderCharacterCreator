using DataBaseAccess;
using Microsoft.AspNetCore.Mvc;
using Web_API.Entities.User;
using Web_API.Servicies;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        /// <summary>
        /// Сервис для создания персонажа.
        /// </summary>
        private UserService _userService;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="service">Сервис для создания персонажа.</param>
        public UserController(UserService dataAccess)
        {
            _userService = dataAccess;
        }

        [HttpGet]
        [Route("test/get")]
        public List<string> testGet()
        {
            return new List<string> { "123123", "321" };
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
                return Ok(_userService.GetUsersList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Возвращает список пользователей.
        /// </summary>
        /// <returns>Код сервера.</returns>
        [HttpGet]
        [Route("GetUser")]
        public ActionResult GetUserById([FromBody] int id)
        {
            try
            {
                return Ok(_userService.GetUser(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Возвращает список пользователей.
        /// </summary>
        /// <returns>Код сервера.</returns>
        [HttpPost]
        [Route("PostNewUser")]
        public ActionResult PostNewUser([FromBody] UserView newUser)
        {
            try
            {
                return Ok(_userService.GetUsersList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
