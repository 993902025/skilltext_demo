using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace skilltest
{
    public class Skill_do
    {
        public const int WM_KEYDOWN = 0x100;

        [DllImport("user32.dll", EntryPoint = "PostMessageW")]
        public static extern int PostMessage(int hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern int GetFocus();

        [DllImport("user32.dll")]
        public static extern int GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern int AttachThreadInput(int idAttach, int idAttachTo, int fAttach);

        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(int hwnd, int lpdwProcessId);

        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();

    }
}


/*skill对象，返回伤害值用于显示，触发cd，
 * 判断skill是否可用，cd、mana、人物状态，所有需要一个人物类player
 * 
 * 
 */