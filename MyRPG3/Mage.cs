using System;

namespace MyRPG
{
    internal class Mage : Character
    {
        public Mage()
        {
            AiAttack = 55;
            AiDefend = 65;
            AiSpell = 95;

            SpellOne = 35;
            SpellTwo = 75;
            SpellThree = 90;

            CurrentHealth = 18;
            MaxHealth = 18;
            CurrentMagic = 17;
            MaxMagic = 17;
            Strength = 5;
            Defense = 3;
            Agility = 6;
            Intelligence = 15;
            Experience = 25;
            Gold = 20;
            PotionQty = 0;
            XpMod = 1.5;
            GoldMod = 150;
            Level = 1;

            Identifier = "Mage";
            IsAlive = true;
            AttackDamage = Strength;
        }

        public override string Ai()
        {
            string choice;
            int aiNumberChoice;
            rand = new Random();
            aiNumberChoice = rand.Next(1, 100);
            if (aiNumberChoice < AiAttack)
            {
                choice = "A";
            }
            else if (aiNumberChoice <= AiDefend && aiNumberChoice >= AiAttack)
            {
                choice = "D";
            }
            else if (aiNumberChoice < AiSpell && aiNumberChoice > AiDefend)
            {
                choice = "S";
            }
            else
            {
                choice = "F";
            }
            return choice;
        }

        public override string SpellAi()
        {
            if (CurrentHealth < (CurrentHealth / 2))
            {//here we're giving the mage a bit of common sense to heal
                SpellOne /= 2;
                SpellTwo /= 2;
            }
            string choice;
            int aiNumberChoice;
            rand = new Random();
            aiNumberChoice = rand.Next(1, 100);
            if (aiNumberChoice < SpellOne)
            {
                choice = "F";
            }
            else if (aiNumberChoice <= SpellTwo && aiNumberChoice >= SpellOne)
            {
                choice = "I";
            }
            else if (aiNumberChoice <= SpellThree && aiNumberChoice >= SpellTwo)
            {
                choice = "L";
            }
            else
            {
                choice = "H";
            }
            return choice;
        }
    }
}
