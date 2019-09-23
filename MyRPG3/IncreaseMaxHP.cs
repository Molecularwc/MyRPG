﻿using System;

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

        public override int PotionUse(Character User)
        {
            Console.WriteLine("{0} uses a Increase Max HP potion,", User.Identifier);
            User.PotionQty = User.PotionQty - potionCost;
            potency = User.MaxHealth * 10;
            if (User.PotionQty < 0)
            {
                User.PotionQty += potionCost;
                Console.WriteLine("however {0} doesn't have enough potions to mix", User.Identifier);
                potency = 0;
            }
            else if (User.PotionQty >= 0)
            {
                Console.WriteLine("and gains {0} additional HP!", potency);
            }
            return potency;
        }
    }
}
