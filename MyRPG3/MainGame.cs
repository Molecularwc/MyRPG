using System;
using System.Collections.Generic;

namespace MyRPG
{
    internal class MainGame
    {
        private static void BasicGameLoop()
        {
            string answer;
            Battle battle;
            List<Character> Monster;
            DataHandler data = new DataHandler();
            Hero myhero;
            Console.WriteLine("Welcome to the arena!");
            myhero = new Hero();
            Hero.Initialize(myhero);
            Monster = new List<Character>();

            do
            {
                Console.WriteLine();

                Console.Write(@"

What would you like to do?

_____________________________

(F)ight

(S)tore

(I)nn

(V)iew

(L)oad

s(A)ve

(Q)uit

_____________________________

F,S,I,V,L,A, or Q?");

                Console.WriteLine();

                answer = Console.ReadLine();

                Console.WriteLine();

                switch (answer.ToUpper())
                {
                    case "L":
                        data.Load(myhero);

                        break;

                    case "A":
                        data.Save(myhero);

                        break;

                    case "S":
                        var store = new Store(myhero);

                        break;

                    case "I":
                        Inn.Sleep(myhero);

                        break;

                    case "V":
                        View.PrintStats(myhero);

                        break;

                    case "F":
                        var done = "";

                        do
                        {
                            Console.Write(@"

Which monster do you want to fight?

(S)lime:

(B)arbarian:

(M)age:

_________________________");

                            Console.WriteLine();

                            var choice = Console.ReadLine();

                            switch (choice)
                            {
                                case "S":
                                    Monster.Add(new Slime());
                                    break;

                                case "B":
                                    Monster.Add(new Barbarian());
                                    break;

                                case "M":
                                    Monster.Add(new Mage());
                                    break;

                                default:
                                    Monster.Add(new Slime());
                                    break;
                            }

                            Console.WriteLine("Would you like to fight more monsters?");

                            Console.WriteLine();

                            done = Console.ReadLine();
                        }

                        while (done == "Y" || done == "y");

                        battle = new Battle(myhero, Monster);
                        if (myhero.CurrentHealth <= 0)
                        {
                            Console.WriteLine("Your game is over!");

                            continue;
                        }
                        else if (myhero.Fled == false)
                        {
                            double gold = 0;
                            double experience = 0;
                            double curXp = 0;
                            double curGol = 0;

                            foreach (Character monster in Monster)
                            {
                                monster.Experience += ((((myhero.Level * 2) * monster.XpMod) / 0.75 + 15) * monster.XpMod);
                                curXp += monster.Experience;
                                curGol += (monster.Gold * 1.5) + monster.GoldMod;

                                if (monster.Fled == false)
                                {
                                    experience = curXp;
                                    if (experience >= 25000)
                                    {
                                        experience = 25000;
                                    }
                                    gold = curGol;
                                }
                                else
                                {
                                    experience += 0;
                                    gold += 0;
                                }
                            }

                            if (myhero.Level < 100)
                            {
                                Console.WriteLine("{0} gets {1} gold and {2} experience"

                                , myhero.Identifier, $"{gold:F0}", $"{experience:F0}");
                                myhero.Experience += experience;
                                myhero.CurrentXp += experience;
                                myhero.Gold += gold;
                                Monster.Clear();

                                while (myhero.CurrentXp >= myhero.XpThresh)
                                {
                                    Console.WriteLine("{0} is ready for the next level!", myhero.Identifier);
                                    myhero.Level = myhero.Level + 1;
                                    myhero.MaxHealth = (myhero.MaxHealth * 4) / 3;
                                    if (myhero.MaxHealth > 100000)
                                    {
                                        myhero.MaxHealth = 100000;
                                    }
                                    myhero.MaxMagic = (myhero.MaxMagic * 4) / 3;
                                    if (myhero.MaxMagic > 15000)
                                    {
                                        myhero.MaxMagic = 15000;
                                    }
                                    myhero.Defense = ((myhero.Defense * 7) / 3) + 10;
                                    if (myhero.Defense > 1300)
                                    {
                                        myhero.Defense = 1300;
                                    }
                                    myhero.Agility = ((myhero.Agility * 4) / 3) + 15;
                                    if (myhero.Agility > 950)
                                    {
                                        myhero.Agility = 950;
                                    }
                                    myhero.CurrentXp -= myhero.XpThresh;
                                    if (myhero.CurrentXp < 0)
                                    {
                                        myhero.CurrentXp = 0;
                                    }
                                    myhero.XpThresh = (myhero.Level * 500) * 1.5;
                                    myhero.XpToLevel = myhero.XpThresh - myhero.CurrentXp;
                                    myhero.CurrentHealth = myhero.MaxHealth;
                                    myhero.CurrentMagic = myhero.MaxMagic;
                                    myhero.Strength = ((myhero.Strength * 7) / 3) + 20;
                                    if (myhero.Strength > 1000)
                                    {
                                        myhero.Strength = 1000;
                                    }
                                    myhero.AttackDamage = (myhero.Strength * 7) / 2;
                                    myhero.Intelligence = ((myhero.Intelligence * 4) / 3) + 10;
                                    if (myhero.Intelligence > 775)
                                    {
                                        myhero.Intelligence = 775;
                                    }
                                    Console.WriteLine("Experience until next level: {0}", myhero.XpToLevel);
                                }
                                Console.WriteLine("Press enter to continue....");
                                Console.ReadLine();
                                //continue;
                                //Console.WriteLine("Press enter to continue....");
                                //Console.ReadLine();
                            }
                            else if ((myhero.Level == 100))
                            {
                                Console.WriteLine("{0} gets {1} gold and 0 experience"

                                , myhero.Identifier, $"{gold:F0}");
                                myhero.CurrentXp = 0;
                                myhero.Gold += gold;
                                Monster.Clear();

                                Console.WriteLine("Press enter to continue....");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            myhero.Fled = false;
                        }

                        break;

                    case "Q":
                        Console.WriteLine("Goodbye {0}", myhero.Identifier);
                        Console.WriteLine();
                        Console.WriteLine("Press enter to continue....");
                        Console.ReadLine();
                        return;
                }
            }

            while (answer != "Q");
        }

        private static void Main(string[] args)
        {
            BasicGameLoop();
        }
    }
}
