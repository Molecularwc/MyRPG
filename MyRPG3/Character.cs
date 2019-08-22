using System;

namespace MyRPG3
{
    public class Character
    {
        public int AttackDamage;
        public int CurrentHealth, MaxHealth, Level, newHP, oldHP, newMaxHP, oldMaxHP;
        public double CurrentMagic;
        public bool defending, increaseAttack;
        public bool defenseMod;
        public double Experience, Gold, XpToLevel, XpThresh, CurrentXP;
        public bool fled;
        public string Identifier;
        public bool isAlive;
        public int MaxMagic, Strength, Defense, Agility, Intelligence;
        public int PotionQty;
        public bool statIncrease;
        public double xpMod, goldMod;
        protected double AiAttack, AiDefend, AiSpell;
        protected Random rand;
        protected double spellOne, spellTwo, spellThree;

        public Character()
        {
            spellOne = 0;
            spellTwo = 0;
            spellThree = 0;
            defending = false;
            increaseAttack = false;
            fled = false;
            defenseMod = false;
        }

        public virtual string AI()
        {
            string choice = "";
            return choice;
        }

        public virtual string PotionAI()
        {
            string choice = "";
            return choice;
        }

        public virtual string SpellAI()
        {
            string choice = "";
            return choice;
        }
    }
}