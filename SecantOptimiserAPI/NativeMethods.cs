using System;
using System.Runtime.InteropServices;

namespace SecantWrapper
{
    public static class NativeMethods
    {
        [DllImport("wopt64dll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool InitializeLicense(string licenseKey);

        [DllImport("wopt64dll.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool Optimise(IntPtr hWnd,
            [MarshalAs(UnmanagedType.LPStr)] string pszDir,
            [MarshalAs(UnmanagedType.LPStr)] string pszJob,
            [MarshalAs(UnmanagedType.LPStr)] string pszSystem,
            Int64 jFlags,
            IntPtr lpfnCallBack);
    }
}
