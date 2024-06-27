using ArchinzelloUI.Common.Players;
using ArchinzelloUI.Core.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace ArchinzelloUI.Common.UI.TestingUI
{
    internal class TestingUIState : UIState
    {
        private ArchUIPanelDraggable area;
        private ArchUIDropdown dropdown;
        private ArchUIItemSlot itemSlot;
        private ArchUIItemSlot[] itemSlots = new ArchUIItemSlot[8];
        private UITextPanel<string> stringTab;
        private UIPanel thingAMaJig;
        private UIPanel blurg;
        private ArchUITab tab;
        private ArchUINumberInput numberInput;


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

            itemSlot = new ArchUIItemSlot(ModContent.Request<Texture2D>("ArchinzelloUI/Assets/Circle"));
            itemSlot.Left.Set(200, 0f);
            itemSlot.Top.Set(40, 0f);

            thingAMaJig = new UIPanel();
            thingAMaJig.Left.Set(0, 0f);
            thingAMaJig.Top.Set(32, 0f);
            thingAMaJig.Width.Set(460, 0f);
            thingAMaJig.Height.Set(100, 0f);

            blurg = new UIPanel();
            blurg.Left.Set(0, 0f);
            blurg.Top.Set(32, 0f);
            blurg.Width.Set(460, 0f);
            blurg.Height.Set(100, 0f);

            stringTab = new UITextPanel<string>("True");
            stringTab.Left.Set(0, 0f);
            stringTab.Top.Set(32, 0f);
            stringTab.Width.Set(460, 0f);
            stringTab.Height.Set(100, 0f);

            numberInput = new ArchUINumberInput(digits: 3);
            numberInput.Left.Set(0, 0f);
            numberInput.Top.Set(282, 0f);

            for (int i = 0; i < itemSlots.Length; i++) {
                itemSlots[i] = new ArchUIItemSlot();
                itemSlots[i].Left.Set(42 * i, 0f);
                itemSlots[i].Top.Set(0, 0f);
                blurg.Append(itemSlots[i]);
            }

            tab = new ArchUITab([new Tuple<Asset<Texture2D>, UIElement>(ModContent.Request<Texture2D>("ArchinzelloUI/Assets/HardPanel"), stringTab), new Tuple<Asset<Texture2D>, UIElement>(ModContent.Request<Texture2D>("ArchinzelloUI/Assets/RoundedPanel"), thingAMaJig), new Tuple<Asset<Texture2D>, UIElement>(ModContent.Request<Texture2D>("ArchinzelloUI/Assets/SoftPanel"), blurg)]);
            tab.Left.Set(20, 0f);
            tab.Top.Set(150, 0f);
            tab.Width.Set(460, 0f);
            tab.Height.Set(132, 0f);

            area.Append(itemSlot);
            area.Append(dropdown);
            area.Append(numberInput);
            area.Append(tab);
            
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