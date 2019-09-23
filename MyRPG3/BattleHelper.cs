using System;
using System.Collections.Generic;

namespace MyRPG
{
    /// <summary>
    /// A collection of static methods used in our battle loop
    /// </summary>
    internal class BattleHelper
    {
        private static int damage;
        private static Random rand;

        #region CheckHealth

        /// <summary>
        /// This method should be called for each character to determine if they are alive A dead
        /// character should not be allowed to do any actions
        /// </summary>
        /// <param name="health">the characters current health int</param>
        /// <returns>Returns if the character is alive</returns>
        public static bool CheckHealth(int health)
        {
            bool alive;
            alive = health > 0;
            return alive;
        }

        #endregion CheckHealth

        #region DealDamage

        /// <summary>
        /// This method calculates the damage based on the attackers attack power vs the defenders
        /// defense stat
        /// </summary>
        /// <param name="attacker">The attacking character</param>
        /// <param name="defender">The defending character</param>
        /// <returns></returns>
        public static int DealDamage(Character attacker, Character defender)
        {
            int max;
            int min;
            rand = new Random();
            max = (attacker.AttackDamage * 8) - defender.Defense;
            if (max <= 0)
            {
                max = 1;
            }
            min = (attacker.AttackDamage * 4) - defender.Defense;
            if (min <= 0)
            {
                min = 1;
            }
            damage = rand.Next(min, max);
            if (attacker.IncreaseAttack)
            {
                damage = (int)(damage * 3) / 2;
            }
            if (defender.Defending)
            {
                damage = damage / 2;
            }
            if (defender.DefenseMod)
            {
                damage = damage / 10;
            }
            return damage;
        }

        #endregion DealDamage

        #region ProcessChoice

        /// <summary>
        /// This method is used to take the choice and determine the right action for it
        /// </summary>
        /// <param name="choice">the attackers choice</param>
        /// <param name="attacker">The active character</param>
        /// <param name="defender">The target character the attacker is attacking</param>
        /// <param name="spellChoice">The chosen spell</param>
        /// <param name="potionChoice">The chosen potion</param>
        public static void ProcessChoice(string choice, Character attacker, Character defender, string spellChoice, string potionChoice)
        {
            switch (choice.ToUpper())
            {
                case "A":
                    Console.WriteLine();
                    Console.WriteLine("{0} attacks!", attacker.Identifier);
                    DealDamage(attacker, defender);
                    defender.CurrentHealth -= damage;
                    Console.WriteLine("{0} hits the {1} for {2}hp of damage"
                        , attacker.Identifier, defender.Identifier, damage);
                    break;

                case "D":
                    Console.WriteLine();
                    Console.WriteLine("{0} defends!", attacker.Identifier);
                    break;

                case "F":
                    Console.WriteLine();
                    Console.WriteLine("{0} flees!", attacker.Identifier);
                    attacker.Fled = true;
                    attacker.IsAlive = false;
                    break;

                case "S":
                    Console.WriteLine();
                    CastSpell(attacker, defender, spellChoice);
                    break;

                case "P":
                    Console.WriteLine();
                    break;

                default:
                    Console.WriteLine("I'm sorry, I didn't recognize that.");
                    Console.WriteLine();
                    choice = PrintChoice();
                    Console.WriteLine();
                    ProcessChoice(choice, attacker, defender, spellChoice, potionChoice);
                    break;
            }
        }

        #endregion ProcessChoice

        #region PrintStatus

        /// <summary>
        /// This method is used to print the status of both characters
        /// </summary>
        /// <param name="hero">Our hero character</param>
        public static void PrintStatus(Character hero)
        {
            Console.Write(@"    HP/MaxHP   MP/MaxMP     Level
{0}:   {1}/{2}hp    {3}/{4}mp   {5}
********************************
", hero.Identifier, hero.CurrentHealth, hero.MaxHealth,
 hero.CurrentMagic, hero.MaxMagic, hero.Level);
        }

        #endregion PrintStatus

        #region PrintChoice

