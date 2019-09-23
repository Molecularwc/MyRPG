namespace MyRPG
{
    internal class Spell
    {
        public bool Fire, Ice, Lightning;

        //These would be used if you want elemental defense and weakness
        public string Identifier;

        public int MagicCost;

        //this is how much MP it costs to cast the spell
        public bool MultipleHits, SingleTarget, IsOnSelf;

        public int Power;//This is for the base potency of the spell

        public int SpellPwr; //This is the spell power mod

        //These are to determine how to use the spell
        public Spell()
        {
            MultipleHits = false;
            SingleTarget = false;
            IsOnSelf = false;
            Fire = false;
            Ice = false;
            Lightning = false;
        }

        public virtual int SpellCast(Character caster)
        {
            return SpellPwr;
        }
    }
}
