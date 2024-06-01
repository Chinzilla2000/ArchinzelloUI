using ArchinzelloUI.Common.Players;
using ArchinzelloUI.Core.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace ArchinzelloUI.Common.UI.TestingUI
{
    internal class TestingUIState : UIState
    {
        private ArchUIPanelDraggable area;
        private ArchUIDropdown dropdown;
        private ArchUIItemSlot itemSlot;


        public override void OnInitialize()
        {
            area = new ArchUIPanelDraggable();
            area.Left.Set(-area.Width.Pixels - 850, 1f);
            area.Top.Set(50, 0f);
            area.Width.Set(500, 0f);
            area.Height.Set(500, 0f);

            dropdown = new ArchUIDropdown(new Rectangle(40, 20, 100, 100));
            dropdown.AddOption("Test");
            dropdown.AddOption("Text");
            dropdown.AddOption("Tent");

            itemSlot = new ArchUIItemSlot();
            itemSlot.Left.Set(200, 0f);
            itemSlot.Top.Set(40, 0f);

            area.Append(itemSlot);
            area.Append(dropdown);
            
            Append(area);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!Main.LocalPlayer.GetModPlayer<TestUIPlayer>().testingUI) return;

            base.Draw(spriteBatch);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            if (Main.LocalPlayer.TryGetModPlayer(out TestUIPlayer modPlayer) && (!modPlayer.testingUI))
                return;

            base.Update(gameTime);
        }

        public override void LeftClick(UIMouseEvent evt)
        {
            if (Main.LocalPlayer.TryGetModPlayer(out TestUIPlayer modPlayer) && (!modPlayer.testingUI))
                return;
        }
    }

    [Autoload(Side = ModSide.Client)]
    internal class TestingUISystem : ModSystem
    {
        private UserInterface TestingUserInterface;

        internal TestingUIState TestingUIState;

        public override void Load()
        {
            TestingUIState = new();
            TestingUserInterface = new();
            TestingUserInterface.SetState(TestingUIState);
        }

        public override void UpdateUI(GameTime gameTime)
        {
            TestingUserInterface?.Update(gameTime);
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
            if (resourceBarIndex != -1)
            {
                layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
                    "ArchinzelloUI: Testing UI",
                    delegate {
                        TestingUserInterface.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }
    }
}