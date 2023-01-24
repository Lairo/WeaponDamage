using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwordDamage_Console
{
    internal class SwordDamage
    {
        private const int BASE_DAMAGE = 3;
        private const int FLAME_DAMAGE= 2;

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
            set { 
                if(value > 0)
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
            decimal magicMultiplier = 1M;
            if (Magic) magicMultiplier = 1.75M;

            Damage = BASE_DAMAGE;

            Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE + FLAME_DAMAGE;
            if (Flaming) Damage += FLAME_DAMAGE;
            Debug.WriteLine($"CalculateDamage finished: {Damage} (roll: {Roll})");

        }

        /// <summary>
        /// The constructor calculated damage based on default Magic 
        /// and Flaming values and a starting 3d6 roll.
        /// </summary>
        /// <param name="startingRoll">Starting 3d6 roll</param>

        public SwordDamage(int startingRoll)
        {
            roll = startingRoll;
            CalculateDamage();
        }
    }
}
