using System;
using System.Collections.Generic;

namespace MyRPG3
{
    internal class Battle
    {
        private bool amonsterleft;
        private string monsterchoice;
        private string monsterpotionchoice;
        private string monsterspellchoice;
        private int rnds;
        private int targetmonster;
        private string userchoice;
        private string userpotionchoice;
        private string userspellchoice;

        public Battle(Hero hero, List<Character> monsters)
        {
            Console.WriteLine("{0} is facing:", hero.Identifier);
            foreach (Character monster in monsters)
            {
                Console.WriteLine("{0}", monster.Identifier);
            }
            BattleLoop(hero, monsters);
        }

        public void BattleLoop(Hero hero, List<Character> monsters)
        {
            rnds = 0;
            do
            {
                Console.WriteLine("********************************");
                BattleHelper.PrintStatus(hero);
                foreach (Character monster in monsters)
                {
                    if (monster.isAlive)
                    {
                        if (hero.Level > monster.Level)
                        {
                            monster.Level = hero.Level + 1;
                            monster.MaxHealth = (monster.MaxHealth * 10) / 3;
                            monster.CurrentHealth = monster.MaxHealth;
                            monster.MaxMagic = (monster.MaxMagic * 10) / 3;
                            monster.CurrentMagic = monster.MaxMagic;
                            monster.Strength = (monster.Strength * 3) / 2;
                            monster.Defense = (monster.Defense * 3) / 2;
                            monster.Agility = (monster.Agility * 3) / 2;
                            monster.Intelligence = (monster.Intelligence * 3) / 2;
                            monster.AttackDamage = monster.Strength;
                            monster.Experience = (monster.Experience * (hero.Level * 2)) * monster.xpMod;
                            monster.Gold = (monster.Gold * (hero.Level * 2)) * 1.5;
                        }
                        BattleHelper.PrintStatus(monster);
                        if (rnds >= 3 && hero.defenseMod == true)
                        {
                            hero.defenseMod = false;
                        }
                        if (rnds >= 4 && hero.statIncrease == true)
                        {
                            hero.CurrentHealth = hero.oldHP;
                            hero.MaxHealth = hero.oldMaxHP;
                            hero.statIncrease = false;
                        }
                    }
                }
                userchoice = BattleHelper.PrintChoice();

                Console.WriteLine();
                BattleHelper.CheckDefense(userchoice, hero);
                if (userchoice == "s" || userchoice == "S")
                {
                    userspellchoice = BattleHelper.PrintSpells();
                }
                else if (userchoice == "f" || userchoice == "F")
                {
                    Console.WriteLine("You have fled");
                    Console.WriteLine("Press any key to continue");
                    hero.fled = true;
                    continue;
                }
                else if (userchoice == "p" || userchoice == "P")
                {
                    userpotionchoice = BattleHelper.PrintPotions();
                }
                targetmonster = BattleHelper.ChooseTarget(monsters);
                BattleHelper.ProcessChoice(userchoice, hero, monsters[targetmonster], userspellchoice, userpotionchoice);

                foreach (Character monster in monsters)
                {
                    bool v = BattleHelper.CheckHealth(monster.CurrentHealth);
                    monster.isAlive = v;
                    if (monster.isAlive == true)
                    {
                        monsterchoice = monster.AI();
                        BattleHelper.CheckDefense(monsterchoice, monster);
                        if (monsterchoice == "S" || monsterchoice == "s")
                        {
                            monsterspellchoice = monster.SpellAI();
                        }
                        else if (monsterchoice == "p" || monsterchoice == "P")
                        {
                            monsterpotionchoice = monster.PotionAI();
                        }

                        BattleHelper.ProcessChoice(monsterchoice, monster, hero, monsterspellchoice, monsterpotionchoice);
                    }
                }
                amonsterleft = BattleHelper.CheckMonsters(monsters);
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                Console.Clear();
            }
            while (hero.isAlive == true && amonsterleft == true);
        }
    }
}
