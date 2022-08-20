using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Forms;
using MetroFramework.Controls;
using Logix;
using System.Runtime.InteropServices;
namespace MicroPCGUI
{
    public partial class MicroPCUI : MetroForm
    {
        public struct GUI_Test
        {
            public Single Hammer_Setpoint;
            public Single Hammer_Feedback;
            public Int16 cycleSetPoint;
            public Int16 cycleActiveCount;
            public Int16 Hammer_Mode;
            public Int16 Hammer_Retract_Time;
            public int cycleReset;
            public int cycleStart;
            public int cycleStop;
            public int eStopReset;
            public int Stroke_Verify;
            public int Part_Detect;
            public int boolVals;
            public string Data_Display;
        };
        public struct STRUCT_A
        {
            // boolean values are packed into 32-bit ints
            public int boolVals;
            public Int32 Cycle_Setpoint;
            public Int32 Cycle_Active_Count;
            public Int32 Hammer_Retract;
            public Single Hammer_Setpoint;
            public Single Hammer_Feedback;
            public Data_Display data_display;
        };
        public struct Data_Display
        {
            public Int32 LEN;
            // marshal the .DATA member as a string
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 82)]
            public string DATA;
        };
        List<MicroPCUI> formInstances = new List<MicroPCUI>(7);
        private Controller myPLC = new Controller();
        private Tag hammerMode = new Tag("hammerMode");
        Dictionary<int, string> impactFrame = new Dictionary<int, string>();
        int seqCount, totalSeqCount;
        bool comboReady = false;
        Tag struct_atag = new Tag("struct_a", Logix.Tag.ATOMIC.OBJECT);
        Tag gui_test = new Tag("gui_Test", Logix.Tag.ATOMIC.OBJECT);
        DTEncoding udtEnc = new DTEncoding();
        bool[] bits;

        public MicroPCUI()
        {
            InitializeComponent();
            List<MicroPCUI> formInstances = new List<MicroPCUI>(7);
            Control.CheckForIllegalCrossThreadCalls = false;
            myImpactFrameArray();
            myPLC.IPAddress = "169.169.1.10";
            myPLC.CPUType = Controller.CPU.LOGIX;
            myPLC.Path = "0";
            myPLC.Timeout = 3000;
            myPLC.Connect();
            if (myPLC.Connect() != ResultCode.E_SUCCESS)
            {
                Console.Write("Failure.");
                MessageBox.Show(myPLC.ErrorString, this.Text);
                return;
            }
            if (myPLC.IsConnected)
            {
                Console.WriteLine("Connected.");
            }
        }
        private void myImpactFrameArray()
        {
            MetroComboBox impactFrameArray = new MetroComboBox();
            // probably doesn't need to be here Dictionary<int, string> impactFrame = new Dictionary<int, string>();
            impactFrame[1] = "SELECT BELOW";
            impactFrame[2] = "RED";
            impactFrame[3] = "GREEN";
            impactFrame[4] = "ORANGE";
            impactFrame[5] = "BLUE";
            impactFrame[6] = "YELLOW";
            impactFrame[7] = "VIOLET";
            BindingSource bindingSource = new BindingSource(impactFrame, null);
            impactFrameArrayDrop.DataSource = bindingSource;
            impactFrameArrayDrop.DisplayMember = "Value";
            impactFrameArrayDrop.ValueMember = "Value";
            comboReady = true;
        }
        private void impactFrameArrayDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboReady)
            {
                int placeholder = impactFrameArrayDrop.SelectedIndex;
                switch(placeholder)
                {
                    case 1:
                        RedFrame();
                        break;
                    case 2:
                        GreenFrame();
                        break;
                    case 3:
                        OrangeFrame();
                        break;
                    case 4:
                        BlueFrame();
                        break;
                    case 5:
                        YellowFrame();
                        break;
                    case 6:
                        VioletFrame();
                        break;
                    default:
                        break;
                }
            }
        }

        private void VioletFrame()
        {
            this.Hide();
            formInstances.Clear();
            formInstances.Add(new MicroPCUI());
            formInstances[formInstances.Count - 1].Show();
        }

        private void YellowFrame()
        {
            this.Hide();
            formInstances.Clear();
            formInstances.Add(new MicroPCUI());
            //Not sure how to lessen .exe speed here.
            formInstances[formInstances.Count - 1].Show();
        }

        private void BlueFrame()
        {
            this.Hide();
            formInstances.Clear();
            formInstances.Add(new MicroPCUI());
            formInstances[formInstances.Count - 1].Show();
        }

        private void OrangeFrame()
        {
            this.Hide();
            formInstances.Clear();
            formInstances.Add(new MicroPCUI());
            formInstances[formInstances.Count - 1].Show();
        }

        private void GreenFrame()
        {
            this.Hide();
            formInstances.Clear();
            formInstances.Add(new MicroPCUI());
            formInstances[formInstances.Count - 1].Show();
            //visibility of buttons goes here
        }

        private void RedFrame()
        {
            this.Hide();
            formInstances.Clear();
            formInstances.Add(new MicroPCUI());
            formInstances[formInstances.Count - 1].Show();
        }

        private void startCycle_Click(object sender, EventArgs e)
        {
            //startcyc
        }

        private void stopCycle_Click(object sender, EventArgs e)
        {
            //stopcyc
        }

        private void eStop_Click(object sender, EventArgs e)
        {
            //e-stop button
        }

        private void dataDisplay_Click(object sender, EventArgs e)
        {
            //reference to that string array in factorytalk at index 0
        }

        private void handModeRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (handModeRadio.Checked)
            {
                hammerMode.Value = 1;
                myPLC.WriteTag(hammerMode);
            }
        }
        //send to central function to reduce lines
        private void automaticMode_CheckedChanged(object sender, EventArgs e)
        {
            if (automaticMode.Checked)
            {
                hammerMode.Value = 2;
                myPLC.WriteTag(hammerMode);
            }
        }

        private void keyenceMode_CheckedChanged(object sender, EventArgs e)
        {
            if (keyenceMode.Checked)
            {
                hammerMode.Value = 5;
                myPLC.WriteTag(hammerMode);
            }
        }
        private void cycleCounter_Click(object sender, EventArgs e)
        {

        }

        private void seqCounter_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int i = 0;
            cycleCounter.Text = i + ""; // same as i.ToString();
            i++; //change this to ONLY increase if the cycle actually goes up!
            /*if(i == totalCycleCount)
            {
                i = 0; //ONLY change to 0 when changing to a new cycle
            }*/

        }

        private void dataDisplayLbl_Click(object sender, EventArgs e)
        {
            //this isn't required, need to update this based on various statuses of system
            //point to array position zero
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //let the user edit a value in whenever they want, possible bugs
            cycleCounter.Text = seqCount + ""; // same as i.ToString();
            seqCount++; //!!!!!!!!!!change this to ONLY increase if the sequence actually goes up! (use controller tags)
            if (seqCount == totalSeqCount)
            {
                seqCount = 0; //ONLY change to 0 when changing to a new cycle
                totalSeqCount = 0;
            }
        }

        private void resetCount_Click(object sender, EventArgs e)
        {
            //counter = 0;
        }
        private void guiTesterBtnRead_Click(object sender, EventArgs e)
        {
            try
            {
                // read the tag
                if (myPLC.ReadTag(struct_atag) != Logix.ResultCode.E_SUCCESS)
                {
                    if (myPLC.ErrorCode == 0x10312)
                        MessageBox.Show(myPLC.ErrorString + Environment.NewLine + "If this is a 5069 CompactLogix 5380 or 5480, Disconnect, clear CIP Path and reconnect", "Error Reading Tag");
                    else
                        MessageBox.Show("Error : " + myPLC.ErrorString, this.Text);
                    return;
                }
                // decode
                DecodeStructA();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guiTesterBtnWrite_Click(object sender, EventArgs e)
        {
            // get data for STRUCT_A
            EncodeStructA();
            // write it to PLC
            if (myPLC.WriteTag(struct_atag) != Logix.ResultCode.E_SUCCESS)
                MessageBox.Show(struct_atag.ErrorString);
        }
        private void DecodeStructA()
        {
            try
            {
                //
                // decode tag struct_a to STRUCT_A User Data Type
                //
                STRUCT_A struct_a = (STRUCT_A)udtEnc.ToType(struct_atag, typeof(STRUCT_A));

                // 
                // convert the boolVals member to bits
                //
                bits = udtEnc.ToBoolArray(struct_a.boolVals);

                //
                // update fields
                //
                strokeVerifyChk.Checked = bits[0];
                partDetectChk.Checked = bits[1];
                cycleSetPoint.Text = struct_a.Cycle_Setpoint.ToString();
                cycleCounter.Text = struct_a.Cycle_Active_Count.ToString();
                hammerSP.Text = struct_a.Hammer_Setpoint.ToString();
                hammerFeedback.Text = struct_a.Hammer_Feedback.ToString();
                hammerRetract.Text = struct_a.Hammer_Retract.ToString();
                dataDisplayLbl.Text = struct_a.data_display.DATA.ToString();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Encodes values from STRUCT_A to UDT for writing to the PLC.
        /// </summary>
        /// <returns></returns>
        private void EncodeStructA()
        {

            STRUCT_A struct_a = new STRUCT_A();
            bool[] limits = new bool[2];

            // populate STRUCT_A members
            try
            {
                // get the bit values from check box
                limits[0] = strokeVerifyChk.Checked;
                limits[1] = partDetectChk.Checked;
                // convert bool[] to Int32
                struct_a.boolVals = udtEnc.FromBoolArray(limits);

                // get values for remaining members
                struct_a.Cycle_Active_Count = Convert.ToInt32(cycleCounter.Text);
                struct_a.Cycle_Setpoint = Convert.ToInt32(cycleSetPoint.Text);
                struct_a.Hammer_Retract = Convert.ToInt32(hammerRetract.Text);
                struct_a.Hammer_Setpoint = Convert.ToSingle(hammerSP.Text);
                struct_a.Hammer_Feedback = Convert.ToSingle(hammerFeedback.Text);
                struct_a.data_display.DATA = Convert.ToString(dataDisplayLbl.Text);

                // encode STRUCT_A for writing
                struct_atag.Value = udtEnc.FromType(struct_a);

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Decodes UDT tag "struct_a" to STRUCT_A 
        /// </summary>
        /// 
        /*
        private void DecodeStructA()
        {
            try
            {
                //
                // decode tag struct_a to STRUCT_A User Data Type
                //
                GUI_Test gui_Tester = (GUI_Test)udtEnc.ToType(gui_test, typeof(GUI_Test));

                // 
                // convert the boolVals member to bits
                //
                bits = udtEnc.ToBoolArray(gui_Tester.boolVals);

                //
                // update fields
                //
                strokeVerifyChk.Checked = bits[0];
                partDetectChk.Checked = bits[1];
                cycleCounter.Text = gui_Tester.cycleActiveCount.ToString();
                cycleSetPoint.Text = gui_Tester.cycleSetPoint.ToString();
                hammerSP.Text = gui_Tester.Hammer_Setpoint.ToString();
                hammerRetract.Text = gui_Tester.Hammer_Retract_Time.ToString();
                hammerFeedback.Text = gui_Tester.Hammer_Feedback.ToString();
                dataDisplayLbl.Text = gui_Tester.Data_Display;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Encodes values from STRUCT_A to UDT for writing to the PLC.
        /// </summary>
        /// <returns></returns>
        private void EncodeStructA()
        {

            GUI_Test gui_Tester = new GUI_Test();
            bool[] values = new bool[2];

            // populate STRUCT_A members
            try
            {
                // get the bit values from check box
                gui_Tester.boolVals = udtEnc.FromBoolArray(values);
                values[0] = strokeVerifyChk.Checked;
                values[1] = partDetectChk.Checked;

                // get values for remaining members
                gui_Tester.cycleActiveCount = Convert.ToInt16(cycleCounter.Text);
                gui_Tester.cycleSetPoint = Convert.ToInt16(cycleSetPoint.Text);
                //useless, this is more complicatedgui_Tester.Hammer_Mode = Convert.ToInt16(hammerMode.Text);
                gui_Tester.Hammer_Retract_Time = Convert.ToInt16(hammerRetract.Text);
                gui_Tester.Hammer_Setpoint = Convert.ToSingle(hammerSP.Text);
                gui_Tester.Hammer_Feedback = Convert.ToSingle(hammerFeedback.Text);
                gui_Tester.Data_Display = Convert.ToString(dataDisplayLbl.Text);

                // encode STRUCT_A for writing
                //Encoded_TypeCode = udtEnc.GetDataTypeCode(gui_test);
                //UDT_TypeCode = BitConverter.ToUInt16(Encoded_TypeCode, 0);
                gui_test.Value = udtEnc.FromType(gui_Tester);

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }*/
    }
}
