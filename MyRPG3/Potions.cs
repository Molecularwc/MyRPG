namespace MyRPG
{
    internal class Potions
    {
        public bool IsUsed;
        public bool DefenseMod;
        public bool Invincibility, IncreaseMaxHp, RestoreHp;
        public bool IsOnSelf;
        public int Potency;
        public int PotionCost;
        public string PotionIdent;

        public Potions()
        {
            Invincibility = false;
            IncreaseMaxHp = false;
            RestoreHp = false;
            IsOnSelf = false;
            DefenseMod = false;
            IsUsed = false;
        }

        public virtual int PotionUse(Character user)
        {
            return Potency;
        }
    }
}
