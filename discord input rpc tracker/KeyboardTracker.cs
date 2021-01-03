namespace InputTracker
{
    internal class KeyboardTracker
    {
        public delegate void KeyPressEventFunction();

        private static KeyPressEventFunction OnPressFunction; 

        public static void RegisterKeys(KeyPressEventFunction OnPress)
        {
            OnPressFunction = OnPress;
        }
    }
}
