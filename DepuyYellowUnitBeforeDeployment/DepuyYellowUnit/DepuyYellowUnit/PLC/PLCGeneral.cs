using Logix;
namespace DepuyYellowUnit.PLC
{
    /// <summary>
    /// Base class for all PLCGeneral classes
    /// </summary>
    public abstract class PLCGeneral : PLCBase
    {
        public int InvertedStop { get; set; }
        public int PBTracker { get; set; }
        protected Tag activeUpdater;
        protected Tag hammerTag;
        protected Tag gui_pbs;
        protected Tag gui_general_struct;

        protected PLCGeneral(int impactFrameValue, MetroFramework.Forms.MetroForm screen)
        : base(impactFrameValue, screen)
        {
            gui_general_struct = new Tag($"gui_general_struct[{impactFrame}]", Tag.ATOMIC.OBJECT);
            gui_pbs = new Tag($"gui_pbs_struct[{impactFrame}]", Tag.ATOMIC.OBJECT);
            hammerTag = new Tag($"hammer_struct[{impactFrame}]", Tag.ATOMIC.OBJECT);
            activeUpdater = new Tag($"active_update_struct[{impactFrame}]", Tag.ATOMIC.OBJECT);
        }
    }
}
