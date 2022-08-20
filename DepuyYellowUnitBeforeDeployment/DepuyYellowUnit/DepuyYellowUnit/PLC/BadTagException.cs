using System;
namespace DepuyYellowUnit.PLC
{
    /// <summary>
    /// Custom exception only regarding tag read operations with a PLC.
    /// If a tag is read with a bad error code 
    /// (due to no tag existing, controller timeout, unplugged controller, or power blackout),
    /// then this exception is called and the user must fix the problem.
    /// </summary>
    /// <remarks>
    /// This software cannot fix this error, it can only control it by avoiding
    /// a crash completely due to this. This software is entirely reliant on 
    /// good PLC communication between the device this software runs on and the PLC itself.
    /// If this PLC connection is severed in some way, then this software cannot function without external help.
    /// </remarks>
    [Serializable]
    public class BadTagException : Exception
    {
        public string TagName { get; }

        public BadTagException() { }

        public BadTagException(string message)
        : base(message) { }

        public BadTagException(string message, Exception inner)
        : base(message, inner) { }
        /// <summary>
        /// A bad read on a tag exception.
        /// </summary>
        /// <param name="tagName">The name of a tag as addressed in the PLC.</param>
        /// <param name="tagType">Type of a tag. <para /> 1 is for any tag that is like an UDT or an array because it has bracket syntax such as [1] to indicate the first index. <para /> 0 is for any other type of tag.</param>
        public BadTagException(Logix.Tag tagName, int tagType)
        {
            switch (tagType)
            {
                case 1: //case 1 is here for the many tags that are UDTs and are arrays such as gui_general_struct[4]
                    TagName = tagName.Name.Substring(0, tagName.Name.Length - 3);
                    break;
                default:
                    TagName = tagName.Name;
                    break;
            }
        }
    }
}
