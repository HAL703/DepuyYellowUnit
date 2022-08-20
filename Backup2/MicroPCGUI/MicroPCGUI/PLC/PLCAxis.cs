using Logix;
namespace MicroPCGUI.PLC
{
    /// <summary>
    /// Base class for all PLCAxis classes
    /// </summary>
    public abstract class PLCAxis : PLCBase
    {
        protected readonly int axisFrame;
        protected Tag z_axis;
        protected Tag x_axis;
        protected Tag mz_axis;
        protected Tag mx_axis;
        protected Tag YellowHMIMapping;
        protected Tag FaultReset;
        protected string textboxText;
        protected int textboxValue;

        protected PLCAxis(int impactFrameValue, MetroFramework.Forms.MetroForm screen)
        : base(impactFrameValue, screen)
        {
            axisFrame = impactFrameValue;
            z_axis = new Tag($"z_axis[{axisFrame}]", Tag.ATOMIC.OBJECT);
            x_axis = new Tag($"x_axis[{axisFrame}]", Tag.ATOMIC.OBJECT);
            mz_axis = new Tag($"mz_axis[{axisFrame}]", Tag.ATOMIC.OBJECT);
            mx_axis = new Tag($"mx_axis[{axisFrame}]", Tag.ATOMIC.OBJECT);
            YellowHMIMapping = new Tag("YellowHMIMapping", Tag.ATOMIC.OBJECT);
            FaultReset = new Tag("fault_reset", Tag.ATOMIC.BOOL);
        }
    }
}
