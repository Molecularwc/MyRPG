namespace MyRPG
{
    internal class Spell
    {
        public bool fire, ice, lightning;

        //These would be used if you want elemental defense and weakness
        public string identifier;

        public int magicCost;

        //this is how much MP it costs to cast the spell
        public bool multipleHits, singleTarget, isOnSelf;

        public int power;//This is for the base potency of the spell

        public int spellPwr; //This is the spell power mod

        //These are to determine how to use the spell
        public Spell()
        {
            multipleHits = false;
            singleTarget = false;
            isOnSelf = false;
            fire = false;
            ice = false;
            lightning = false;
        }

        public virtual int SpellCast(Character caster)
        {
            return spellPwr;
        }
    }
}