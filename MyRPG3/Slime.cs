using System;

namespace MyRPG
{
    internal class Slime : Character
    {
        public Slime()
        {
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
            XpMod = 1.5;
            GoldMod = 50;
            Level = 1;

            Identifier = "Slime";
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
    }
}
