using ArchinzelloUI.Common.Systems;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace ArchinzelloUI.Common.Players
{
    public class TestUIPlayer : ModPlayer
    {
        public bool testingUI = false;

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (KeybindSystem.TestingUI.JustPressed)
            {
                testingUI = !testingUI;
            }
        }
    }
}