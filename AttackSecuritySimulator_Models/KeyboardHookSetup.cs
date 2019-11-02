using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace AttackSecuritySimulator_Models
{
    /// <summary>
    /// Imported some functions from user32.dll to create a keyboard hook.
    /// A wrapper class for setting up the hook.
    /// Requires a definition for the hook call back when setting it up.
    /// 
    /// Reference: https://blogs.msdn.microsoft.com/toub/2006/05/03/low-level-keyboard-hook-in-c/
    /// </summary>
    public class KeyboardHookSetup
    {
        //Hook procedure: Low Level Keyboard
        private const int WH_KEYBOARD_LL = 13;
        //Key state: On Key Down
        private const int WM_KEYDOWN = 0x0100;
        public int KeyStateDown
        {
            get
            {
                return WM_KEYDOWN;
            }
        }
        private IntPtr hookID = IntPtr.Zero;

        public void SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {

                hookID = SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        public void UnHook()
        {
            UnhookWindowsHookEx(hookID);
        }

        #region user32.dll Imports

        /// <summary>
        /// Callback delegate used with the SetWindowsHookEx function.
        /// The system calls this function every time a new keyboard input event is about to be posted into a thread input queue.
        /// 
        /// Docs:       https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms644985(v=vs.85)
        /// 
        /// Params:
        ///     nCode:      A code the hook procedure uses to determine how to process the message.
        ///     wParam:     Keyboard message identifier
        ///     lParam:     A pointer to a KBDLLHOOKSTRUCT struct
        /// </summary>
        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private LowLevelKeyboardProc keyPressCallback;
        //Callback will be defined in another class
        public LowLevelKeyboardProc KeyPressedCallback
        {
            set
            {
                keyPressCallback = value;
            }
        }
        /// <summary>
        /// Creates the hook procedure to monitor the system for certain types of events.
        /// 
        /// Docs: https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowshookexa
        /// 
        /// Params:
        ///     idHook:     Type of hook procedure to be used
        ///     lfpn:       Pointer to the delegate that executes when the hook proc occurs
        ///     hMod:       A handle to the DLL containing the hook procedure
        ///     dwThreadId: Process ID, setting to 0 applies the hook globally
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);


        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        #endregion


    }
}
