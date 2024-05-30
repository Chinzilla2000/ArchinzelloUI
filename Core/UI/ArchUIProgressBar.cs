using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.UI;

namespace ArchinzelloUI.Core.UI
{
    public class ArchUIProgressBar : UIElement {
        public float progress = 0;
        public Color color = Color.White;
        public Asset<Texture2D> marker;
        public Rectangle Filler;

        Vector2 PositionTopLeft => GetDimensions().ToRectangle().TopLeft();
        Vector2 Sizing => new(GetDimensions().Width, GetDimensions().Height * progress);

        public ArchUIProgressBar(Asset<Texture2D> marker = null) {
            this.marker = marker;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Filler = new((int)PositionTopLeft.X, (int)(PositionTopLeft.Y + (GetDimensions().Height - Sizing.Y)), (int)Sizing.X, (int)Sizing.Y);
            spriteBatch.Draw(TextureAssets.MagicPixel.Value, Filler, color);
            if (marker != null) 
                spriteBatch.Draw(marker.Value, new Vector2(PositionTopLeft.X, PositionTopLeft.Y + (GetDimensions().Height - GetDimensions().Height * progress) - marker.Value.Height / 2), Color.White);
        }
    }
}