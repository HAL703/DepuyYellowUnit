namespace MicroPCGUI.PLC
{
    /// <summary>
    /// Responsible for reading values from tags in a PLC to
    /// specific controls on the general GUI screen.
    /// </summary>
    public class PLCGeneralRead : PLCGeneral
    {
        public PLCGeneralRead(int impactFrameValue, MetroFramework.Forms.MetroForm screen)
        : base(impactFrameValue, screen)
        {
        }
        /// <summary>
        /// Changes eStop visibility based on a respective tag in the PLC.
        /// </summary>
        /// <returns>Boolean value for eStopBtn visibility.</returns>
        public bool EStopVisibilityUpdater()
        {
            BadTagReadChecker(gui_pbs);
            if (TagNullChecker(gui_pbs))
                return false;
            Structures.GUI_PBS_STRUCT guiPBSGen = (Structures.GUI_PBS_STRUCT)udtEnc.ToType(gui_pbs, typeof(Structures.GUI_PBS_STRUCT));
            var boolVal = guiPBSGen.resetVis == 1;
            return boolVal;
        }
        /// <summary>
        /// Stores appropriate tag values for the general screen in arrays.
        /// </summary>
        /// <param name="checkValues">Boolean array for the states of multiple checkboxes.</param>
        /// <param name="textboxText">String array for the text content of multiple textboxes.</param>
        public void GeneralGUI(bool[] checkValues, string[] textboxText)
        {
            bool[] bits;
            BadTagReadChecker(gui_general_struct);
            if (TagNullChecker(gui_general_struct))
                return;
            Structures.GUI_GENERAL_STRUCT guiGen = (Structures.GUI_GENERAL_STRUCT)udtEnc.ToType(gui_general_struct, typeof(Structures.GUI_GENERAL_STRUCT));
            bits = udtEnc.ToBoolArray(guiGen.boolVals);
            checkValues[0] = bits[0];
            checkValues[1] = bits[1];
            textboxText[0] = guiGen.Cycle_Setpoint.ToString();
            textboxText[1] = guiGen.Hammer_Setpoint.ToString();
            textboxText[2] = guiGen.Hammer_Retract.ToString();
            textboxText[3] = guiGen.data_display.DATA.ToString();
            BadTagReadChecker(lostFocus);
        }
        //reads and writes(?) push button values at the start of the application for setup purposes
        //public void PBGUI()
        //{
        //    myPLC.ReadTag(gui_pbs);
        //    Structures.GUI_PBS_STRUCT guiPBSGen = (Structures.GUI_PBS_STRUCT)udtEnc.ToType(gui_pbs, typeof(Structures.GUI_PBS_STRUCT));
        //    pbValues = udtEnc.ToBoolArray(guiPBSGen.boolPBVals);//guiPBSGen.guiPBSArray[impactFrame].boolPBVals);
        //    guiPBSGen.boolPBVals = udtEnc.FromBoolArray(pbValues);
        //    gui_pbs.Value = udtEnc.FromType(guiPBSGen);
        //    myPLC.WriteTag(gui_pbs);
        //}
        /// <summary>
        /// Stores the hammerMode value from the PLC.
        /// </summary>
        /// <returns>Hammer Mode</returns>
        public int HammerGUI()
        {
            BadTagReadChecker(hammerTag);
            if (TagNullChecker(hammerTag))
                return 0;
            Structures.HAMMER_STRUCT hammerInst = (Structures.HAMMER_STRUCT)udtEnc.ToType(hammerTag, typeof(Structures.HAMMER_STRUCT));
            return hammerInst.Hammer_Mode;
        }
        /// <summary>
        /// Stores the cycleCounter value from the PLC.
        /// </summary>
        /// <returns>Text for the cycleCounter textbox.</returns>
        public string ActiveUpdaterGUI()
        {
            BadTagReadChecker(activeUpdater);
            if (TagNullChecker(activeUpdater))
                return "";
            Structures.ACTIVE_UPDATE_STRUCT cycleCounterUpdate = (Structures.ACTIVE_UPDATE_STRUCT)udtEnc.ToType(activeUpdater, typeof(Structures.ACTIVE_UPDATE_STRUCT));
            string cycleCounter = cycleCounterUpdate.Cycle_Active_Counter.ToString();//cycleCounterUpdate.Active_Update[impactFrame].Cycle_Active_Counter.ToString();
            return cycleCounter;
        }
        /// <summary>
        /// Stores the values of ACTIVE_UPDATE_STRUCT from the PLC.
        /// </summary>
        /// <returns>String array containing text content for actively updated controls.</returns>
        public string[] ActiveUpdater()
        {
            BadTagReadChecker(activeUpdater);
            string[] result = new string[3];
            if (TagNullChecker(activeUpdater))
                return result;
            Structures.ACTIVE_UPDATE_STRUCT activeUp = (Structures.ACTIVE_UPDATE_STRUCT)udtEnc.ToType(activeUpdater, typeof(Structures.ACTIVE_UPDATE_STRUCT));
            result[0] = activeUp.Cycle_Active_Counter.ToString();
            result[1] = activeUp.Hammer_Feed.ToString();
            result[2] = activeUp.Velocity_Feed.ToString();
            udtEnc.ToBoolArray(activeUp.boolVals);
            return result;
        }
    }
}
