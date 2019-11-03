using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace AttackSecuritySimulator_Models
{
    public static class KeyboardCipher
    {
        public static bool ShiftCheck()
        {
            Keys[] shiftKeys = new Keys[3];
            shiftKeys[0] = Keys.LShiftKey;
            shiftKeys[1] = Keys.RShiftKey;
            shiftKeys[2] = Keys.Shift;

            short state;

            for (int i = 0; i < shiftKeys.Length; i++)
            {
                state = GetAsyncKeyState(shiftKeys[i]);
                if (Convert.ToBoolean(state & 0x8000))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CapsCheck()
        {
            return GetKeyState(Keys.Capital) == 1 ? true : false;
        }

        public static string KeyTranslator(Keys virtualKeyCode, bool shiftOn, bool capsOn)
        {
            bool useLower;
            if (shiftOn && capsOn)
            {
                useLower = true;
            }
            else if (shiftOn || capsOn)
            {
                useLower = false;
            }
            else
            {
                useLower = true;
            }

            switch (virtualKeyCode)
            {
                //case Keys.KeyCode:
                //    break;
                //case Keys.Modifiers:
                //    break;
                //case Keys.None:
                //    break;
                //case Keys.LButton:
                //    return "[LClick]";
                //case Keys.RButton:
                //    return "[RClick]";
                //case Keys.Cancel:
                //    return "[Cancel]";
                //case Keys.MButton:
                //    return "[MClick]";
                //case Keys.XButton1:
                //    break;
                //case Keys.XButton2:
                //    break;
                case Keys.Back:
                    return "[BackSpace]";
                case Keys.Tab:
                    return "[Tab]";
                //case Keys.LineFeed:
                //    break;
                case Keys.Clear:
                    return "[Clear]";
                case Keys.Return:
                    return "[Enter]";
                //case Keys.Enter:
                //    break;
                case Keys.ShiftKey:
                    return "[Shift]";
                case Keys.ControlKey:
                    return "[Ctrl]";
                case Keys.Menu:
                    return "[Alt]";
                case Keys.Pause:
                    return "[Pause]";
                case Keys.Capital:
                    return "[CapsLock]";
                //case Keys.CapsLock:
                //    break;
                //case Keys.KanaMode:
                //    break;
                //case Keys.HanguelMode:
                //    break;
                //case Keys.HangulMode:
                //    break;
                //case Keys.JunjaMode:
                //    break;
                //case Keys.FinalMode:
                //    break;
                //case Keys.HanjaMode:
                //    break;
                //case Keys.KanjiMode:
                //    break;
                case Keys.Escape:
                    return "[Esc]";
                //case Keys.IMEConvert:
                //    break;
                //case Keys.IMENonconvert:
                //    break;
                //case Keys.IMEAccept:
                //    break;
                //case Keys.IMEAceept:
                //    break;
                //case Keys.IMEModeChange:
                //    break;
                case Keys.Space:
                    return " ";
                //case Keys.Prior:
                //    break;
                case Keys.PageUp:
                    return "[PageUp]";
                case Keys.Next:
                    return "[PageDown]";
                //case Keys.PageDown:
                //    break;
                case Keys.End:
                    return "[End]";
                case Keys.Home:
                    return "[Home]";
                case Keys.Left:
                    return "[Left]";
                case Keys.Up:
                    return "[Up]";
                case Keys.Right:
                    return "[Right]";
                case Keys.Down:
                    return "[Down]";
                case Keys.Select:
                    return "[Select]";
                case Keys.Print:
                    return "[Print]";
                //case Keys.Execute:
                //    break;
                //case Keys.Snapshot:
                //    break;
                case Keys.PrintScreen:
                    return "[PrtScr]";
                case Keys.Insert:
                    return "[Insert]";
                case Keys.Delete:
                    return "[Delete]";
                case Keys.Help:
                    return "[Help]";
                case Keys.D0:
                    return shiftOn ? ")" : "0";
                case Keys.D1:
                    return shiftOn ? "!" : "1";
                case Keys.D2:
                    return shiftOn ? "@" : "2";
                case Keys.D3:
                    return shiftOn ? "#" : "3";
                case Keys.D4:
                    return shiftOn ? "$" : "4";
                case Keys.D5:
                    return shiftOn ? "%" : "5";
                case Keys.D6:
                    return shiftOn ? "^" : "6";
                case Keys.D7:
                    return shiftOn ? "&" : "7";
                case Keys.D8:
                    return shiftOn ? "*" : "8";
                case Keys.D9:
                    return shiftOn ? "(" : "9";
                case Keys.A:
                    return useLower ? "a" : "A";
                case Keys.B:
                    return useLower ? "b" : "B";
                case Keys.C:
                    return useLower ? "c" : "C";
                case Keys.D:
                    return useLower ? "d" : "D";
                case Keys.E:
                    return useLower ? "e" : "E";
                case Keys.F:
                    return useLower ? "f" : "F";
                case Keys.G:
                    return useLower ? "g" : "G";
                case Keys.H:
                    return useLower ? "h" : "H";
                case Keys.I:
                    return useLower ? "i" : "I";
                case Keys.J:
                    return useLower ? "j" : "J";
                case Keys.K:
                    return useLower ? "k" : "K";
                case Keys.L:
                    return useLower ? "l" : "L";
                case Keys.M:
                    return useLower ? "m" : "M";
                case Keys.N:
                    return useLower ? "n" : "N";
                case Keys.O:
                    return useLower ? "o" : "O";
                case Keys.P:
                    return useLower ? "p" : "P";
                case Keys.Q:
                    return useLower ? "q" : "Q";
                case Keys.R:
                    return useLower ? "r" : "R";
                case Keys.S:
                    return useLower ? "s" : "S";
                case Keys.T:
                    return useLower ? "t" : "T";
                case Keys.U:
                    return useLower ? "u" : "U";
                case Keys.V:
                    return useLower ? "v" : "V";
                case Keys.W:
                    return useLower ? "w" : "W";
                case Keys.X:
                    return useLower ? "x" : "X";
                case Keys.Y:
                    return useLower ? "y" : "Y";
                case Keys.Z:
                    return useLower ? "z" : "Z";
                //case Keys.LWin:
                //    break;
                //case Keys.RWin:
                //    break;
                //case Keys.Apps:
                //    break;
                //case Keys.Sleep:
                //    break;
                case Keys.NumPad0:
                    return "0";
                case Keys.NumPad1:
                    return "1";
                case Keys.NumPad2:
                    return "2";
                case Keys.NumPad3:
                    return "3";
                case Keys.NumPad4:
                    return "4";
                case Keys.NumPad5:
                    return "5";
                case Keys.NumPad6:
                    return "6";
                case Keys.NumPad7:
                    return "7";
                case Keys.NumPad8:
                    return "8";
                case Keys.NumPad9:
                    return "9";
                case Keys.Multiply:
                    return "*";
                case Keys.Add:
                    return "+";
                //case Keys.Separator:
                //    break;
                case Keys.Subtract:
                    return "-";
                case Keys.Decimal:
                    return ".";
                case Keys.Divide:
                    return "/";
                case Keys.F1:
                    return "F1";
                case Keys.F2:
                    return "F2";
                case Keys.F3:
                    return "F3";
                case Keys.F4:
                    return "F4";
                case Keys.F5:
                    return "F5";
                case Keys.F6:
                    return "F6";
                case Keys.F7:
                    return "F7";
                case Keys.F8:
                    return "F8";
                case Keys.F9:
                    return "F9";
                case Keys.F10:
                    return "F10";
                case Keys.F11:
                    return "F11";
                case Keys.F12:
                    return "F12";
                case Keys.F13:
                    return "F13";
                case Keys.F14:
                    return "F14";
                case Keys.F15:
                    return "F15";
                case Keys.F16:
                    return "F16";
                case Keys.F17:
                    return "F17";
                case Keys.F18:
                    return "F18";
                case Keys.F19:
                    return "F19";
                case Keys.F20:
                    return "F20";
                case Keys.F21:
                    return "F21";
                case Keys.F22:
                    return "F22";
                case Keys.F23:
                    return "F23";
                case Keys.F24:
                    return "F24";
                case Keys.NumLock:
                    return "[NumLock]";
                case Keys.Scroll:
                    return "[Scroll]";
                case Keys.LShiftKey:
                    return "[LShift]";
                case Keys.RShiftKey:
                    return "[RShift]";
                case Keys.LControlKey:
                    return "[LCTRL]";
                case Keys.RControlKey:
                    return "[RCTRL]";
                case Keys.LMenu:
                    return "[LMenu]";
                case Keys.RMenu:
                    return "[RMenu]";
                //case Keys.BrowserBack:
                //    break;
                //case Keys.BrowserForward:
                //    break;
                //case Keys.BrowserRefresh:
                //    break;
                //case Keys.BrowserStop:
                //    break;
                //case Keys.BrowserSearch:
                //    break;
                //case Keys.BrowserFavorites:
                //    break;
                //case Keys.BrowserHome:
                //    break;
                //case Keys.VolumeMute:
                //    break;
                //case Keys.VolumeDown:
                //    break;
                //case Keys.VolumeUp:
                //    break;
                //case Keys.MediaNextTrack:
                //    break;
                //case Keys.MediaPreviousTrack:
                //    break;
                //case Keys.MediaStop:
                //    break;
                //case Keys.MediaPlayPause:
                //    break;
                //case Keys.LaunchMail:
                //    break;
                //case Keys.SelectMedia:
                //    break;
                //case Keys.LaunchApplication1:
                //    break;
                //case Keys.LaunchApplication2:
                //    break;
                //case Keys.OemSemicolon:
                //    break;
                case Keys.Oem1:
                    return shiftOn ? ":" : ";";
                case Keys.Oemplus:
                    return shiftOn ? "+" : "=";
                case Keys.Oemcomma:
                    return shiftOn ? "<" : ",";
                case Keys.OemMinus:
                    return shiftOn ? "_" : "-";
                case Keys.OemPeriod:
                    return shiftOn ? ">" : ".";
                case Keys.OemQuestion:
                    return shiftOn ? "?" : "/";
                //case Keys.Oem2:
                //    break;
                case Keys.Oemtilde:
                    return shiftOn ? "~" : "`";
                //case Keys.Oem3:
                //    break;
                case Keys.OemOpenBrackets:
                    return shiftOn ? "{" : "[";
                //case Keys.Oem4:
                //    break;
                //case Keys.OemPipe:
                //    return shiftOn ? "|" : "\\";
                case Keys.Oem5:
                    return shiftOn ? "|" : "\\";
                //case Keys.OemCloseBrackets:
                //    return shiftOn ? "}" : "]";
                case Keys.Oem6:
                    return shiftOn ? "}" : "]";
                //case Keys.OemQuotes:
                //    break;
                case Keys.Oem7:
                    char quote = '"';
                    return shiftOn ? "'" : $"{quote}";
                //case Keys.Oem8:
                //    break;
                //case Keys.OemBackslash:
                //    break;
                //case Keys.Oem102:
                //    break;
                //case Keys.ProcessKey:
                //    break;
                //case Keys.Packet:
                //    break;
                //case Keys.Attn:
                //    break;
                //case Keys.Crsel:
                //    break;
                //case Keys.Exsel:
                //    break;
                //case Keys.EraseEof:
                //    break;
                //case Keys.Play:
                //    break;
                //case Keys.Zoom:
                //    break;
                //case Keys.NoName:
                //    break;
                //case Keys.Pa1:
                //    break;
                //case Keys.OemClear:
                //    break;
                case Keys.Shift:
                    return "[Shift]";
                case Keys.Control:
                    return "[Control]";
                case Keys.Alt:
                    return "[Alt]";
                default:
                    return "<Untracked Key>";
            }
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern short GetKeyState(Keys virtualKeyCode);

        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(Keys vKey);
    }
}
