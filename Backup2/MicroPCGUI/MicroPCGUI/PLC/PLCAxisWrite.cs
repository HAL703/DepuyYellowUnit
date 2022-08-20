using System;
namespace MicroPCGUI.PLC
{
    /// <summary>
    /// Responsible for writing values from user input on the Axis GUI screen
    /// into tags in a PLC accordingly
    /// </summary>
    public class PLCAxisWrite : PLCAxis
    {
        public PLCAxisWrite(int impactFrameValue, MetroFramework.Forms.MetroForm screen)
        : base(impactFrameValue, screen)
        {
        }
        /// <summary>
        /// Writes a true or false value to a Z axis tag based on the button
        /// </summary>
        /// <param name="buttonTracker">Integer representing the button that calls this method for the Z axis</param>
        /// <param name="value">True or false value to be written to the PLC for a tag</param>
        public void ZButtonBoolWrite(int buttonTracker, bool value)
        {
            BadTagReadChecker(z_axis);
            if (TagNullChecker(z_axis))
                return;
            Structures.Z_AXIS_STRUCT zAxisStruct = (Structures.Z_AXIS_STRUCT)udtEnc.ToType(z_axis, typeof(Structures.Z_AXIS_STRUCT));
            pbValues = udtEnc.ToBoolArray(zAxisStruct.boolVals);
            pbValues[buttonTracker] = value;
            zAxisStruct.boolVals = udtEnc.FromBoolArray(pbValues);
            z_axis.Value = udtEnc.FromType(zAxisStruct);
            myPLC.WriteTag(z_axis);
        }
        /// <summary>
        /// Writes a true or false value to a X axis tag based on the button
        /// </summary>
        /// <param name="buttonTracker">Integer representing the button that calls this method for the X axis</param>
        /// <param name="value">True or false value to be written to the PLC for a tag</param>
        public void XButtonBoolWrite(int buttonTracker, bool value)
        {
            BadTagReadChecker(x_axis);
            if (TagNullChecker(x_axis))
                return;
            Structures.X_AXIS_STRUCT xAxisStruct = (Structures.X_AXIS_STRUCT)udtEnc.ToType(x_axis, typeof(Structures.X_AXIS_STRUCT));
            pbValues = udtEnc.ToBoolArray(xAxisStruct.boolVals);
            pbValues[buttonTracker] = value;
            xAxisStruct.boolVals = udtEnc.FromBoolArray(pbValues);
            x_axis.Value = udtEnc.FromType(xAxisStruct);
            myPLC.WriteTag(x_axis);
        }
        /// <summary>
        /// Writes a true or false value to a MZ axis tag based on the button
        /// </summary>
        /// <param name="buttonTracker">Integer representing the button that calls this method for the MZ axis</param>
        /// <param name="value">True or false value to be written to the PLC for a tag</param>
        public void MZButtonBoolWrite(int buttonTracker, bool value)
        {
            BadTagReadChecker(mz_axis);
            if (TagNullChecker(mz_axis))
                return;
            Structures.MZ_AXIS_STRUCT mzAxisStruct = (Structures.MZ_AXIS_STRUCT)udtEnc.ToType(mz_axis, typeof(Structures.MZ_AXIS_STRUCT));
            pbValues = udtEnc.ToBoolArray(mzAxisStruct.boolVals);
            pbValues[buttonTracker] = value;
            mzAxisStruct.boolVals = udtEnc.FromBoolArray(pbValues);
            mz_axis.Value = udtEnc.FromType(mzAxisStruct);
            myPLC.WriteTag(mz_axis);
        }
        /// <summary>
        /// Writes a true or false value to a MX axis tag based on the button
        /// </summary>
        /// <param name="buttonTracker">Integer representing the button that calls this method for the MX axis</param>
        /// <param name="value">True or false value to be written to the PLC for a tag</param>
        public void MXButtonBoolWrite(int buttonTracker, bool value)
        {
            BadTagReadChecker(mx_axis);
            if (TagNullChecker(mx_axis))
                return;
            Structures.MX_AXIS_STRUCT mxAxisStruct = (Structures.MX_AXIS_STRUCT)udtEnc.ToType(mx_axis, typeof(Structures.MX_AXIS_STRUCT));
            pbValues = udtEnc.ToBoolArray(mxAxisStruct.boolVals);
            pbValues[buttonTracker] = value;
            mxAxisStruct.boolVals = udtEnc.FromBoolArray(pbValues);
            mx_axis.Value = udtEnc.FromType(mxAxisStruct);
            myPLC.WriteTag(mx_axis);
        }
        /// <summary>
        /// Writes a true or false value to a specified BOOL in the PLC.
        /// This is based on the yellow frame panel.
        /// </summary>
        /// <param name="buttonTracker">Integer representing a specific button</param>
        /// <param name="value">True or false boolean value to write to a PLC</param>
        public void YellowButtonWrite(int buttonTracker, bool value)
        {
            BadTagReadChecker(YellowHMIMapping);
            if (TagNullChecker(YellowHMIMapping))
                return;
            Structures.YellowHMIMapping yellowHMI = (Structures.YellowHMIMapping)udtEnc.ToType(YellowHMIMapping, typeof(Structures.YellowHMIMapping));
            pbValues = udtEnc.ToBoolArray(yellowHMI.boolVals);
            pbValues[buttonTracker] = value;
            yellowHMI.boolVals = udtEnc.FromBoolArray(pbValues);
            YellowHMIMapping.Value = udtEnc.FromType(yellowHMI);
            myPLC.WriteTag(YellowHMIMapping);
        }
        /// <summary>
        /// Writes an integer value to a PLC tag from a button's state.
        /// This is based on the yellow frame panel.
        /// </summary>
        /// <param name="buttonTracker">Integer representing a specific button</param>
        /// <param name="value">Integer value to write to a PLC</param>
        public void YellowButtonWrite(int buttonTracker, int value)
        {
            BadTagReadChecker(YellowHMIMapping);
            if (TagNullChecker(YellowHMIMapping))
                return;
            Structures.YellowHMIMapping yellowHMI = (Structures.YellowHMIMapping)udtEnc.ToType(YellowHMIMapping, typeof(Structures.YellowHMIMapping));
            yellowHMI.AKD_HOA = value;
            YellowHMIMapping.Value = udtEnc.FromType(yellowHMI);
            myPLC.WriteTag(YellowHMIMapping);
        }

