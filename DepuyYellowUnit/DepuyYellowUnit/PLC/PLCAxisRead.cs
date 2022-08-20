using System.Collections.Generic;
namespace DepuyYellowUnit.PLC
{
    /// <summary>
    /// Responsible for reading values from a PLC into
    /// specific controls on the Axis screen to be read by a user.
    /// </summary>
    public class PLCAxisRead : PLCAxis
    {
        public PLCAxisRead(int impactFrameValue, MetroFramework.Forms.MetroForm screen)
        : base(impactFrameValue, screen)
        {
        }
        /// <summary>
        /// Main textbox update method required by timers to update values correctly
        /// </summary>
        /// <param name="textboxvalue">The value of a textbox</param>
        /// <returns>String containing the updated value for a textbox</returns>
        public string TextboxRead(int textboxvalue)
        {
            textboxValue = textboxvalue;
            switch (textboxValue)
            {
                case 0:
                    return ZTextboxRead();
                case 1:
                    return XTextboxRead();
                case 2:
                    return MZTextboxRead();
                case 3:
                    return MXTextboxRead();
                default:
                    return null;
            }
        }
        /// <summary>
        /// Main method for label updating,
        /// this uses the current axis value to insert a tag's value into a label
        /// </summary>
        /// <param name="axisVal">Integer value of the current axis</param>
        /// <returns>List of strings to be shown in labels</returns>
        public List<string> LabelUpdater(int axisVal)
        {
            var labels = new List<string>();
            switch (axisVal)
            {
                case 0:
                    ZLabelUpdater(labels);
                    return labels;
                case 1:
                    XLabelUpdater(labels);
                    return labels;
                case 2:
                    MZLabelUpdater(labels);
                    return labels;
                case 3:
                    MXLabelUpdater(labels);
                    return labels;
                default:
                    return labels;
            }
        }
        /// <summary>
        /// Reads a label value in the PLC in order to update it on the C# side
        /// </summary>
        /// <returns>String for a label</returns>
        public string YellowLabelUpdater()
        {
            BadTagReadChecker(YellowHMIMapping);
            if (TagNullChecker(YellowHMIMapping))
                return "";
            Structures.YellowHMIMapping yellowHMIMapping = (Structures.YellowHMIMapping)udtEnc.ToType(YellowHMIMapping, typeof(Structures.YellowHMIMapping));
            return yellowHMIMapping.AKD_AV.ToString();
        }
        /// <summary>
        /// Updates the value of the yellow enable button based on whether the AKD drive has faults or not.
        /// </summary>
        /// <returns>Boolean value for the state of the yellow enable button</returns>
        public bool YellowEnableUpdater()
        {
            BadTagReadChecker(YellowHMIMapping);
            if (TagNullChecker(YellowHMIMapping))
                return false;
            Structures.YellowHMIMapping yellowHMIMapping = (Structures.YellowHMIMapping)udtEnc.ToType(YellowHMIMapping, typeof(Structures.YellowHMIMapping));
            var bits = udtEnc.ToBoolArray(yellowHMIMapping.boolVals);
            return bits[0];
        }
        /// <summary>
        /// Updates the values of the yellow impact/extract textboxes according to the values from the actual values from the PLC.
        /// </summary>
        /// <returns>String array holding values of the yellow impact and extract counts in that order.</returns>
        public string[] YellowTextboxUpdater()
        {
            string[] textContent = new string[2];
            BadTagReadChecker(YellowHMIMapping);
            if (TagNullChecker(YellowHMIMapping))
                return textContent;
            Structures.YellowHMIMapping yellowHMIMapping = (Structures.YellowHMIMapping)udtEnc.ToType(YellowHMIMapping, typeof(Structures.YellowHMIMapping));
            textContent[0] = yellowHMIMapping.AKD_IMPACT.ToString();
            textContent[1] = yellowHMIMapping.AKD_EXTRACT.ToString();
            return textContent;
        }
        /// <summary>
        /// Reads a tag to input an updated value in a textbox for the Z axis
        /// </summary>
        /// <returns>String to TextboxRead</returns>
        private string ZTextboxRead()
        {
            BadTagReadChecker(z_axis);
            if (TagNullChecker(z_axis))
                return "";
            Structures.Z_AXIS_STRUCT singleTag = (Structures.Z_AXIS_STRUCT)udtEnc.ToType(z_axis, typeof(Structures.Z_AXIS_STRUCT));
            return singleTag.Req_Pos.ToString();
        }
        /// <summary>
        /// Reads a tag to input an updated value in a textbox for the X axis
        /// </summary>
        /// <returns>String to TextboxRead</returns>
        private string XTextboxRead()
        {
            BadTagReadChecker(x_axis);
            if (TagNullChecker(x_axis))
                return "";
            Structures.X_AXIS_STRUCT singleTag = (Structures.X_AXIS_STRUCT)udtEnc.ToType(x_axis, typeof(Structures.X_AXIS_STRUCT));
            return singleTag.Pos_Req.ToString();
        }
        /// <summary>
        /// Reads a tag to input an updated value in a textbox for the MZ axis
        /// </summary>
        /// <returns>String to TextboxRead</returns>
        private string MZTextboxRead()
        {
            BadTagReadChecker(mz_axis);
            if (TagNullChecker(mz_axis))
                return "";
            Structures.MZ_AXIS_STRUCT singleTag = (Structures.MZ_AXIS_STRUCT)udtEnc.ToType(mz_axis, typeof(Structures.MZ_AXIS_STRUCT));
            return singleTag.Pos_Req.ToString();
        }
        /// <summary>
        /// Reads a tag to input an updated value in a textbox for the MX axis
        /// </summary>
        /// <returns>String to TextboxRead</returns>
        private string MXTextboxRead()
        {
            BadTagReadChecker(mx_axis);
            if (TagNullChecker(mx_axis))
                return "";
            Structures.MX_AXIS_STRUCT singleTag = (Structures.MX_AXIS_STRUCT)udtEnc.ToType(mx_axis, typeof(Structures.MX_AXIS_STRUCT));
            return singleTag.Pos_Req.ToString();
        }
        /// <summary>
        /// Reads certain tag values from the Z axis for labels
        /// </summary>
        /// <param name="labelList">List of strings for label values</param>
        /// <returns>List of strings with added values from the Z axis</returns>
        private List<string> ZLabelUpdater(List<string> labelList)
        {
            BadTagReadChecker(z_axis);
            if (TagNullChecker(z_axis))
                return labelList;
            Structures.Z_AXIS_STRUCT zAxisStruct = (Structures.Z_AXIS_STRUCT)udtEnc.ToType(z_axis, typeof(Structures.Z_AXIS_STRUCT));
            labelList.Add(zAxisStruct.Display_Pos.ToString());
            var limits = udtEnc.ToBoolArray(zAxisStruct.boolVals);
            labelList.Add(limits[5].ToString());
            labelList.Add(limits[6].ToString());
            return labelList;
        }
        /// <summary>
        /// Reads certain tag values from the X axis for labels
        /// </summary>
        /// <param name="labelList">List of strings for label values</param>
        /// <returns>List of strings with added values from the X axis</returns>
        private List<string> XLabelUpdater(List<string> labelList)
        {
            BadTagReadChecker(x_axis);
            if (TagNullChecker(x_axis))
                return labelList;
            Structures.X_AXIS_STRUCT xAxisStruct = (Structures.X_AXIS_STRUCT)udtEnc.ToType(x_axis, typeof(Structures.X_AXIS_STRUCT));
            labelList.Add(xAxisStruct.Actual_MM.ToString());
            return labelList;
        }
        /// <summary>
        /// Reads certain tag values from the MZ axis for labels
        /// </summary>
        /// <param name="labelList">List of strings for label values</param>
        /// <returns>List of strings with added values from the MZ axis</returns>
        private List<string> MZLabelUpdater(List<string> labelList)
        {
            BadTagReadChecker(mz_axis);
            if (TagNullChecker(mz_axis))
                return labelList;
            Structures.MZ_AXIS_STRUCT mzAxisStruct = (Structures.MZ_AXIS_STRUCT)udtEnc.ToType(mz_axis, typeof(Structures.MZ_AXIS_STRUCT));
            labelList.Add(mzAxisStruct.Actual_Degree.ToString());
            return labelList;
        }
        /// <summary>
        /// Reads certain tag values from the MX axis for labels
        /// </summary>
        /// <param name="labelList">List of strings for label values</param>
        /// <returns>List of strings with added values from the MX axis</returns>
        private List<string> MXLabelUpdater(List<string> labelList)
        {
            BadTagReadChecker(mx_axis);
            if (TagNullChecker(mx_axis))
                return labelList;
            Structures.MX_AXIS_STRUCT mxAxisStruct = (Structures.MX_AXIS_STRUCT)udtEnc.ToType(mx_axis, typeof(Structures.MX_AXIS_STRUCT));
            labelList.Add(mxAxisStruct.Actual_Degree.ToString());
            return labelList;
        }
    }
}
