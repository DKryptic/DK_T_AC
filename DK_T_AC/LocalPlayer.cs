using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK_T_AC
{
    // I guess will create one instance of this object in the main code. 
    // We will then have a function in a thread, that reads all of the values, and updates these values
    // to this object. 
    // This way we can always refer to this object when we want any of the local player values.

    // For the enemies, I think we will create another enemy object with the parameters as well.
    // We will then do the same, and use an array or list of the enemy object, and refer to them
    // by index to update thier values.
    class LocalPlayer
    {
        // This is the local players health
        public int iLPHealth;
        // This is the current ammo of the player, no matter which gun is chosen
        public int iLPCurrentAmmo;
        // This will be the extra magazines, but will be written to, and read as rounds. i.e. 60 rounds left.
        public int iLPExtraAmmo;

        public int iLPCurrentWeaponID;

        public string iLPCurrentWeaponType;

        public int iLPCurrentTeam;

        public int iAddressOfClosestEnemy = 0x0;
        public string iClosestEnemyName = "NA";
        public int iClosestEnemyHealth = 999;
        public int iClosestEnemyTeam = 3;

        public int iAddressOfCrosshairTarget = 0x0;
        public string iCrosshairTargetName = "NA";
        public int iCrosshairTargetHealth = 999;
        public int iCrosshairTargetTeam=3;

        // Constructor
        public LocalPlayer()
        {

        }

    }
}
