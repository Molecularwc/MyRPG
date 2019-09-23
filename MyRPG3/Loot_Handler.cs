using System.Collections.Generic;

namespace MyRPG
{
    internal class LootHandler
    {
        public const string gold = "Gold";
        private readonly Dictionary<string, int> Loot;

        public LootHandler()
        {
            Loot = new Dictionary<string, int>();
        }

        public static void Initialize(LootHandler lewt)
        {
            lewt.Loot.Add(gold, 10);
        }
    }
}
