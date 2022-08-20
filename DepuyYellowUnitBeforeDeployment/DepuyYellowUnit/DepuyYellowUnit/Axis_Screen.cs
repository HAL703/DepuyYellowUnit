using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using DepuyYellowUnit.PLC;
using System.Text.RegularExpressions;
using MetroFramework.Controls;
using System.Collections.Generic;
namespace DepuyYellowUnit
{
    /// <summary>
    /// Axis screen for AKD servo axes.
    /// Controls on this screen can control a Kollmorgen servo.
    /// </summary>
    public partial class Axis_Screen : MetroForm
    {
        //if ActiveControl = null doesn't work, switch back to the enables
        public MetroForm RefToGeneralForm { get; set; }
        private readonly Timer ZTBUpdateTimer = new Timer();
        private readonly Timer XTBUpdateTimer = new Timer();
        private readonly Timer MZTBUpdateTimer = new Timer();
        private readonly Timer MXTBUpdateTimer = new Timer();
        private readonly Timer SocketRetryTimer = new Timer();
        private readonly Timer yellowENMAINTimer = new Timer();
        private readonly Timer yellowTextboxTimer = new Timer();
        private readonly string notDecimalNumber = "Please enter only an integer value or a decimal value up to two decimal points.";
        private readonly string oneDecimalOnly = "Please enter only one decimal point.";
        private readonly int axisFrame;
        private PLCAxisWrite plcAxisWrite;
        private PLCAxisRead plcAxisRead;
        private int buttonTracker;
        private int exceptType;
        private string btnNameHolder;

        public Axis_Screen(int impactFrame)
        {
            InitializeComponent();
            //FrameCheck(impactFrame);
            axisFrame = impactFrame - 1;
            plcAxisRead = new PLCAxisRead(axisFrame, this);
            plcAxisRead.PLCConnect("169.169.3.10");
            plcAxisWrite = new PLCAxisWrite(axisFrame, this);
            plcAxisWrite.PLCConnect("169.169.3.10");
            YellowAxisOnly();
            TimerSetupStarter();
            ZLimitReached1Lbl.Visible = false;
            ZLimitReached2Lbl.Visible = false;
            YellowMultistateBtnSetup();
            SocketRetryTimer.Interval = 30000;
            SocketRetryTimer.Tick += SocketRetry;
            SocketRetryTimer.Enabled = true;
            yellowENMAINTimer.Interval = 1500;
            yellowENMAINTimer.Tick += YellowENMAINTicked;
            yellowENMAINTimer.Enabled = true;
            yellowTextboxTimer.Enabled = true;
            yellowTextboxTimer.Interval = 1500;
            yellowTextboxTimer.Tick += YellowTextboxTimerTicked;
            yellowTextboxTimer.Start();
        }

