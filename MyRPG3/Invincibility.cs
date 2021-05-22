using System;

namespace MyRPG
{
    internal class Invincibility : Potions
    {
        public Invincibility()
        {
            PotionIdent = "Invincibility";
            Invincibility = true;
            IsOnSelf = true;
            DefenseMod = true;
            PotionCost = 3;
            IsUsed = false;
        }

        public override int PotionUse(Character User)
        {
            Console.WriteLine("{0} uses an invincibility potion,", User.Identifier);
            User.PotionQty -= PotionCost;
            Potency = User.Defense * 10;
            if (User.PotionQty < 0)
            {
                User.PotionQty += PotionCost;
                Console.WriteLine("however {0} doesn't have enough potions to mix", User.Identifier);
                Potency = 0;
            }
            else if (User.PotionQty >= 0)
            {
                Console.WriteLine("and gains {0} defense!", Potency);
                Console.WriteLine("{0} becomes invincible!", User.Identifier);
            }
            return Potency;
        }
    }
}
