using System;

namespace MyRPG
{
    internal class Icebolt : Spell
    {
        public Icebolt()
        {
            Identifier = "Icebolt";
            Power = 12;
            SpellPwr = 0;
            SingleTarget = true;
            MagicCost = 2;
        }

        public override int SpellCast(Character Caster)
        {
            Console.WriteLine("{0} casts Icebolt,", Caster.Identifier);
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
                Console.WriteLine("and hits for {0}hp of ice damage", SpellPwr);
            }
            return SpellPwr;
        }
    }
}