        ///// <summary> NOT NEEDED UNLESS USING MULTI COLOR FRAMES
        ///// Checks the index of the impact frames and subtracts one
        ///// if the index is 2 or 3
        ///// </summary>
        ///// <param name="impactFrameValue">Impact frame value received from the general form</param>
        ///// <remarks>
        ///// This is to offset the index so that PLC writing will work correctly.
        ///// Otherwise, an invalid index would be called and an error would occur.
        ///// </remarks>
        //private void FrameCheck(int impactFrameValue)
        //{
        //    //if it's a red or green frame
        //    if (impactFrameValue == 0 || impactFrameValue == 1)
        //    {
        //        axisFrame = impactFrameValue;
        //        return;
        //    }
        //    axisFrame = impactFrameValue - 1; //otherwise, the index needs to be subtracted by one
        //}
        /// <summary>
        /// The yellow frame does not have a x, mz, or mx axis;
        /// so, the respective panels are hidden.
        /// Similarly, all other frames do not have the YellowPanel.
        /// The yellow frame only has the yellow axis panel.
        /// </summary>
        private void YellowAxisOnly()
        {
            if (axisFrame == 3)
            {
                ZAxisPanel.Visible = false; //verify that it's unneeded and rescale appropriately in YellowPanelRescale
                XAxisPanel.Visible = false;
                MZAxisPanel.Visible = false;
                MXAxisPanel.Visible = false;
                YellowPanelsRescale();
            }
            else if (axisFrame != 3) { YellowPanel.Visible = false; }
        }
        /// <summary>
        /// Rescales some panels when the axisFrame is the yellow frame (3).
        /// </summary>
        private void YellowPanelsRescale()
        {
            SizeF scale = new SizeF(1.6f, 1.25f); //1.25, 1.25
            ZAxisPanel.Scale(scale);
            ZAxisPanel.Location = new Point(0, 75);
            YellowPanel.Scale(scale);
            YellowPanel.Location = new Point(200, 35); //500, 35
            scale.Width = 1.5f;
            scale.Height = 1.5f;
            ReturnGeneralBtn.Scale(scale);
            ReturnGeneralBtn.Location = new Point(330, 400);
        }
        /// <summary>
        /// On startup, this sets up tag-updating timers.
        /// </summary>
        private void TimerSetupStarter()
        {
            //ZTBUpdateTimer.Interval = 1500;
            //ZTBUpdateTimer.Tick += ZTBUpdateTimerTick;
            //ZTBUpdateTimer.Start();
            //ZLabelTimer.Start();
            if (axisFrame != 3)
            {
                XTBUpdateTimer.Interval = 1500;
                XTBUpdateTimer.Tick += XTBUpdateTimerTick;
                MZTBUpdateTimer.Interval = 1500;
                MZTBUpdateTimer.Tick += MZTBUpdateTimerTick;
                MXTBUpdateTimer.Interval = 1500;
                MXTBUpdateTimer.Tick += MXTBUpdateTimerTick;
                XLabelTimer.Start();
                MZLabelTimer.Start();
                MXLabelTimer.Start();
                XTBUpdateTimer.Start();
                MZTBUpdateTimer.Start();
                MXTBUpdateTimer.Start();
                YellowLabelTimer.Dispose();
            }
            else
            {
                YellowLabelTimer.Start();
                XTBUpdateTimer.Dispose();
                XLabelTimer.Dispose();
                MZTBUpdateTimer.Dispose();
                MZLabelTimer.Dispose();
                MXTBUpdateTimer.Dispose();
                MXLabelTimer.Dispose();
            }
        }
        /// <summary>
        /// Event handler for the MouseDown event of Z Axis momentary buttons.
        /// Writes a 1 to a tag in a PLC, based on the button clicked, while the button is pressed and held.
        /// </summary>
        private void ZMomentaryBtnMouseDown(object sender, MouseEventArgs e)
        {
            string btnName = btnNameHolder = ((MetroButton)sender).Name;
            if (btnName == "ZEnableBtn") { buttonTracker = 0; }
            else if (btnName == "ZReqPosBtn") { buttonTracker = 1; }
            else if (btnName == "ZSetHomeBtn") { buttonTracker = 2; }
            else if (btnName == "ZExBtn") { buttonTracker = 3; }
            else { buttonTracker = 4; }
            try { plcAxisWrite.ZButtonBoolWrite(buttonTracker, true); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        /// <summary>
        /// Event handler for the keypress event of the ZBlueInput textbox.
        /// Writes a value based on what the user enters to a respective tag in a PLC.
        /// Any characters other than '.' or digits are not permitted.
        /// </summary>
        /// <exception cref="FormatException">
        /// User entered non-digit character or '.' more than once.
        /// </exception>
        private void ZBlueInputKeyPress(object sender, KeyPressEventArgs e)
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
                if (e.KeyChar == (char)Keys.Enter && Regex.IsMatch(ZBlueInput.Text, "^[0-9]{1,3}\\.?[0-9]{1,2}$"))
                {
                    ActiveControl = null;
                    plcAxisWrite.TextboxInputWrite(ZBlueInput.Text, 0);
                }
            }
            catch (FormatException)
            {
                if (exceptType == 1) { MessageBox.Show(notDecimalNumber); }
                else { MessageBox.Show(oneDecimalOnly); }
                e.Handled = true;
            }
        }
        /// <summary>
        /// Event handler for the tick event of the ZTBUpdateTimer.
        /// Writes a value in the ZBlueInput textbox based on a read tag.
        /// </summary>
        private void ZTBUpdateTimerTick(object sender, EventArgs e)
        {
            ZBlueInput.Text = plcAxisRead.TextboxRead(0);
            ZBlueInput.Text = StringIntegerTest(ZBlueInput.Text, 2);
        }
        /// <summary>
        /// Event handler for the tick event of the ZLabelTimer.
        /// Updates the text of ZCMLbl and the visibility of ZLimitReached1Lbl
        /// and ZLimitReached2Lbl based on PLC tag values.
        /// </summary>
        private void ZLabelTimerTick(object sender, EventArgs e)
        {
            var labels = plcAxisRead.LabelUpdater(0);
            var intTest = StringIntegerTest(labels[0], 1);
            ZCMLbl.Text = $"Z. AXIS ({intTest})cm"; //used to be labels[0]
            ZLimitReached1Lbl.Visible = Convert.ToBoolean(labels[1]);
            ZLimitReached2Lbl.Visible = Convert.ToBoolean(labels[2]);
        }
        /// <summary>
        /// Event handler for the enter event of ZBlueInput.
        /// Stops the update timer associated with Z axis textboxes while user has ZBlueInput in focus.
        /// Empties the text so the user doesn't have to.
        /// </summary>
        private void ZBlueInputFocusEnter(object sender, EventArgs e)
        {
            ZTBUpdateTimer.Stop();
            ZBlueInput.Text = "";
        }
        /// <summary>
        /// Event handler for the leave event of ZBlueInput.
        /// Restarts the update timer associated with Z axis textboxes.
        /// </summary>
        private void ZBlueInputFocusLeave(object sender, EventArgs e)
        {
            ZTBUpdateTimer.Start();
        }
        /// <summary>
        /// Event handler for the MouseDown event of X Axis momentary buttons.
        /// Writes a 1 to a tag in a PLC, based on the button clicked, while the button is pressed and held.
        /// </summary>
        private void XMomentaryBtnMouseDown(object sender, MouseEventArgs e)
        {
            string btnName = btnNameHolder = ((MetroButton)sender).Name;
            if (btnName == "XEnableBtn") { buttonTracker = 0; }
            else if (btnName == "XReqPosBtn") { buttonTracker = 1; }
            else if (btnName == "XSetHomeBtn") { buttonTracker = 2; }
            else if (btnName == "XLBtn") { buttonTracker = 3; }
            else if (btnName == "XRBtn") { buttonTracker = 4; }
            else { buttonTracker = 5; }
            try { plcAxisWrite.XButtonBoolWrite(buttonTracker, true); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        /// <summary>
        /// Event handler for the keypress event of the XBlueInput textbox.
        /// Writes a value based on what the user enters to a respective tag in a PLC.
        /// Any characters other than '.' or digits are not permitted.
        /// </summary>
        /// <exception cref="FormatException">
        /// User entered non-digit character or '.' more than once.
        /// </exception>
        private void XBlueInputKeyPress(object sender, KeyPressEventArgs e)
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
                if (e.KeyChar == (char)Keys.Enter && Regex.IsMatch(ZBlueInput.Text, "^[0-9]{1,3}\\.?[0-9]{1,2}$"))
                {
                    ActiveControl = null;
                    plcAxisWrite.TextboxInputWrite(XBlueInput.Text, 1);
                }
            }
            catch (FormatException)
            {
                if (exceptType == 1) { MessageBox.Show(notDecimalNumber); }
                else { MessageBox.Show(oneDecimalOnly); }
                e.Handled = true;
            }
        }
        /// <summary>
        /// Event handler for the tick event of the XTBUpdateTimer.
        /// Writes a value in the XBlueInput textbox based on a read tag.
        /// </summary>
        private void XTBUpdateTimerTick(object sender, EventArgs e)
        {
            XBlueInput.Text = plcAxisRead.TextboxRead(1);
            XBlueInput.Text = StringIntegerTest(XBlueInput.Text, 2);
        }
        /// <summary>
        /// Event handler for the tick event of the XLabelTimer.
        /// Updates the text of XMMLbl based on a respective PLC tag value.
        /// </summary>
        private void XLabelTimerTick(object sender, EventArgs e)
        {
            var labels = plcAxisRead.LabelUpdater(1);
            var intTest = StringIntegerTest(labels[0], 1);
            XMMLbl.Text = $"X. AXIS ({intTest})mm";
        }
        /// <summary>
        /// Event handler for the enter event of XBlueInput.
        /// Stops the update timer associated with X axis textboxes while user has XBlueInput in focus.
        /// Empties the text so the user doesn't have to.
        /// </summary>
        private void XBlueInputFocusEnter(object sender, EventArgs e)
        {
            XTBUpdateTimer.Stop();
            XBlueInput.Text = "";
        }
        /// <summary>
        /// Event handler for the leave event of XBlueInput.
        /// Restarts the update timer associated with X axis textboxes.
        /// </summary>
        private void XBlueInputFocusLeave(object sender, EventArgs e)
        {
            XTBUpdateTimer.Start();
        }
        /// <summary>
        /// Event handler for the MouseDown event of MZ Axis momentary buttons.
        /// Writes a 1 to a tag in a PLC, based on the button clicked, while the button is pressed and held.
        /// </summary>
        private void MZMomentaryBtnMouseDown(object sender, MouseEventArgs e)
        {
            string btnName = btnNameHolder = ((MetroButton)sender).Name;
            if (btnName == "MZEnableBtn") { buttonTracker = 0; }
            else if (btnName == "MZReqPosBtn") { buttonTracker = 1; }
            else if (btnName == "MZSetHomeBtn") { buttonTracker = 2; }
            else if (btnName == "MZMOMCWBtn") { buttonTracker = 3; }
            else if (btnName == "MZMOMCCWBtn") { buttonTracker = 4; }
            else { buttonTracker = 5; }
            try { plcAxisWrite.MZButtonBoolWrite(buttonTracker, true); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        /// <summary>
        /// Event handler for the click event of MZMAINCWBtn.
        /// Writes a value of 1 to a respective tag in a PLC.
        /// </summary>
        private void MZMAINCWBtnClick(object sender, EventArgs e)
        {
            buttonTracker = 3;
            plcAxisWrite.MZButtonBoolWrite(buttonTracker, true);
            //setup an update timer here on PLC to keep bit high, also have one here to read if bit goes low
            //toggle button here
        }
        /// <summary>
        /// Event handler for the click event of MZMAINCCWBtn.
        /// Writes a value of 1 to a respective tag in a PLC.
        /// </summary>
        private void MZMAINCCWBtnClick(object sender, EventArgs e)
        {
            buttonTracker = 4;
            plcAxisWrite.MZButtonBoolWrite(buttonTracker, true);
        }
        /// <summary>
        /// Event handler for the keypress event of the MZBlueInput textbox.
        /// Writes a value based on what the user enters to a respective tag in a PLC.
        /// Any characters other than '.' or digits are not permitted.
        /// </summary>
        /// <exception cref="FormatException">
        /// User entered non-digit character or '.' more than once.
        /// </exception>
        private void MZBlueInputKeyPress(object sender, KeyPressEventArgs e)
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
                if (e.KeyChar == (char)Keys.Enter && Regex.IsMatch(ZBlueInput.Text, "^[0-9]{1,3}\\.?[0-9]{1,2}$"))
                {
                    ActiveControl = null;
                    plcAxisWrite.TextboxInputWrite(MZBlueInput.Text, 2);
                }
            }
            catch (FormatException)
            {
                if (exceptType == 1) { MessageBox.Show(notDecimalNumber); }
                else { MessageBox.Show(oneDecimalOnly); }
                e.Handled = true;
            }
        }
        /// <summary>
        /// Event handler for the tick event of the MZTBUpdateTimer.
        /// Writes a value in the MZBlueInput textbox based on a read tag.
        /// </summary>
        private void MZTBUpdateTimerTick(object sender, EventArgs e)
        {
            MZBlueInput.Text = plcAxisRead.TextboxRead(2);
            MZBlueInput.Text = StringIntegerTest(MZBlueInput.Text, 2);

        }
        /// <summary>
        /// Event handler for the tick event of the MZLabelTimer.
        /// Updates the text of MZDegLbl based on a respective PLC tag value.
        /// </summary>
        private void MZLabelTimerTick(object sender, EventArgs e)
        {
            var labels = plcAxisRead.LabelUpdater(2);
            var intTest = StringIntegerTest(labels[0], 1);
            MZDegLbl.Text = $"MZ.AXIS--({intTest})";
        }
        /// <summary>
        /// Event handler for the enter event of MZBlueInput.
        /// Stops the update timer associated with MZ axis textboxes while user has MZBlueInput in focus.
        /// Empties the text so the user doesn't have to.
        /// </summary>
        private void MZBlueInputFocusEnter(object sender, EventArgs e)
        {
            MZTBUpdateTimer.Stop();
            MZBlueInput.Text = "";
        }
        /// <summary>
        /// Event handler for the leave event of MZBlueInput.
        /// Restarts the update timer associated with MZ axis textboxes.
        /// </summary>
        private void MZBlueInputFocusLeave(object sender, EventArgs e)
        {
            MZTBUpdateTimer.Start();
        }
        /// <summary>
        /// Event handler for the MouseDown event of MX Axis momentary buttons.
        /// Writes a 1 to a tag in a PLC, based on the button clicked, while the button is pressed and held.
        /// </summary>
        private void MXMomentaryBtnMouseDown(object sender, MouseEventArgs e)
        {
            string btnName = btnNameHolder = ((MetroButton)sender).Name;
            if (btnName == "MXEnableBtn") { buttonTracker = 0; }
            else if (btnName == "MXReqPosBtn") { buttonTracker = 1; }
            else if (btnName == "MXSetHomeBtn") { buttonTracker = 2; }
            else if (btnName == "MXCWBtn") { buttonTracker = 3; }
            else if (btnName == "MXCCWBtn") { buttonTracker = 4; }
            else { buttonTracker = 5; }
            try { plcAxisWrite.MXButtonBoolWrite(buttonTracker, true); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        /// <summary>
        /// Event handler for the keypress event of the MXBlueInput textbox.
        /// Writes a value based on what the user enters to a respective tag in a PLC.
        /// Any characters other than '.' or digits are not permitted.
        /// </summary>
        /// <exception cref="FormatException">
        /// User entered non-digit character or '.' more than once.
        /// </exception>
        private void MXBlueInputKeyPress(object sender, KeyPressEventArgs e)
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
                if (e.KeyChar == (char)Keys.Enter && Regex.IsMatch(ZBlueInput.Text, "^[0-9]{1,3}\\.?[0-9]{1,2}$"))
                {
                    ActiveControl = null;
                    plcAxisWrite.TextboxInputWrite(MXBlueInput.Text, 3);
                }
            }
            catch (FormatException)
            {
                if (exceptType == 1) { MessageBox.Show(notDecimalNumber); }
                else { MessageBox.Show(oneDecimalOnly); }
                e.Handled = true;
            }
        }
        /// <summary>
        /// Event handler for the tick event of the MXTBUpdateTimer.
        /// Writes a value in the MXBlueInput textbox based on a read tag.
        /// </summary>
        private void MXTBUpdateTimerTick(object sender, EventArgs e)
        {
            MXBlueInput.Text = plcAxisRead.TextboxRead(3);
            MXBlueInput.Text = StringIntegerTest(MXBlueInput.Text, 2);
        }
        /// <summary>
        /// Event handler for the tick event of the MXLabelTimer.
        /// Updates the text of MXDegLbl based on a respective PLC tag value.
        /// </summary>
        private void MXLabelTimerTick(object sender, EventArgs e)
        {
            var labels = plcAxisRead.LabelUpdater(3);
            var intTest = StringIntegerTest(labels[0], 1);
            MXDegLbl.Text = $"MX. AXIS ({intTest})";
        }
        /// <summary>
        /// Event handler for the enter event of MXBlueInput.
        /// Stops the update timer associated with MX axis textboxes while user has MXBlueInput in focus.
        /// Empties the text so the user doesn't have to.
        /// </summary>
        private void MXBlueInputFocusEnter(object sender, EventArgs e)
        {
            MXTBUpdateTimer.Stop();
            MXBlueInput.Text = "";
        }
        /// <summary>
        /// Event handler for the leave event of MXBlueInput.
        /// Restarts the update timer associated with MX axis textboxes.
        /// </summary>
        private void MXBlueInputFocusLeave(object sender, EventArgs e)
        {
            MXTBUpdateTimer.Start();
        }
        /// <summary>
        /// Event handler for the MouseUp event of axis momentary buttons.
        /// Writes a 0 to a tag in a PLC, based on the button clicked, when the button held is released.
        /// </summary>
        private void AxisMomentaryBtnMouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (btnNameHolder.Contains("MX")) { plcAxisWrite.MXButtonBoolWrite(buttonTracker, false); }
                else if (btnNameHolder.Contains("MZ")) { plcAxisWrite.MZButtonBoolWrite(buttonTracker, false); }
                else if (btnNameHolder.Contains("X")) { plcAxisWrite.XButtonBoolWrite(buttonTracker, false); }
                else { plcAxisWrite.ZButtonBoolWrite(buttonTracker, false); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            ActiveControl = null;
        }
        /// <summary>
        /// If the state of yellowENMainToggle changes, then either a true or false value
        /// is sent to the PLC depending on the state.
        /// </summary>
        /// <remarks>
        /// This button is maintained.
        /// </remarks>
        private void YellowENMAINToggleCheckedChanged(object sender, EventArgs e)
        {
            buttonTracker = 0;
            if (yellowENMAINToggle.Checked) { plcAxisWrite.YellowButtonWrite(buttonTracker, true); yellowENMAINLbl.Text = "AKD EN ON"; }
            else { plcAxisWrite.YellowButtonWrite(buttonTracker, false); yellowENMAINLbl.Text = "AKD EN OFF"; }
        }
        /// <summary>
        /// Update timer that ticks every 1.5 seconds to update the value of the yellow enable button
        /// </summary>
        private void YellowENMAINTicked(object sender, EventArgs e)
        {
            yellowENMAINToggle.Checked = plcAxisRead.YellowEnableUpdater();

        }
        /// <summary>
        /// Writes user input in the yellowAKDSP textbox to the PLC.
        /// </summary>
        /// <exception cref="FormatException">
        /// User enters any non-digit character or enters more than one '.' character
        /// </exception>
        private void YellowAKDSPKeyPress(object sender, KeyPressEventArgs e)
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
                if (e.KeyChar == (char)Keys.Enter && (Regex.IsMatch(yellowAKDSP.Text, "^[0-9]{0,3}\\.?[0-9]{1,2}$")))
                {
                    ActiveControl = null;
                    plcAxisWrite.TextboxInputWrite(yellowAKDSP.Text, 4);
                }
            }
            catch (FormatException)
            {
                if (exceptType == 1) { MessageBox.Show(notDecimalNumber); }
                else { MessageBox.Show("Please enter only one decimal point."); }
                e.Handled = true;
            }
        }
        /// <summary>
        /// Writes user input in the yellowExtractTextbox textbox to the PLC.
        /// </summary>
        /// <exception cref="FormatException">
        /// User enters any non-digit character
        /// </exception>
        private void YellowImpactKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    throw new FormatException();
                }
                if (e.KeyChar == (char)Keys.Enter && (Regex.IsMatch(yellowImpactTextbox.Text, "^[0-9]{1,5}$")))
                {
                    ActiveControl = null;
                    plcAxisWrite.TextboxInputWrite(yellowImpactTextbox.Text, 5);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter only an integer value");
                e.Handled = true;
            }
        }
        /// <summary>
        /// Writes user input in the yellowImpactTextbox to the PLC.
        /// </summary>
        /// <exception cref="FormatException">
        /// User enters any non-digit character
        /// </exception>
        private void YellowExtractKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    throw new FormatException();
                }
                if (e.KeyChar == (char)Keys.Enter && (Regex.IsMatch(yellowExtractTextbox.Text, "^[0-9]{1,5}$")))
                {
                    ActiveControl = null;
                    plcAxisWrite.TextboxInputWrite(yellowExtractTextbox.Text, 6);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter only an integer value");
                e.Handled = true;
            }
        }
        /// <summary>
        /// Inserts text into the yellowAKDActualLbl from a value read in the PLC
        /// </summary>
        private void YellowLabelTimerTick(object sender, EventArgs e)
        {
            yellowAKDActualLbl.Text = $"{plcAxisRead.YellowLabelUpdater()} LBS";
        }
        /// <summary>
        /// If a yellow panel textbox gains focus, text is deleted
        /// for convenience and the textbox timer is stopped to prevent overwriting of data from the PLC.
        /// </summary>
        private void YellowTextboxGotFocus(object sender, EventArgs e)
        {
            MetroTextBox control = (MetroTextBox)sender;
            control.Text = "";
            yellowTextboxTimer.Stop();
        }
        /// <summary>
        /// If a yellow panel textbox gains focus, text is deleted
        /// for convenience and the textbox timer is restarted.
        /// </summary>
        private void YellowTextboxLostFocus(object sender, EventArgs e)
        {
            yellowTextboxTimer.Start();
        }
        /// <summary>
        /// Event handler for the tick event of yellowTextboxTimer.
        /// Updates the text for yellow frame textboxes based on PLC values.
        /// </summary>
        private void YellowTextboxTimerTicked(object sender, EventArgs e)
        {
            var textArray = plcAxisRead.YellowTextboxUpdater();
            yellowImpactTextbox.Text = textArray[0];
            yellowExtractTextbox.Text = textArray[1];
        }
        /// <summary>
        /// Event handler for the MouseDown event of yellow momentary buttons.
        /// Writes a 1 to a tag in a PLC, based on the button clicked, while the button is pressed and held.
        /// </summary>
        private void YellowMomentaryBtnMouseDown(object sender, MouseEventArgs e)
        {
            string btnName = btnNameHolder = ((MetroButton)sender).Name;
            if (btnName == "yellowLiftBtn")
            {
                buttonTracker = 1;
                yellowLiftBtn.Text = "LIFTING...";
            }
            else if (btnName == "yellowLowerBtn")
            {
                buttonTracker = 2;
                yellowLowerBtn.Text = "LOWERING...";
            }
            else { buttonTracker = 3; }
            try { plcAxisWrite.YellowButtonWrite(buttonTracker, true); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        /// <summary>
        /// Event handler that's called upon releasing the mouse on a yellow button.
        /// Changes the state (color, text) of some buttons back to defaults,
        /// and it writes an inverted value to a PLC since the buttons are momentary.
        /// </summary>
        private void YellowMomentaryBtnMouseUp(object sender, MouseEventArgs e)
        {
            var btn = sender as MetroButton;
            if (sender == yellowLiftBtn || sender == yellowLowerBtn)
            {
                btn.Text = btn == yellowLiftBtn ? "LIFT" : "LOWER";
            }
            try { plcAxisWrite.YellowButtonWrite(buttonTracker, false); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            ActiveControl = null;
        }
        /// <summary>
        /// Event handler for the MouseDown event of the Yellow FaultReset momentary button.
        /// Writes a 1 to a tag in a PLC that resets AKD faults while the button is pressed and held.
        /// </summary>
        private void YellowFaultResetMouseDown(object sender, MouseEventArgs e)
        {
            try { plcAxisWrite.FaultResetButtonWrite(true); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        /// <summary>
        /// Event handler that's called upon releasing the mouse on a yellow fault reset button.
        /// Writes an inverted value (0 or false) to a PLC since the buttons are momentary.
        /// </summary>
        private void YellowFaultResetMouseUp(object sender, MouseEventArgs e)
        {
            try { plcAxisWrite.FaultResetButtonWrite(false); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            ActiveControl = null;
        }
        /// <summary>
        /// Assigns members to the yellowDropdownBtn 
        /// </summary>
        private void YellowMultistateBtnSetup()
        {
            Dictionary<int, string> yellowMultistate = new Dictionary<int, string>
            {
                [1] = "OFF",
                [2] = "HAND",
                [3] = "AUTO"
            };
            BindingSource bindingSource = new BindingSource(yellowMultistate, null);
            yellowDropdownBtn.DisplayMember = "Value";
            yellowDropdownBtn.ValueMember = "Value";
            yellowDropdownBtn.DataSource = bindingSource;
        }
        /// <summary>
        /// Writes a value to a PLC tag depending on what the index was changed to
        /// </summary>
        private void YellowMultistateBtnSelectedIndexChanged(object sender, EventArgs e)
        {
            buttonTracker = 4;
            plcAxisWrite.YellowButtonWrite(buttonTracker, yellowDropdownBtn.SelectedIndex);
        }
        /// <summary>
        /// If a user clicks outside the active control, 
        /// the control loses focus and ZAxisPanel gains focus as a placeholder
        /// </summary>
        private void FormMouseDown(object sender, MouseEventArgs e) => ZAxisPanel.Focus();
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
            plcAxisRead = new PLCAxisRead(axisFrame, this);
            plcAxisWrite = new PLCAxisWrite(axisFrame, this);
            plcAxisRead.PLCConnect("169.169.3.10");
            plcAxisWrite.PLCConnect("169.169.3.10");
        }
        /// <summary>
        /// If a string is an integer, this adds .0 to the end for better formatting. 
        /// </summary>
        /// <param name="text"> The <see cref="string"/> content of a label or textbox. </param>
        /// <returns>Same string or a string appended with either .0 or .00</returns>
        private string StringIntegerTest(string text, int decimalPlaces)
        {
            if (Int32.TryParse(text, out int value) && decimalPlaces == 1)
            {
                return text + ".0";
            }
            else if (Int32.TryParse(text, out int val) && decimalPlaces == 2)
            {
                return text + ".00";
            }
            return text;
        }
        /// <summary>
        /// Event handler for the click event of the ReturnGeneralBtn.
        /// </summary>
        private void ReturnGeneralBtnClick(object sender, EventArgs e)
        {
            RefToGeneralForm.Show();
            this.Close();
        }
    }
}
