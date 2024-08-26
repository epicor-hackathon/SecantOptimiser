using SecantWrapper;
using System;

namespace SecantOptimiserAPI
{
    public class InvokeSecant
    {
        internal static bool  Call(string pszDir,string pszJob)
        {
            try
            {
                IntPtr hWnd = IntPtr.Zero; // Replace with actual window handle if needed

                string pszSystem = Directory.GetCurrentDirectory() + @"\Secant\";
                Int64 jFlags = 011; // Replace with actual flags if needed
                IntPtr lpfnCallBack = IntPtr.Zero; // Replace with actual callback if needed
                bool result = NativeMethods.Optimise(hWnd, pszDir, pszJob, pszSystem, jFlags, lpfnCallBack);
                return result;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
                return false;
            }
        }
    }
}
