namespace Model.Creation
{
    using DataBaseAccess.Character;
    using DataBaseAccess.CoreBook.Feats;
    using DataBaseAccess.CoreBook.Types;

    /// <summary>
    /// Сервис для уменьшения дублирования кода в стратегиях.
    /// </summary>
    public class CreationGeneralInfoService
    {
        /// <summary>
        /// Прибавляет пункты здоровья класса.
        /// </summary>
        /// <param name="character">Объект персонажа.</param>
        /// <param name="healthPoints">Добавляемое число пунктов здоровья.</param>
        /// <returns>Изменённый объект персонажа.</returns>
        public DBCharacter SetHealthPoints(DBCharacter character, int healthPoints)
        {
            character.Stats.CurrentHealthPoints += healthPoints;
            character.Stats.MaxHealthPoints += healthPoints;

            return character;
        }

        /// <summary>
        /// Добавляет характеристики родословной.
        /// </summary>
        /// <param name="character">Объект персонажа.</param>
        /// <param name="firstBonusAbility">Тип характеристики, которую нужно повысить.</param>
        /// <param name="secondBonusAbility">Тип характеристики, которую нужно повысить.</param>
        /// <param name="penaltyAbility">Тип характеристики, которую нужно понизить.</param>
        /// <returns></returns>
        public DBCharacter SetAbility(DBCharacter character,
                                        AbilityType firstBonusAbility,
                                        AbilityType secondBonusAbility,
                                        AbilityType penaltyAbility)
        {
            character.Stats.Abilities[(int)firstBonusAbility] += 2;
            character.Stats.Abilities[(int)(int)secondBonusAbility] += 2;
            character.Stats.Abilities[(int)penaltyAbility] -= 2;

            return character;
        }

        /// <summary>
        /// Присваивает значение спасбросков.
        /// </summary>
        /// <param name="character">Объект персонажа.</param>
        /// <param name="fortitude">Значение спасброска стойкости.</param>
        /// <param name="reflex">Значение спасброска реакции.</param>
        /// <param name="will">Значение спасброска воли.</param>
        /// <returns>Изменённый объект персонажа.</returns>
        public DBCharacter SetSavingThrows(DBCharacter character,
                                                ProficientyType fortitude,
                                                ProficientyType reflex,
                                                ProficientyType will)
        {
            character.Stats.SavingThrows[(int)SavingThrowType.Fortitude] = fortitude;
            character.Stats.SavingThrows[(int)SavingThrowType.Reflex] = reflex;
            character.Stats.SavingThrows[(int)SavingThrowType.Will] = will;

            return character;
        }

        /// <summary>
        /// Присваивает значение умений в оружии.
        /// </summary>
        /// <param name="character">Объект персонажа.</param>
        /// <param name="unarmored">Умение в обращении безоружным оружием.</param>
        /// <param name="simple">Умение в обращении простым оружием.</param>
        /// <param name="martial">Умение в обращении особым оружием.</param>
        /// <param name="advanced">Умение в обращении продвинутым оружием.</param>
        /// <returns>Изменённый объект персонажа.</returns>
        public DBCharacter SetWeaponProficienty(DBCharacter character,
                                                ProficientyType unarmored,
                                                ProficientyType simple,
                                                ProficientyType martial,
                                                ProficientyType advanced)
        {
            character.Stats.WeaponProficienty[(int)WeaponType.Unarmed] = unarmored;
            character.Stats.WeaponProficienty[(int)WeaponType.Simple] = simple;
            character.Stats.WeaponProficienty[(int)WeaponType.Martial] = martial;
            character.Stats.WeaponProficienty[(int)WeaponType.Advanced] = advanced;

            return character;
        }

        /// <summary>
        /// Присваивает значение умений в доспехах.
        /// </summary>
        /// <param name="character">Объект персонажа.</param>
        /// <param name="unarmored">Умение в обращении без брони.</param>
        /// <param name="light">Умение в обращении с лёгкой бронёй.</param>
        /// <param name="medium">Умение в обращении со средней бронёй.</param>
        /// <param name="heavy">Умение в обращении с тяжёлыми доспехами.</param>
        /// <returns>Изменённый объект персонажа.</returns>
        public DBCharacter SetArmorProficienty(DBCharacter character,
                                                ProficientyType unarmored,
                                                ProficientyType light,
                                                ProficientyType medium,
                                                ProficientyType heavy)
        {
            character.Stats.ArmorProficienty[(int)ArmorType.Unarmored] = unarmored;
            character.Stats.ArmorProficienty[(int)ArmorType.Light] = light;
            character.Stats.ArmorProficienty[(int)ArmorType.Medium] = medium;
            character.Stats.ArmorProficienty[(int)ArmorType.Heavy] = heavy;

            return character;
        }

        /// <summary>
        /// Присваивает персонажу черту.
        /// </summary>
        /// <param name="character">Изменяемый персонаж.</param>
        /// <param name="featName">Применяемая черта.</param>
        /// <returns>Изменённый персонаж.</returns>
        public void SetFeat(DBCharacter character, string featName)
        {
            var featManager = new FeatManager();

            var feat = featManager.FindFeat(featName);

            if (feat != null && feat.CanAssign(character))
            {
                feat.Assign(character);
                character.FeatNames.Add(feat.Name);
            }
        }
    }
}
