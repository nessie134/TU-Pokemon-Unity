
using System;

namespace _2023_GC_A2_Partiel_POO.Level_2
{
    public class Fight
    {
        public Character Character1 { get; }
        public Character Character2 { get; }
        /// <summary>
        /// Est-ce la condition de victoire/défaite a été rencontré ?
        /// </summary>
        public bool IsFightFinished { get; private set; }

        public Fight(Character character1, Character character2)
        {
            if (character1 == null)
            {
                throw new ArgumentNullException(nameof(character1), "Character 1 cannot be null.");
            }

            if (character2 == null)
            {
                throw new ArgumentNullException(nameof(character2), "Character 2 cannot be null.");
            }

            Character1 = character1;
            Character2 = character2;
            IsFightFinished = false;


        }


        /// <summary>
        /// Jouer l'enchainement des attaques. Attention à bien gérer l'ordre des attaques par apport à la speed des personnages
        /// </summary>
        /// <param name="skillFromCharacter1">L'attaque selectionné par le joueur 1</param>
        /// <param name="skillFromCharacter2">L'attaque selectionné par le joueur 2</param>
        /// <exception cref="ArgumentNullException">si une des deux attaques est null</exception>
        public void ExecuteTurn(Skill skillFromCharacter1, Skill skillFromCharacter2)
        {
            if (IsFightFinished)
            {
                throw new InvalidOperationException("The fight has already finished.");
            }

            Character1.ReceiveAttack(skillFromCharacter2);
            if (!Character1.IsAlive)
            {
                IsFightFinished = true;
                return;
            }

            Character2.ReceiveAttack(skillFromCharacter1);
            if (!Character2.IsAlive)
            {
                IsFightFinished = true;
            }
        }

    }
}
