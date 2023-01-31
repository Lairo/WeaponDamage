using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponDamage
{
    internal class SwordDamage : WeaponDamage
    {
        private const int BASE_DAMAGE = 3;
        private const int FLAME_DAMAGE= 2;

        public SwordDamage(int startingRoll) : base(startingRoll) { }

        protected override void CalculateDamage()
        {
            decimal magicMultiplier = 1M;
            if (base.Magic) magicMultiplier = 1.75M;

            base.Damage = BASE_DAMAGE;

            base.Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE + FLAME_DAMAGE;
            if (base.Flaming) base.Damage += FLAME_DAMAGE;        
        }
        
    }
}
