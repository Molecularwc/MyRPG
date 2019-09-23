using System;

namespace MyRPG
{
    internal class Heal : Spell
    {
        public Heal()
        {
            Identifier = "Heal";
            IsOnSelf = true;
            Power = 180;
            SpellPwr = 0;
            MagicCost = 6;
        }

        public override int SpellCast(Character Caster)
        {
            Console.WriteLine("{0} casts heal,", Caster.Identifier);
            Caster.CurrentMagic -= MagicCost;
            SpellPwr = (Power * Caster.Intelligence) / 5;
            if (Caster.CurrentMagic < 0)
            {
                Caster.CurrentMagic += MagicCost;
                Console.WriteLine("however {0} doesn't have enough magic points", Caster.Identifier);
                Power = 0;
            }
            else if (Caster.CurrentMagic >= 0)
            {
                Console.WriteLine("and heals {0}hp", SpellPwr);
            }
            return SpellPwr;
        }
    }
}
