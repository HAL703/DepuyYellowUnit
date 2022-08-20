using MetroFramework;
namespace MicroPCGUI
{
    partial class MicroPCUI
    {
        //public sealed class BorderColor
        //{
        //    public static Color Form(MetroThemeStyle theme)
        //    {
        //        if (theme == MetroThemeStyle.Dark)
        //            return Color.FromArgb(153, 153, 153);

        //        return Color.FromArgb(153, 153, 153);
        //    }
        //}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MicroPCUI));
            this.impactFrameArrayDrop = new MetroFramework.Controls.MetroComboBox();
            this.startCycleBtn = new MetroFramework.Controls.MetroButton();
            this.stopCycleBtn = new MetroFramework.Controls.MetroButton();
            this.eStopBtn = new MetroFramework.Controls.MetroButton();
            this.resetCountBtn = new MetroFramework.Controls.MetroButton();
            this.activeUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.hammerFeedback = new MetroFramework.Controls.MetroLabel();
            this.hammerSetPointLbl = new MetroFramework.Controls.MetroLabel();
            this.cycleSP = new MetroFramework.Controls.MetroTextBox();
            this.hammerRetract = new MetroFramework.Controls.MetroTextBox();
            this.hammerRetractLbl = new MetroFramework.Controls.MetroLabel();
            this.handModeRadio = new MetroFramework.Controls.MetroRadioButton();
            this.automaticModeRadio = new MetroFramework.Controls.MetroRadioButton();
            this.keyenceModeRadio = new MetroFramework.Controls.MetroRadioButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.hammerSP = new MetroFramework.Controls.MetroTextBox();
            this.dataDisplayLbl = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.strokeVerifyChk = new MetroFramework.Controls.MetroCheckBox();
            this.partDetectChk = new MetroFramework.Controls.MetroCheckBox();
            this.cycleCounter = new MetroFramework.Controls.MetroTextBox();
            this.GeneralInformation = new MetroFramework.Controls.MetroLabel();
            this.Logo = new MetroFramework.Controls.MetroPanel();
            this.GeneralWindow = new MetroFramework.Controls.MetroPanel();
            this.PSI_UP_MAN_Btn = new MetroFramework.Controls.MetroButton();
            this.PSI_DN_MAN_Btn = new MetroFramework.Controls.MetroButton();
            this.velocityFeedbackLbl = new MetroFramework.Controls.MetroLabel();
            this.velFeedLbl = new MetroFramework.Controls.MetroLabel();
            this.velocityEntryLbl = new MetroFramework.Controls.MetroLabel();
            this.velocityEntry = new MetroFramework.Controls.MetroTextBox();
            this.AxisScreenBtn = new MetroFramework.Controls.MetroButton();
            this.generalControlsUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.eStopTimer = new System.Windows.Forms.Timer(this.components);
            this.GeneralWindow.SuspendLayout();
            this.SuspendLayout();
            // 
            // impactFrameArrayDrop
            // 
            this.impactFrameArrayDrop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.impactFrameArrayDrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.impactFrameArrayDrop.Cursor = System.Windows.Forms.Cursors.Default;
            this.impactFrameArrayDrop.DropDownHeight = 300;
            this.impactFrameArrayDrop.DropDownWidth = 150;
            this.impactFrameArrayDrop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.impactFrameArrayDrop.FontWeight = MetroFramework.MetroComboBoxWeight.Bold;
            this.impactFrameArrayDrop.ForeColor = System.Drawing.Color.OrangeRed;
            this.impactFrameArrayDrop.FormattingEnabled = true;
            this.impactFrameArrayDrop.IntegralHeight = false;
            this.impactFrameArrayDrop.ItemHeight = 24;
            this.impactFrameArrayDrop.Location = new System.Drawing.Point(852, 178);
            this.impactFrameArrayDrop.Margin = new System.Windows.Forms.Padding(2);
            this.impactFrameArrayDrop.Name = "impactFrameArrayDrop";
            this.impactFrameArrayDrop.PromptText = "IMPACT FRAMES";
            this.impactFrameArrayDrop.Size = new System.Drawing.Size(158, 30);
            this.impactFrameArrayDrop.Style = MetroFramework.MetroColorStyle.Orange;
            this.impactFrameArrayDrop.TabIndex = 0;
            this.impactFrameArrayDrop.Tag = "";
            this.impactFrameArrayDrop.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.impactFrameArrayDrop.UseCustomBackColor = true;
            this.impactFrameArrayDrop.UseCustomForeColor = true;
            this.impactFrameArrayDrop.UseSelectable = true;
            this.impactFrameArrayDrop.UseStyleColors = true;
            this.impactFrameArrayDrop.SelectedIndexChanged += new System.EventHandler(this.ImpactFrameArrayDropIndexChanged);
            // 
            // startCycleBtn
            // 
            this.startCycleBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.startCycleBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.startCycleBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.startCycleBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.startCycleBtn.Location = new System.Drawing.Point(345, 11);
            this.startCycleBtn.Margin = new System.Windows.Forms.Padding(2);
            this.startCycleBtn.Name = "startCycleBtn";
            this.startCycleBtn.Size = new System.Drawing.Size(205, 75);
            this.startCycleBtn.TabIndex = 2;
            this.startCycleBtn.Tag = "but1";
            this.startCycleBtn.Text = "START CYCLE";
            this.startCycleBtn.UseCustomBackColor = true;
            this.startCycleBtn.UseCustomForeColor = true;
            this.startCycleBtn.UseSelectable = true;
            this.startCycleBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartCycleMouseDown);
            this.startCycleBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // stopCycleBtn
            // 
            this.stopCycleBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.stopCycleBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.stopCycleBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.stopCycleBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.stopCycleBtn.Location = new System.Drawing.Point(345, 91);
            this.stopCycleBtn.Margin = new System.Windows.Forms.Padding(2);
            this.stopCycleBtn.Name = "stopCycleBtn";
            this.stopCycleBtn.Size = new System.Drawing.Size(205, 75);
            this.stopCycleBtn.TabIndex = 3;
            this.stopCycleBtn.Tag = "but2";
            this.stopCycleBtn.Text = "STOP CYCLE";
            this.stopCycleBtn.UseCustomBackColor = true;
            this.stopCycleBtn.UseCustomForeColor = true;
            this.stopCycleBtn.UseSelectable = true;
            this.stopCycleBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StopCycleMouseDown);
            this.stopCycleBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // eStopBtn
            // 
            this.eStopBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.eStopBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.eStopBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.eStopBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.eStopBtn.Location = new System.Drawing.Point(345, 251);
            this.eStopBtn.Margin = new System.Windows.Forms.Padding(2);
            this.eStopBtn.Name = "eStopBtn";
            this.eStopBtn.Size = new System.Drawing.Size(205, 75);
            this.eStopBtn.TabIndex = 4;
            this.eStopBtn.Tag = "but4";
            this.eStopBtn.Text = "E-STOP";
            this.eStopBtn.UseCustomBackColor = true;
            this.eStopBtn.UseCustomForeColor = true;
            this.eStopBtn.UseSelectable = true;
            this.eStopBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EStopMouseDown);
            this.eStopBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // resetCountBtn
            // 
            this.resetCountBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.resetCountBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.resetCountBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.resetCountBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.resetCountBtn.Location = new System.Drawing.Point(345, 171);
            this.resetCountBtn.Margin = new System.Windows.Forms.Padding(2);
            this.resetCountBtn.Name = "resetCountBtn";
            this.resetCountBtn.Size = new System.Drawing.Size(205, 75);
            this.resetCountBtn.TabIndex = 5;
            this.resetCountBtn.Tag = "but3";
            this.resetCountBtn.Text = "RESET COUNT";
            this.resetCountBtn.UseCustomBackColor = true;
            this.resetCountBtn.UseCustomForeColor = true;
            this.resetCountBtn.UseSelectable = true;
            this.resetCountBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ResetCountMouseDown);
            this.resetCountBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // activeUpdateTimer
            // 
            this.activeUpdateTimer.Interval = 500;
            this.activeUpdateTimer.Tick += new System.EventHandler(this.UpdateTimerTicked);
            // 
            // hammerFeedback
            // 
            this.hammerFeedback.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hammerFeedback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hammerFeedback.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.hammerFeedback.Location = new System.Drawing.Point(863, 186);
            this.hammerFeedback.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.hammerFeedback.Name = "hammerFeedback";
            this.hammerFeedback.Size = new System.Drawing.Size(95, 28);
            this.hammerFeedback.TabIndex = 13;
            this.hammerFeedback.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hammerFeedback.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // hammerSetPointLbl
            // 
            this.hammerSetPointLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hammerSetPointLbl.AutoSize = true;
            this.hammerSetPointLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.hammerSetPointLbl.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.hammerSetPointLbl.Location = new System.Drawing.Point(813, 70);
            this.hammerSetPointLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.hammerSetPointLbl.Name = "hammerSetPointLbl";
            this.hammerSetPointLbl.Size = new System.Drawing.Size(187, 25);
            this.hammerSetPointLbl.TabIndex = 14;
            this.hammerSetPointLbl.Text = "HAMMER SETPOINT";
            this.hammerSetPointLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // cycleSP
            // 
            this.cycleSP.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.cycleSP.CustomButton.AutoSize = true;
            this.cycleSP.CustomButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cycleSP.CustomButton.Image = null;
            this.cycleSP.CustomButton.Location = new System.Drawing.Point(73, 2);
            this.cycleSP.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.cycleSP.CustomButton.Name = "";
            this.cycleSP.CustomButton.Size = new System.Drawing.Size(6, 6);
            this.cycleSP.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.cycleSP.CustomButton.TabIndex = 1;
            this.cycleSP.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.cycleSP.CustomButton.UseSelectable = true;
            this.cycleSP.CustomButton.Visible = false;
            this.cycleSP.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.cycleSP.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.cycleSP.Lines = new string[0];
            this.cycleSP.Location = new System.Drawing.Point(588, 44);
            this.cycleSP.Margin = new System.Windows.Forms.Padding(2);
            this.cycleSP.MaxLength = 5;
            this.cycleSP.Name = "cycleSP";
            this.cycleSP.PasswordChar = '\0';
            this.cycleSP.PromptText = "#####";
            this.cycleSP.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.cycleSP.SelectedText = "";
            this.cycleSP.SelectionLength = 0;
            this.cycleSP.SelectionStart = 0;
            this.cycleSP.ShortcutsEnabled = true;
            this.cycleSP.Size = new System.Drawing.Size(95, 24);
            this.cycleSP.TabIndex = 15;
            this.cycleSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cycleSP.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cycleSP.UseSelectable = true;
            this.cycleSP.WaterMark = "#####";
            this.cycleSP.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cycleSP.WaterMarkFont = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.cycleSP.Enter += new System.EventHandler(this.TextboxGotFocus);
            this.cycleSP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CycleSPKeyPress);
            this.cycleSP.Leave += new System.EventHandler(this.TextboxLostFocus);
            // 
            // hammerRetract
            // 
            this.hammerRetract.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.hammerRetract.CustomButton.AutoSize = true;
            this.hammerRetract.CustomButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.hammerRetract.CustomButton.Image = null;
            this.hammerRetract.CustomButton.Location = new System.Drawing.Point(73, 2);
            this.hammerRetract.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.hammerRetract.CustomButton.Name = "";
            this.hammerRetract.CustomButton.Size = new System.Drawing.Size(6, 6);
            this.hammerRetract.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.hammerRetract.CustomButton.TabIndex = 1;
            this.hammerRetract.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.hammerRetract.CustomButton.UseSelectable = true;
            this.hammerRetract.CustomButton.Visible = false;
            this.hammerRetract.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.hammerRetract.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.hammerRetract.Lines = new string[0];
            this.hammerRetract.Location = new System.Drawing.Point(863, 44);
            this.hammerRetract.Margin = new System.Windows.Forms.Padding(2);
            this.hammerRetract.MaxLength = 5;
            this.hammerRetract.Name = "hammerRetract";
            this.hammerRetract.PasswordChar = '\0';
            this.hammerRetract.PromptText = "#####";
            this.hammerRetract.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.hammerRetract.SelectedText = "";
            this.hammerRetract.SelectionLength = 0;
            this.hammerRetract.SelectionStart = 0;
            this.hammerRetract.ShortcutsEnabled = true;
            this.hammerRetract.Size = new System.Drawing.Size(95, 24);
            this.hammerRetract.TabIndex = 19;
            this.hammerRetract.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.hammerRetract.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.hammerRetract.UseSelectable = true;
            this.hammerRetract.WaterMark = "#####";
            this.hammerRetract.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.hammerRetract.WaterMarkFont = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.hammerRetract.Enter += new System.EventHandler(this.TextboxGotFocus);
            this.hammerRetract.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HammerRetractKeyPress);
            this.hammerRetract.Leave += new System.EventHandler(this.TextboxLostFocus);
            // 
            // hammerRetractLbl
            // 
            this.hammerRetractLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hammerRetractLbl.AutoSize = true;
            this.hammerRetractLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.hammerRetractLbl.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.hammerRetractLbl.Location = new System.Drawing.Point(813, 11);
            this.hammerRetractLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.hammerRetractLbl.Name = "hammerRetractLbl";
            this.hammerRetractLbl.Size = new System.Drawing.Size(229, 25);
            this.hammerRetractLbl.TabIndex = 23;
            this.hammerRetractLbl.Text = "HAMMER RETRACT TIME";
            this.hammerRetractLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // handModeRadio
            // 
            this.handModeRadio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.handModeRadio.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.handModeRadio.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.handModeRadio.Location = new System.Drawing.Point(575, 200);
            this.handModeRadio.Margin = new System.Windows.Forms.Padding(2);
            this.handModeRadio.Name = "handModeRadio";
            this.handModeRadio.Size = new System.Drawing.Size(198, 44);
            this.handModeRadio.TabIndex = 24;
            this.handModeRadio.Text = "HAND MODE";
            this.handModeRadio.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.handModeRadio.UseSelectable = true;
            this.handModeRadio.CheckedChanged += new System.EventHandler(this.HandModeCheckedChanged);
            // 
            // automaticModeRadio
            // 
            this.automaticModeRadio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.automaticModeRadio.AutoSize = true;
            this.automaticModeRadio.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.automaticModeRadio.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.automaticModeRadio.Location = new System.Drawing.Point(575, 266);
            this.automaticModeRadio.Margin = new System.Windows.Forms.Padding(2);
            this.automaticModeRadio.Name = "automaticModeRadio";
            this.automaticModeRadio.Size = new System.Drawing.Size(194, 25);
            this.automaticModeRadio.TabIndex = 25;
            this.automaticModeRadio.Text = "AUTOMATIC MODE";
            this.automaticModeRadio.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.automaticModeRadio.UseSelectable = true;
            this.automaticModeRadio.CheckedChanged += new System.EventHandler(this.AutomaticModeCheckedChanged);
            // 
            // keyenceModeRadio
            // 
            this.keyenceModeRadio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.keyenceModeRadio.AutoSize = true;
            this.keyenceModeRadio.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.keyenceModeRadio.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.keyenceModeRadio.Location = new System.Drawing.Point(575, 321);
            this.keyenceModeRadio.Margin = new System.Windows.Forms.Padding(2);
            this.keyenceModeRadio.Name = "keyenceModeRadio";
            this.keyenceModeRadio.Size = new System.Drawing.Size(165, 25);
            this.keyenceModeRadio.TabIndex = 26;
            this.keyenceModeRadio.Text = "KEYENCE MODE";
            this.keyenceModeRadio.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.keyenceModeRadio.UseSelectable = true;
            this.keyenceModeRadio.CheckedChanged += new System.EventHandler(this.KeyenceModeCheckedChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(813, 141);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(190, 25);
            this.metroLabel1.TabIndex = 27;
            this.metroLabel1.Text = "HAMMER FEEDBACK";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // hammerSP
            // 
            this.hammerSP.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.hammerSP.CustomButton.AutoSize = true;
            this.hammerSP.CustomButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.hammerSP.CustomButton.FlatAppearance.BorderSize = 0;
            this.hammerSP.CustomButton.Image = null;
            this.hammerSP.CustomButton.Location = new System.Drawing.Point(73, 2);
            this.hammerSP.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.hammerSP.CustomButton.Name = "";
            this.hammerSP.CustomButton.Size = new System.Drawing.Size(6, 6);
            this.hammerSP.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.hammerSP.CustomButton.TabIndex = 1;
            this.hammerSP.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.hammerSP.CustomButton.UseSelectable = true;
            this.hammerSP.CustomButton.Visible = false;
            this.hammerSP.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.hammerSP.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.hammerSP.Lines = new string[0];
            this.hammerSP.Location = new System.Drawing.Point(863, 104);
            this.hammerSP.Margin = new System.Windows.Forms.Padding(2);
            this.hammerSP.MaxLength = 5;
            this.hammerSP.Name = "hammerSP";
            this.hammerSP.PasswordChar = '\0';
            this.hammerSP.PromptText = "###.##";
            this.hammerSP.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.hammerSP.SelectedText = "";
            this.hammerSP.SelectionLength = 0;
            this.hammerSP.SelectionStart = 0;
            this.hammerSP.ShortcutsEnabled = true;
            this.hammerSP.Size = new System.Drawing.Size(95, 24);
            this.hammerSP.TabIndex = 28;
            this.hammerSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.hammerSP.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.hammerSP.UseSelectable = true;
            this.hammerSP.WaterMark = "###.##";
            this.hammerSP.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.hammerSP.WaterMarkFont = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.hammerSP.Enter += new System.EventHandler(this.TextboxGotFocus);
            this.hammerSP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HammerSPKeyPress);
            this.hammerSP.Leave += new System.EventHandler(this.TextboxLostFocus);
            // 
            // dataDisplayLbl
            // 
            this.dataDisplayLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataDisplayLbl.AutoSize = true;
            this.dataDisplayLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.dataDisplayLbl.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.dataDisplayLbl.Location = new System.Drawing.Point(345, 390);
            this.dataDisplayLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dataDisplayLbl.Name = "dataDisplayLbl";
            this.dataDisplayLbl.Size = new System.Drawing.Size(112, 25);
            this.dataDisplayLbl.TabIndex = 29;
            this.dataDisplayLbl.Text = "dataDisplay";
            this.dataDisplayLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(554, 11);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(156, 25);
            this.metroLabel2.TabIndex = 30;
            this.metroLabel2.Text = "CYCLE SETPOINT";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel3
            // 
            this.metroLabel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(554, 91);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(200, 25);
            this.metroLabel3.TabIndex = 31;
            this.metroLabel3.Text = "CYCLE ACTIVE COUNT";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // strokeVerifyChk
            // 
            this.strokeVerifyChk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.strokeVerifyChk.AutoSize = true;
            this.strokeVerifyChk.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.strokeVerifyChk.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.strokeVerifyChk.Location = new System.Drawing.Point(831, 251);
            this.strokeVerifyChk.Margin = new System.Windows.Forms.Padding(2);
            this.strokeVerifyChk.Name = "strokeVerifyChk";
            this.strokeVerifyChk.Size = new System.Drawing.Size(162, 25);
            this.strokeVerifyChk.TabIndex = 33;
            this.strokeVerifyChk.Text = "STROKE VERIFY";
            this.strokeVerifyChk.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.strokeVerifyChk.UseSelectable = true;
            this.strokeVerifyChk.Click += new System.EventHandler(this.CheckboxClick);
            // 
            // partDetectChk
            // 
            this.partDetectChk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.partDetectChk.AutoSize = true;
            this.partDetectChk.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.partDetectChk.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.partDetectChk.Location = new System.Drawing.Point(829, 302);
            this.partDetectChk.Margin = new System.Windows.Forms.Padding(2);
            this.partDetectChk.Name = "partDetectChk";
            this.partDetectChk.Size = new System.Drawing.Size(145, 25);
            this.partDetectChk.TabIndex = 34;
            this.partDetectChk.Text = "PART DETECT";
            this.partDetectChk.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.partDetectChk.UseSelectable = true;
            this.partDetectChk.Click += new System.EventHandler(this.CheckboxClick);
            // 
            // cycleCounter
            // 
            this.cycleCounter.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.cycleCounter.CustomButton.AutoSize = true;
            this.cycleCounter.CustomButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cycleCounter.CustomButton.Image = null;
            this.cycleCounter.CustomButton.Location = new System.Drawing.Point(73, 2);
            this.cycleCounter.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.cycleCounter.CustomButton.Name = "";
            this.cycleCounter.CustomButton.Size = new System.Drawing.Size(6, 6);
            this.cycleCounter.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.cycleCounter.CustomButton.TabIndex = 1;
            this.cycleCounter.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.cycleCounter.CustomButton.UseSelectable = true;
            this.cycleCounter.CustomButton.Visible = false;
            this.cycleCounter.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.cycleCounter.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.cycleCounter.Lines = new string[0];
            this.cycleCounter.Location = new System.Drawing.Point(588, 131);
            this.cycleCounter.Margin = new System.Windows.Forms.Padding(2);
            this.cycleCounter.MaxLength = 5;
            this.cycleCounter.Name = "cycleCounter";
            this.cycleCounter.PasswordChar = '\0';
            this.cycleCounter.PromptText = "#####";
            this.cycleCounter.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.cycleCounter.SelectedText = "";
            this.cycleCounter.SelectionLength = 0;
            this.cycleCounter.SelectionStart = 0;
            this.cycleCounter.ShortcutsEnabled = true;
            this.cycleCounter.Size = new System.Drawing.Size(95, 24);
            this.cycleCounter.TabIndex = 39;
            this.cycleCounter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cycleCounter.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cycleCounter.UseSelectable = true;
            this.cycleCounter.WaterMark = "#####";
            this.cycleCounter.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cycleCounter.WaterMarkFont = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.cycleCounter.Enter += new System.EventHandler(this.TextboxGotFocus);
            this.cycleCounter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CycleCounterKeyPress);
            this.cycleCounter.Leave += new System.EventHandler(this.TextboxLostFocus);
            // 
            // GeneralInformation
            // 
            this.GeneralInformation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GeneralInformation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GeneralInformation.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.GeneralInformation.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.GeneralInformation.Location = new System.Drawing.Point(743, 116);
            this.GeneralInformation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.GeneralInformation.Name = "GeneralInformation";
            this.GeneralInformation.Size = new System.Drawing.Size(370, 40);
            this.GeneralInformation.TabIndex = 40;
            this.GeneralInformation.Text = "SELECT IMPACT FRAME BELOW";
            this.GeneralInformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.GeneralInformation.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Logo
            // 
            this.Logo.AutoSize = true;
            this.Logo.BackgroundImage = global::MicroPCGUI.Properties.Resources.DEP_BIO_Logo;
            this.Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Logo.HorizontalScrollbarBarColor = true;
            this.Logo.HorizontalScrollbarHighlightOnWheel = false;
            this.Logo.HorizontalScrollbarSize = 10;
            this.Logo.Location = new System.Drawing.Point(0, 0);
            this.Logo.Margin = new System.Windows.Forms.Padding(2);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(424, 192);
            this.Logo.TabIndex = 43;
            this.Logo.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Logo.VerticalScrollbarBarColor = true;
            this.Logo.VerticalScrollbarHighlightOnWheel = false;
            this.Logo.VerticalScrollbarSize = 10;
            this.Logo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMouseDown);
            // 
            // GeneralWindow
            // 
            this.GeneralWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GeneralWindow.AutoSize = true;
            this.GeneralWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GeneralWindow.Controls.Add(this.PSI_UP_MAN_Btn);
            this.GeneralWindow.Controls.Add(this.PSI_DN_MAN_Btn);
            this.GeneralWindow.Controls.Add(this.velocityFeedbackLbl);
            this.GeneralWindow.Controls.Add(this.velFeedLbl);
            this.GeneralWindow.Controls.Add(this.velocityEntryLbl);
            this.GeneralWindow.Controls.Add(this.velocityEntry);
            this.GeneralWindow.Controls.Add(this.AxisScreenBtn);
            this.GeneralWindow.Controls.Add(this.startCycleBtn);
            this.GeneralWindow.Controls.Add(this.dataDisplayLbl);
            this.GeneralWindow.Controls.Add(this.stopCycleBtn);
            this.GeneralWindow.Controls.Add(this.resetCountBtn);
            this.GeneralWindow.Controls.Add(this.cycleCounter);
            this.GeneralWindow.Controls.Add(this.eStopBtn);
            this.GeneralWindow.Controls.Add(this.automaticModeRadio);
            this.GeneralWindow.Controls.Add(this.metroLabel3);
            this.GeneralWindow.Controls.Add(this.metroLabel2);
            this.GeneralWindow.Controls.Add(this.cycleSP);
            this.GeneralWindow.Controls.Add(this.partDetectChk);
            this.GeneralWindow.Controls.Add(this.hammerSP);
            this.GeneralWindow.Controls.Add(this.strokeVerifyChk);
            this.GeneralWindow.Controls.Add(this.keyenceModeRadio);
            this.GeneralWindow.Controls.Add(this.handModeRadio);
            this.GeneralWindow.Controls.Add(this.hammerSetPointLbl);
            this.GeneralWindow.Controls.Add(this.hammerRetractLbl);
            this.GeneralWindow.Controls.Add(this.hammerRetract);
            this.GeneralWindow.Controls.Add(this.metroLabel1);
            this.GeneralWindow.Controls.Add(this.hammerFeedback);
            this.GeneralWindow.HorizontalScrollbarBarColor = true;
            this.GeneralWindow.HorizontalScrollbarHighlightOnWheel = false;
            this.GeneralWindow.HorizontalScrollbarSize = 12;
            this.GeneralWindow.Location = new System.Drawing.Point(52, 199);
            this.GeneralWindow.Margin = new System.Windows.Forms.Padding(4);
            this.GeneralWindow.Name = "GeneralWindow";
            this.GeneralWindow.Size = new System.Drawing.Size(1388, 576);
            this.GeneralWindow.TabIndex = 44;
            this.GeneralWindow.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.GeneralWindow.VerticalScrollbarBarColor = true;
            this.GeneralWindow.VerticalScrollbarHighlightOnWheel = false;
            this.GeneralWindow.VerticalScrollbarSize = 12;
            this.GeneralWindow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMouseDown);
            // 
            // PSI_UP_MAN_Btn
            // 
            this.PSI_UP_MAN_Btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PSI_UP_MAN_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.PSI_UP_MAN_Btn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.PSI_UP_MAN_Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.PSI_UP_MAN_Btn.Location = new System.Drawing.Point(622, 452);
            this.PSI_UP_MAN_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.PSI_UP_MAN_Btn.Name = "PSI_UP_MAN_Btn";
            this.PSI_UP_MAN_Btn.Size = new System.Drawing.Size(223, 75);
            this.PSI_UP_MAN_Btn.TabIndex = 46;
            this.PSI_UP_MAN_Btn.Tag = "";
            this.PSI_UP_MAN_Btn.Text = "MANUAL PSI UP";
            this.PSI_UP_MAN_Btn.UseCustomBackColor = true;
            this.PSI_UP_MAN_Btn.UseCustomForeColor = true;
            this.PSI_UP_MAN_Btn.UseSelectable = true;
            this.PSI_UP_MAN_Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PSIUPMouseDown);
            this.PSI_UP_MAN_Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // PSI_DN_MAN_Btn
            // 
            this.PSI_DN_MAN_Btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PSI_DN_MAN_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PSI_DN_MAN_Btn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.PSI_DN_MAN_Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.PSI_DN_MAN_Btn.Location = new System.Drawing.Point(897, 452);
            this.PSI_DN_MAN_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.PSI_DN_MAN_Btn.Name = "PSI_DN_MAN_Btn";
            this.PSI_DN_MAN_Btn.Size = new System.Drawing.Size(225, 75);
            this.PSI_DN_MAN_Btn.TabIndex = 45;
            this.PSI_DN_MAN_Btn.Tag = "";
            this.PSI_DN_MAN_Btn.Text = "MANUAL PSI DOWN";
            this.PSI_DN_MAN_Btn.UseCustomBackColor = true;
            this.PSI_DN_MAN_Btn.UseCustomForeColor = true;
            this.PSI_DN_MAN_Btn.UseSelectable = true;
            this.PSI_DN_MAN_Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PSIDOWNMouseDown);
            this.PSI_DN_MAN_Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // velocityFeedbackLbl
            // 
            this.velocityFeedbackLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.velocityFeedbackLbl.AutoSize = true;
            this.velocityFeedbackLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.velocityFeedbackLbl.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.velocityFeedbackLbl.Location = new System.Drawing.Point(98, 266);
            this.velocityFeedbackLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.velocityFeedbackLbl.Name = "velocityFeedbackLbl";
            this.velocityFeedbackLbl.Size = new System.Drawing.Size(191, 25);
            this.velocityFeedbackLbl.TabIndex = 44;
            this.velocityFeedbackLbl.Text = "VELOCITY FEEDBACK";
            this.velocityFeedbackLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // velFeedLbl
            // 
            this.velFeedLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.velFeedLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.velFeedLbl.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.velFeedLbl.Location = new System.Drawing.Point(115, 298);
            this.velFeedLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.velFeedLbl.Name = "velFeedLbl";
            this.velFeedLbl.Size = new System.Drawing.Size(128, 28);
            this.velFeedLbl.TabIndex = 43;
            this.velFeedLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.velFeedLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // velocityEntryLbl
            // 
            this.velocityEntryLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.velocityEntryLbl.AutoSize = true;
            this.velocityEntryLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.velocityEntryLbl.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.velocityEntryLbl.Location = new System.Drawing.Point(98, 200);
            this.velocityEntryLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.velocityEntryLbl.Name = "velocityEntryLbl";
            this.velocityEntryLbl.Size = new System.Drawing.Size(159, 25);
            this.velocityEntryLbl.TabIndex = 42;
            this.velocityEntryLbl.Text = "VELOCITY ENTRY";
            this.velocityEntryLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // velocityEntry
            // 
            this.velocityEntry.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.velocityEntry.CustomButton.AutoSize = true;
            this.velocityEntry.CustomButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.velocityEntry.CustomButton.Image = null;
            this.velocityEntry.CustomButton.Location = new System.Drawing.Point(102, 1);
            this.velocityEntry.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.velocityEntry.CustomButton.Name = "";
            this.velocityEntry.CustomButton.Size = new System.Drawing.Size(6, 6);
            this.velocityEntry.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.velocityEntry.CustomButton.TabIndex = 1;
            this.velocityEntry.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.velocityEntry.CustomButton.UseSelectable = true;
            this.velocityEntry.CustomButton.Visible = false;
            this.velocityEntry.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.velocityEntry.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.velocityEntry.Lines = new string[0];
            this.velocityEntry.Location = new System.Drawing.Point(115, 227);
            this.velocityEntry.Margin = new System.Windows.Forms.Padding(2);
            this.velocityEntry.MaxLength = 5;
            this.velocityEntry.Name = "velocityEntry";
            this.velocityEntry.PasswordChar = '\0';
            this.velocityEntry.PromptText = "##.##";
            this.velocityEntry.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.velocityEntry.SelectedText = "";
            this.velocityEntry.SelectionLength = 0;
            this.velocityEntry.SelectionStart = 0;
            this.velocityEntry.ShortcutsEnabled = true;
            this.velocityEntry.Size = new System.Drawing.Size(128, 27);
            this.velocityEntry.TabIndex = 41;
            this.velocityEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.velocityEntry.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.velocityEntry.UseSelectable = true;
            this.velocityEntry.WaterMark = "##.##";
            this.velocityEntry.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.velocityEntry.WaterMarkFont = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.velocityEntry.Enter += new System.EventHandler(this.TextboxGotFocus);
            this.velocityEntry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VelocityEntryKeyPress);
            this.velocityEntry.Leave += new System.EventHandler(this.TextboxLostFocus);
            // 
            // AxisScreenBtn
            // 
            this.AxisScreenBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AxisScreenBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.AxisScreenBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.AxisScreenBtn.ForeColor = System.Drawing.Color.White;
            this.AxisScreenBtn.Location = new System.Drawing.Point(1135, 11);
            this.AxisScreenBtn.Name = "AxisScreenBtn";
            this.AxisScreenBtn.Size = new System.Drawing.Size(167, 85);
            this.AxisScreenBtn.TabIndex = 40;
            this.AxisScreenBtn.Text = "TO AXIS";
            this.AxisScreenBtn.UseCustomBackColor = true;
            this.AxisScreenBtn.UseCustomForeColor = true;
            this.AxisScreenBtn.UseSelectable = true;
            this.AxisScreenBtn.Click += new System.EventHandler(this.AxisScreenBtnClick);
            // 
            // generalControlsUpdateTimer
            // 
            this.generalControlsUpdateTimer.Interval = 2000;
            this.generalControlsUpdateTimer.Tick += new System.EventHandler(this.GeneralTimerTicked);
            // 
            // eStopTimer
            // 
            this.eStopTimer.Interval = 3000;
            // 
            // MicroPCUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1556, 884);
            this.Controls.Add(this.impactFrameArrayDrop);
            this.Controls.Add(this.GeneralInformation);
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.GeneralWindow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MicroPCUI";
            this.Padding = new System.Windows.Forms.Padding(19, 75, 19, 20);
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "MicroPCUI";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TransparencyKey = System.Drawing.Color.MidnightBlue;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMouseDown);
            this.GeneralWindow.ResumeLayout(false);
            this.GeneralWindow.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox impactFrameArrayDrop;
        private MetroFramework.Controls.MetroButton startCycleBtn;
        private MetroFramework.Controls.MetroButton stopCycleBtn;
        private MetroFramework.Controls.MetroButton eStopBtn;
        private MetroFramework.Controls.MetroButton resetCountBtn;
        private System.Windows.Forms.Timer activeUpdateTimer;
        private MetroFramework.Controls.MetroLabel hammerFeedback;
        private MetroFramework.Controls.MetroLabel hammerSetPointLbl;
        private MetroFramework.Controls.MetroTextBox cycleSP;
        private MetroFramework.Controls.MetroTextBox hammerRetract;
        private MetroFramework.Controls.MetroLabel hammerRetractLbl;
        private MetroFramework.Controls.MetroRadioButton handModeRadio;
        private MetroFramework.Controls.MetroRadioButton automaticModeRadio;
        private MetroFramework.Controls.MetroRadioButton keyenceModeRadio;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox hammerSP;
        private MetroFramework.Controls.MetroLabel dataDisplayLbl;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroCheckBox strokeVerifyChk;
        private MetroFramework.Controls.MetroCheckBox partDetectChk;
        private MetroFramework.Controls.MetroTextBox cycleCounter;
        private MetroFramework.Controls.MetroLabel GeneralInformation;
        private MetroFramework.Controls.MetroPanel Logo;
        private MetroFramework.Controls.MetroPanel GeneralWindow;
        private System.Windows.Forms.Timer generalControlsUpdateTimer;
        private System.Windows.Forms.Timer eStopTimer;
        private MetroFramework.Controls.MetroButton AxisScreenBtn;
        private MetroFramework.Controls.MetroLabel velocityEntryLbl;
        private MetroFramework.Controls.MetroTextBox velocityEntry;
        private MetroFramework.Controls.MetroLabel velocityFeedbackLbl;
        private MetroFramework.Controls.MetroLabel velFeedLbl;
        private MetroFramework.Controls.MetroButton PSI_UP_MAN_Btn;
        private MetroFramework.Controls.MetroButton PSI_DN_MAN_Btn;
    }
}

