using System;

namespace MyRPG
{
    public class Character
    {
        public int AttackDamage;
        public int CurrentHealth, MaxHealth, Level, NewHp, OldHp, NewMaxHp, OldMaxHp;
        public double CurrentMagic;
        public bool Defending, IncreaseAttack;
        public bool DefenseMod;
        public double Experience, Gold, XpToLevel, XpThresh, CurrentXp;
        public bool Fled;
        public string Identifier;
        public bool IsAlive;
        public int MaxMagic, Strength, Defense, Agility, Intelligence;
        public int PotionQty;
        public bool StatIncrease;
        public double XpMod, GoldMod;
        protected double AiAttack, AiDefend, AiSpell;
        protected Random rand;
        protected double SpellOne, SpellTwo, SpellThree;

        public Character()
        {
            SpellOne = 0;
            SpellTwo = 0;
            SpellThree = 0;
            Defending = false;
            IncreaseAttack = false;
            Fled = false;
            DefenseMod = false;
        }

        public virtual string Ai()
        {
            var choice = "";
            return choice;
        }

        public virtual string PotionAi()
        {
            var choice = "";
            return choice;
        }

        public virtual string SpellAi()
        {
            var choice = "";
            return choice;
        }
    }
}
