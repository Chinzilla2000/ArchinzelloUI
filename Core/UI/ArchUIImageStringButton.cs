using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ReLogic.Content;
using ReLogic.Graphics;
using Terraria.GameContent;

namespace ArchinzelloUI.Core.UI {
    public class ArchUIImageStringButton(Asset<Texture2D> texture, string content) : ArchUIImageButton(texture) {
        public string text = content;

        public override void ArchDraw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch);
            spriteBatch.DrawString(FontAssets.MouseText.Value, text, GetDimensions().Position(), Color.LightGreen);
        }
    }
}