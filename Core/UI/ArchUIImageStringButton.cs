using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ReLogic.Content;
using ReLogic.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.UI.Elements;

namespace ArchinzelloUI.Core.UI {
    public class ArchUIImageStringButton : UIImageButton {
        public string text;

        public ArchUIImageStringButton(Asset<Texture2D> texture, string content) : base(texture) {
            text = content;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.DrawString(FontAssets.MouseText.Value, text, GetDimensions().Position(), Color.LightGreen);
        }
    }
}