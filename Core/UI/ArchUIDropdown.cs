using Microsoft.Xna.Framework;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader.UI;
using Terraria.UI;

namespace ArchinzelloUI.Core.UI {
    public class ArchUIDropdown : ArchUIElement {
        public int current = 0;
        public string[] options = [""];
        private UIButton<string>[] optionButtons = [];
        private readonly UIScrollbar scrollbar;
        private readonly UIPanel panel = new();

        public ArchUIDropdown(Rectangle positions) {
            Top.Set(positions.Y, 0f);
            Left.Set(positions.X, 0f);
            Height.Set(positions.Height, 0f);
            Width.Set(positions.Width - 20, 0f);

            panel.Top.Set(0, 0f);
            panel.Left.Set(0, 0f);
            panel.Height.Set(positions.Height, 0f);
            panel.Width.Set(positions.Width - 20, 0f);
            panel.OverflowHidden = true;

            scrollbar = new UIScrollbar();
            scrollbar.Top.Set(0, 0f);
            scrollbar.Left.Set(positions.Width - 20, 0f);
            scrollbar.Height.Set(positions.Height, 0f);
            scrollbar.Width.Set(20, 0f);
            scrollbar.SetView(10, 200);

            Append(panel);
            Append(scrollbar);

            options = [""];
            optionButtons = new UIButton<string>[options.Length];
            for (int i = 0; i < options.Length; i++) {
                optionButtons[i] = new UIButton<string>(options[i]);
                optionButtons[i].Top.Set(0, 0f);
                optionButtons[i].Left.Set(0, 0f);
                optionButtons[i].Width.Set(positions.Width - 20, 0f);
                optionButtons[i].Height.Set(36, 0f);
                panel.Append(optionButtons[i]);
            }
        }

        public void AddOption(string option) {
            options = [.. options, option];
            optionButtons = [.. optionButtons, new UIButton<string>(option)];
            optionButtons[^1].Top.Set(0, 0f);
            optionButtons[^1].Left.Set(0, 0f);
            optionButtons[^1].Width.Set(Width.Pixels - 20, 0f);
            optionButtons[^1].Height.Set(36, 0f);
            panel.Append(optionButtons[^1]);
        }

        public void Reset(string[] newOptions) {
            for (int i = 0; i < optionButtons.Length; i++) {
                panel.RemoveChild(optionButtons[i]);
            }
            options = newOptions;
            optionButtons = new UIButton<string>[options.Length];
            for (int i = 0; i < options.Length; i++) {
                optionButtons[i] = new UIButton<string>(options[i]);
                optionButtons[i].Top.Set(0, 0f);
                optionButtons[i].Left.Set(0, 0f);
                optionButtons[i].Width.Set(Width.Pixels - 20, 0f);
                optionButtons[i].Height.Set(36, 0f);
                panel.Append(optionButtons[i]);
            }
        }

        public override void ArchUpdate(GameTime gameTime)
        {
            for (int i = 0; i < options.Length; i++) {
                optionButtons[i].Top.Set(4 + (36 * i) - (scrollbar.ViewPosition * 16), 0f);
            }
        }
    }
}