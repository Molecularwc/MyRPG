using System;
using System.Collections.Generic;

namespace MyRPG3
{
    public class Hero : Character
    {
        public List<string> items;

        public Hero()
        {
            items = new List<string>();
        }

        public static void Initialize(Hero hero)
        {
            hero.CurrentHealth = 90;
            hero.MaxHealth = 90;
            hero.CurrentMagic = 40;
            hero.MaxMagic = 40;
            hero.Strength = 30;
            hero.Defense = 12;
            hero.Agility = 24;
            hero.Intelligence = 18;
            hero.increaseAttack = true;
            hero.Level = 1;
            hero.XpThresh = (hero.Level * 500) * 1.5;
            hero.Experience = 0;
            hero.CurrentXP = 0;
            hero.XpToLevel = hero.XpThresh - hero.CurrentXP;
            hero.Gold = 0;
            hero.PotionQty = 0;
            hero.defenseMod = false;
            hero.newHP = 0;
            hero.oldHP = 0;
            hero.newMaxHP = 0;
            hero.oldMaxHP = 0;
            hero.statIncrease = false;

            while (hero.Identifier == null || hero.Identifier == "" ||
                hero.Identifier == " ")
            {
                Console.WriteLine("What is your Hero's name?");
                hero.Identifier = Console.ReadLine();
            }
            hero.isAlive = true;
            hero.AttackDamage = (hero.Strength * 10) / 2;
        }

        public bool CheckItems(string item)
        {
            if (items.Contains(item))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}