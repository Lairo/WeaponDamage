using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponDamage
{
    internal abstract class WeaponDamage
    {

        public int Damage { get; protected set; }
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
        /// The constructor calculated damage based on default Magic 
        /// and Flaming values and a starting 3d6 roll.
        /// </summary>
        /// <param name="startingRoll">Starting 3d6 roll</param>
        public WeaponDamage(int startingRoll)
        {
            roll = startingRoll;
            CalculateDamage();
        }
        /// <summary>
        /// Calculates the damage based on the current properties.
        /// </summary>
        protected abstract void CalculateDamage();
    }
}
