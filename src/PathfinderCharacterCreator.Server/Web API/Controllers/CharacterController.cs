namespace Web_API.Controllers
{
    using DataBaseAccess;
    using DataBaseAccess.Character;
    using Microsoft.AspNetCore.Mvc;
    using Web_API.Entities;
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
                    return Ok(_dataAccessService.GetCharacter(characterID));
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

        /// <summary>
        /// Пост запрос, отправляющий общие параметры персонажа.
        /// </summary>
        /// <param name="generalInfo">Общие параметры персонажа.</param>
        /// <returns>Код сервера.</returns>
        [HttpPost]
        [Route("setGeneralParameters")]
        public ActionResult<GeneralInfoView> SetGeneralParameters
            ([FromBody] GeneralInfoView generalInfo)
        {
            try
            {
                _creationService.SetGeneralParameters(generalInfo);

                return Ok(_dataAccessService.GetCharacter(generalInfo.id));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Пост запрос, отправляющий конечные значения характеристик персонажа.
        /// </summary>
        /// <param name="abilities">Конечные значения характеристик персонажа.</param>
        /// <returns>Код сервера.</returns>
        [HttpPost]
        [Route("setAbilities")]
        public ActionResult<AbilitiesView> SetAbilities([FromBody] AbilitiesView abilities )
        {
            try
            {
                _creationService.SetAbilities(abilities);

                return Ok(_dataAccessService.GetCharacter(abilities.Id));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Пост запрос, отправляющий конечные значения навыков персонажа.
        /// </summary>
        /// <param name="abilities">Конечные значения навыков персонажа.</param>
        /// <returns>Код сервера.</returns>
        [HttpPost]
        [Route("SetSkills")]
        public ActionResult<SkillsView> SetSkills([FromBody] SkillsView skills)
        {
            try
            {
                _creationService.SetSkills(skills);

                return Ok(_dataAccessService.GetCharacter(skills.Id));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Пост запрос отправляющий список названий выбранных пользователем черт.
        /// </summary>
        /// <param name="feats"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SetFeats")]
        public ActionResult<FeatsView> SetFeats([FromBody] FeatsView feats)
        {
            try
            {
                _creationService.SetFeats(feats);

                return Ok(_dataAccessService.GetCharacter(feats.Id));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
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
