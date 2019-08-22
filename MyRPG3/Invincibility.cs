using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRPG3
{
    internal class Invincibility : Potions
    {
        public Invincibility()
        {
            potionIdent = "Invincibility";
            invincibility = true;
            isOnSelf = true;
            defenseMod = true;
            potionCost = 3;
            _isUsed = false;
        }

        public override int PotionUse(Character User)
        {
            Console.WriteLine("{0} uses an invincibility potion,", User.Identifier);
            User.PotionQty = User.PotionQty - potionCost;
            potency = User.Defense * 10;
            if (User.PotionQty < 0)
            {
                User.PotionQty += potionCost;
                Console.WriteLine("however {0} doesn't have enough potions to mix", User.Identifier);
                potency = 0;
            }
            else if (User.PotionQty >= 0)
            {
                Console.WriteLine("and gains {0} defense!", potency);
                Console.WriteLine("{0} becomes invincible!", User.Identifier);
            }
            return potency;
        }
    }
}