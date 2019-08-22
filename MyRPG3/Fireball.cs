using System;

namespace MyRPG3
{
    internal class Fireball : Spell
    {
        public Fireball()
        {
            identifier = "Fireball";
            multipleHits = true;
            power = 10;
            spellPwr = 0;
            magicCost = 5;
        }

        public override int SpellCast(Character Caster)
        {
            Console.WriteLine("{0} casts fireball,", Caster.Identifier);
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
                Console.WriteLine("and hits for {0}hp of fire damage", spellPwr);
            }
            return spellPwr;
        }
    }
}