using System;
using System.Runtime.InteropServices;

namespace R4iny.Library.Gui.ImportedMethods
{
    public class DwmApi
    {
        // Import dwmapi.dll and define DwmSetWindowAttribute in C# corresponding to the native function.
        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
#pragma warning disable CA1401 // P/Invokes should not be visible
        public static extern long DwmSetWindowAttribute(IntPtr hwnd,
#pragma warning restore CA1401 // P/Invokes should not be visible
                                                        DwmWindowAttribute attribute,
                                                        ref DwmWindowCornerPreference pvAttribute,
                                                        uint cbAttribute);
    }

    // The enum flag for DwmSetWindowAttribute's second parameter, which tells the function what attribute to set.
    public enum DwmWindowAttribute
    {
        WindowCornerPreference = 33
    }

    // The DWM_WINDOW_CORNER_PREFERENCE enum for DwmSetWindowAttribute's third parameter, which tells the function
    // what value of the enum to set.
    public enum DwmWindowCornerPreference
    {
        Default = 0,
        DoNotRound = 1,
        Round = 2,
        RoundSmall = 3
    }
}
