using System;

namespace MyRPG3
{
    internal class Mage : Character
    {
        public Mage()
        {
            AiAttack = 55;
            AiDefend = 65;
            AiSpell = 95;

            spellOne = 35;
            spellTwo = 75;
            spellThree = 90;

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
            xpMod = 1.5;
            goldMod = 150;
            Level = 1;

            Identifier = "Mage";
            isAlive = true;
            AttackDamage = Strength;
        }

        public override string AI()
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

        public override string SpellAI()
        {
            if (CurrentHealth < (CurrentHealth / 2))
            {//here we're giving the mage a bit of common sense to heal
                spellOne /= 2;
                spellTwo /= 2;
            }
            string choice;
            int ainumberchoice;
            rand = new Random();
            ainumberchoice = rand.Next(1, 100);
            if (ainumberchoice < spellOne)
            {
                choice = "F";
            }
            else if (ainumberchoice <= spellTwo && ainumberchoice >= spellOne)
            {
                choice = "I";
            }
            else if (ainumberchoice <= spellThree && ainumberchoice >= spellTwo)
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