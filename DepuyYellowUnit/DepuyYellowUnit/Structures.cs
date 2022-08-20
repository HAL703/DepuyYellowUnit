using System;
using System.Runtime.InteropServices;
namespace DepuyYellowUnit
{
    /// <summary>
    /// Data structures used for reading/writing values to and from a Rockwell PLC.
    /// These map over to UDTs in a Rockwell PLC, which are user-defined data types.
    /// Essentially, they are structs in C#, so structs can represent them 
    /// with the help of additional software/drivers.
    /// </summary>
    /// <remarks>
    ///     NOTE: BOOL values are packed into 32-bit ints in C#. <para />
    ///     NOTE: REAL values in the PLC are Single values in C#. <para />
    ///     NOTE: DINT values in the PLC are Int32 values in C#. <para />
    /// </remarks>
    public class Structures
    {
        /// <summary>
        /// GUI_GENERAL_STRUCT User Defined Data Type
        /// </summary>
        /// <remarks>        
        /// This structure represents the
        /// user-defined type GUI_GENERAL_STRUCT in the PLC
        /// 
        /// GUI_GENERAL_STRUCT.Stroke_Verify    (BOOL)
        /// GUI_GENERAL_STRUCT.Part_Detect      (BOOL)
        /// GUI_GENERAL_STRUCT.Cycle_Setpoint   (DINT)
        /// GUI_GENERAL_STRUCT.Hammer_Retract   (DINT)
        /// GUI_GENERAL_STRUCT.Hammer_Setpoint  (REAL)
        /// GUI_GENERAL_STRUCT.Data_Display     (STRING)
        /// GUI_GENERAL_STRUCT.Velocity_Value   (REAL)
        /// 
        /// In the PLC, define the GUI_GENERAL_STRUCT user defined data type,
        /// then create a Controller Scope tag called "gui_general_struct"
        /// 
        ///</remarks>
        public struct GUI_GENERAL_STRUCT
        {
            public int boolVals;
            public Int32 Cycle_Setpoint;
            public Int32 Hammer_Retract;
            public Single Hammer_Setpoint;
            public DATA_DISPLAY data_display;
            public Single Velocity_Value;
        };
        /// <summary>
        /// GUI_PBS_STRUCT User Defined Data Type
        /// </summary>
        /// <remarks>        
        /// This structure represents the
        /// user-defined type GUI_PBS_STRUCT in the PLC
        /// 
        /// GUI_PBS_STRUCT.cycleStart           (BOOL)
        /// GUI_PBS_STRUCT.cycleStop            (BOOL)
        /// GUI_PBS_STRUCT.cycleReset           (BOOL)
        /// GUI_PBS_STRUCT.eStopReset           (BOOL)
        /// GUI_PBS_STRUCT.psiUp                (BOOL)
        /// GUI_PBS_STRUCT.psiDown              (BOOL)
        /// GUI_PBS_STRUCT.resetVis             (DINT)
        /// 
        /// In the PLC, define the GUI_PBS_STRUCT user defined data type,
        /// then create a Controller Scope tag called "gui_pbs_struct"
        /// 
        ///</remarks>
        public struct GUI_PBS_STRUCT
        {
            public int boolPBVals;
            public Int32 resetVis;
        };
        /// <summary>
        /// HAMMER_STRUCT User Defined Data Type
        /// </summary>
        /// <remarks>        
        /// This structure represents the
        /// user-defined type GUI_PBS_STRUCT in the PLC
        /// 
        /// HAMMER_STRUCT.hammerMode            (BOOL)
        /// 
        /// In the PLC, define the HAMMER_STRUCT user defined data type,
        /// then create a Controller Scope tag called "hammer_struct"
        /// 
        ///</remarks>
        public struct HAMMER_STRUCT
        {
            public Int32 Hammer_Mode;
        };
        /// <summary>
        /// ACTIVE_UPDATE_STRUCT User Defined Data TYpe
        /// </summary>
        /// <remarks>        
        /// This structure represents the
        /// user-defined type ACTIVE_UPDATE_STRUCT in the PLC
        /// 
        /// ACTIVE_UPDATE_STRUCT.Hammer_Feed           (REAL)
        /// ACTIVE_UPDATE_STRUCT.Cycle_Active_Counter  (DINT)
        /// ACTIVE_UPDATE_STRUCT.Velocity_Feed         (REAL)
        /// ACTIVE_UPDATE_STRUCT.Heartbeat_Bit         (BOOL)
        /// 
        /// In the PLC, define the ACTIVE_UPDATE_STRUCT user defined data type,
        /// then create a Controller Scope tag called "active_update_struct"
        /// 
        ///</remarks>
        public struct ACTIVE_UPDATE_STRUCT
        {
            public Single Hammer_Feed;
            public Int32 Cycle_Active_Counter;
            public Single Velocity_Feed;
            public int boolVals;
        };
        /// <summary>
        /// Data_Display STRING data type
        /// </summary>
        /// <remarks>        
        /// This structure represents the
        /// STRING data type Data_Display in the PLC
        /// 
        /// Data_Display.Stroke_Verify    (DINT)
        /// Data_Display.Part_Detect      (SINT[82])
        /// 
        /// In the PLC, define Data_Display as a STRING data type inside GUI_GENERAL_STRUCT.
        /// Verify that DATA is of size 82.
        /// 
        ///</remarks>
        public struct DATA_DISPLAY
        {
            public Int32 LEN;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 82)] //have to marshal types here, mainly due to it being a SINT array in the PLC
            public string DATA;
        };
        /// <summary>
        /// Z_AXIS_STRUCT User Defined Data Type
        /// </summary>
        /// <remarks>        
        /// This structure represents the
        /// user-defined type Z_AXIS_STRUCT in the PLC
        /// 
        /// Z_AXIS_STRUCT.Pos_Req_Hold  (BOOL)
        /// Z_AXIS_STRUCT.Pos_Req_CMD   (BOOL)
        /// Z_AXIS_STRUCT.Set_Zero      (BOOL)
        /// Z_AXIS_STRUCT.Ex_PB         (BOOL)
        /// Z_AXIS_STRUCT.Re_PB         (BOOL)
        /// Z_AXIS_STRUCT.HH_EN         (BOOL)
        /// Z_AXIS_STRUCT.LL_EN         (BOOL)
        /// Z_AXIS_STRUCT.Display_Pos   (REAL)
        /// Z_AXIS_STRUCT.Req_Pos       (REAL)
        /// 
        /// In the PLC, define the Z_AXIS_STRUCT user defined data type,
        /// then create a Controller Scope tag called "z_axis"
        /// 
        ///</remarks>
        public struct Z_AXIS_STRUCT
        {
            public int boolVals;
            public Single Display_Pos;
            public Single Req_Pos;
        };
        /// <summary>
        /// X_AXIS_STRUCT User Defined Data Type
        /// </summary>
        /// <remarks>        
        /// This structure represents the
        /// user-defined type X_AXIS_STRUCT in the PLC
        /// 
        /// X_AXIS_STRUCT.Pos_Req_Hold  (BOOL)
        /// X_AXIS_STRUCT.Pos_Req_CMD   (BOOL)
        /// X_AXIS_STRUCT.Set_Home      (BOOL)
        /// X_AXIS_STRUCT.L_PB          (BOOL)
        /// X_AXIS_STRUCT.R_PB          (BOOL)
        /// X_AXIS_STRUCT.Reset_Fault   (BOOL)
        /// X_AXIS_STRUCT.Fault         (BOOL)
        /// X_AXIS_STRUCT.Actual_MM     (REAL)
        /// X_AXIS_STRUCT.Req_Pos       (REAL)
        /// 
        /// In the PLC, define the X_AXIS_STRUCT user defined data type,
        /// then create a Controller Scope tag called "x_axis"
        /// 
        ///</remarks>
        public struct X_AXIS_STRUCT
        {
            public int boolVals;
            public Single Actual_MM; //blue boxes
            public Single Pos_Req; //black text that needs value from PLC
        };
        /// <summary>
        /// MZ_AXIS_STRUCT User Defined Data Type
        /// </summary>
        /// <remarks>        
        /// This structure represents the
        /// user-defined type MZ_AXIS_STRUCT in the PLC
        /// 
        /// MZ_AXIS_STRUCT.Pos_Req_Hold  (BOOL)
        /// MZ_AXIS_STRUCT.Pos_Req_CMD   (BOOL)
        /// MZ_AXIS_STRUCT.Set_Home      (BOOL)
        /// MZ_AXIS_STRUCT.CW_PB         (BOOL)
        /// MZ_AXIS_STRUCT.CCW_PB        (BOOL)
        /// MZ_AXIS_STRUCT.Reset_Fault   (BOOL)
        /// MZ_AXIS_STRUCT.Fault         (BOOL)
        /// MZ_AXIS_STRUCT.Actual_Degree (REAL)
        /// MZ_AXIS_STRUCT.Req_Pos       (REAL)
        /// 
        /// In the PLC, define the MZ_AXIS_STRUCT user defined data type,
        /// then create a Controller Scope tag called "mz_axis"
        /// 
        ///</remarks>
        public struct MZ_AXIS_STRUCT
        {
            public int boolVals;
            public Single Actual_Degree;
            public Single Pos_Req;
        };
        /// <summary>
        /// MX_AXIS_STRUCT User Defined Data Type
        /// </summary>
        /// <remarks>        
        /// This structure represents the
        /// user-defined type MX_AXIS_STRUCT in the PLC
        /// 
        /// MX_AXIS_STRUCT.Pos_Req_Hold  (BOOL)
        /// MX_AXIS_STRUCT.Pos_Req_CMD   (BOOL)
        /// MX_AXIS_STRUCT.Set_Home      (BOOL)
        /// MX_AXIS_STRUCT.CW_PB         (BOOL)
        /// MX_AXIS_STRUCT.CCW_PB        (BOOL)
        /// MX_AXIS_STRUCT.Reset_Fault   (BOOL)
        /// MX_AXIS_STRUCT.Fault         (BOOL)
        /// MX_AXIS_STRUCT.Actual_Degree (REAL)
        /// MX_AXIS_STRUCT.Req_Pos       (REAL)
        /// 
        /// In the PLC, define the MX_AXIS_STRUCT user defined data type,
        /// then create a Controller Scope tag called "mx_axis"
        /// 
        ///</remarks>
        public struct MX_AXIS_STRUCT
        {
            public int boolVals;
            public Single Actual_Degree;
            public Single Pos_Req;
        };
        /// <summary>
        /// YellowHMIMapping User Defined Data Type
        /// </summary>
        /// <remarks>        
        /// This structure represents the
        /// user-defined type YellowHMIMapping in the PLC
        /// 
        /// YellowHMIMapping.AKD_ENABLE        (BOOL)
        /// YellowHMIMapping.AKD_LIFT          (BOOL)
        /// YellowHMIMapping.AKD_LOWER         (BOOL)
        /// YellowHMIMapping.AKD_RESET         (BOOL)
        /// YellowHMIMapping.AKD_SP            (REAL)
        /// YellowHMIMapping.AKD_AV            (REAL)
        /// YellowHMIMapping.AKD_IMPACT        (DINT)
        /// YellowHMIMapping.AKD_HOA           (DINT)
        /// YellowHMIMapping.AKD_EXTRACT       (DINT)
        /// 
        /// In the PLC, define the YellowHMIMapping user defined data type,
        /// then create a Controller Scope tag called "YellowHMIMapping"
        /// 
        ///</remarks>
        public struct YellowHMIMapping
        {
            public int boolVals;
            public Single AKD_SP;
            public Single AKD_AV;
            public Int32 AKD_IMPACT;
            public Int32 AKD_HOA;
            public Int32 AKD_EXTRACT;
        };
    }
}
