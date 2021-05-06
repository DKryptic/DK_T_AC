using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DK_T_AC
{

    public partial class frmMain : Form
    {

        [DllImport("user32.dll", SetLastError = true)]
        static extern HandleRef FindWindow(string lpClassName, string lpWindowName);

        

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

        IntPtr hwnd;
        // Every time the user starts a new match, we want to re initialize the values to default.
        // We will do this later.
        // Let's use a multidimensional array so we can store the distance, AND the pointer to the enemy.
        private int[] enemyDistances = new int[32]; // 32 is the max number of players for the game.
        private int[] enemyAddresses = new int[32];

        float[] viewMatrix = new float[16];

        int iAmountOfPlayers = 0;

        int[] iEntityList = new int[32];
        int iLocalPlayerCrosshairTarget = 0x0;
        public static int iWidthOfGameWindow;
        public int iHeightOfGameWindow;

        RECT rect;

        private byte[] bOriginalBytesUnlimitedAmmo = new byte[3];
        private byte[] bOriginalBytesGodMode = new byte[3];

        public bool bTrainerRunning = false;
        // Let's add a thread to handle everything that's happening. Don't want to run things on the main thread in general.
        private Thread gameThread;
        // Plus, it WILL freeze the GUI if we don't :p
        // This will holdour window handle
        private int _hWnd;

        // Holds where the Form was clicked
        Point lastClick;

        // Title of the window so we can get the window handle
        private const string gameTitle = "AssaultCube";
        // Process name from task manager (without the extension) so we can get the process
        private const string processName = "ac_client";
        // This will be the name of the module we need when getting the module address.
        private string moduleName = "ac_client.exe";
        // Creating new instance of our memory class (Process Memory Class Read Write)
        private PMCRW pmcrw;
        // Create a new instance of our local player object that will constantly update the values via the thread function,
        // and retreive the values for the GUI.
        LocalPlayer localPlayer = new LocalPlayer();
        // This is the base address of the game (also known as the image address).
        // We will assign the address to this variable when attaching to the process below.
        public static int moduleBaseAddress;
        // We need a player base address also
        private int localPlayerBaseAddress;

        private bool bEnableTriggerBot = false;

        public frmMain()
        {
            InitializeComponent();
            pmcrw = new PMCRW();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text.Equals("Start"))
            {
                if (fStart())
                {
                    btnStart.Text = "Stop";
                    btnStart.BackColor = Color.Green;
                    bTrainerRunning = true;
                    gameThread = new Thread(new ThreadStart(this.fGameUpdateThread));
                    gameThread.IsBackground = true;
                    gameThread.Start();
                    tmrUpdateValues.Enabled = true;
                }
            } else if (btnStart.Text.Equals("Stop"))
            {
                btnStart.Text = "Start";
                btnStart.BackColor = Color.Maroon;
                if (gameThread.IsAlive)
                {
                    gameThread.Abort();
                }
            } else
            {
                AddToLog("Something went wrong with starting or stopping the program (unknown error)");
            }
        }

        private bool fStart()
        {
            bool bStarted = false;

            if ((_hWnd = WAPI.FindWindowByCaption(_hWnd, gameTitle)) == -1)
                bStarted = false;
          //  HandleRef hWnd = FindWindow("AssaultCube", null);
            
            AddToLog("Looking for AC process.");
            Process[] process = Process.GetProcessesByName(processName);
            AddToLog("FOUND AC process.");
            AddToLog("Attaching to AC process.");
            if (process.Length > 0)
            {
                pmcrw.ReadProcess = process[0];
                pmcrw.OpenProcess();
                AddToLog("Succesfully attached AC process.");
                
                for (int i=0; i < process[0].Modules.Count; i++)
                {
                    if (process[0].Modules[i].ModuleName == moduleName)
                    {
                        moduleBaseAddress = (int)process[0].Modules[i].BaseAddress;
                        hwnd = process[0].MainWindowHandle;
                    }
                }
                GetWindowRect(hwnd, out rect);
                iAmountOfPlayers = pmcrw.ReadInt(0x50F500);
                iWidthOfGameWindow = rect.Right - rect.Left;
                iHeightOfGameWindow = rect.Bottom - rect.Top;
                localPlayerBaseAddress = pmcrw.ReadInt(moduleBaseAddress + OS.m_os_LocalPlayer);
                fUpdateEntityList();
                bStarted = true; 
            }
            else
            {
                AddToLog("Couldn't connect to AC process! Is it running?");
                bStarted = false;
            }
            return bStarted;
        }

        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            // Record the currend coordinates, so they can be used to calculate to the new position.
            lastClick = new Point(e.X, e.Y);
        }

        private void frmMain_MouseMove(object sender, MouseEventArgs e)
        {
            // Move the Form the same difference the mouse cursor moved;
            // Only when mouse is clicked
            if (e.Button == MouseButtons.Left) 
            {
                // Move the Form the same difference the mouse cursor moved;
                this.Left += e.X - lastClick.X;
                this.Top += e.Y - lastClick.Y;
            }
        }

        public void AddToLog(String sText)
        {
            try
            {
                // I created this function to make it easier to log things.
                // This also scrolls automatically to the bottom of the text box when adding new text. User experience FTW?
                txtLog.AppendText("\n" + sText);
                txtLog.ScrollToCaret();
            }catch(Exception ex)
            {

            }
        }

        private void fGameUpdateThread()
        {
            try
            {
                while (WAPI.GetAsyncKeyState(WAPI.VirtualKeyShort.END) == 0)
                {
                    while (bTrainerRunning)
                    {
                        iAmountOfPlayers = pmcrw.ReadInt(0x50F500);
                        fGetAndStoreViewMatrix();
                        fUpdateEntityList();

                        localPlayer.iLPHealth = (int)pmcrw.ReadInt(localPlayerBaseAddress + OS.m_os_LocalPlayerHealth);
                        localPlayer.iLPCurrentAmmo = pmcrw.ReadInt(localPlayerBaseAddress + OS.m_os_LocalPlayerExtraAmmo);
                        localPlayer.iLPCurrentTeam = pmcrw.ReadInt(localPlayerBaseAddress + OS.m_os_LocalPlayerTeam_ID);
                        int iCurrentWeaponIDAddress = pmcrw.ReadMultiLevelPointer(localPlayerBaseAddress + OS.m_os_LocalPlayerCurrentWeapon, 4, OS.m_os_LocalPlayerCurrentWeaponID);
                        localPlayer.iLPCurrentWeaponID = pmcrw.ReadInt(iCurrentWeaponIDAddress);
                        int iCurrentWeaponTypeAddress = pmcrw.ReadMultiLevelPointer(localPlayerBaseAddress + OS.m_os_LocalPlayerCurrentWeapon, 8, OS.m_os_LocalPlayerCurrentWeaponType);
                        localPlayer.iLPCurrentWeaponType = pmcrw.readString(iCurrentWeaponTypeAddress, 8);
                        
                        // This function is to get the 2d Coords for world to screen for the ESP
                        fGet2dCoords();

                        // The function above populates the arrays. So we can call the function here to get the closest enemy.
                        localPlayer.iAddressOfClosestEnemy = fGetClosestEnemy(enemyDistances, iEntityList);
                        localPlayer.iClosestEnemyName = pmcrw.readString(localPlayer.iAddressOfCrosshairTarget + OS.m_os_LocalPlayerName, 16);
                        localPlayer.iClosestEnemyHealth = pmcrw.ReadInt(localPlayer.iAddressOfCrosshairTarget + OS.m_os_EnemyPlayerHealth);
                        localPlayer.iClosestEnemyTeam = pmcrw.ReadInt(localPlayer.iAddressOfClosestEnemy + OS.m_os_LocalPlayerTeam_ID);

                        
                        localPlayer.iCrosshairTargetName = pmcrw.readString(moduleBaseAddress + OS.m_os_CrosshairTargetName, 16);

                        localPlayer.iAddressOfCrosshairTarget = fGetCrosshairTargetAddress(localPlayer.iCrosshairTargetName);
                        localPlayer.iCrosshairTargetHealth = pmcrw.ReadInt(localPlayer.iAddressOfCrosshairTarget + OS.m_os_EnemyPlayerHealth);
                        localPlayer.iCrosshairTargetTeam = pmcrw.ReadInt(localPlayer.iAddressOfCrosshairTarget + OS.m_os_LocalPlayerTeam_ID);
/*
                        if (bEnableTriggerBot)
                        {
                            
                            if (localPlayer.iCrosshairTargetTeam != localPlayer.iLPCurrentTeam) {
                            // We will do a compare here to compare crosshairs then fire the guy while matching crosshairs coords;
                                fEnableFireGun();
                                bEnableTriggerBot = false;
                            } else
                            {
                                fDisableFireGun();
                            }
                        }
                        else
                        {
                            fDisableFireGun();
                        }
*/

                        //
                        //Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                //AddToLog("Error inside thread: " + ex.ToString());
            }
        }

        public void fUpdateLocalPlayerInfoOnGUI()
        {
            // This function will be called from a timer on the main form. That way we're not updating it with the thread, essentially mating the GUI
            // with the thread with processing. That's what we are avoiding, by having a thread.

            // Update players health onthe GUI from our global player object
            if (localPlayer.iLPHealth > 0 && localPlayer.iLPHealth < 101)
            {
                pbLocalPlayerHealth.Value = localPlayer.iLPHealth;
                lblLocalPlayerHealth.Text = localPlayer.iLPHealth.ToString();
            } else
            {
                pbLocalPlayerHealth.Value = 0;
                lblLocalPlayerHealth.Text = "0";
            }

            if (localPlayer.iLPCurrentAmmo > 0)
            {
                lblLocalPlayerAmmo.Text = localPlayer.iLPCurrentAmmo.ToString();
            }
            else
            {
                lblLocalPlayerAmmo.Text = "0";
            }

            if (localPlayer.iLPCurrentTeam == 0)
            {
                lblTeam.Text = "Red Team";
            } else if (localPlayer.iLPCurrentTeam == 1)
            {
                lblTeam.Text = "Blue Team";
            } else
            {
                lblTeam.Text = "N/A";
            }

            if (localPlayer.iLPCurrentWeaponID.ToString() != null)
            {
                lblLocalPlayerWeaponID.Text = localPlayer.iLPCurrentWeaponID.ToString();
            }

            if (localPlayer.iLPCurrentWeaponType.ToString() != null)
            {
                lblLocalPlayerWeaponType.Text = localPlayer.iLPCurrentWeaponType.ToString();
            }

            if (localPlayer.iAddressOfClosestEnemy != 0x0)
            {
                lblClosestEnemyName.Text = pmcrw.readString(localPlayer.iAddressOfClosestEnemy + OS.m_os_LocalPlayerName, 12); // I believe enemy player name is at the same offset..
                int iClosestEnemyPlayerHealth = pmcrw.ReadInt(localPlayer.iAddressOfClosestEnemy + OS.m_os_EnemyPlayerHealth);
                if (iClosestEnemyPlayerHealth >= 0 && iClosestEnemyPlayerHealth < 101) {
                    lblClosestEnemyHealth.Text = iClosestEnemyPlayerHealth.ToString();
                    pbClosestEnemyHealth.Value = iClosestEnemyPlayerHealth;
                    if (localPlayer.iClosestEnemyTeam == 0)
                    {
                        lblClosestEnemyTeam.Text = "Red Team";
                    } else
                    {
                        lblClosestEnemyTeam.Text = "Blue Team";
                    }
                } else
                {
                    lblClosestEnemyHealth.Text = "[DEAD]";
                    pbClosestEnemyHealth.Value = 0;
                }
            }

            if (localPlayer.iAddressOfCrosshairTarget != 0x0)
            {
                lblCrosshairEnemyName.Text = localPlayer.iCrosshairTargetName;
                if (localPlayer.iCrosshairTargetHealth >= 0 && localPlayer.iCrosshairTargetHealth < 101)
                {
                    lblCrosshairEnemyHealth.Text = localPlayer.iCrosshairTargetHealth.ToString();
                    pbCrosshairEnemyHealth.Value = localPlayer.iCrosshairTargetHealth;
                }
                if (localPlayer.iCrosshairTargetTeam == 0)
                {
                    lblCrosshairEnemyTeam.Text = "Red Team";
                }
                else
                {
                    lblCrosshairEnemyTeam.Text = "Blue Team";
                }
            }

            if (localPlayer.iAddressOfClosestEnemy != 0x0)
            {
                lblCrosshairEnemyName.Text = localPlayer.iCrosshairTargetName;
                if (localPlayer.iCrosshairTargetHealth >= 0 && localPlayer.iCrosshairTargetHealth < 101)
                {
                    lblCrosshairEnemyHealth.Text = localPlayer.iCrosshairTargetHealth.ToString();
                    pbCrosshairEnemyHealth.Value = localPlayer.iCrosshairTargetHealth;
                }
            }
        }

        private void tmrUpdateValues_Tick(object sender, EventArgs e)
        {
            fUpdateLocalPlayerInfoOnGUI();
        }

        private void fEnableUnlimitedAmmo()
        {
            int iAddressOfAmmoDecreaseFunction = pmcrw.ReadMultiLevelPointer(moduleBaseAddress + OS.m_os_LocalPlayerAmmoDecreaseFunctionInGame, 8, OS.m_os_OffsetsForAmmoFunction);
            bOriginalBytesUnlimitedAmmo[0] = 0x14;
            bOriginalBytesUnlimitedAmmo[1] = 0xFF;
            bOriginalBytesUnlimitedAmmo[2] = 0x0E;
            byte[] nopAmmo = {0x14, 0x90, 0x90 };
            pmcrw.WriteBytes(iAddressOfAmmoDecreaseFunction, nopAmmo);
        }

        private void fDisableUnlimitedAmmo()
        {
            int iAddressOfAmmoDecreaseFunction = pmcrw.ReadMultiLevelPointer(moduleBaseAddress + OS.m_os_LocalPlayerAmmoDecreaseFunctionInGame, 8, OS.m_os_OffsetsForAmmoFunction);
            if (bOriginalBytesUnlimitedAmmo.Length == 3)
            {
                pmcrw.WriteBytes(iAddressOfAmmoDecreaseFunction, bOriginalBytesUnlimitedAmmo);
            } else
            {
                bOriginalBytesUnlimitedAmmo[0] = 0x14;
                bOriginalBytesUnlimitedAmmo[1] = 0xFF;
                bOriginalBytesUnlimitedAmmo[2] = 0x0E;
                pmcrw.WriteBytes(iAddressOfAmmoDecreaseFunction, bOriginalBytesUnlimitedAmmo);
                AddToLog("Original bytes gone for Unlimited Ammo. Trying to override, but feature may nat be disabled. Restart game to disable Unlimited Ammo if it's not working.");
            }
        }

        private void chkUnlimitedAmmo_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkUnlimitedAmmo.Checked)
            {
                fEnableUnlimitedAmmo();
            } else if (!chkUnlimitedAmmo.Checked)
            {
                fDisableUnlimitedAmmo();
            }
        }

        private void chkGodMode_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkGodMode.Checked)
            {
                fEnableGodMode();
            }
            else if (!chkGodMode.Checked)
            {
                fDisableGodMode();
            }
        }

        private void fEnableGodMode()
        {
            int iAddressOfGodModeFunction = moduleBaseAddress + OS.m_os_GodMode;
            //bOriginalBytesGodMode = pmcrw.readBytes(iAddressOfGodModeFunction, 3);
            byte[] nopGodMode = { 0x90, 0x90, 0x90 };
            pmcrw.WriteBytes(iAddressOfGodModeFunction, nopGodMode);
        }

        private void fDisableGodMode()
        {
            int iAddressOfGodModeFunction = pmcrw.ReadInt(moduleBaseAddress + OS.m_os_GodMode);
            //if (bOriginalBytesGodMode.Length == 3) {
               // if (bOriginalBytesGodMode[0] == 0x90)
               // {
                    // The original bytes didn't get stored for some reason, so let's write the bytes we know should be there.
                    // Not sure if these are the same for any PC, so don't leave this here unless you verify
                    byte[] bStaticOriginalBytes = { 0x29, 0x7B, 0x04 };
                    pmcrw.WriteBytes(moduleBaseAddress + OS.m_os_GodMode, bStaticOriginalBytes);
               // } else
              //  {
               //     pmcrw.WriteBytes(iAddressOfGodModeFunction, bOriginalBytesGodMode);
               // }
            //}
           // else
            //{ //0x029 0x7B 0x4
                AddToLog("Original bytes gone for God Mode. Can't disable feature. Restart game to disable God Mode");
            //}
        }

        private void fEnableFireGun()
        {
            int iAddressOfFireCurrentFunFunction = pmcrw.ReadMultiLevelPointer(moduleBaseAddress + OS.m_os_FireCurrentGun, 4, OS.m_os_OffsetsForFireCurrentGun);

                pmcrw.WriteByte(iAddressOfFireCurrentFunFunction, 0x1);
            Thread.Sleep(2000);
            fDisableFireGun();
        }

        private void fDisableFireGun()
        {
            int iAddressOfFireCurrentFunFunction = pmcrw.ReadMultiLevelPointer(moduleBaseAddress + OS.m_os_FireCurrentGun, 4, OS.m_os_OffsetsForFireCurrentGun);

            pmcrw.WriteByte(iAddressOfFireCurrentFunFunction, 0x0);
        }

        public void fGetAndStoreViewMatrix()
        {
            byte[] buffer =  new byte[16];
            byte[] temporaryBytes =new byte[16];
            int j = 0;
            for (int i = 0; i < 16; i++)
            {
                viewMatrix[i] = pmcrw.ReadFloat(OS.m_os_viewMatrix + (i * 0x04));
            }       
        }

        private void fUpdateEntityList()
        {
            for (int i=0; i < 32; i++)
            {
                int[] iEntityOffset = {i * 0x04};
                int iEntityListAddress = pmcrw.ReadInt(moduleBaseAddress + OS.m_os_EntityList);
                iEntityList[i] = pmcrw.ReadInt(iEntityListAddress + (i * 0x04));

                VecInt2 tmpLocalPlayer = new VecInt2();
                tmpLocalPlayer.x = pmcrw.ReadInt(localPlayerBaseAddress + OS.m_os_LocalPlayerBodyXCoord);
                tmpLocalPlayer.y = pmcrw.ReadInt(localPlayerBaseAddress + OS.m_os_LocalPlayerBodyYCoord);

                VecInt2 tmpEnemyPlayer = new VecInt2();
                tmpEnemyPlayer.x = pmcrw.ReadInt(iEntityList[i] + OS.m_os_EnemyPlayerXCoord);
                tmpEnemyPlayer.y = pmcrw.ReadInt(iEntityList[i] + OS.m_os_EnemyPlayerYCoord);

                /* We are calculating the distance to the current enemy player. We will store this distance in an array
                 along with the enemy index. We can validate if needed by storing unique parameters and checking later.
                 But for now, this is good.
                */
                int iDistanceToEnemy = ACFunctions.fGetDistance(tmpLocalPlayer, tmpEnemyPlayer);

                // We will store the distance, and the pointer to the enemy. So later on when we figure out which distance is the closest,
                // we can grab the pointer to that enemy and do what we want. As an example, set the mouse cursor to aim at them, etc..
                enemyDistances.SetValue(iDistanceToEnemy, i);
            }

            //fGet2dCoords();
        }

        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("User32.dll")]
        public static extern void ReleaseDC(IntPtr hwnd, IntPtr dc);

        private void fGet2dCoords()
        {
            //int entityList = pmcrw.ReadInt(moduleBaseAddress + OS.m_os_EntityList);
            
            //our entity list loop
            for (int i = 1; i < iAmountOfPlayers; i++)
            {


                //Create the entity
               // int entity = pmcrw.ReadInt(iEntityList[i] + 0x4 * i);



                //The entitys Pos
                float enemyX = pmcrw.ReadFloat(iEntityList[i] + 0x34);
                float enemyY = pmcrw.ReadFloat(iEntityList[i] + 0x38);
                float enemyZ = pmcrw.ReadFloat(iEntityList[i] + 0x3C);

                Vec3 enemyPos = new Vec3();
                enemyPos.x = enemyX;
                enemyPos.y = enemyY;
                enemyPos.z = enemyZ;

                /*
                 * I guess I will do the processing here to get the current distance from the local player to the enemy, as we are already
                 * looking at each enemies parameters here.
                 * */

                //Enemys Head Pos
                float enemyXHead = pmcrw.ReadFloat(iEntityList[i] + 0x4);
                float enemyYHead = pmcrw.ReadFloat(iEntityList[i] + 0x8);
                float enemyZHead = pmcrw.ReadFloat(iEntityList[i] + 0xC);

                Vec3 enemyHeadPos = new Vec3();
                enemyHeadPos.x = enemyXHead;
                enemyHeadPos.y = enemyYHead;
                enemyHeadPos.z = enemyZHead;


                //Sets each entitys health
                int health = pmcrw.ReadInt(iEntityList[i] + OS.m_os_EnemyPlayerHealth);

                if (ACFunctions.WorldToScreenFPos(enemyPos, viewMatrix, iWidthOfGameWindow, iHeightOfGameWindow)) {

                    if (ACFunctions.WorldToScreenHPos(enemyHeadPos, viewMatrix, iWidthOfGameWindow, iHeightOfGameWindow))
                    {

                        VecInt2 tmpLocalPlayer = new VecInt2();
                        tmpLocalPlayer.x = pmcrw.ReadInt(localPlayerBaseAddress + OS.m_os_LocalPlayerBodyXCoord);
                        tmpLocalPlayer.y = pmcrw.ReadInt(localPlayerBaseAddress + OS.m_os_LocalPlayerBodyYCoord);

                        VecInt2 tmpEnemyPlayer = new VecInt2();
                        tmpEnemyPlayer.x = pmcrw.ReadInt(iEntityList[i] + OS.m_os_EnemyPlayerXCoord);
                        tmpEnemyPlayer.y = pmcrw.ReadInt(iEntityList[i] + OS.m_os_EnemyPlayerYCoord);

                        /* We are calculating the distance to the current enemy player. We will store this distance in an array
                         along with the enemy index. We can validate if needed by storing unique parameters and checking later.
                         But for now, this is good.
                        */
                        int iDistanceToEnemy = ACFunctions.fGetDistance(tmpLocalPlayer, tmpEnemyPlayer);
                        iDistanceToEnemy = iDistanceToEnemy / 20000;
                        //Creates the head height
                        float head = ACFunctions.vHead.y - ACFunctions.vFoot.y;
                        //Creates Width
                        float width = head / 2;
                        //Creates Center
                        float center = width / -2;
                        //Creates Extra area above head
                        float extra = head / -6;

                        Graphics g = Graphics.FromHwnd(hwnd);

                        SolidBrush b = new SolidBrush(Color.Aqua);

                        int iTeam = pmcrw.ReadInt(iEntityList[i] + OS.m_os_LocalPlayerTeam_ID);
                        // It is sorted, so the first address should be the closest enemy.
                        if (!(iTeam == localPlayer.iLPCurrentTeam))
                        {
                            b = new SolidBrush(Color.Red);
                        } else
                        {
                            b = new SolidBrush(Color.Green);
                        }
                        Pen myPen = new Pen(b);

                        System.Drawing.Rectangle myrect = new Rectangle();
                        myrect.X = (int)ACFunctions.vFoot.x - (int)center;
                        myrect.Y = (int)ACFunctions.vHead.y - 20;
                        // myrect.Width = (int)ACFunctions.vFoot.x + (int)center + (int)width;
                        myrect.Width = iDistanceToEnemy / 5 ;//- (int)center + (int)width;
                        // myrect.Height = (int)ACFunctions.vFoot.y + ((int)head - (int)extra);
                        myrect.Height =  iDistanceToEnemy * 2 / 5;
 
                        g.DrawRectangle(myPen, myrect);

                       // g.FillRectangle(Brushes.Red, new Rectangle((SystemInformation.WorkingArea.Width / 2) - 4, (SystemInformation.WorkingArea.Height / 2) - 20, 8, 40));
                       // g.FillRectangle(Brushes.Red, new Rectangle((SystemInformation.WorkingArea.Width / 2) - 20, (SystemInformation.WorkingArea.Height / 2) - 4, 40, 8));
                       // g.Dispose();
                       // ReleaseDC(IntPtr.Zero, hwnd);
                    }
                }
            }
        }

        private void chkTriggerBot_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkTriggerBot.Checked)
            {
                bEnableTriggerBot = true;
            }
            else if (!chkTriggerBot.Checked)
            {
                bEnableTriggerBot = false;
            }
        }

        private void btn_Set_Weapon_Click(object sender, EventArgs e)
        {/*
            int iCurrentWeaponIDAddress = pmcrw.ReadMultiLevelPointer(localPlayerBaseAddress + OS.m_os_LocalPlayerCurrentWeapon, 4, OS.m_os_LocalPlayerCurrentWeaponID);

            if (cmbWeapons.Text.Contains("MTP-57"))
                pmcrw.WriteInt(iCurrentWeaponIDAddress, 0x6);

            if (cmbWeapons.Text.Contains("DR-88"))
                pmcrw.WriteInt(iCurrentWeaponIDAddress, 0x0);

            if (cmbWeapons.Text.Contains("MK-77"))
                pmcrw.WriteInt(iCurrentWeaponIDAddress, 0x1);
            */
        }

        // This function should sort, and figure out the distances from the multidimensional array, then return then pointer
        // to the enemy that's the closest.
        private int fGetClosestEnemy(int[] tmpenemyIndexes, int[] tmpenemyAddresses)
        {
            int iAddressOfClosestEnemy = 0x0;
            // This sort function should of sorted the first array, and then sorted the second one so it still matched the first..
            Array.Sort(tmpenemyIndexes, tmpenemyAddresses);
            for (int i = 0; i < tmpenemyAddresses.Length; i++)
            {
                int iTeam = pmcrw.ReadInt(tmpenemyAddresses[i] + OS.m_os_LocalPlayerTeam_ID);
                // It is sorted, so the first address should be the closest enemy.
                if (!(iTeam == localPlayer.iLPCurrentTeam))
                {
                    iAddressOfClosestEnemy = tmpenemyAddresses[i];
                    return iAddressOfClosestEnemy;
                }
            }
            return iAddressOfClosestEnemy;
        }

        private int fGetCrosshairTargetAddress(string sCrosshairTargetName)
        {
            int iTargetAddress = 0x0;

            for (int i=0; i < iEntityList.Length; i++)
            {
                string sNameFromEntityList = pmcrw.readString(iEntityList[i] + OS.m_os_LocalPlayerName, 16);
                if (sNameFromEntityList.Equals(sCrosshairTargetName)){
                    iTargetAddress = iEntityList[i];
                }
            }

            return iTargetAddress;
        }
    }
}
