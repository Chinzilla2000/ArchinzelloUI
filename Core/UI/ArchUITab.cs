using System;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace ArchinzelloUI.Core.UI {
    public class ArchUITab : UIElement {
        public ArchUITabButton[] tabButton;
        public UIElement[] tabs;

        private int currentThingy = 0;

        public ArchUITab(Tuple<Asset<Texture2D>, UIElement>[] tabs) {
            tabButton = new ArchUITabButton[tabs.Length];
            this.tabs = new UIElement[tabs.Length];

            float left = 0;

            for (int i = 0; i < tabs.Length; i++) {
                Logging.PublicLogger.Debug("Left: " + left);
                tabButton[i] = new ArchUITabButton(tabs[i].Item1, i);
                tabButton[i].OnLeftClick += (s, e) => {
                    Logging.PublicLogger.Debug("BOOO");
                    SwitchTab(((ArchUITabButton)e).thingy);
                };
                tabButton[i].Left.Set(left, 0f);
                left += tabs[i].Item1.Width();
                tabButton[i].Top.Set(0, 0f);

                this.tabs[i] = tabs[i].Item2;
                this.tabs[i].Deactivate();
            }

            for (int i = 0; i < tabButton.Length; i++) {
                Append(tabButton[i]);
                Append(this.tabs[i]);
            }

            SwitchTab(currentThingy);
        }

        public void SwitchTab(int newTab) {
            RemoveChild(tabs[currentThingy]);
            currentThingy = newTab;
            Append(tabs[currentThingy]);
        }
    }

    public class ArchUITabButton : UIImageButton {
        public int thingy;

        public ArchUITabButton(Asset<Texture2D> texture, int thingy) : base(texture) {
            this.thingy = thingy;
        }
    }
}