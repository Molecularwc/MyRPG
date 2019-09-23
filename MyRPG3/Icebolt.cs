using System;

namespace MyRPG
{
    internal class Icebolt : Spell
    {
        public Icebolt()
        {
            identifier = "Icebolt";
            power = 12;
            spellPwr = 0;
            singleTarget = true;
            magicCost = 2;
        }

        public override int SpellCast(Character Caster)
        {
            Console.WriteLine("{0} casts Icebolt,", Caster.Identifier);
            Caster.CurrentMagic -= magicCost;
            spellPwr = (power * Caster.Intelligence) / 3;
            if (Caster.CurrentMagic < 0)
            {
                Caster.CurrentMagic += magicCost;
                Console.WriteLine("however {0} doesn't have enough magic points", Caster.Identifier);
                power = 0;
            }
            else if (Caster.CurrentMagic >= 0)
            {
                Console.WriteLine("and hits for {0}hp of ice damage", spellPwr);
            }
            return spellPwr;
        }
    }
}