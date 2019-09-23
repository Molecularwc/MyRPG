using System;

namespace MyRPG
{
    /// <summary>
    /// This is a very simple store with just a few items. We could alternatively make each item it's
    /// own class as opposed to a string The const keyword indicates that this string is a constant
    /// and will not change
    /// </summary>
    internal class Store
    {
        private const string Armor = "Armor";
        private const string Battleaxe = "Battle Axe";
        private const string Cloak = "Cloak";
        private const string Helmet = "Helmet";
        private const string Mace = "Mace";
        private const string PaladinShield = "Paladin Shield";
        private const string Potion = "Potion";
        private const string Sword = "Sword";
        private string _choice = "";

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
                var checkItem = false;
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
                _choice = Console.ReadLine();
                switch (_choice.ToUpper())
                {
                    case "S":
                        checkItem = hero.CheckItems(Sword);
                        if (checkItem == false)
                        {
                            if (hero.Gold >= 100)
                            {
                                hero.Gold -= 100;
                                hero.Items.Add(Sword);
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
                        checkItem = hero.CheckItems(Helmet);
                        if (checkItem == false)
                        {
                            if (hero.Gold >= 130)
                            {
                                hero.Gold -= 130;
                                hero.Items.Add(Helmet);
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
                        checkItem = hero.CheckItems(Armor);
                        if (checkItem == false)
                        {
                            if (hero.Gold >= 125)
                            {
                                hero.Gold -= 125;
                                hero.Items.Add(Armor);
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
                        checkItem = hero.CheckItems(Mace);
                        if (checkItem == false)
                        {
                            if (hero.Gold >= 115)
                            {
                                hero.Gold -= 115;
                                hero.Items.Add(Mace);
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
                        checkItem = hero.CheckItems(Battleaxe);
                        if (checkItem == false)
                        {
                            if (hero.Gold >= 200)
                            {
                                hero.Gold -= 200;
                                hero.Items.Add(Battleaxe);
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
                        checkItem = hero.CheckItems(PaladinShield);
                        if (checkItem == false)
                        {
                            if (hero.Gold >= 200)
                            {
                                hero.Gold -= 200;
                                hero.Items.Add(PaladinShield);
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

                    case "C":
                        checkItem = hero.CheckItems(Cloak);
                        if (checkItem == false)
                        {
                            if (hero.Gold >= 175)
                            {
                                hero.Gold -= 175;
                                hero.Items.Add(Cloak);
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
                        Console.WriteLine("Goodbye {0}, and be careful out there!", hero.Identifier);
                        break;

                    default:
                        Console.WriteLine("I can't understand that gibberish you're sayin'");
                        break;
                }
            }
            while (_choice != "D");
            Console.WriteLine("Press enter to continue....");
            Console.ReadLine();
        }
    }
}
