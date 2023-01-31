using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponDamage
{
    internal class ArrowDamage : WeaponDamage
    {
        private const decimal BASE_MULTIPLIER = 0.35M;
        private const decimal MAGIC_MULTIPLIER = 2.5M;
        private const decimal FLAME_DAMAGE = 1.25M;

        /// <summary>
        /// The constructor calculated damage based on default Magic 
        /// and Flaming values and a starting 3d6 roll.
        /// </summary>
        /// <param name="startingRoll">Starting 3d6 roll</param>

        public ArrowDamage(int startingRoll) : base(startingRoll) { }

        protected override void CalculateDamage()
        {
            decimal baseDamage = Roll * BASE_MULTIPLIER;
            if (base.Magic) baseDamage *= MAGIC_MULTIPLIER;
            if (base.Flaming) base.Damage = (int)Math.Ceiling(baseDamage + FLAME_DAMAGE);
            else base.Damage = (int)Math.Ceiling(baseDamage);

        }

        
    }
}
