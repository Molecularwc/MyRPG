using System;

namespace MyRPG3
{
    internal class Slime : Character
    {
        public Slime()
        {//Truth be told the slime was our original monster
            AiAttack = 70;
            AiDefend = 75;
            AiSpell = 0;

            CurrentHealth = 8;
            MaxHealth = 8;
            Strength = 5;
            Defense = 3;
            Agility = 4;
            CurrentMagic = 0;
            MaxMagic = 0;
            Intelligence = 0;
            Experience = 15;
            Gold = 10;
            PotionQty = 0;
            xpMod = 1.5;
            goldMod = 50;
            Level = 1;

            Identifier = "Slime";
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
    }
}