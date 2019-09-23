using System;

namespace MyRPG
{
    internal class IncreaseMaxHp : Potions
    {
        public IncreaseMaxHp()
        {
            potionIdent = "IncreaseMaxHP";
            increaseMaxHP = true;
            isOnSelf = true;
            potionCost = 2;
            _isUsed = false;
        }

        public override int PotionUse(Character user)
        {
            Console.WriteLine("{0} uses a Increase Max HP potion,", user.Identifier);
            user.PotionQty = user.PotionQty - potionCost;
            potency = user.MaxHealth * 10;
            if (user.PotionQty < 0)
            {
                user.PotionQty += potionCost;
                Console.WriteLine("however {0} doesn't have enough potions to mix", user.Identifier);
                potency = 0;
            }
            else if (user.PotionQty >= 0)
            {
                Console.WriteLine("and gains {0} additional HP!", potency);
            }
            return potency;
        }
    }
}
