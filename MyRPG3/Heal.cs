using System;

namespace MyRPG3
{
    internal class Heal : Spell
    {
        public Heal()
        {
            identifier = "Heal";
            isOnSelf = true;
            power = 180;
            spellPwr = 0;
            magicCost = 6;
        }

        public override int SpellCast(Character Caster)
        {
            Console.WriteLine("{0} casts heal,", Caster.Identifier);
            Caster.CurrentMagic -= magicCost;
            spellPwr = (power * Caster.Intelligence) / 5;
            if (Caster.CurrentMagic < 0)
            {
                Caster.CurrentMagic += magicCost;
                Console.WriteLine("however {0} doesn't have enough magic points", Caster.Identifier);
                power = 0;
            }
            else if (Caster.CurrentMagic >= 0)
            {
                Console.WriteLine("and heals {0}hp", spellPwr);
            }
            return spellPwr;
        }
    }
}