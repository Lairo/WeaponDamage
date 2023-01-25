using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponDamage
{
    internal class ArrowDamage
    {
        private const decimal BASE_MULTIPLIER = 0.35M;
        private const decimal MAGIC_MULTIPLIER = 2.5M;
        private const decimal FLAME_DAMAGE = 1.25M;


        /// <summary>
        /// Contains the calculated Damage.
        /// </summary>
        public int Damage { get; private set; }

        private int roll;

        /// <summary>
        /// Set or gets the 3d6 roll;
        /// </summary>
        public int Roll
        {
            get { return roll; }
            set
            {
                if (value > 0)
                    roll = value;
                CalculateDamage();
            }
        }

        private bool flaming;

        /// <summary>
        /// True if flaming is selected, false otherwise.
        /// </summary>
        public bool Flaming
        {
            get { return flaming; }
            set
            {
                flaming = value;
                CalculateDamage();
            }
        }

        private bool magic;

        /// <summary>
        /// True if magic is selected, false otherwise.
        /// </summary>
        public bool Magic
        {
            get { return magic; }
            set
            {
                magic = value;
                CalculateDamage();
            }
        }

        /// <summary>
        /// Calculates the damage based on the current properties.
        /// </summary>
        private void CalculateDamage()
        {
            decimal baseDamage = Roll * BASE_MULTIPLIER;
            if (Magic) baseDamage *= MAGIC_MULTIPLIER;
            if (flaming) Damage = (int)Math.Ceiling(baseDamage + FLAME_DAMAGE);
            else Damage = (int)Math.Ceiling(baseDamage);

        }

        /// <summary>
        /// The constructor calculated damage based on default Magic 
        /// and Flaming values and a starting 3d6 roll.
        /// </summary>
        /// <param name="startingRoll">Starting 3d6 roll</param>

        public ArrowDamage(int startingRoll)
        {
            roll = startingRoll;
            CalculateDamage();
        }
    }
}