        /// <summary>
        /// This method prints our choices and gets the choice.
        /// </summary>
        /// <returns>returns the string of the hero's choice</returns>
        public static string PrintChoice()
        {
            string choice;
            Console.WriteLine();
            Console.Write(@"
_____________________
Please choose an action:
(A)ttack:
(D)efend:
(S)pell:
(P)otion:
(F)lee:
_____________________");
            Console.WriteLine();
            choice = Console.ReadLine();
            return choice;
        }

        #endregion PrintChoice

        #region CheckDefense

        /// <summary>
        /// This method should be called for each active character. This sets the bools defending and
        /// increase attack for the character. This method should be called prior to any processchoice.
        /// </summary>
        /// <param name="choice">input the string choice to check for defense</param>
        /// <param name="attacker">input the active character we are checking</param>
        public static void CheckDefense(string choice, Character attacker)
        {
            attacker.IncreaseAttack = attacker.Defending == true;

            attacker.Defending = choice == "D";
        }

        #endregion CheckDefense

        #region CastSpell

        /// <summary>
        /// "cast" the spell
        /// </summary>
        /// <param name="attacker">The attacker</param>
        /// <param name="defender">The defender</param>
        /// <param name="spellChoice">The spell they've chosen to cast</param>
        public static void CastSpell(Character attacker, Character defender, string spellChoice)
        {
            Spell spell;
            spell = ProcessSpellChoice(spellChoice, attacker);
            var spellpower = spell.SpellCast(attacker);
            if (spell.IsOnSelf == true)
            {
                attacker.CurrentHealth += spellpower;
                if (attacker.CurrentHealth > attacker.MaxHealth)
                {
                    attacker.CurrentHealth = attacker.MaxHealth;
                }
            }
            else if (spell.MultipleHits == true)
            {
                defender.CurrentHealth -= spellpower;
                //To Do: make it hit multiple enemies
            }
            else if (spell.SingleTarget == true)
            {
                defender.CurrentHealth -= spellpower;
            }
        }

        #endregion CastSpell

        #region PrintSpells

        /// <summary>
        /// A method to print out the spells to choose from
        /// </summary>
        /// <returns>A string of the spell choice</returns>
        public static string PrintSpells()
        {
            Console.WriteLine();
            string spellchoice;
            Console.Write(@"
Please choose a spell:
***********************
(H)eal
(F)ireball
(I)cebolt
(L)ightningbolt
***********************");
            Console.WriteLine();
            spellchoice = Console.ReadLine();
            return spellchoice;
        }

        #endregion PrintSpells

        #region ProcessSpellChoice

        /// <summary>
        /// A method to determine which spell should be cast
        /// </summary>
        /// <param name="spellchoice">The spell choice</param>
        /// <param name="attacker">the attacker</param>
        public static Spell ProcessSpellChoice(string spellchoice, Character attacker)
        {
            Spell spell;
            switch (spellchoice.ToUpper())
            {
                case "H":
                    var heal = new Heal();
                    return heal;

                case "F":
                    var fireball = new Fireball();
                    return fireball;

                case "I":
                    var icebolt = new Icebolt();
                    return icebolt;

                case "L":
                    var lightningbolt = new LightningBolt();
                    return lightningbolt;

                default:
                    Console.WriteLine();
                    Console.WriteLine("I'm sorry that wasn't a valid choice");
                    spellchoice = PrintSpells();
                    spell = ProcessSpellChoice(spellchoice, attacker);
                    break;
            }
            return spell;
        }

        #endregion ProcessSpellChoice

        #region UsePotion

        /// <summary>
        /// "use" the potion
        /// </summary>
        /// <param name="attacker">The attacker</param>
        /// <param name="defender">The defender</param>
        /// <param name="potionChoice">The potion they've chosen to use</param>
        public static void UsePotion(Character attacker, Character defender, string potionChoice)
        {
            Potions potion;
            potion = ProcessPotionsChoice(potionChoice, attacker);
            var pot = potion.PotionUse(attacker);
            if (potion.RestoreHp == true)
            {
                attacker.NewHp = attacker.CurrentHealth + pot;
                attacker.OldHp = attacker.CurrentHealth;
                attacker.CurrentHealth = attacker.NewHp;
                if (attacker.NewHp > attacker.MaxHealth)
                {
                    attacker.NewHp = attacker.MaxHealth;
                }
            }
            else if (potion.IncreaseMaxHp == true && potion.IsUsed == true)
            {
                attacker.NewMaxHp = attacker.MaxHealth + pot;
                attacker.OldMaxHp = attacker.MaxHealth;
                attacker.MaxHealth = attacker.NewMaxHp;
                attacker.StatIncrease = true;
            }
            if (potion.Invincibility == true && potion.IsUsed == true)
            {
                attacker.DefenseMod = true;
            }
        }

        #endregion UsePotion

        #region PrintPotions

        /// <summary>
        /// A method to print out the potions to choose from
        /// </summary>
        /// <returns>A string of the potion choice</returns>
        public static string PrintPotions()
        {
            Console.WriteLine();
            string potionchoice;
            Console.Write(@"
Please choose a potion:
***********************
(I)nvincibility
Increase (M)ax HP
(R)estore HP
***********************");
            Console.WriteLine();
            potionchoice = Console.ReadLine();
            return potionchoice;
        }

        #endregion PrintPotions

        #region ProcessPotionChoice

        /// <summary>
        /// A method to determine which spell should be cast
        /// </summary>
        /// <param name="potionchoice">The spell choice</param>
        /// <param name="attacker">the attacker</param>
        /// <param name="defender">the defender</param>
        public static Potions ProcessPotionsChoice(string potionchoice, Character attacker)
        {
            Potions potions;
            switch (potionchoice.ToUpper())
            {
                case "I":
                    Invincibility invincibility = new Invincibility();
                    invincibility.IsUsed = true;
                    return invincibility;

                case "M":
                    IncreaseMaxHp increaseMaxHP = new IncreaseMaxHp();
                    increaseMaxHP.IsUsed = true;
                    return increaseMaxHP;

                case "R":
                    RestoreHP restoreHP = new RestoreHP();
                    restoreHP.IsUsed = true;
                    return restoreHP;

                default:
                    Console.WriteLine();
                    Console.WriteLine("I'm sorry that wasn't a valid choice");
                    potionchoice = PrintSpells();
                    potions = ProcessPotionsChoice(potionchoice, attacker);
                    break;
            }
            return potions;
        }

        #endregion ProcessPotionChoice

        #region CheckMonsters

        /// <summary>
        /// This method makes sure at least one monster is alive to continue the battle
        /// </summary>
        /// <param name="Monsters"></param>
        public static bool CheckMonsters(List<Character> Monsters)
        {
            var foundone = false;
            foreach (Character monster in Monsters)
            {
                if (monster.IsAlive)
                {
                    foundone = true;
                }
            }
            if (foundone)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion CheckMonsters

        #region ChooseTarget

        /// <summary>
        /// This method will print out the current monster with an index so the attacker can choose
        /// which one to target.
        /// </summary>
        /// <param name="Monster">This is the list of monsters</param>
        /// <returns>Returns an index of the character to attack</returns>
        public static int ChooseTarget(List<Character> Monster)
        {
            Console.WriteLine("Please choose the monster to attack");
            string choice;
            var x = 0;
            foreach (Character monster in Monster)
            {
                x++;
                if (monster.IsAlive)
                {
                    Console.WriteLine("{0}: {1}", x, monster.Identifier);
                }
            }
            Console.WriteLine();
            choice = Console.ReadLine();
            try//try this stuff
            {
                x = int.Parse(choice);
            }
            catch (Exception)//if problem try this
            {
                Console.WriteLine("Invalid choice");
                x = ChooseTarget(Monster);
                x++;
            }
            finally//finally when it works do this
            {
                x -= 1;
            }
            return x;
        }

        #endregion ChooseTarget
    }
}
