using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRPG
{
    internal class RestoreHP : Potions
    {
        public RestoreHP()
        {
            potionIdent = "RestoreHP";
            restoreHP = true;
            isOnSelf = true;
            potionCost = 1;
            _isUsed = false;
        }

        public override int PotionUse(Character User)
        {
            Console.WriteLine("{0} uses a Restore HP potion,", User.Identifier);
            User.PotionQty = User.PotionQty - potionCost;
            potency = User.CurrentHealth * 10;
            if (User.PotionQty < 0)
            {
                User.PotionQty += potionCost;
                Console.WriteLine("however {0} doesn't have enough potions to mix", User.Identifier);
                potency = 0;
            }
            else if (User.PotionQty >= 0)
            {
                Console.WriteLine("and gains {0} HP!", potency);
            }
            return potency;
        }
    }
}