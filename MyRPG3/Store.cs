using System;

namespace MyRPG3
{
    /// <summary>
    /// This is a very simple store with just a few items. We could alternatively make each item it's
    /// own class as opposed to a string The const keyword indicates that this string is a constant
    /// and will not change
    /// </summary>
    internal class Store
    {
        private const string armor = "Armor";
        private const string battleaxe = "Battle Axe";
        private const string cloak = "Cloak";
        private const string helmet = "Helmet";
        private const string mace = "Mace";
        private const string paladinshield = "Paladin Shield";
        private const string potion = "Potion";
        private const string sword = "Sword";
        private string choice = "";

        public Store(Hero hero)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the store!");
            Console.WriteLine("Gold Balance: {0}", $"{hero.Gold:F0}");
            StoreLoop(hero);
        }

        public void StoreLoop(Hero hero)
        {
            do
            {
                bool checkitem = false;
                Console.WriteLine("What would you like to buy?");
                Console.Write(@"
                    (S)word:           100 gold +5 Attack
                    (H)elmet:          130 gold +10 Defense
                    (A)rmor:           125 gold +15 Defense
                    (M)ace:            115 gold +8 Attack
                    (B)attle Axe:      200 gold +10 Attack
                    (P)aladin Shield:  200 gold +15 Defense
                    (C)loak:           175 gold +10 Intelligence
                    P(O)tion:          350 gold
                    (D)one:
                    ");
                Console.WriteLine();
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "S":
                    case "s":
                        checkitem = hero.CheckItems(sword);
                        if (checkitem == false)
                        {
                            if (hero.Gold >= 100)
                            {
                                hero.Gold -= 100;
                                hero.items.Add(sword);
                                hero.AttackDamage += 5;
                                Console.WriteLine("Thank you {0}!", hero.Identifier);
                                Console.WriteLine("Gold Balance: {0}", $"{hero.Gold:F0}");
                            }
                            else
                            {
                                Console.WriteLine("You don't have enough money.  Come back when ya do");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You've already got that!");
                        }
                        break;

                    case "H":
                    case "h":
                        checkitem = hero.CheckItems(helmet);
                        if (checkitem == false)
                        {
                            if (hero.Gold >= 130)
                            {
                                hero.Gold -= 130;
                                hero.items.Add(helmet);
                                hero.Defense += 10;
                                Console.WriteLine("Thank you {0}!", hero.Identifier);
                                Console.WriteLine("Gold Balance: {0}", $"{hero.Gold:F0}");
                            }
                            else
                            {
                                Console.WriteLine("You don't have enough money.  Come back when ya do");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You've already got that!");
                        }
                        break;

                    case "A":
                    case "a":
                        checkitem = hero.CheckItems(armor);
                        if (checkitem == false)
                        {
                            if (hero.Gold >= 125)
                            {
                                hero.Gold -= 125;
                                hero.items.Add(armor);
                                hero.Defense += 15;
                                Console.WriteLine("Thank you {0}!", hero.Identifier);
                                Console.WriteLine("Gold Balance: {0}", $"{hero.Gold:F0}");
                            }
                            else
                            {
                                Console.WriteLine("You don't have enough money.  Come back when ya do");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You've already got that!");
                        }
                        break;

                    case "M":
                    case "m":
                        checkitem = hero.CheckItems(mace);
                        if (checkitem == false)
                        {
                            if (hero.Gold >= 115)
                            {
                                hero.Gold -= 115;
                                hero.items.Add(mace);
                                hero.AttackDamage += 8;
                                Console.WriteLine("Thank you {0}!", hero.Identifier);
                                Console.WriteLine("Gold Balance: {0}", $"{hero.Gold:F0}");
                            }
                            else
                            {
                                Console.WriteLine("You don't have enough money.  Come back when ya do");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You've already got that!");
                        }
                        break;

                    case "B":
                    case "b":
                        checkitem = hero.CheckItems(battleaxe);
                        if (checkitem == false)
                        {
                            if (hero.Gold >= 200)
                            {
                                hero.Gold -= 200;
                                hero.items.Add(battleaxe);
                                hero.AttackDamage += 10;
                                Console.WriteLine("Thank you {0}!", hero.Identifier);
                                Console.WriteLine("Gold Balance: {0}", $"{hero.Gold:F0}");
                            }
                            else
                            {
                                Console.WriteLine("You don't have enough money.  Come back when ya do");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You've already got that!");
                        }
                        break;

                    case "P":
                    case "p":
                        checkitem = hero.CheckItems(paladinshield);
                        if (checkitem == false)
                        {
                            if (hero.Gold >= 200)
                            {
                                hero.Gold -= 200;
                                hero.items.Add(paladinshield);
                                hero.Defense += 15;
                                Console.WriteLine("Thank you {0}!", hero.Identifier);
                                Console.WriteLine("Gold Balance: {0}", $"{hero.Gold:F0}");
                            }
                            else
                            {
                                Console.WriteLine("You don't have enough money.  Come back when ya do");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You've already got that!");
                        }
                        break;

                    case "c":
                    case "C":
                        checkitem = hero.CheckItems(cloak);
                        if (checkitem == false)
                        {
                            if (hero.Gold >= 175)
                            {
                                hero.Gold -= 175;
                                hero.items.Add(cloak);
                                hero.Intelligence += 10;
                                Console.WriteLine("Thank you {0}!", hero.Identifier);
                                Console.WriteLine("Gold Balance: {0}", $"{hero.Gold:F0}");
                            }
                            else
                            {
                                Console.WriteLine("You don't have enough money.  Come back when ya do");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You've already got that!");
                        }
                        break;

                    case "O":
                    case "o":
                        if (hero.Gold >= 350)
                        {
                            hero.Gold -= 350;
                            hero.PotionQty += 1;
                            Console.WriteLine("Thank you {0}!", hero.Identifier);
                            Console.WriteLine("Gold Balance: {0}", $"{hero.Gold:F0}");
                        }
                        else
                        {
                            Console.WriteLine("You don't have enough money.  Come back when ya do");
                        }
                        break;

                    case "D":
                    case "d":
                        Console.WriteLine("Goodbye {0}, and be careful out there!", hero.Identifier);
                        break;

                    default:
                        Console.WriteLine("I can't understand that gibberish you're sayin'");
                        break;
                }
            }
            while (choice != "d" && choice != "D");
            Console.WriteLine("Press enter to continue....");
            Console.ReadLine();
        }
    }
}