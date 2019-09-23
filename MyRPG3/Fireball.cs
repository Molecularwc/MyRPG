using System;

namespace MyRPG
{
    internal class Fireball : Spell
    {
        public Fireball()
        {
            Identifier = "Fireball";
            MultipleHits = true;
            Power = 10;
            SpellPwr = 0;
            MagicCost = 5;
        }

        public override int SpellCast(Character Caster)
        {
            Console.WriteLine("{0} casts fireball,", Caster.Identifier);
            Caster.CurrentMagic -= MagicCost;
            SpellPwr = (Power * Caster.Intelligence) / 3;
            if (Caster.CurrentMagic < 0)
            {
                Caster.CurrentMagic += MagicCost;
                Console.WriteLine("however {0} doesn't have enough magic points", Caster.Identifier);
                Power = 0;
            }
            else if (Caster.CurrentMagic >= 0)
            {
                Console.WriteLine("and hits for {0}hp of fire damage", SpellPwr);
            }
            return SpellPwr;
        }
    }
}
