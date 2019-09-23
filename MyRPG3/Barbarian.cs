using System;

namespace MyRPG
{
    internal class Barbarian : Character
    {
        public Barbarian()
        {
            AiAttack = 85;
            AiDefend = 96;
            AiSpell = 0;

            CurrentHealth = 25;
            MaxHealth = 25;
            Strength = 15;
            Defense = 5;
            Agility = 4;
            CurrentMagic = 0;
            MaxMagic = 0;
            Intelligence = 0;
            Experience = 35;
            Gold = 25;
            PotionQty = 0;
            XpMod = 1.5;
            GoldMod = 225;
            Level = 1;

            Identifier = "Barbarian";
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
    }
}
