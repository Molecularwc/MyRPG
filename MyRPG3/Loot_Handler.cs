using System.Collections.Generic;

namespace MyRPG
{
    internal class Loot_Handler
    {
        public const string gold = "Gold";
        private readonly Dictionary<string, int> Loot;

        public Loot_Handler()
        {
            Loot = new Dictionary<string, int>();
        }

        public static void Initialize(Loot_Handler lewt)
        {
            lewt.Loot.Add(gold, 10);
        }
    }
}