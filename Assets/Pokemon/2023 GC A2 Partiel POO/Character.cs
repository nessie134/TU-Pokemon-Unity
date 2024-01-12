using System;

namespace _2023_GC_A2_Partiel_POO.Level_2
{
    /// <summary>
    /// Définition d'un personnage
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Stat de base, HP
        /// </summary>
        int _baseHealth = 100;
        /// <summary>
        /// Stat de base, ATK
        /// </summary>
        int _baseAttack = 50;
        /// <summary>
        /// Stat de base, DEF
        /// </summary>
        int _baseDefense = 30;
        /// <summary>
        /// Stat de base, SPE
        /// </summary>
        int _baseSpeed = 20;
        /// <summary>
        /// Type de base
        /// </summary>
        TYPE _baseType = TYPE.NORMAL;

        public Character(int baseHealth, int baseAttack, int baseDefense, int baseSpeed, TYPE baseType)
        {
            _baseHealth = baseHealth;
            _baseAttack = baseAttack;
            _baseDefense = baseDefense;
            _baseSpeed = baseSpeed;
            _baseType = baseType;
            CurrentHealth = MaxHealth;
        }
        /// <summary>
        /// HP actuel du personnage
        /// </summary>
        public int CurrentHealth { get; private set; }
        public TYPE BaseType { get => _baseType; }
        /// <summary>
        /// HPMax, prendre en compte base et equipement potentiel
        /// </summary>
        public int MaxHealth
        {
            get
            {
                int equipmentBonus = (CurrentEquipment != null) ? CurrentEquipment.BonusHealth : 0;
                return _baseHealth + equipmentBonus;
            }
        }
        /// <summary>
        /// ATK, prendre en compte base et equipement potentiel
        /// </summary>
        public int Attack
        {
            get
            {
                int equipmentBonus = (CurrentEquipment != null) ? CurrentEquipment.BonusAttack : 0;
                return _baseAttack + equipmentBonus;
            }
        }
        /// <summary>
        /// DEF, prendre en compte base et equipement potentiel
        /// </summary>
        public int Defense
        {
            get
            {
                int equipmentBonus = (CurrentEquipment != null) ? CurrentEquipment.BonusDefense : 0;
                return _baseDefense + equipmentBonus;
            }
        }
        /// <summary>
        /// SPE, prendre en compte base et equipement potentiel
        /// </summary>
        public int Speed
        {
            get
            {
                int equipmentBonus = (CurrentEquipment != null) ? CurrentEquipment.BonusSpeed : 0;
                return _baseSpeed + equipmentBonus;
            }
        }
        /// <summary>
        /// Equipement unique du personnage
        /// </summary>
        public Equipment CurrentEquipment { get; private set; }
        /// <summary>
        /// null si pas de status
        /// </summary>
        public StatusEffect CurrentStatus { get; private set; }

        public bool IsAlive => CurrentHealth > 0;


        /// <summary>
        /// Application d'un skill contre le personnage
        /// On pourrait potentiellement avoir besoin de connaitre le personnage attaquant,
        /// Vous pouvez adapter au besoin
        /// </summary>
        /// <param name="s">skill attaquant</param>
        /// <exception cref="NotImplementedException"></exception>
        public void ReceiveAttack(Skill s)
        {
            if (IsAlive)
            {
                int damage = Math.Max(s.Power - Defense, 0);// Math.Max permet de prendre le plus grand des deux nombres
                                                            //car on ne peut pas faire de dégâts négatifs donc on met 0 si le dégât est négatif.

                CurrentHealth = Math.Max(CurrentHealth - damage, 0);

                if (CurrentHealth <= 0)
                {
                    CurrentHealth = 0;//on reset la vie
                }
            }
        }
        /// <summary>
        /// Equipe un objet au personnage
        /// </summary>
        /// <param name="newEquipment">equipement a appliquer</param>
        /// <exception cref="ArgumentNullException">Si equipement est null</exception>
        public void Equip(Equipment newEquipment)
        {
            if (newEquipment == null)
            {
                throw new ArgumentNullException("L'equipment ne peut pas etre null.");
            }

            CurrentEquipment = newEquipment;

        }
        /// <summary>
        /// Desequipe l'objet en cours au personnage
        /// </summary>
        public void Unequip()
        {
            CurrentEquipment = null;
        }

    }
}
