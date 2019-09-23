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
            int ainumberchoice;
            rand = new Random();
            ainumberchoice = rand.Next(1, 100);
            if (ainumberchoice < AiAttack)
            {
                choice = "A";
            }
            else if (ainumberchoice <= AiDefend && ainumberchoice >= AiAttack)
            {
                choice = "D";
            }
            else if (ainumberchoice < AiSpell && ainumberchoice > AiDefend)
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
            int ainumberchoice;
            rand = new Random();
            ainumberchoice = rand.Next(1, 100);
            if (ainumberchoice < SpellOne)
            {
                choice = "F";
            }
            else if (ainumberchoice <= SpellTwo && ainumberchoice >= SpellOne)
            {
                choice = "I";
            }
            else if (ainumberchoice <= SpellThree && ainumberchoice >= SpellTwo)
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
