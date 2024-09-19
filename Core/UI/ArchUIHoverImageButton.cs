using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;

namespace ArchinzelloUI.Core.UI
{
	public class ArchUIHoverImageButton(Asset<Texture2D> texture, string hoverText) : ArchUIImageButton(texture)
	{
		public string hoverText = hoverText;

        protected override void ArchDrawSelf(SpriteBatch spriteBatch) {
			DrawSelf(spriteBatch);

			if (IsMouseHovering)
				Main.hoverItemName = hoverText;
		}
	}
}