        /// <summary>
        /// Main textbox write method required to write user input from textboxes
        /// to the PLC
        /// </summary>
        /// <param name="text">String containing what a user entered into a textbox</param>
        /// <param name="textboxvalue">Value of a textbox</param>
        public void TextboxInputWrite(string text, int textboxvalue)
        {
            textboxText = text;
            textboxValue = textboxvalue;
            var convertedValue = Convert.ToSingle(textboxText);
            switch (textboxValue)
            {
                case 0:
                    ZTextboxInputWrite(convertedValue);
                    break;
                case 1:
                    XTextboxInputWrite(convertedValue);
                    break;
                case 2:
                    MZTextboxInputWrite(convertedValue);
                    break;
                case 3:
                    MXTextboxInputWrite(convertedValue);
                    break;
                case 4:
                    YellowTextboxInputWrite(convertedValue);
                    break;
                case 5:
                case 6:
                    YellowTextboxInputWrite(Convert.ToInt32(textboxText), textboxvalue);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Writes a value to the Z axis Req_Pos tag
        /// </summary>
        /// <param name="value">Single containing the value needed to write to the PLC</param>
        private void ZTextboxInputWrite(Single value)
        {
            BadTagReadChecker(z_axis);
            if (TagNullChecker(z_axis))
                return;
            Structures.Z_AXIS_STRUCT singleTag = (Structures.Z_AXIS_STRUCT)udtEnc.ToType(z_axis, typeof(Structures.Z_AXIS_STRUCT));
            singleTag.Req_Pos = value;
            lostFocus.Name = "lostFocus[8]";
            lostFocus.Value = true;
            z_axis.Value = udtEnc.FromType(singleTag);
            myPLC.WriteTag(z_axis);
            myPLC.WriteTag(lostFocus);
        }
        /// <summary>
        /// Writes a value to the X axis Req_Pos tag
        /// </summary>
        /// <param name="value">Single containing the value needed to write to the PLC</param>
        private void XTextboxInputWrite(Single value)
        {
            BadTagReadChecker(x_axis);
            if (TagNullChecker(x_axis))
                return;
            Structures.X_AXIS_STRUCT singleTag = (Structures.X_AXIS_STRUCT)udtEnc.ToType(x_axis, typeof(Structures.X_AXIS_STRUCT));
            singleTag.Pos_Req = value;
            lostFocus.Name = "lostFocus[9]";
            lostFocus.Value = true;
            x_axis.Value = udtEnc.FromType(singleTag);
            myPLC.WriteTag(x_axis);
            myPLC.WriteTag(lostFocus);
        }
        /// <summary>
        /// Writes a value to the MZ axis Req_Pos tag
        /// </summary>
        /// <param name="value">Single containing the value needed to write to the PLC</param>
        private void MZTextboxInputWrite(Single value)
        {
            BadTagReadChecker(mz_axis);
            if (TagNullChecker(mz_axis))
                return;
            Structures.MZ_AXIS_STRUCT singleTag = (Structures.MZ_AXIS_STRUCT)udtEnc.ToType(mz_axis, typeof(Structures.MZ_AXIS_STRUCT));
            singleTag.Pos_Req = value;
            lostFocus.Name = "lostFocus[10]";
            lostFocus.Value = true;
            mz_axis.Value = udtEnc.FromType(singleTag);
            myPLC.WriteTag(mz_axis);
            myPLC.WriteTag(lostFocus);
        }
        /// <summary>
        /// Writes a value to the MX axis Req_Pos tag
        /// </summary>
        /// <param name="value">Single containing the value needed to write to the PLC</param>
        private void MXTextboxInputWrite(Single value)
        {
            BadTagReadChecker(mx_axis);
            if (TagNullChecker(mx_axis))
                return;
            Structures.MX_AXIS_STRUCT singleTag = (Structures.MX_AXIS_STRUCT)udtEnc.ToType(mx_axis, typeof(Structures.MX_AXIS_STRUCT));
            singleTag.Pos_Req = value;
            lostFocus.Name = "lostFocus[11]";
            lostFocus.Value = true;
            mx_axis.Value = udtEnc.FromType(singleTag);
            myPLC.WriteTag(mx_axis);
            myPLC.WriteTag(lostFocus);
        }
        /// <summary>
        /// Writes a Single value to a specified tag in the PLC.
        /// This is based on the yellow frame panel.
        /// </summary>
        /// <param name="value">Single value to write to a PLC</param>
        private void YellowTextboxInputWrite(Single value)
        {
            BadTagReadChecker(YellowHMIMapping);
            if (TagNullChecker(YellowHMIMapping))
                return;
            Structures.YellowHMIMapping yellowHMI = (Structures.YellowHMIMapping)udtEnc.ToType(YellowHMIMapping, typeof(Structures.YellowHMIMapping));
            yellowHMI.AKD_SP = value;
            YellowHMIMapping.Value = udtEnc.FromType(yellowHMI);
            myPLC.WriteTag(YellowHMIMapping);
        }
        /// <summary>
        /// Writes an integer value to a specified tag in the PLC.
        /// This is based on the yellow frame panel.
        /// </summary>
        /// <param name="value">Value to be written to the PLC</param>
        /// <param name="textboxValue">Value of </param>
        private void YellowTextboxInputWrite(int value, int textboxValue)
        {
            BadTagReadChecker(YellowHMIMapping);
            if (TagNullChecker(YellowHMIMapping))
                return;
            Structures.YellowHMIMapping yellowHMI = (Structures.YellowHMIMapping)udtEnc.ToType(YellowHMIMapping, typeof(Structures.YellowHMIMapping));
            if (textboxValue == 5) { yellowHMI.AKD_IMPACT = value; }
            else { yellowHMI.AKD_EXTRACT = value; }
            YellowHMIMapping.Value = udtEnc.FromType(yellowHMI);
            myPLC.WriteTag(YellowHMIMapping);
        }
        /// <summary>
        /// Write method for the yellow axis fault reset button (for AKD)
        /// </summary>
        /// <param name="val">Value to be written to the respective tag in the PLC</param>
        public void FaultResetButtonWrite(bool val)
        {
            BadTagReadChecker(FaultReset);
            if (TagNullChecker(FaultReset))
                return;
            FaultReset.Value = val;
            myPLC.WriteTag(FaultReset);
        }
    }
}
