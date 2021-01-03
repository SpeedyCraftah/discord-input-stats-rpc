using System.Runtime.InteropServices;
using System.Threading;

namespace InputTracker
{
    internal class MouseTracker
    {
        public delegate void ClickEventFunction();

        private static ClickEventFunction OnClickFunction;

        internal static void RegisterClicks(ClickEventFunction OnClick)
        {
            OnClickFunction = OnClick;

            Thread thread = new Thread(DetectClicks);
            thread.Start();
        }

        [DllImport("user32.dll")]
        public static extern short GetKeyState(int vKey);

        static private void DetectClicks()
        {
            short oldState = GetKeyState(0x01);

            while (true)
            {
                short newState = GetKeyState(0x01);

                if (oldState != newState)
                {
                    oldState = newState;

                    if (newState < 0)
                    {
                        OnClickFunction?.Invoke();
                    }
                }

                Thread.Sleep(50);
            }
        }
    }
}