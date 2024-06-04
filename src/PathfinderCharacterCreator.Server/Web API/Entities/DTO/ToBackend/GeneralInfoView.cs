namespace Web_API.Entities.DTO
{
    /// <summary>
    /// Структура данных приходящая со страницы Создание персонажа - Общее.
    /// </summary>
    public struct GeneralInfoView
    {
        public int id { get; set; }

        /// <summary>
        /// Имя персонажа.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Мировоззрение персонажа.
        /// </summary>
        public string Aligment { get; set; }

        /// <summary>
        /// Родословная персонажа.
        /// </summary>
        public string Ancestry { get; set; }

        /// <summary>
        /// Наследие персонажа.
        /// </summary>
        public string Haritage { get; set; }

        /// <summary>
        /// Предыстория персонажа.
        /// </summary>
        public string Background { get; set; }

        /// <summary>
        /// Класс персонажа.
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// Подкласс персонажа.
        /// </summary>
        public string SubClass { get; set; }

        /// <summary>
        /// Вера персонажа.
        /// </summary>
        public string Deity { get; set; }
    }
}
