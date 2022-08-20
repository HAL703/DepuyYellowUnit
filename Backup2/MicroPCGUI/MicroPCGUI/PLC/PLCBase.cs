using Logix;
using System.Windows.Forms;
using MetroFramework.Forms;
namespace MicroPCGUI.PLC
{
    /// <summary>
    /// Base class for all PLC-based classes that contains general PLC centric methods/values.
    /// </summary>
    /// <remarks>
    /// The PLC classes all use a driver for Allen-Bradley controllers called INGEAR.
    /// This software can only be run with an embedded, valid INGEAR license.
    /// </remarks>
    public abstract class PLCBase
    {
        public Controller myPLC = new Controller();
        protected DTEncoding udtEnc;
        protected Tag lostFocus;
        protected int impactFrame;
        protected bool[] pbValues = new bool[8];
        protected bool success = false;
        protected int retryAttempts = 4;
        protected MetroForm screenRef;
        protected bool heartbeatBit = false;

        protected PLCBase(int impactFrameValue, MetroForm screen)
        {
            screenRef = screen;
            impactFrame = impactFrameValue;
            udtEnc = new DTEncoding();
            lostFocus = new Tag
            {
                Name = "lostFocus[0]",
                DataType = Tag.ATOMIC.BOOL,
                Length = 1
            };
        }
        /// <summary>
        /// Prevents NullReferenceExceptions (hard crashes) from occurring as a result of lost communication 
        /// between this software and the PLC by checking the appropriate tag before controller UDT
        /// communication statements (see below).
        /// </summary>
        /// <param name="tag">Tag to be checked for a good read from the PLC</param>
        /// <remarks>
        /// Controller UDT communication/instantiation could also be known as statements like this:
        /// <code>Structures.ACTIVE_UPDATE_STRUCT cycActive = (Structures.ACTIVE_UPDATE_STRUCT)udtEnc.ToType(activeUpdater, typeof(Structures.ACTIVE_UPDATE_STRUCT));</code>
        /// These statements allow for UDT decoding/encoding (reading and writing) between the PLC data types and C# data types. 
        /// </remarks>
        protected void BadTagReadChecker(Tag tag)
        {
            try
            {
                if (myPLC.ReadTag(tag) != ResultCode.E_SUCCESS)
                {
                    MetroFramework.MetroMessageBox.Show(screenRef, $"CRITICAL ERROR: Controller most likely is disconnected in some way, please retry after reconnecting... " + myPLC.ErrorString + $". Retry attempts left = {retryAttempts}", "CRITICAL ERROR: BAD TAG READ", MessageBoxButtons.OK, MessageBoxIcon.Error, 90);
                    throw new BadTagException();
                }
                retryAttempts = 4;
            }
            catch (BadTagException)
            {
                retryAttempts--;
                if (retryAttempts == 0) 
                { 
                    MetroFramework.MetroMessageBox.Show(screenRef, $"CRITICAL ERROR: Maximum retry attempts exceeded. Please reconnect the controller appropriately and restart this program. Closing...", "CRITICAL ERROR: RETRY ATTEMPTS EXCEEDED", MessageBoxButtons.OK, MessageBoxIcon.Error, 90); 
                    System.Environment.Exit(0); 
                }
                myPLC = new Controller();
                PLCConnect("169.169.3.10");
                BadTagReadChecker(tag);
            }
        }
        /// <summary>
        /// Required function in the event that the PLC comes back online/continues functioning
        /// after a user clicks retry on a bad tag error prompt instead of the PLC 
        /// continuing functionality on the prompt before a user clicks retry. <para />
        /// If the user does the latter, then this function is ignored, but the former 
        /// requires this function as a hard crash will occur that's irrecoverable (NullReference).
        /// </summary>
        /// <param name="tag">Tag to be checked for a null value</param>
        /// <returns>Boolean value that returns from parent function if true</returns>
        protected bool TagNullChecker(Tag tag)
        {
            if (tag.Value == null)
                return true;
            return false;
        }
        /// <summary>
        /// Connects to a Rockwell PLC based on IP Address, type, and path.
        /// </summary>
        /// <param name="IPAddress">Represents the IP Address of the PLC</param>
        public void PLCConnect(string IPAddress)
        {
            myPLC.IPAddress = IPAddress;
            myPLC.CPUType = Controller.CPU.LOGIX;
            myPLC.Path = "0";
            myPLC.Timeout = 3000;
            if (retryAttempts == 0)
            {
                MetroFramework.MetroMessageBox.Show(screenRef, $"CRITICAL ERROR: Maximum retry attempts exceeded. Please reconnect the controller appropriately and restart this program. Closing...", "CRITICAL ERROR: RETRY ATTEMPTS EXCEEDED", MessageBoxButtons.OK, MessageBoxIcon.Error, 90);
                System.Environment.Exit(0);
            }
            if (myPLC.Connect() != ResultCode.E_SUCCESS)
            {
                retryAttempts--;
                var res = MetroFramework.MetroMessageBox.Show(screenRef, $"CRITICAL ERROR: Could not connect to the PLC. Please reconnect the PLC or restart this program if it continues to fail.", "CRITICAL ERROR: CONTROLLER CONNECTION TIMEOUT", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, 90);
                if (res == DialogResult.Retry) { PLCConnect("169.169.3.10"); } 
                if (res == DialogResult.Cancel) { MessageBox.Show("Error cancelled, exiting program..."); System.Environment.Exit(0); }
            }
        }

    }
}
