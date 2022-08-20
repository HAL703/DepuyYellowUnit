using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Text.RegularExpressions;
using DepuyYellowUnit.PLC;
using MetroFramework.Controls;

namespace DepuyYellowUnit
{
    /// <summary>
    /// Main general screen for all impact frames.
    /// Contains controls needed by all frames.
    /// </summary>
    public partial class General_Screen : MetroForm
    {
        //may need to split textbox function into 4 functions and change how the timer works when one is in focus
        private readonly string notIntegerNumber = "Please enter only an integer value";
        private readonly Timer SocketRetryTimer = new Timer();
        private bool comboReady = false;
        private int impactFrameTracker;
        private PLCGeneralWrite plcWrite;
        private PLCGeneralRead plcRead;
        private int exceptType;

        public General_Screen()
        {
            InitializeComponent();
            SocketRetryTimer.Interval = 30000;
            MyImpactFrameArray();
            GeneralWindow.Hide();
        }
        /// <summary>
        /// Sets up the impactFrameArrayDrop's members so the user can
        /// select an impact frame.
        /// </summary>
        /// <remarks>
        /// A placeholder text "SELECT BELOW" was needed.
        /// However, due to limitations, this could only be implemented 
        /// if "SELECT BELOW" was a member of impactFrameArrayDrop.
        /// </remarks>
        private void MyImpactFrameArray()
        {
            Dictionary<int, string> impactFrame = new Dictionary<int, string>
            {
                [0] = "SELECT BELOW",
                [5] = "YELLOW",
                [6] = "STAND"
            };
            BindingSource bindingSource = new BindingSource(impactFrame, null);
            impactFrameArrayDrop.DataSource = bindingSource;
            impactFrameArrayDrop.DisplayMember = "Value";
            impactFrameArrayDrop.ValueMember = "Value";
            comboReady = true;
        }
        /// <summary>
        /// Event handler for the IndexChanged event of impactFrameArrayDrop.
        /// This handler indicates that the user has selected a member of impactFrameArrayDrop.
        /// Adjusts the impact frame index and connects a PLC.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// User selects "SELECT BELOW".
        /// </exception>
        /// <remarks>
        /// The index is subtracted by one due to "SELECT BELOW" being a member.
        /// This appropriately matches to the index of the impact frames in the PLC.
        /// </remarks>
        private void ImpactFrameArrayDropIndexChanged(object sender, EventArgs e)
        {
            if (comboReady)
            {
                try
                {
                    impactFrameTracker = impactFrameArrayDrop.SelectedIndex + 4; //change this + 4 to nothing if working on the project for multicolor frames
                    impactFrameTracker -= 1;
                    if (impactFrameTracker == 3) { throw new ArgumentOutOfRangeException(); }
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Error, please do NOT select 'SELECT BELOW'");
                    impactFrameTracker = 0;
                    return;
                }
                plcWrite = new PLCGeneralWrite(impactFrameTracker, this);
                plcWrite.PLCConnect("169.169.3.10");
                plcRead = new PLCGeneralRead(impactFrameTracker, this);
                plcRead.PLCConnect("169.169.3.10");
                GeneralScreenSetup();
                Stand_Unit();
                AxisScreenBtn.Visible = impactFrameTracker != 2 && impactFrameTracker != 5;
                SocketRetryTimer.Enabled = true;
                SocketRetryTimer.Tick += SocketRetry;
            }
        }
        /// <summary>
        /// Performs visibility operations for controls that aren't needed for the stand unit.
        /// Also performs visibility operations for controls if the user first chooses the stand unit
        /// and switches over to the yellow unit.
        /// </summary>
        private void Stand_Unit()
        {
            if (impactFrameTracker == 5)
            {
                startCycleBtn.Visible = false;
                stopCycleBtn.Visible = false;
                resetCountBtn.Visible = false;
                cycleCounter.Visible = false;
                cycleSP.Visible = false;
                metroLabel2.Visible = false;
                metroLabel3.Visible = false;
                velocityEntry.Visible = false;
                velocityEntryLbl.Visible = false;
                velocityFeedbackLbl.Visible = false;
                strokeVerifyChk.Visible = false;
                partDetectChk.Visible = false;
                velFeedLbl.Visible = false;
                keyenceModeRadio.Visible = false;
            }
            else if (impactFrameTracker == 4) //this is if the user switches to the yellow frame from the stand unit
            {
                startCycleBtn.Visible = true;
                stopCycleBtn.Visible = true;
                resetCountBtn.Visible = true;
                cycleCounter.Visible = true;
                cycleSP.Visible = true;
                metroLabel2.Visible = true;
                metroLabel3.Visible = true;
                velocityEntry.Visible = true;
                velocityEntryLbl.Visible = true;
                velocityFeedbackLbl.Visible = true;
                strokeVerifyChk.Visible = true;
                partDetectChk.Visible = true;
                velFeedLbl.Visible = true;
                keyenceModeRadio.Visible = true;
            }
        }
        /// <summary>
        /// Sets up the main general screen needed for every impact frame.
        /// Additionally, tag reading from the PLC is performed here 
        /// to have controls work appropriately.
        /// </summary>
        private void GeneralScreenSetup()
        {
            bool[] checkedValues = new bool[3];
            string[] textboxContent = new string[4];
            GeneralWindow.Show();
            GeneralInformation.Visible = false;
            GeneralWindow.Controls.Add(impactFrameArrayDrop);
            impactFrameArrayDrop.Location = new Point(75, 70);
            impactFrameArrayDrop.SelectedIndex = impactFrameTracker - 3;
            //performing tag reading from PLC and setting controls appropriately
            plcRead.GeneralGUI(checkedValues, textboxContent);
            GeneralUIControlsSetter(checkedValues, textboxContent);
            var activeValues = plcRead.ActiveUpdater();
            cycleCounter.Text = activeValues[0];
            hammerFeedback.Text = $"{activeValues[1]} psi";
            HammerSetup(plcRead.HammerGUI());
            plcWrite.InvertedStop = 0;
            plcWrite.PBTracker = 1; //writing a 1 to the PLC for the stopCycle variable since it's normally closed
            plcWrite.PBStructWriter(false);
            TimerHandler();
        }
        /// <summary>
        /// Takes values from tags in the PLC and inserts them into their respective controls
        /// </summary>
        /// <param name="checkBoxes">A boolean array for the state of all checkboxes.</param>
        /// <param name="textContent">A string array of the text content to be inserted into a control.</param>
        private void GeneralUIControlsSetter(bool[] checkBoxes, string[] textContent)
        {
            strokeVerifyChk.Checked = checkBoxes[0];
            partDetectChk.Checked = checkBoxes[1];
            cycleSP.Text = textContent[0];
            hammerSP.Text = $"{textContent[1]} psi";
            hammerRetract.Text = textContent[2];
            dataDisplayLbl.Text = textContent[3];
        }
        /// <summary>
        /// Starts constantly running timers
        /// </summary>
        private void TimerHandler()
        {
            activeUpdateTimer.Start();
            generalControlsUpdateTimer.Start();
        }
        /// <summary>
        /// Checks a radio button based on the read hammer mode value in a PLC.
        /// </summary>
        /// <param name="hammerMode">The mode selected in the PLC.</param>
        private void HammerSetup(int hammerMode)
        {
            if (hammerMode == 1) { handModeRadio.Checked = true; }
            else if (hammerMode == 2) { automaticModeRadio.Checked = true; }
            else if (hammerMode == 5) { keyenceModeRadio.Checked = true; }
        }
        /// <summary>
        /// Event handler for CheckedChanged event of handModeRadio.
        /// Writes a value to a respective PLC tag based on the value of HammerModeSetValue.
        /// </summary>
        private void HandModeCheckedChanged(object sender, EventArgs e) => plcWrite.HammerTagWrite(1);
        /// <summary>
        /// Event handler for CheckedChanged event of automaticModeRadio.
        /// Writes a value to a respective PLC tag based on the value of HammerModeSetValue.
        /// </summary>
        private void AutomaticModeCheckedChanged(object sender, EventArgs e) => plcWrite.HammerTagWrite(2);
        /// <summary>
        /// Event handler for CheckedChanged event of keyenceModeRadio.
        /// Writes a value to a respective PLC tag based on the value of HammerModeSetValue.
        /// </summary>
        private void KeyenceModeCheckedChanged(object sender, EventArgs e) => plcWrite.HammerTagWrite(5);
        /// <summary>
        /// Writes user input in the cycleSP textbox to the PLC.
        /// </summary>
        /// <exception cref="FormatException">
        /// User enters any non-digit character
        /// </exception>
        private void CycleSPKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //only allow digits
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    throw new FormatException();
                }
                //if user presses enter and the text is appropriate, control loses focus and timer will begin updating again
                if (e.KeyChar == (char)Keys.Enter && (Regex.IsMatch(cycleSP.Text, "^[0-9]{1,5}$")))
                {
                    ActiveControl = null;
                    plcWrite.TextboxWriteGuiGeneral(Convert.ToInt32(cycleSP.Text), 1);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show(notIntegerNumber);
                e.Handled = true;
            }
        }
        /// <summary>
        /// Writes user input in the hammerRetract textbox to the PLC.
        /// </summary>
        /// <exception cref="FormatException">
        /// User enters any non-digit character
        /// </exception>
        private void HammerRetractKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    throw new FormatException();
                }
                if (e.KeyChar == (char)Keys.Enter && (Regex.IsMatch(hammerRetract.Text, "^[0-9]{1,5}$")))
                {
                    ActiveControl = null;
                    plcWrite.TextboxWriteGuiGeneral(Convert.ToInt32(hammerRetract.Text), 2);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show(notIntegerNumber);
                e.Handled = true;
            }
        }
        /// <summary>
        /// Writes user input in the hammerSP textbox to the PLC.
        /// </summary>
        /// <exception cref="FormatException">
        /// User enters any non-digit character or enters more than one '.' character
        /// </exception>
        private void HammerSPKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //only allow digits or decimal points
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    exceptType = 1;
                    throw new FormatException();
                }
                // only allow one decimal point
                if ((e.KeyChar == '.') && ((sender as MetroTextBox).Text.IndexOf('.') > -1))
                {
                    exceptType = 2;
                    throw new FormatException();
                }
                //if user presses enter and the text is appropriate, control loses focus and timer will begin updating again
                if (e.KeyChar == (char)Keys.Enter && (Regex.IsMatch(hammerSP.Text, "^[0-9]{1,3}\\.?[0-9]{0,2}$")))
                {
                    ActiveControl = null;
                    plcWrite.TextboxWriteGuiGeneral(Convert.ToSingle(hammerSP.Text), 3);
                }
            }
            catch (FormatException)
            {
                if (exceptType == 1) { MessageBox.Show("Please enter only an integer value or a decimal value up to two decimal points."); }
                else { MessageBox.Show("Please enter only one decimal point."); }
                e.Handled = true;
            }
        }
        /// <summary>
        /// Writes user input in the cycleCounter textbox to the PLC
        /// </summary>
        /// <exception cref="FormatException">
        /// User enters any non-digit character
        /// </exception>
        private void CycleCounterKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    throw new FormatException();
                }
                if (e.KeyChar == (char)Keys.Enter && (Regex.IsMatch(cycleCounter.Text, "^[0-9]{1,5}$")))
                {
                    ActiveControl = null;
                    plcWrite.TextboxWriteActiveUpdate(Convert.ToInt32(cycleCounter.Text), 1);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show(notIntegerNumber);
                e.Handled = true;
            }
        }
        /// <summary>
        /// Writes user input in the velocityEntry textbox to the PLC
        /// </summary>
        /// <exception cref="FormatException">
        /// User enters any non-digit character or more than one decimal point
        /// </exception>
        private void VelocityEntryKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    exceptType = 1;
                    throw new FormatException();
                }
                if ((e.KeyChar == '.') && ((sender as MetroTextBox).Text.IndexOf('.') > -1))
                {
                    exceptType = 2;
                    throw new FormatException();
                }
                if (e.KeyChar == (char)Keys.Enter && (Regex.IsMatch(velocityEntry.Text, "^[0-9]{1,2}\\.?[0-9]{1,2}$")))
                {
                    ActiveControl = null;
                    plcWrite.TextboxWriteGuiGeneral(Convert.ToSingle(velocityEntry.Text), 5);
                    velocityEntry.Text += " m/s";
                }
            }
            catch (FormatException)
            {
                if (exceptType == 1) { MessageBox.Show("Please enter only an integer value or a decimal value up to two decimal points."); }
                else { MessageBox.Show("Please enter only one decimal point."); }
                e.Handled = true;
            }
        }
        /// <summary>
        /// Event handler for the click event of any checkbox.
        /// Writes values to the PLC based on the state of the checkboxes.
        /// </summary>
        private void CheckboxClick(object sender, EventArgs e)
        {
            bool[] limits = new bool[2];
            limits[0] = strokeVerifyChk.Checked;
            limits[1] = partDetectChk.Checked;
            try { plcWrite.CheckboxWrite(limits); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        /// <summary>
        /// Event handler for the tick event of UpdateTimer.
        /// Constantly reads values for cycleCounter and hammerFeedback from the PLC every second.
        /// </summary>
        private void UpdateTimerTicked(object sender, EventArgs e)
        {
            string[] contentList = plcRead.ActiveUpdater();
            cycleCounter.Text = contentList[0];
            hammerFeedback.Text = $"{contentList[1]} psi";
            velFeedLbl.Text = $"{contentList[2]} m/s";
            plcWrite.HeartBeatWriter();
            HammerSetup(plcRead.HammerGUI());
            eStopBtn.Visible = plcRead.EStopVisibilityUpdater();
        }
        /// <summary>
        /// Event handler for the tick event of GeneralTimer.
        /// Constantly reads values for several controls from the PLC every 5 seconds.
        /// </summary>
        private void GeneralTimerTicked(object sender, EventArgs e)
        {
            bool[] checkedValues = new bool[2];
            string[] textboxContent = new string[4];
            plcRead.GeneralGUI(checkedValues, textboxContent);
            GeneralUIControlsSetter(checkedValues, textboxContent);
        }
        /// <summary>
        /// When a user clicks/tabs into a textbox or it gains focus in some other way.
        /// </summary>
        private void TextboxGotFocus(object sender, EventArgs e)
        {
            MetroTextBox control = (MetroTextBox)sender;
            control.Text = ""; //verify
            generalControlsUpdateTimer.Stop();
            activeUpdateTimer.Stop();
        }
        /// <summary>
        /// When a user presses enter for a textbox or it loses focus in some other way (i.e. clicking the form).
        /// </summary>
        private void TextboxLostFocus(object sender, EventArgs e) => TimerHandler();
        /// <summary>
        /// Event handler for the MouseDown event of startCycleBtn.
        /// Writes a corresponding value to the PLC while a user clicks and holds the button.
        /// </summary>
        private void StartCycleMouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                plcWrite.InvertedStop = 0;
                plcWrite.PBTracker = 0;
                plcWrite.PBStructWriter(false);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        /// <summary>
        /// Event handler for the MouseDown event of stopCycleBtn.
        /// Writes a corresponding value to the PLC while a user clicks and holds the button.
        /// </summary>
        private void StopCycleMouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                //this is inverted from the start button
                plcWrite.InvertedStop = 1;
                plcWrite.PBTracker = 1;
                plcWrite.PBStructWriter(false);
                plcWrite.InvertedStop = 0;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        /// <summary>
        /// Event handler for the MouseDown event of resetCountBtn.
        /// Writes a corresponding value to the PLC while a user clicks and holds the button.
        /// </summary>
        private void ResetCountMouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                plcWrite.InvertedStop = 2;
                plcWrite.PBTracker = 2;
                plcWrite.PBStructWriter(false);
                plcWrite.InvertedStop = 0;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        /// <summary>
        /// Event handler for the MouseDown event of eStopBtn.
        /// Writes a corresponding value to the PLC while a user clicks and holds the button.
        /// </summary>
        private void EStopMouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                plcWrite.PBTracker = 3;
                plcWrite.PBStructWriter(false);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        /// <summary>
        /// Event handler for the MouseDown event of PSI_UP_MAN_Btn.
        /// Writes a corresponding value to the PLC while a user clicks and holds the button.
        /// </summary>
        private void PSIUPMouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                plcWrite.PBTracker = 4;
                plcWrite.PBStructWriter(false);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        /// <summary>
        /// Event handler for the MouseDown event of PSI_DN_MAN_Btn.
        /// Writes a corresponding value to the PLC while a user clicks and holds the button.
        /// </summary>
        private void PSIDOWNMouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                plcWrite.PBTracker = 5;
                plcWrite.PBStructWriter(false);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        /// <summary>
        /// Event handler that's called upon releasing the mouse on a momentary button.
        /// Writes an inverted value back to the PLC for a tag based on the corresponding
        /// MouseDown event handler.
        /// </summary>
        private void MomentaryButtonMouseUp(object sender, MouseEventArgs e)
        {
            plcWrite.PBStructWriter(true);
            if (plcWrite.PBTracker <= 3)
                eStopBtn.Visible = false;
            ActiveControl = null;
        }
        /// <summary>
        /// Constantly running function, based on a 30 second timer, that reconnects 
        /// the PLC sockets.
        /// </summary>
        /// <remarks>
        /// This is needed because this C# application 
        /// inexplicably refuses to let a user write after about 10 minutes have passed,
        /// even though it can still read tags just fine. This type of error must be avoided 
        /// at all costs due to the nature of what this program is designed to do. Thus, this event handler exists.
        /// </remarks>
        private void SocketRetry(object sender, EventArgs e)
        {
            plcRead = new PLCGeneralRead(impactFrameTracker, this);
            plcWrite = new PLCGeneralWrite(impactFrameTracker, this);
            plcRead.PLCConnect("169.169.3.10");
            plcWrite.PLCConnect("169.169.3.10");
        }
        /// <summary>
        /// Event handler for the click event of AxisScreenBtn.
        /// Opens Axis_Screen and hides the main form.
        /// </summary>
        private void AxisScreenBtnClick(object sender, EventArgs e)
        {
            plcRead.myPLC.Disconnect();
            plcWrite.myPLC.Disconnect();
            var axisScreen = new Axis_Screen(impactFrameTracker);
            axisScreen.RefToGeneralForm = this;
            axisScreen.Location = this.Location;
            axisScreen.StartPosition = FormStartPosition.Manual;
            axisScreen.FormClosing += delegate { this.Show(); };
            axisScreen.Show();
            this.Hide();
        }
        /// <summary>
        /// If a user clicks outside the active control, 
        /// the control loses focus and GeneralWindow gains focus as a placeholder
        /// </summary>
        private void FormMouseDown(object sender, MouseEventArgs e) => GeneralWindow.Focus();
    }
}
