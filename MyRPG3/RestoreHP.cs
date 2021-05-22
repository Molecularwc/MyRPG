using System;

namespace MyRPG
{
    internal class RestoreHP : Potions
    {
        public RestoreHP()
        {
            PotionIdent = "RestoreHP";
            RestoreHp = true;
            IsOnSelf = true;
            PotionCost = 1;
            IsUsed = false;
        }

        public override int PotionUse(Character User)
        {
            Console.WriteLine("{0} uses a Restore HP potion,", User.Identifier);
            User.PotionQty -= PotionCost;
            Potency = User.CurrentHealth * 10;
            if (User.PotionQty < 0)
            {
                User.PotionQty += PotionCost;
                Console.WriteLine("however {0} doesn't have enough potions to mix", User.Identifier);
                Potency = 0;
            }
            else if (User.PotionQty >= 0)
            {
                Console.WriteLine("and gains {0} HP!", Potency);
            }
            return Potency;
        }
    }
}
