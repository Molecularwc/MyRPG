using System;

namespace MyRPG
{
    public class View
    {
        public static void PrintStats(Hero hero)
        {
            hero.XpToLevel = hero.XpThresh - hero.CurrentXp;
            Console.Clear();
            Console.Write(@"
Name:{0}
Hitpoints: {1}/{2}
Strength: {3}
Agility: {4}
Intelligence: {5}
Defense: {6}
Attack: {7}
Experience: {8}/{9}
Exp to level: {10}
Total Experience: {11}
Gold: {12}
Level: {13}
Magic: {14}/{15}
Potions: {16}
Items:", hero.Identifier, hero.CurrentHealth, hero.MaxHealth, hero.Strength, hero.Agility, hero.Intelligence,
         hero.Defense, hero.AttackDamage, $"{hero.CurrentXp:F0}", hero.XpThresh, hero.XpToLevel, $"{hero.Experience:F0}", $"{hero.Gold:F0}", hero.Level, hero.CurrentMagic, hero.MaxMagic, hero.PotionQty);
            foreach (var item in hero.Items)
            {
                Console.WriteLine();
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("Press enter to continue....");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
