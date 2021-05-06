
namespace DK_T_AC
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.lblLocalPlayer = new System.Windows.Forms.Label();
            this.lblClosestEnemy = new System.Windows.Forms.Label();
            this.lblLocalPlayerHealthDesc = new System.Windows.Forms.Label();
            this.pbLocalPlayerHealth = new System.Windows.Forms.ProgressBar();
            this.tmrUpdateValues = new System.Windows.Forms.Timer(this.components);
            this.lblLocalPlayerHealth = new System.Windows.Forms.Label();
            this.lblLocalPlayerAmmo = new System.Windows.Forms.Label();
            this.lblLocalPlayerAmmoDesc = new System.Windows.Forms.Label();
            this.chkUnlimitedAmmo = new System.Windows.Forms.CheckBox();
            this.chkGodMode = new System.Windows.Forms.CheckBox();
            this.chkTriggerBot = new System.Windows.Forms.CheckBox();
            this.lblTeam = new System.Windows.Forms.Label();
            this.lblTeamDesc = new System.Windows.Forms.Label();
            this.lblLocalPlayerWeaponID = new System.Windows.Forms.Label();
            this.lblLocalPlayerWeaponIDDesc = new System.Windows.Forms.Label();
            this.lblLocalPlayerWeaponType = new System.Windows.Forms.Label();
            this.lblLocalPlayerWeaponTypeDesc = new System.Windows.Forms.Label();
            this.cmbWeapons = new System.Windows.Forms.ComboBox();
            this.btn_Set_Weapon = new System.Windows.Forms.Button();
            this.lblClosestEnemyName = new System.Windows.Forms.Label();
            this.lblClosestEnemyNameDesc = new System.Windows.Forms.Label();
            this.lblClosestEnemyHealth = new System.Windows.Forms.Label();
            this.pbClosestEnemyHealth = new System.Windows.Forms.ProgressBar();
            this.lblClosestEnemyHealthDesc = new System.Windows.Forms.Label();
            this.lblCrosshairEnemyHealth = new System.Windows.Forms.Label();
            this.pbCrosshairEnemyHealth = new System.Windows.Forms.ProgressBar();
            this.lblCrosshairEnemyHealthDesc = new System.Windows.Forms.Label();
            this.lblCrosshairEnemyName = new System.Windows.Forms.Label();
            this.lblCrosshairEnemyNameDesc = new System.Windows.Forms.Label();
            this.lblCrosshairEnemy = new System.Windows.Forms.Label();
            this.lblClosestEnemyTeam = new System.Windows.Forms.Label();
            this.lblClosestEnemyTeamDesc = new System.Windows.Forms.Label();
            this.lblCrosshairEnemyTeam = new System.Windows.Forms.Label();
            this.lblCrosshairEnemyTeamDesc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Maroon;
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(12, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(108, 41);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.Black;
            this.txtLog.ForeColor = System.Drawing.Color.White;
            this.txtLog.Location = new System.Drawing.Point(12, 296);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(735, 108);
            this.txtLog.TabIndex = 1;
            this.txtLog.Text = "";
            // 
            // lblLocalPlayer
            // 
            this.lblLocalPlayer.AutoSize = true;
            this.lblLocalPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalPlayer.ForeColor = System.Drawing.Color.White;
            this.lblLocalPlayer.Location = new System.Drawing.Point(168, 61);
            this.lblLocalPlayer.Name = "lblLocalPlayer";
            this.lblLocalPlayer.Size = new System.Drawing.Size(67, 24);
            this.lblLocalPlayer.TabIndex = 2;
            this.lblLocalPlayer.Text = "Player:";
            // 
            // lblClosestEnemy
            // 
            this.lblClosestEnemy.AutoSize = true;
            this.lblClosestEnemy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClosestEnemy.ForeColor = System.Drawing.Color.White;
            this.lblClosestEnemy.Location = new System.Drawing.Point(790, 61);
            this.lblClosestEnemy.Name = "lblClosestEnemy";
            this.lblClosestEnemy.Size = new System.Drawing.Size(141, 24);
            this.lblClosestEnemy.TabIndex = 3;
            this.lblClosestEnemy.Text = "Closest Enemy:";
            // 
            // lblLocalPlayerHealthDesc
            // 
            this.lblLocalPlayerHealthDesc.AutoSize = true;
            this.lblLocalPlayerHealthDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalPlayerHealthDesc.ForeColor = System.Drawing.Color.White;
            this.lblLocalPlayerHealthDesc.Location = new System.Drawing.Point(168, 110);
            this.lblLocalPlayerHealthDesc.Name = "lblLocalPlayerHealthDesc";
            this.lblLocalPlayerHealthDesc.Size = new System.Drawing.Size(50, 16);
            this.lblLocalPlayerHealthDesc.TabIndex = 4;
            this.lblLocalPlayerHealthDesc.Text = "Health:";
            // 
            // pbLocalPlayerHealth
            // 
            this.pbLocalPlayerHealth.BackColor = System.Drawing.Color.Maroon;
            this.pbLocalPlayerHealth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pbLocalPlayerHealth.Location = new System.Drawing.Point(224, 111);
            this.pbLocalPlayerHealth.Name = "pbLocalPlayerHealth";
            this.pbLocalPlayerHealth.Size = new System.Drawing.Size(152, 15);
            this.pbLocalPlayerHealth.TabIndex = 5;
            // 
            // tmrUpdateValues
            // 
            this.tmrUpdateValues.Tick += new System.EventHandler(this.tmrUpdateValues_Tick);
            // 
            // lblLocalPlayerHealth
            // 
            this.lblLocalPlayerHealth.AutoSize = true;
            this.lblLocalPlayerHealth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalPlayerHealth.ForeColor = System.Drawing.Color.White;
            this.lblLocalPlayerHealth.Location = new System.Drawing.Point(382, 110);
            this.lblLocalPlayerHealth.Name = "lblLocalPlayerHealth";
            this.lblLocalPlayerHealth.Size = new System.Drawing.Size(16, 16);
            this.lblLocalPlayerHealth.TabIndex = 6;
            this.lblLocalPlayerHealth.Text = "0";
            // 
            // lblLocalPlayerAmmo
            // 
            this.lblLocalPlayerAmmo.AutoSize = true;
            this.lblLocalPlayerAmmo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalPlayerAmmo.ForeColor = System.Drawing.Color.White;
            this.lblLocalPlayerAmmo.Location = new System.Drawing.Point(224, 131);
            this.lblLocalPlayerAmmo.Name = "lblLocalPlayerAmmo";
            this.lblLocalPlayerAmmo.Size = new System.Drawing.Size(16, 16);
            this.lblLocalPlayerAmmo.TabIndex = 9;
            this.lblLocalPlayerAmmo.Text = "0";
            // 
            // lblLocalPlayerAmmoDesc
            // 
            this.lblLocalPlayerAmmoDesc.AutoSize = true;
            this.lblLocalPlayerAmmoDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalPlayerAmmoDesc.ForeColor = System.Drawing.Color.White;
            this.lblLocalPlayerAmmoDesc.Location = new System.Drawing.Point(168, 131);
            this.lblLocalPlayerAmmoDesc.Name = "lblLocalPlayerAmmoDesc";
            this.lblLocalPlayerAmmoDesc.Size = new System.Drawing.Size(50, 16);
            this.lblLocalPlayerAmmoDesc.TabIndex = 7;
            this.lblLocalPlayerAmmoDesc.Text = "Ammo:";
            // 
            // chkUnlimitedAmmo
            // 
            this.chkUnlimitedAmmo.AutoSize = true;
            this.chkUnlimitedAmmo.ForeColor = System.Drawing.Color.White;
            this.chkUnlimitedAmmo.Location = new System.Drawing.Point(171, 236);
            this.chkUnlimitedAmmo.Name = "chkUnlimitedAmmo";
            this.chkUnlimitedAmmo.Size = new System.Drawing.Size(101, 17);
            this.chkUnlimitedAmmo.TabIndex = 10;
            this.chkUnlimitedAmmo.Text = "Unlimited Ammo";
            this.chkUnlimitedAmmo.UseVisualStyleBackColor = true;
            this.chkUnlimitedAmmo.CheckStateChanged += new System.EventHandler(this.chkUnlimitedAmmo_CheckStateChanged);
            // 
            // chkGodMode
            // 
            this.chkGodMode.AutoSize = true;
            this.chkGodMode.ForeColor = System.Drawing.Color.White;
            this.chkGodMode.Location = new System.Drawing.Point(278, 236);
            this.chkGodMode.Name = "chkGodMode";
            this.chkGodMode.Size = new System.Drawing.Size(76, 17);
            this.chkGodMode.TabIndex = 11;
            this.chkGodMode.Text = "God Mode";
            this.chkGodMode.UseVisualStyleBackColor = true;
            this.chkGodMode.CheckStateChanged += new System.EventHandler(this.chkGodMode_CheckStateChanged);
            // 
            // chkTriggerBot
            // 
            this.chkTriggerBot.AutoSize = true;
            this.chkTriggerBot.ForeColor = System.Drawing.Color.White;
            this.chkTriggerBot.Location = new System.Drawing.Point(172, 269);
            this.chkTriggerBot.Name = "chkTriggerBot";
            this.chkTriggerBot.Size = new System.Drawing.Size(78, 17);
            this.chkTriggerBot.TabIndex = 12;
            this.chkTriggerBot.Text = "Trigger Bot";
            this.chkTriggerBot.UseVisualStyleBackColor = true;
            this.chkTriggerBot.CheckStateChanged += new System.EventHandler(this.chkTriggerBot_CheckStateChanged);
            // 
            // lblTeam
            // 
            this.lblTeam.AutoSize = true;
            this.lblTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam.ForeColor = System.Drawing.Color.White;
            this.lblTeam.Location = new System.Drawing.Point(225, 156);
            this.lblTeam.Name = "lblTeam";
            this.lblTeam.Size = new System.Drawing.Size(34, 16);
            this.lblTeam.TabIndex = 14;
            this.lblTeam.Text = "N/A";
            // 
            // lblTeamDesc
            // 
            this.lblTeamDesc.AutoSize = true;
            this.lblTeamDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamDesc.ForeColor = System.Drawing.Color.White;
            this.lblTeamDesc.Location = new System.Drawing.Point(169, 156);
            this.lblTeamDesc.Name = "lblTeamDesc";
            this.lblTeamDesc.Size = new System.Drawing.Size(47, 16);
            this.lblTeamDesc.TabIndex = 13;
            this.lblTeamDesc.Text = "Team:";
            // 
            // lblLocalPlayerWeaponID
            // 
            this.lblLocalPlayerWeaponID.AutoSize = true;
            this.lblLocalPlayerWeaponID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalPlayerWeaponID.ForeColor = System.Drawing.Color.White;
            this.lblLocalPlayerWeaponID.Location = new System.Drawing.Point(224, 182);
            this.lblLocalPlayerWeaponID.Name = "lblLocalPlayerWeaponID";
            this.lblLocalPlayerWeaponID.Size = new System.Drawing.Size(34, 16);
            this.lblLocalPlayerWeaponID.TabIndex = 16;
            this.lblLocalPlayerWeaponID.Text = "N/A";
            // 
            // lblLocalPlayerWeaponIDDesc
            // 
            this.lblLocalPlayerWeaponIDDesc.AutoSize = true;
            this.lblLocalPlayerWeaponIDDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalPlayerWeaponIDDesc.ForeColor = System.Drawing.Color.White;
            this.lblLocalPlayerWeaponIDDesc.Location = new System.Drawing.Point(139, 182);
            this.lblLocalPlayerWeaponIDDesc.Name = "lblLocalPlayerWeaponIDDesc";
            this.lblLocalPlayerWeaponIDDesc.Size = new System.Drawing.Size(79, 16);
            this.lblLocalPlayerWeaponIDDesc.TabIndex = 15;
            this.lblLocalPlayerWeaponIDDesc.Text = "Weapon ID:";
            // 
            // lblLocalPlayerWeaponType
            // 
            this.lblLocalPlayerWeaponType.AutoSize = true;
            this.lblLocalPlayerWeaponType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalPlayerWeaponType.ForeColor = System.Drawing.Color.White;
            this.lblLocalPlayerWeaponType.Location = new System.Drawing.Point(224, 208);
            this.lblLocalPlayerWeaponType.Name = "lblLocalPlayerWeaponType";
            this.lblLocalPlayerWeaponType.Size = new System.Drawing.Size(34, 16);
            this.lblLocalPlayerWeaponType.TabIndex = 18;
            this.lblLocalPlayerWeaponType.Text = "N/A";
            // 
            // lblLocalPlayerWeaponTypeDesc
            // 
            this.lblLocalPlayerWeaponTypeDesc.AutoSize = true;
            this.lblLocalPlayerWeaponTypeDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalPlayerWeaponTypeDesc.ForeColor = System.Drawing.Color.White;
            this.lblLocalPlayerWeaponTypeDesc.Location = new System.Drawing.Point(115, 208);
            this.lblLocalPlayerWeaponTypeDesc.Name = "lblLocalPlayerWeaponTypeDesc";
            this.lblLocalPlayerWeaponTypeDesc.Size = new System.Drawing.Size(98, 16);
            this.lblLocalPlayerWeaponTypeDesc.TabIndex = 17;
            this.lblLocalPlayerWeaponTypeDesc.Text = "Weapon Type:";
            // 
            // cmbWeapons
            // 
            this.cmbWeapons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbWeapons.ForeColor = System.Drawing.Color.White;
            this.cmbWeapons.FormattingEnabled = true;
            this.cmbWeapons.Items.AddRange(new object[] {
            "MTP-57 (Assault rifle)",
            "MK-77 (Pistol)",
            "DR-88 (Knife)"});
            this.cmbWeapons.Location = new System.Drawing.Point(443, 110);
            this.cmbWeapons.Name = "cmbWeapons";
            this.cmbWeapons.Size = new System.Drawing.Size(168, 21);
            this.cmbWeapons.TabIndex = 19;
            this.cmbWeapons.Text = "MTP-57 (Assault rifle)";
            // 
            // btn_Set_Weapon
            // 
            this.btn_Set_Weapon.BackColor = System.Drawing.Color.Maroon;
            this.btn_Set_Weapon.ForeColor = System.Drawing.Color.White;
            this.btn_Set_Weapon.Location = new System.Drawing.Point(443, 137);
            this.btn_Set_Weapon.Name = "btn_Set_Weapon";
            this.btn_Set_Weapon.Size = new System.Drawing.Size(168, 26);
            this.btn_Set_Weapon.TabIndex = 20;
            this.btn_Set_Weapon.Text = "Set Weapon";
            this.btn_Set_Weapon.UseVisualStyleBackColor = false;
            this.btn_Set_Weapon.Click += new System.EventHandler(this.btn_Set_Weapon_Click);
            // 
            // lblClosestEnemyName
            // 
            this.lblClosestEnemyName.AutoSize = true;
            this.lblClosestEnemyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClosestEnemyName.ForeColor = System.Drawing.Color.White;
            this.lblClosestEnemyName.Location = new System.Drawing.Point(831, 110);
            this.lblClosestEnemyName.Name = "lblClosestEnemyName";
            this.lblClosestEnemyName.Size = new System.Drawing.Size(34, 16);
            this.lblClosestEnemyName.TabIndex = 22;
            this.lblClosestEnemyName.Text = "N/A";
            // 
            // lblClosestEnemyNameDesc
            // 
            this.lblClosestEnemyNameDesc.AutoSize = true;
            this.lblClosestEnemyNameDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClosestEnemyNameDesc.ForeColor = System.Drawing.Color.White;
            this.lblClosestEnemyNameDesc.Location = new System.Drawing.Point(775, 110);
            this.lblClosestEnemyNameDesc.Name = "lblClosestEnemyNameDesc";
            this.lblClosestEnemyNameDesc.Size = new System.Drawing.Size(48, 16);
            this.lblClosestEnemyNameDesc.TabIndex = 21;
            this.lblClosestEnemyNameDesc.Text = "Name:";
            // 
            // lblClosestEnemyHealth
            // 
            this.lblClosestEnemyHealth.AutoSize = true;
            this.lblClosestEnemyHealth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClosestEnemyHealth.ForeColor = System.Drawing.Color.White;
            this.lblClosestEnemyHealth.Location = new System.Drawing.Point(986, 137);
            this.lblClosestEnemyHealth.Name = "lblClosestEnemyHealth";
            this.lblClosestEnemyHealth.Size = new System.Drawing.Size(16, 16);
            this.lblClosestEnemyHealth.TabIndex = 25;
            this.lblClosestEnemyHealth.Text = "0";
            // 
            // pbClosestEnemyHealth
            // 
            this.pbClosestEnemyHealth.BackColor = System.Drawing.Color.Maroon;
            this.pbClosestEnemyHealth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pbClosestEnemyHealth.Location = new System.Drawing.Point(828, 132);
            this.pbClosestEnemyHealth.Name = "pbClosestEnemyHealth";
            this.pbClosestEnemyHealth.Size = new System.Drawing.Size(152, 15);
            this.pbClosestEnemyHealth.TabIndex = 24;
            // 
            // lblClosestEnemyHealthDesc
            // 
            this.lblClosestEnemyHealthDesc.AutoSize = true;
            this.lblClosestEnemyHealthDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClosestEnemyHealthDesc.ForeColor = System.Drawing.Color.White;
            this.lblClosestEnemyHealthDesc.Location = new System.Drawing.Point(772, 131);
            this.lblClosestEnemyHealthDesc.Name = "lblClosestEnemyHealthDesc";
            this.lblClosestEnemyHealthDesc.Size = new System.Drawing.Size(50, 16);
            this.lblClosestEnemyHealthDesc.TabIndex = 23;
            this.lblClosestEnemyHealthDesc.Text = "Health:";
            // 
            // lblCrosshairEnemyHealth
            // 
            this.lblCrosshairEnemyHealth.AutoSize = true;
            this.lblCrosshairEnemyHealth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrosshairEnemyHealth.ForeColor = System.Drawing.Color.White;
            this.lblCrosshairEnemyHealth.Location = new System.Drawing.Point(1259, 137);
            this.lblCrosshairEnemyHealth.Name = "lblCrosshairEnemyHealth";
            this.lblCrosshairEnemyHealth.Size = new System.Drawing.Size(16, 16);
            this.lblCrosshairEnemyHealth.TabIndex = 31;
            this.lblCrosshairEnemyHealth.Text = "0";
            // 
            // pbCrosshairEnemyHealth
            // 
            this.pbCrosshairEnemyHealth.BackColor = System.Drawing.Color.Maroon;
            this.pbCrosshairEnemyHealth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pbCrosshairEnemyHealth.Location = new System.Drawing.Point(1101, 132);
            this.pbCrosshairEnemyHealth.Name = "pbCrosshairEnemyHealth";
            this.pbCrosshairEnemyHealth.Size = new System.Drawing.Size(152, 15);
            this.pbCrosshairEnemyHealth.TabIndex = 30;
            // 
            // lblCrosshairEnemyHealthDesc
            // 
            this.lblCrosshairEnemyHealthDesc.AutoSize = true;
            this.lblCrosshairEnemyHealthDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrosshairEnemyHealthDesc.ForeColor = System.Drawing.Color.White;
            this.lblCrosshairEnemyHealthDesc.Location = new System.Drawing.Point(1045, 131);
            this.lblCrosshairEnemyHealthDesc.Name = "lblCrosshairEnemyHealthDesc";
            this.lblCrosshairEnemyHealthDesc.Size = new System.Drawing.Size(50, 16);
            this.lblCrosshairEnemyHealthDesc.TabIndex = 29;
            this.lblCrosshairEnemyHealthDesc.Text = "Health:";
            // 
            // lblCrosshairEnemyName
            // 
            this.lblCrosshairEnemyName.AutoSize = true;
            this.lblCrosshairEnemyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrosshairEnemyName.ForeColor = System.Drawing.Color.White;
            this.lblCrosshairEnemyName.Location = new System.Drawing.Point(1103, 110);
            this.lblCrosshairEnemyName.Name = "lblCrosshairEnemyName";
            this.lblCrosshairEnemyName.Size = new System.Drawing.Size(34, 16);
            this.lblCrosshairEnemyName.TabIndex = 28;
            this.lblCrosshairEnemyName.Text = "N/A";
            // 
            // lblCrosshairEnemyNameDesc
            // 
            this.lblCrosshairEnemyNameDesc.AutoSize = true;
            this.lblCrosshairEnemyNameDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrosshairEnemyNameDesc.ForeColor = System.Drawing.Color.White;
            this.lblCrosshairEnemyNameDesc.Location = new System.Drawing.Point(1047, 110);
            this.lblCrosshairEnemyNameDesc.Name = "lblCrosshairEnemyNameDesc";
            this.lblCrosshairEnemyNameDesc.Size = new System.Drawing.Size(48, 16);
            this.lblCrosshairEnemyNameDesc.TabIndex = 27;
            this.lblCrosshairEnemyNameDesc.Text = "Name:";
            // 
            // lblCrosshairEnemy
            // 
            this.lblCrosshairEnemy.AutoSize = true;
            this.lblCrosshairEnemy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrosshairEnemy.ForeColor = System.Drawing.Color.White;
            this.lblCrosshairEnemy.Location = new System.Drawing.Point(1063, 61);
            this.lblCrosshairEnemy.Name = "lblCrosshairEnemy";
            this.lblCrosshairEnemy.Size = new System.Drawing.Size(185, 24);
            this.lblCrosshairEnemy.TabIndex = 26;
            this.lblCrosshairEnemy.Text = "Enemy in crosshairs:";
            // 
            // lblClosestEnemyTeam
            // 
            this.lblClosestEnemyTeam.AutoSize = true;
            this.lblClosestEnemyTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClosestEnemyTeam.ForeColor = System.Drawing.Color.White;
            this.lblClosestEnemyTeam.Location = new System.Drawing.Point(831, 156);
            this.lblClosestEnemyTeam.Name = "lblClosestEnemyTeam";
            this.lblClosestEnemyTeam.Size = new System.Drawing.Size(34, 16);
            this.lblClosestEnemyTeam.TabIndex = 33;
            this.lblClosestEnemyTeam.Text = "N/A";
            // 
            // lblClosestEnemyTeamDesc
            // 
            this.lblClosestEnemyTeamDesc.AutoSize = true;
            this.lblClosestEnemyTeamDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClosestEnemyTeamDesc.ForeColor = System.Drawing.Color.White;
            this.lblClosestEnemyTeamDesc.Location = new System.Drawing.Point(775, 156);
            this.lblClosestEnemyTeamDesc.Name = "lblClosestEnemyTeamDesc";
            this.lblClosestEnemyTeamDesc.Size = new System.Drawing.Size(47, 16);
            this.lblClosestEnemyTeamDesc.TabIndex = 32;
            this.lblClosestEnemyTeamDesc.Text = "Team:";
            // 
            // lblCrosshairEnemyTeam
            // 
            this.lblCrosshairEnemyTeam.AutoSize = true;
            this.lblCrosshairEnemyTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrosshairEnemyTeam.ForeColor = System.Drawing.Color.White;
            this.lblCrosshairEnemyTeam.Location = new System.Drawing.Point(1104, 156);
            this.lblCrosshairEnemyTeam.Name = "lblCrosshairEnemyTeam";
            this.lblCrosshairEnemyTeam.Size = new System.Drawing.Size(34, 16);
            this.lblCrosshairEnemyTeam.TabIndex = 35;
            this.lblCrosshairEnemyTeam.Text = "N/A";
            // 
            // lblCrosshairEnemyTeamDesc
            // 
            this.lblCrosshairEnemyTeamDesc.AutoSize = true;
            this.lblCrosshairEnemyTeamDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrosshairEnemyTeamDesc.ForeColor = System.Drawing.Color.White;
            this.lblCrosshairEnemyTeamDesc.Location = new System.Drawing.Point(1048, 156);
            this.lblCrosshairEnemyTeamDesc.Name = "lblCrosshairEnemyTeamDesc";
            this.lblCrosshairEnemyTeamDesc.Size = new System.Drawing.Size(47, 16);
            this.lblCrosshairEnemyTeamDesc.TabIndex = 34;
            this.lblCrosshairEnemyTeamDesc.Text = "Team:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1284, 425);
            this.Controls.Add(this.lblCrosshairEnemyTeam);
            this.Controls.Add(this.lblCrosshairEnemyTeamDesc);
            this.Controls.Add(this.lblClosestEnemyTeam);
            this.Controls.Add(this.lblClosestEnemyTeamDesc);
            this.Controls.Add(this.lblCrosshairEnemyHealth);
            this.Controls.Add(this.pbCrosshairEnemyHealth);
            this.Controls.Add(this.lblCrosshairEnemyHealthDesc);
            this.Controls.Add(this.lblCrosshairEnemyName);
            this.Controls.Add(this.lblCrosshairEnemyNameDesc);
            this.Controls.Add(this.lblCrosshairEnemy);
            this.Controls.Add(this.lblClosestEnemyHealth);
            this.Controls.Add(this.pbClosestEnemyHealth);
            this.Controls.Add(this.lblClosestEnemyHealthDesc);
            this.Controls.Add(this.lblClosestEnemyName);
            this.Controls.Add(this.lblClosestEnemyNameDesc);
            this.Controls.Add(this.btn_Set_Weapon);
            this.Controls.Add(this.cmbWeapons);
            this.Controls.Add(this.lblLocalPlayerWeaponType);
            this.Controls.Add(this.lblLocalPlayerWeaponTypeDesc);
            this.Controls.Add(this.lblLocalPlayerWeaponID);
            this.Controls.Add(this.lblLocalPlayerWeaponIDDesc);
            this.Controls.Add(this.lblTeam);
            this.Controls.Add(this.lblTeamDesc);
            this.Controls.Add(this.chkTriggerBot);
            this.Controls.Add(this.chkGodMode);
            this.Controls.Add(this.chkUnlimitedAmmo);
            this.Controls.Add(this.lblLocalPlayerAmmo);
            this.Controls.Add(this.lblLocalPlayerAmmoDesc);
            this.Controls.Add(this.lblLocalPlayerHealth);
            this.Controls.Add(this.pbLocalPlayerHealth);
            this.Controls.Add(this.lblLocalPlayerHealthDesc);
            this.Controls.Add(this.lblClosestEnemy);
            this.Controls.Add(this.lblLocalPlayer);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.Opacity = 0.9D;
            this.Text = "DKrypt Trainer Assault Cube";
            this.TransparencyKey = System.Drawing.Color.LightPink;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Label lblLocalPlayer;
        private System.Windows.Forms.Label lblClosestEnemy;
        private System.Windows.Forms.Label lblLocalPlayerHealthDesc;
        private System.Windows.Forms.ProgressBar pbLocalPlayerHealth;
        private System.Windows.Forms.Timer tmrUpdateValues;
        private System.Windows.Forms.Label lblLocalPlayerHealth;
        private System.Windows.Forms.Label lblLocalPlayerAmmo;
        private System.Windows.Forms.Label lblLocalPlayerAmmoDesc;
        private System.Windows.Forms.CheckBox chkUnlimitedAmmo;
        private System.Windows.Forms.CheckBox chkGodMode;
        private System.Windows.Forms.CheckBox chkTriggerBot;
        private System.Windows.Forms.Label lblTeam;
        private System.Windows.Forms.Label lblTeamDesc;
        private System.Windows.Forms.Label lblLocalPlayerWeaponID;
        private System.Windows.Forms.Label lblLocalPlayerWeaponIDDesc;
        private System.Windows.Forms.Label lblLocalPlayerWeaponType;
        private System.Windows.Forms.Label lblLocalPlayerWeaponTypeDesc;
        private System.Windows.Forms.ComboBox cmbWeapons;
        private System.Windows.Forms.Button btn_Set_Weapon;
        private System.Windows.Forms.Label lblClosestEnemyName;
        private System.Windows.Forms.Label lblClosestEnemyNameDesc;
        private System.Windows.Forms.Label lblClosestEnemyHealth;
        private System.Windows.Forms.ProgressBar pbClosestEnemyHealth;
        private System.Windows.Forms.Label lblClosestEnemyHealthDesc;
        private System.Windows.Forms.Label lblCrosshairEnemyHealth;
        private System.Windows.Forms.ProgressBar pbCrosshairEnemyHealth;
        private System.Windows.Forms.Label lblCrosshairEnemyHealthDesc;
        private System.Windows.Forms.Label lblCrosshairEnemyName;
        private System.Windows.Forms.Label lblCrosshairEnemyNameDesc;
        private System.Windows.Forms.Label lblCrosshairEnemy;
        private System.Windows.Forms.Label lblClosestEnemyTeam;
        private System.Windows.Forms.Label lblClosestEnemyTeamDesc;
        private System.Windows.Forms.Label lblCrosshairEnemyTeam;
        private System.Windows.Forms.Label lblCrosshairEnemyTeamDesc;
    }
}

