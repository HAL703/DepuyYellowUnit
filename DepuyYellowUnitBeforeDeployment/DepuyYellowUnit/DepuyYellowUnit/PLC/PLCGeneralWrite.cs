using System;
namespace DepuyYellowUnit.PLC
{
    //PLC has write tag commands
    //Read methods are required before some WriteTag calls for NETLOGIX to function correctly
    /// <summary>
    /// Responsible for writing values from user input on the general GUI screen
    /// into PLC tags accordingly.
    /// </summary>
    public class PLCGeneralWrite : PLCGeneral
    {
        public PLCGeneralWrite(int impactFrameValue, MetroFramework.Forms.MetroForm metroForm)
        : base(impactFrameValue, metroForm)
        {
        }
        /// <summary>
        /// Writes values for push buttons to the PLC.
        /// </summary>
        /// <param name="momentaryValue">This indicates that a user has released the mouse, which writes a 0 to the PLC for the corresponding tag value because the button is momentary.</param>
        public void PBStructWriter(bool momentaryValue)
        {
            BadTagReadChecker(gui_pbs);
            if (TagNullChecker(gui_pbs))
                return;
            Structures.GUI_PBS_STRUCT guiPBSGen = (Structures.GUI_PBS_STRUCT)udtEnc.ToType(gui_pbs, typeof(Structures.GUI_PBS_STRUCT));
            pbValues = udtEnc.ToBoolArray(guiPBSGen.boolPBVals);
            if (momentaryValue)
            {
                pbValues[PBTracker] = !pbValues[PBTracker];
                guiPBSGen.boolPBVals = udtEnc.FromBoolArray(pbValues);
                gui_pbs.Value = udtEnc.FromType(guiPBSGen);
                myPLC.WriteTag(gui_pbs);
                return;
            }
            pbValues[0] = pbValues[4] = pbValues[5] = false; //verify this works
            pbValues[PBTracker] = InvertedStop != 1;
            guiPBSGen.boolPBVals = udtEnc.FromBoolArray(pbValues);
            gui_pbs.Value = udtEnc.FromType(guiPBSGen);
            if(InvertedStop == 2)
            {
                BadTagReadChecker(lostFocus);
                lostFocus.Name = "lostFocus[5]"; //so pressing reset enables lostFocus[5] for 1 second
                lostFocus.Value = true;
                myPLC.WriteTag(lostFocus);
            }
            myPLC.WriteTag(gui_pbs);
        }
        /// <summary>
        /// Writes the value of HammerModeValue to the PLC.
        /// </summary>
        public void HammerTagWrite(int HammerModeValue)
        {
            BadTagReadChecker(hammerTag);
            if (TagNullChecker(hammerTag))
                return;
            Structures.HAMMER_STRUCT hammerInst = (Structures.HAMMER_STRUCT)udtEnc.ToType(hammerTag, typeof(Structures.HAMMER_STRUCT));
            hammerInst.Hammer_Mode = HammerModeValue;
            hammerTag.Value = udtEnc.FromType(hammerInst);
            myPLC.WriteTag(hammerTag);
        }
        /// <summary>
        /// Writes the state values of checkboxes to the PLC.
        /// </summary>
        /// <param name="bools">Boolean array for the state values of checkboxes (whether they are checked).</param>
        public void CheckboxWrite(bool[] bools)
        {
            BadTagReadChecker(gui_general_struct);
            if (TagNullChecker(gui_general_struct))
                return;
            Structures.GUI_GENERAL_STRUCT chkBox = (Structures.GUI_GENERAL_STRUCT)udtEnc.ToType(gui_general_struct, typeof(Structures.GUI_GENERAL_STRUCT));
            chkBox.boolVals = udtEnc.FromBoolArray(bools);
            gui_general_struct.Value = udtEnc.FromType(chkBox);
            myPLC.WriteTag(gui_general_struct);
        }
        /// <summary>
        /// Writes the value of cycleCounter to the PLC.
        /// </summary>
        /// <param name="textboxText">Integer value of cycleCounter.</param>
        /// <param name="textboxValue">Unused, but necessary if more than one control needs this write function.</param>
        public void TextboxWriteActiveUpdate(int textboxText, int textboxValue)
        {
            BadTagReadChecker(activeUpdater);
            if (TagNullChecker(activeUpdater))
                return;
            Structures.ACTIVE_UPDATE_STRUCT cycActive = (Structures.ACTIVE_UPDATE_STRUCT)udtEnc.ToType(activeUpdater, typeof(Structures.ACTIVE_UPDATE_STRUCT));
            cycActive.Cycle_Active_Counter = textboxText;
            activeUpdater.Value = udtEnc.FromType(cycActive);
            myPLC.WriteTag(activeUpdater);
            lostFocus.Name = "lostFocus[0]";
            lostFocus.Value = true;
            myPLC.WriteTag(lostFocus);
        }
        /// <summary>
        /// Writes the converted integer value from a textbox representing a DINT datatype (in the PLC) to the PLC.
        /// </summary>
        /// <param name="textboxText">Integer representing what a user entered in a textbox.</param>
        /// <param name="textboxValue">Integer representing which textbox called this method.</param>
        public void TextboxWriteGuiGeneral(int textboxText, int textboxValue)
        {
            BadTagReadChecker(gui_general_struct);
            if (TagNullChecker(gui_general_struct))
                return;
            Structures.GUI_GENERAL_STRUCT singleTag = (Structures.GUI_GENERAL_STRUCT)udtEnc.ToType(gui_general_struct, typeof(Structures.GUI_GENERAL_STRUCT));
            if (textboxValue == 1)
            {
                singleTag.Cycle_Setpoint = textboxText;
                lostFocus.Name = "lostFocus[1]";
            }
            else
            {
                singleTag.Hammer_Retract = textboxText;
                lostFocus.Name = "lostFocus[2]";
            }
            lostFocus.Value = true;
            gui_general_struct.Value = udtEnc.FromType(singleTag);
            myPLC.WriteTag(gui_general_struct);
            myPLC.WriteTag(lostFocus);
        }
        /// <summary>
        /// Writes the converted Single value representing a REAL datatype (in the PLC) to the PLC.
        /// </summary>
        /// <param name="textboxText">Single representing what a user entered in a textbox.</param>
        /// <param name="textboxValue">Integer representing which textbox called this method.</param>
        public void TextboxWriteGuiGeneral(Single textboxText, int textboxValue)
        {
            BadTagReadChecker(gui_general_struct);
            if (TagNullChecker(gui_general_struct))
                return;
            Structures.GUI_GENERAL_STRUCT realVar = (Structures.GUI_GENERAL_STRUCT)udtEnc.ToType(gui_general_struct, typeof(Structures.GUI_GENERAL_STRUCT));
            if (textboxValue == 3)
            {
                realVar.Hammer_Setpoint = textboxText;
                lostFocus.Name = "lostFocus[3]";
            }
            else
            {
                realVar.Velocity_Value = textboxText;
                lostFocus.Name = "lostFocus[4]";
            }
            lostFocus.Value = true;
            gui_general_struct.Value = udtEnc.FromType(realVar);
            myPLC.WriteTag(gui_general_struct);
            myPLC.WriteTag(lostFocus);
        }
        /// <summary>
        /// Writes to a heartbeat tag constantly to ensure the connection between this C# application
        /// and a PLC. If this application is closed/faults for more than 5 seconds, then 
        /// this method will not be called, and the PLC will respond by stopping any active cycles.
        /// </summary>
        public void HeartBeatWriter()
        {
            BadTagReadChecker(activeUpdater);
            if (TagNullChecker(activeUpdater))
                return;
            Structures.ACTIVE_UPDATE_STRUCT cycActive = (Structures.ACTIVE_UPDATE_STRUCT)udtEnc.ToType(activeUpdater, typeof(Structures.ACTIVE_UPDATE_STRUCT));
            bool[] heartbeat = udtEnc.ToBoolArray(cycActive.boolVals);
            heartbeat[0] = heartbeatBit = !heartbeatBit;
            cycActive.boolVals = udtEnc.FromBoolArray(heartbeat);
            activeUpdater.Value = udtEnc.FromType(cycActive);
            myPLC.WriteTag(activeUpdater);
        }
    }
}
