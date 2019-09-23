using System;
using System.Collections.Generic;

namespace MyRPG
{
    public class Hero : Character
    {
        public List<string> Items;

        public Hero()
        {
            Items = new List<string>();
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
            hero.IncreaseAttack = true;
            hero.Level = 1;
            hero.XpThresh = (hero.Level * 500) * 1.5;
            hero.Experience = 0;
            hero.CurrentXp = 0;
            hero.XpToLevel = hero.XpThresh - hero.CurrentXp;
            hero.Gold = 0;
            hero.PotionQty = 0;
            hero.DefenseMod = false;
            hero.NewHp = 0;
            hero.OldHp = 0;
            hero.NewMaxHp = 0;
            hero.OldMaxHp = 0;
            hero.StatIncrease = false;

            while (string.IsNullOrEmpty(hero.Identifier) ||
                hero.Identifier == " ")
            {
                Console.WriteLine("What is your Hero's name?");
                hero.Identifier = Console.ReadLine();
            }
            hero.IsAlive = true;
            hero.AttackDamage = (hero.Strength * 10) / 2;
        }

        public bool CheckItems(string item)
        {
            return Items.Contains(item);
        }
    }
}
