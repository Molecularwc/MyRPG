using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRPG
{
    internal class Potions
    {
        public bool _isUsed;
        public bool defenseMod;
        public bool invincibility, increaseMaxHP, restoreHP;
        public bool isOnSelf;
        public int potency;
        public int potionCost;
        public string potionIdent;

        public Potions()
        {
            invincibility = false;
            increaseMaxHP = false;
            restoreHP = false;
            isOnSelf = false;
            defenseMod = false;
            _isUsed = false;
        }

        public virtual int PotionUse(Character user)
        {
            return potency;
        }
    }
}