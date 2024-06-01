using Terraria.ModLoader;

namespace ArchinzelloUI.Common.Systems
{
    public class KeybindSystem : ModSystem
    {
        public static ModKeybind TestingUI { get; private set; }

        public override void Load()
        {
            TestingUI = KeybindLoader.RegisterKeybind(Mod, "Testing UI", "U");
        }
        
        public override void Unload()
        {
            TestingUI = null;
        }
    }
}