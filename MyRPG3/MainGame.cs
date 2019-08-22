using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyRPG3
{
    internal class MainGame
    {
        private static void BasicGameLoop()
        {
            string answer;
            Battle battle;
            List<Character> Monster;
            DataHandler data = new DataHandler();
            Admin admin = new Admin();
            Hero myhero;
            Console.WriteLine("Welcome to the arena!");
            myhero = new Hero();
            begin:
            Hero.Initialize(myhero);
            if (myhero.Identifier == "Admin")
            {
                Application.EnableVisualStyles();
                Application.Run(mainForm: new Admin());
                if (admin.Visible == false)
                {
                    myhero.Identifier = " ";
                }
                goto begin;
            }
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

                switch (answer)
                {
                    case "L":

                    case "l":

                        data.Load(myhero);

                        break;

                    case "A":

                    case "a":

                        data.Save(myhero);

                        break;

                    case "S":

                    case "s":

                        Store store = new Store(myhero);

                        break;

                    case "I":

                    case "i":

                        Inn.Sleep(myhero);

                        break;

                    case "v":

                    case "V":

                        View.PrintStats(myhero);

                        break;

                    case "F":

                    case "f":

                        string done = "";

                        do
                        {
                            Console.Write(@"

Which monster do you want to fight?

(S)lime:

(B)arbarian:

(M)age:

_________________________");

                            Console.WriteLine();

                            string choice = Console.ReadLine();

                            if (choice == "S" || choice == "s")
                            {
                                Monster.Add(new Slime());
                            }
                            else if (choice == "B" || choice == "b")
                            {
                                Monster.Add(new Barbarian());
                            }
                            else if (choice == "M" || choice == "m")
                            {
                                Monster.Add(new Mage());
                            }
                            else
                            {
                                Monster.Add(new Slime());
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
                        else if (myhero.fled == false)
                        {
                            double gold = 0;
                            double experience = 0;
                            double curXP = 0;
                            double curGol = 0;

                            foreach (Character monster in Monster)
                            {
                                monster.Experience += ((((myhero.Level * 2) * monster.xpMod) / 0.75 + 15) * monster.xpMod);
                                curXP += monster.Experience;
                                curGol += (monster.Gold * 1.5) + monster.goldMod;

                                if (monster.fled == false)
                                {
                                    experience = curXP;
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
                                myhero.CurrentXP += experience;
                                myhero.Gold += gold;
                                Monster.Clear();

                                if (myhero.CurrentXP >= myhero.XpThresh)
                                {
                                    do
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
                                        myhero.CurrentXP -= myhero.XpThresh;
                                        if (myhero.CurrentXP < 0)
                                        {
                                            myhero.CurrentXP = 0;
                                        }
                                        myhero.XpThresh = (myhero.Level * 500) * 1.5;
                                        myhero.XpToLevel = myhero.XpThresh - myhero.CurrentXP;
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
                                    while (myhero.CurrentXP >= myhero.XpThresh);
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
                                myhero.CurrentXP = 0;
                                myhero.Gold += gold;
                                Monster.Clear();

                                Console.WriteLine("Press enter to continue....");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            myhero.fled = false;
                        }

                        break;

                    case "Q":

                    case "q":

                        Console.WriteLine("Goodbye {0}", myhero.Identifier);
                        Console.WriteLine();
                        Console.WriteLine("Press enter to continue....");
                        Console.ReadLine();
                        return;
                }
            }

            while (answer != "Q" && answer != "q");
        }

        private static void Main(string[] args)
        {
            BasicGameLoop();
        }
    }
}