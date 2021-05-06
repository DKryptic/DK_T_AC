using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK_T_AC
{
    class OS
    {
        //public static int m_os_viewMatrix = 0x101B14;
        public static int m_os_viewMatrix = 0x501AE8;
        public static int m_os_amountOfPlayers = 0x50F500;
        public static int m_os_EntityList = 0x10F4F8;
        //public static int m_os_EntityList = 0x0050F4F4;
        #region ----LocalPlayerOffsets----
        public static int m_os_LocalPlayer = 0x10F4F4; // This will give you the local players base address.
        public static int m_os_LocalPlayerHealth = 0xF8; // This will be the players base address + this offset to give you the health value;
        public static int m_os_LocalPlayerName = 0x225; // This will be the players base address + this offset to give you the player name value;
        public static int m_os_LocalPlayerXCoord = 0x04; // This will be the players base address + this offset to give you the x coordinate value;
        public static int m_os_LocalPlayerYCoord = 0x08; // This will be the players base address + this offset to give you the y coordinate value;
        public static int m_os_LocalPlayerZCoord = 0x0C; // This will be the players base address + this offset to give you the z coordinate value;
        public static int m_os_LocalPlayerCrosshairTarget = 0x607C0;//0x101C38;

        public static int m_os_LocalPlayerFireGunStatus = 0x224; // Need to read this and write the first or is it the last byte? Should be 0, write to 1 to fire the gun. Write to 0 to stop.
        public static int m_os_LocalPlayerCurrentWeapon = 0x374;
        public static int[] m_os_LocalPlayerCurrentWeaponID = { 0x04 }; // m_os_LocalPlayerCurrentWeapon + m_os_LocalPlayerCurrentWeaponID gives you the value to the ID of the current weapon.
        public static int[] m_os_LocalPlayerCurrentWeaponType = { 0x0C, 0x00 };

        //Location of local players head
        public static int m_os_LocalPlayerHeadXCoord = 0x04;
        public static int m_os_LocalPlayerHeadYCoord = 0x08;
        public static int m_os_LocalPlayeHeadZCoord = 0x0C;

        //Location of local players chest/body
        public static int m_os_LocalPlayerBodyXCoord = 0x34;
        public static int m_os_LocalPlayerBodyYCoord = 0x38;
        public static int m_os_LocalPlayeBodyZCoord = 0x3C;

        //Location of local players angles (Not sure what the angles are yet.. left forward and up or something?
        public static int m_os_LocalPlayerFeetXCoord = 0x40;
        public static int m_os_LocalPlayerFeetYCoord = 0x44;
        public static int m_os_LocalPlayeFeetZCoord = 0x48;

        // These offsets are from the moduleBase address. Could use 0x10 for ammo reserve, and 0x14 for current ammo
        public static int m_os_LocalPlayerExtraAmmo = 0x128; // This will be the players base address + this offset to give you the extra ammo value;
        public static int m_os_LocalPlayerFireRate = 0x178; // This will be the players base address + this offset to give you the fire rate value;

        public static int[] m_os_OffsetsForAmmoFunction = { 0x7B8 };
        public static int m_os_LocalPlayerAmmoDecreaseFunctionInGame = 0xEA620;
        public static int m_os_GodMode = 0x29D1F; // Nop this function with this offset. This prevents damage, to enemies, and to the local player. 
        public static int[] m_os_OffsetsForFireCurrentGun = { 0x224 };
        public static int m_os_FireCurrentGun = 0x109B74;
        #endregion
        #region----EnemyOffsets----
        public static int m_os_EnemyPlayerHealth = 0xF8;
        public static int m_os_EnemyPlayerXCoord = 0x04; // This will be the players base address + this offset to give you the x coordinate value;
        public static int m_os_EnemyPlayerYCoord = 0x08; // This will be the players base address + this offset to give you the y coordinate value;
        public static int m_os_EnemyPlayerZCoord = 0x0D;
        #endregion

        public static int m_os_LocalPlayerTeam_ID = 0x32C; // This will be a 0 for one team or 1 for the other in a team deathmatch.
        public static int m_os_CrosshairTargetName = 0x101C38;

        /*
         * 
         * if (bRecoil)
            {
                mem::Nop((BYTE*)(moduleBase + 0x63786), 10);
            }

            else
            {
                //50 8D 4C 24 1C 51 8B CE FF D2 the original stack setup and call
                mem::Patch((BYTE*)(moduleBase + 0x63786), (BYTE*)"\x50\x8D\x4C\x24\x1C\x51\x8B\xCE\xFF\xD2", 10);
            }
         * */
    }
}
