using System;

namespace MyRPG
{
    internal class IncreaseMaxHp : Potions
    {
        public IncreaseMaxHp()
        {
            PotionIdent = "IncreaseMaxHP";
            IncreaseMaxHp = true;
            IsOnSelf = true;
            PotionCost = 2;
            IsUsed = false;
        }

        public override int PotionUse(Character user)
        {
            Console.WriteLine("{0} uses a Increase Max HP potion,", user.Identifier);
            user.PotionQty -= PotionCost;
            Potency = user.MaxHealth * 10;
            if (user.PotionQty < 0)
            {
                user.PotionQty += PotionCost;
                Console.WriteLine("however {0} doesn't have enough potions to mix", user.Identifier);
                Potency = 0;
            }
            else if (user.PotionQty >= 0)
            {
                Console.WriteLine("and gains {0} additional HP!", Potency);
            }
            return Potency;
        }
    }
}
