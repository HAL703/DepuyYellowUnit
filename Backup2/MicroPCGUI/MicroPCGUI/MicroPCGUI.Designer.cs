
namespace MicroPCGUI
{
    partial class MicroPCUI
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
            this.impactFrameArrayDrop = new MetroFramework.Controls.MetroComboBox();
            this.startCycle = new MetroFramework.Controls.MetroButton();
            this.stopCycle = new MetroFramework.Controls.MetroButton();
            this.eStop = new MetroFramework.Controls.MetroButton();
            this.resetCount = new MetroFramework.Controls.MetroButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.hammerFeedback = new MetroFramework.Controls.MetroLabel();
            this.hammerSetPointLbl = new MetroFramework.Controls.MetroLabel();
            this.cycleSetPoint = new MetroFramework.Controls.MetroTextBox();
            this.strokeVerify = new MetroFramework.Controls.MetroToggle();
            this.partDetect = new MetroFramework.Controls.MetroToggle();
            this.hammerRetract = new MetroFramework.Controls.MetroTextBox();
            this.hammerRetractLbl = new MetroFramework.Controls.MetroLabel();
            this.handModeRadio = new MetroFramework.Controls.MetroRadioButton();
            this.automaticMode = new MetroFramework.Controls.MetroRadioButton();
            this.keyenceMode = new MetroFramework.Controls.MetroRadioButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.hammerSP = new MetroFramework.Controls.MetroTextBox();
            this.dataDisplayLbl = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.strokeVerifyChk = new MetroFramework.Controls.MetroCheckBox();
            this.partDetectChk = new MetroFramework.Controls.MetroCheckBox();
            this.guiTesterBtnRead = new MetroFramework.Controls.MetroButton();
            this.guiTesterBtnWrite = new MetroFramework.Controls.MetroButton();
            this.cycleCounter = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // impactFrameArrayDrop
            // 
            this.impactFrameArrayDrop.BackColor = System.Drawing.Color.SlateGray;
            this.impactFrameArrayDrop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.impactFrameArrayDrop.FontWeight = MetroFramework.MetroComboBoxWeight.Bold;
            this.impactFrameArrayDrop.ForeColor = System.Drawing.Color.OrangeRed;
            this.impactFrameArrayDrop.FormattingEnabled = true;
            this.impactFrameArrayDrop.ItemHeight = 24;
            this.impactFrameArrayDrop.Location = new System.Drawing.Point(624, 48);
            this.impactFrameArrayDrop.Name = "impactFrameArrayDrop";
            this.impactFrameArrayDrop.PromptText = "IMPACT FRAMES";
            this.impactFrameArrayDrop.Size = new System.Drawing.Size(168, 30);
            this.impactFrameArrayDrop.Style = MetroFramework.MetroColorStyle.Orange;
            this.impactFrameArrayDrop.TabIndex = 0;
            this.impactFrameArrayDrop.Tag = "";
            this.impactFrameArrayDrop.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.impactFrameArrayDrop.UseCustomBackColor = true;
            this.impactFrameArrayDrop.UseCustomForeColor = true;
            this.impactFrameArrayDrop.UseSelectable = true;
            this.impactFrameArrayDrop.UseStyleColors = true;
            this.impactFrameArrayDrop.SelectedIndexChanged += new System.EventHandler(this.impactFrameArrayDrop_SelectedIndexChanged);
            // 
            // startCycle
            // 
            this.startCycle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.startCycle.ForeColor = System.Drawing.SystemColors.Control;
            this.startCycle.Location = new System.Drawing.Point(489, 54);
            this.startCycle.Name = "startCycle";
            this.startCycle.Size = new System.Drawing.Size(98, 34);
            this.startCycle.TabIndex = 2;
            this.startCycle.Text = "START CYCLE";
            this.startCycle.UseCustomBackColor = true;
            this.startCycle.UseCustomForeColor = true;
            this.startCycle.UseSelectable = true;
            this.startCycle.Click += new System.EventHandler(this.startCycle_Click);
            // 
            // stopCycle
            // 
            this.stopCycle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.stopCycle.ForeColor = System.Drawing.SystemColors.Control;
            this.stopCycle.Location = new System.Drawing.Point(489, 94);
            this.stopCycle.Name = "stopCycle";
            this.stopCycle.Size = new System.Drawing.Size(98, 34);
            this.stopCycle.TabIndex = 3;
            this.stopCycle.Text = "STOP CYCLE";
            this.stopCycle.UseCustomBackColor = true;
            this.stopCycle.UseCustomForeColor = true;
            this.stopCycle.UseSelectable = true;
            this.stopCycle.Click += new System.EventHandler(this.stopCycle_Click);
            // 
            // eStop
            // 
            this.eStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.eStop.ForeColor = System.Drawing.SystemColors.Control;
            this.eStop.Location = new System.Drawing.Point(705, 406);
            this.eStop.Name = "eStop";
            this.eStop.Size = new System.Drawing.Size(98, 35);
            this.eStop.TabIndex = 4;
            this.eStop.Text = "E-STOP";
            this.eStop.UseCustomBackColor = true;
            this.eStop.UseCustomForeColor = true;
            this.eStop.UseSelectable = true;
            this.eStop.Click += new System.EventHandler(this.eStop_Click);
            // 
            // resetCount
            // 
            this.resetCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.resetCount.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.resetCount.Location = new System.Drawing.Point(489, 134);
            this.resetCount.Name = "resetCount";
            this.resetCount.Size = new System.Drawing.Size(98, 34);
            this.resetCount.TabIndex = 5;
            this.resetCount.Text = "RESET COUNT ";
            this.resetCount.UseCustomBackColor = true;
            this.resetCount.UseCustomForeColor = true;
            this.resetCount.UseSelectable = true;
            this.resetCount.Click += new System.EventHandler(this.resetCount_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // hammerFeedback
            // 
            this.hammerFeedback.AutoSize = true;
            this.hammerFeedback.Location = new System.Drawing.Point(79, 157);
            this.hammerFeedback.Name = "hammerFeedback";
            this.hammerFeedback.Size = new System.Drawing.Size(17, 20);
            this.hammerFeedback.TabIndex = 13;
            this.hammerFeedback.Text = "0";
            // 
            // hammerSetPointLbl
            // 
            this.hammerSetPointLbl.AutoSize = true;
            this.hammerSetPointLbl.Location = new System.Drawing.Point(23, 78);
            this.hammerSetPointLbl.Name = "hammerSetPointLbl";
            this.hammerSetPointLbl.Size = new System.Drawing.Size(87, 20);
            this.hammerSetPointLbl.TabIndex = 14;
            this.hammerSetPointLbl.Text = "HAMMER SP";
            // 
            // cycleSetPoint
            // 
            // 
            // 
            // 
            this.cycleSetPoint.CustomButton.Image = null;
            this.cycleSetPoint.CustomButton.Location = new System.Drawing.Point(7, 1);
            this.cycleSetPoint.CustomButton.Name = "";
            this.cycleSetPoint.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.cycleSetPoint.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.cycleSetPoint.CustomButton.TabIndex = 1;
            this.cycleSetPoint.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.cycleSetPoint.CustomButton.UseSelectable = true;
            this.cycleSetPoint.CustomButton.Visible = false;
            this.cycleSetPoint.Lines = new string[] {
        "0"};
            this.cycleSetPoint.Location = new System.Drawing.Point(79, 217);
            this.cycleSetPoint.MaxLength = 32767;
            this.cycleSetPoint.Name = "cycleSetPoint";
            this.cycleSetPoint.PasswordChar = '\0';
            this.cycleSetPoint.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.cycleSetPoint.SelectedText = "";
            this.cycleSetPoint.SelectionLength = 0;
            this.cycleSetPoint.SelectionStart = 0;
            this.cycleSetPoint.ShortcutsEnabled = true;
            this.cycleSetPoint.Size = new System.Drawing.Size(29, 23);
            this.cycleSetPoint.TabIndex = 15;
            this.cycleSetPoint.Text = "0";
            this.cycleSetPoint.UseSelectable = true;
            this.cycleSetPoint.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cycleSetPoint.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // strokeVerify
            // 
            this.strokeVerify.AutoSize = true;
            this.strokeVerify.Location = new System.Drawing.Point(229, 267);
            this.strokeVerify.Name = "strokeVerify";
            this.strokeVerify.Size = new System.Drawing.Size(80, 21);
            this.strokeVerify.TabIndex = 17;
            this.strokeVerify.Text = "Off";
            this.strokeVerify.UseSelectable = true;
            // 
            // partDetect
            // 
            this.partDetect.AutoSize = true;
            this.partDetect.Location = new System.Drawing.Point(229, 304);
            this.partDetect.Name = "partDetect";
            this.partDetect.Size = new System.Drawing.Size(80, 21);
            this.partDetect.TabIndex = 18;
            this.partDetect.Text = "Off";
            this.partDetect.UseSelectable = true;
            // 
            // hammerRetract
            // 
            // 
            // 
            // 
            this.hammerRetract.CustomButton.Image = null;
            this.hammerRetract.CustomButton.Location = new System.Drawing.Point(76, 1);
            this.hammerRetract.CustomButton.Name = "";
            this.hammerRetract.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.hammerRetract.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.hammerRetract.CustomButton.TabIndex = 1;
            this.hammerRetract.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.hammerRetract.CustomButton.UseSelectable = true;
            this.hammerRetract.CustomButton.Visible = false;
            this.hammerRetract.Lines = new string[] {
        "HammerRetract"};
            this.hammerRetract.Location = new System.Drawing.Point(229, 105);
            this.hammerRetract.MaxLength = 32767;
            this.hammerRetract.Name = "hammerRetract";
            this.hammerRetract.PasswordChar = '\0';
            this.hammerRetract.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.hammerRetract.SelectedText = "";
            this.hammerRetract.SelectionLength = 0;
            this.hammerRetract.SelectionStart = 0;
            this.hammerRetract.ShortcutsEnabled = true;
            this.hammerRetract.Size = new System.Drawing.Size(98, 23);
            this.hammerRetract.TabIndex = 19;
            this.hammerRetract.Text = "HammerRetract";
            this.hammerRetract.UseSelectable = true;
            this.hammerRetract.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.hammerRetract.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // hammerRetractLbl
            // 
            this.hammerRetractLbl.AutoSize = true;
            this.hammerRetractLbl.Location = new System.Drawing.Point(207, 78);
            this.hammerRetractLbl.Name = "hammerRetractLbl";
            this.hammerRetractLbl.Size = new System.Drawing.Size(165, 20);
            this.hammerRetractLbl.TabIndex = 23;
            this.hammerRetractLbl.Text = "HAMMER RETRACT TIME";
            // 
            // handModeRadio
            // 
            this.handModeRadio.AutoSize = true;
            this.handModeRadio.Location = new System.Drawing.Point(637, 233);
            this.handModeRadio.Name = "handModeRadio";
            this.handModeRadio.Size = new System.Drawing.Size(102, 17);
            this.handModeRadio.TabIndex = 24;
            this.handModeRadio.Text = "HAND MODE";
            this.handModeRadio.UseSelectable = true;
            this.handModeRadio.CheckedChanged += new System.EventHandler(this.handModeRadio_CheckedChanged);
            // 
            // automaticMode
            // 
            this.automaticMode.AutoSize = true;
            this.automaticMode.Location = new System.Drawing.Point(637, 256);
            this.automaticMode.Name = "automaticMode";
            this.automaticMode.Size = new System.Drawing.Size(136, 17);
            this.automaticMode.TabIndex = 25;
            this.automaticMode.Text = "AUTOMATIC MODE";
            this.automaticMode.UseSelectable = true;
            this.automaticMode.CheckedChanged += new System.EventHandler(this.automaticMode_CheckedChanged);
            // 
            // keyenceMode
            // 
            this.keyenceMode.AutoSize = true;
            this.keyenceMode.Location = new System.Drawing.Point(637, 279);
            this.keyenceMode.Name = "keyenceMode";
            this.keyenceMode.Size = new System.Drawing.Size(120, 17);
            this.keyenceMode.TabIndex = 26;
            this.keyenceMode.Text = "KEYENCE MODE";
            this.keyenceMode.UseSelectable = true;
            this.keyenceMode.CheckedChanged += new System.EventHandler(this.keyenceMode_CheckedChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 134);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(139, 20);
            this.metroLabel1.TabIndex = 27;
            this.metroLabel1.Text = "HAMMER FEEDBACK";
            // 
            // hammerSP
            // 
            // 
            // 
            // 
            this.hammerSP.CustomButton.Image = null;
            this.hammerSP.CustomButton.Location = new System.Drawing.Point(80, 1);
            this.hammerSP.CustomButton.Name = "";
            this.hammerSP.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.hammerSP.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.hammerSP.CustomButton.TabIndex = 1;
            this.hammerSP.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.hammerSP.CustomButton.UseSelectable = true;
            this.hammerSP.CustomButton.Visible = false;
            this.hammerSP.Lines = new string[] {
        "0.00"};
            this.hammerSP.Location = new System.Drawing.Point(23, 101);
            this.hammerSP.MaxLength = 32767;
            this.hammerSP.Name = "hammerSP";
            this.hammerSP.PasswordChar = '\0';
            this.hammerSP.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.hammerSP.SelectedText = "";
            this.hammerSP.SelectionLength = 0;
            this.hammerSP.SelectionStart = 0;
            this.hammerSP.ShortcutsEnabled = true;
            this.hammerSP.Size = new System.Drawing.Size(102, 23);
            this.hammerSP.TabIndex = 28;
            this.hammerSP.Text = "0.00";
            this.hammerSP.UseSelectable = true;
            this.hammerSP.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.hammerSP.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // dataDisplayLbl
            // 
            this.dataDisplayLbl.AutoSize = true;
            this.dataDisplayLbl.Location = new System.Drawing.Point(229, 437);
            this.dataDisplayLbl.Name = "dataDisplayLbl";
            this.dataDisplayLbl.Size = new System.Drawing.Size(79, 20);
            this.dataDisplayLbl.TabIndex = 29;
            this.dataDisplayLbl.Text = "dataDisplay";
            this.dataDisplayLbl.Click += new System.EventHandler(this.dataDisplayLbl_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 184);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(118, 20);
            this.metroLabel2.TabIndex = 30;
            this.metroLabel2.Text = "CYCLE SETPOINT";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(207, 148);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(153, 20);
            this.metroLabel3.TabIndex = 31;
            this.metroLabel3.Text = "CYCLE ACTIVE COUNT";
            // 
            // strokeVerifyChk
            // 
            this.strokeVerifyChk.AutoSize = true;
            this.strokeVerifyChk.Location = new System.Drawing.Point(473, 217);
            this.strokeVerifyChk.Name = "strokeVerifyChk";
            this.strokeVerifyChk.Size = new System.Drawing.Size(114, 17);
            this.strokeVerifyChk.TabIndex = 33;
            this.strokeVerifyChk.Text = "STROKE VERIFY";
            this.strokeVerifyChk.UseSelectable = true;
            // 
            // partDetectChk
            // 
            this.partDetectChk.AutoSize = true;
            this.partDetectChk.Location = new System.Drawing.Point(473, 240);
            this.partDetectChk.Name = "partDetectChk";
            this.partDetectChk.Size = new System.Drawing.Size(101, 17);
            this.partDetectChk.TabIndex = 34;
            this.partDetectChk.Text = "PART DETECT";
            this.partDetectChk.UseSelectable = true;
            // 
            // guiTesterBtnRead
            // 
            this.guiTesterBtnRead.Location = new System.Drawing.Point(274, 199);
            this.guiTesterBtnRead.Name = "guiTesterBtnRead";
            this.guiTesterBtnRead.Size = new System.Drawing.Size(75, 23);
            this.guiTesterBtnRead.TabIndex = 36;
            this.guiTesterBtnRead.Text = "read";
            this.guiTesterBtnRead.UseSelectable = true;
            this.guiTesterBtnRead.Click += new System.EventHandler(this.guiTesterBtnRead_Click);
            // 
            // guiTesterBtnWrite
            // 
            this.guiTesterBtnWrite.Location = new System.Drawing.Point(376, 199);
            this.guiTesterBtnWrite.Name = "guiTesterBtnWrite";
            this.guiTesterBtnWrite.Size = new System.Drawing.Size(75, 23);
            this.guiTesterBtnWrite.TabIndex = 37;
            this.guiTesterBtnWrite.Text = "write";
            this.guiTesterBtnWrite.UseSelectable = true;
            this.guiTesterBtnWrite.Click += new System.EventHandler(this.guiTesterBtnWrite_Click);
            // 
            // cycleCounter
            // 
            // 
            // 
            // 
            this.cycleCounter.CustomButton.Image = null;
            this.cycleCounter.CustomButton.Location = new System.Drawing.Point(76, 1);
            this.cycleCounter.CustomButton.Name = "";
            this.cycleCounter.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.cycleCounter.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.cycleCounter.CustomButton.TabIndex = 1;
            this.cycleCounter.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.cycleCounter.CustomButton.UseSelectable = true;
            this.cycleCounter.CustomButton.Visible = false;
            this.cycleCounter.Lines = new string[] {
        "CYCLE ACTIVE COUNT"};
            this.cycleCounter.Location = new System.Drawing.Point(229, 171);
            this.cycleCounter.MaxLength = 32767;
            this.cycleCounter.Name = "cycleCounter";
            this.cycleCounter.PasswordChar = '\0';
            this.cycleCounter.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.cycleCounter.SelectedText = "";
            this.cycleCounter.SelectionLength = 0;
            this.cycleCounter.SelectionStart = 0;
            this.cycleCounter.ShortcutsEnabled = true;
            this.cycleCounter.Size = new System.Drawing.Size(98, 23);
            this.cycleCounter.TabIndex = 39;
            this.cycleCounter.Text = "CYCLE ACTIVE COUNT";
            this.cycleCounter.UseSelectable = true;
            this.cycleCounter.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cycleCounter.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // MicroPCUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 464);
            this.Controls.Add(this.cycleCounter);
            this.Controls.Add(this.guiTesterBtnWrite);
            this.Controls.Add(this.partDetectChk);
            this.Controls.Add(this.guiTesterBtnRead);
            this.Controls.Add(this.strokeVerifyChk);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.dataDisplayLbl);
            this.Controls.Add(this.hammerSP);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.keyenceMode);
            this.Controls.Add(this.automaticMode);
            this.Controls.Add(this.handModeRadio);
            this.Controls.Add(this.hammerRetractLbl);
            this.Controls.Add(this.hammerRetract);
            this.Controls.Add(this.partDetect);
            this.Controls.Add(this.strokeVerify);
            this.Controls.Add(this.cycleSetPoint);
            this.Controls.Add(this.hammerSetPointLbl);
            this.Controls.Add(this.hammerFeedback);
            this.Controls.Add(this.resetCount);
            this.Controls.Add(this.eStop);
            this.Controls.Add(this.stopCycle);
            this.Controls.Add(this.startCycle);
            this.Controls.Add(this.impactFrameArrayDrop);
            this.Name = "MicroPCUI";
            this.Text = "MicroPCUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox impactFrameArrayDrop;
        private MetroFramework.Controls.MetroButton startCycle;
        private MetroFramework.Controls.MetroButton stopCycle;
        private MetroFramework.Controls.MetroButton eStop;
        private MetroFramework.Controls.MetroButton resetCount;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private MetroFramework.Controls.MetroLabel hammerFeedback;
        private MetroFramework.Controls.MetroLabel hammerSetPointLbl;
        private MetroFramework.Controls.MetroTextBox cycleSetPoint;
        private MetroFramework.Controls.MetroToggle strokeVerify;
        private MetroFramework.Controls.MetroToggle partDetect;
        private MetroFramework.Controls.MetroTextBox hammerRetract;
        private MetroFramework.Controls.MetroLabel hammerRetractLbl;
        private MetroFramework.Controls.MetroRadioButton handModeRadio;
        private MetroFramework.Controls.MetroRadioButton automaticMode;
        private MetroFramework.Controls.MetroRadioButton keyenceMode;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox hammerSP;
        private MetroFramework.Controls.MetroLabel dataDisplayLbl;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroCheckBox strokeVerifyChk;
        private MetroFramework.Controls.MetroCheckBox partDetectChk;
        private MetroFramework.Controls.MetroButton guiTesterBtnRead;
        private MetroFramework.Controls.MetroButton guiTesterBtnWrite;
        private MetroFramework.Controls.MetroTextBox cycleCounter;
    }
}

