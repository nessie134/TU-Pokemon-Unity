
using _2023_GC_A2_Partiel_POO.Level_2;
using NUnit.Framework;
using UnityEngine.PlayerLoop;

namespace _2023_GC_A2_Partiel_POO.Tests.Level_2
{
    public class FightMoreTests
    {
        [Test]
        public void CharacterReceiveSkillWithTypeAdvantage()
        {
            // avantage de type
            var waterTypeCharacter = new Character(100, 50, 30, 20, TYPE.WATER);
            var grassTypeCharacter = new Character(100, 50, 30, 20, TYPE.GRASS);

            // feu avantage
            var fireSkill = new FireBall();

            waterTypeCharacter.ReceiveAttack(fireSkill);

            Assert.That(waterTypeCharacter.CurrentHealth, Is.EqualTo(80)); // moins de degats a cause de l'avantage de type
            Assert.That(grassTypeCharacter.CurrentHealth, Is.EqualTo(20)); // plus de degats

        }

        [Test]
        public void CharacterReceiveSkillWithTypeDisadvantage()
        {
            var fireTypeCharacter = new Character(100, 50, 30, 20, TYPE.FIRE);
            var waterTypeCharacter = new Character(100, 50, 30, 20, TYPE.WATER);

            //eau avantage
            var waterSkill = new WaterBlouBlou();

            fireTypeCharacter.ReceiveAttack(waterSkill);

            waterTypeCharacter.ReceiveAttack(waterSkill);

            Assert.That(fireTypeCharacter.CurrentHealth, Is.EqualTo(20));
            Assert.That(waterTypeCharacter.CurrentHealth, Is.EqualTo(80)); 

        }
    }
}
