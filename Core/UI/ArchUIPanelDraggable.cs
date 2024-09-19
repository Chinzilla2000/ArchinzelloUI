using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.UI;

namespace ArchinzelloUI.Core.UI
{
	public class ArchUIPanelDraggable : ArchUIPanel, IArchUIDraggable
	{
		private Vector2 offset;
		private bool dragging;

		public ArchUIPanelDraggable() : base() {
		}

		public ArchUIPanelDraggable(Asset<Texture2D> customBackground, Asset<Texture2D> customBorder, int customCornerSize = 12, int customBarSize = 4) : base(customBackground, customBorder, customCornerSize, customBarSize) {

		}

		public override void ArchLeftMouseDown(UIMouseEvent evt) {
			LeftMouseDown(evt);
			DragStart(evt);
		}

		public override void ArchLeftMouseUp(UIMouseEvent evt) {
			LeftMouseUp(evt);
			if (dragging) DragEnd(evt);
		}

		public void DragStart(UIMouseEvent evt) {
			offset = new Vector2(evt.MousePosition.X - Left.Pixels, evt.MousePosition.Y - Top.Pixels);
			dragging = true;
		}

		public void DragEnd(UIMouseEvent evt) {
			Vector2 endMousePosition = evt.MousePosition;
			dragging = false;

			Left.Set(endMousePosition.X - offset.X, 0f);
			Top.Set(endMousePosition.Y - offset.Y, 0f);

			Recalculate();
		}

		public override void ArchUpdate(GameTime gameTime) {
			Update(gameTime);

			if (ContainsPoint(Main.MouseScreen)) {
				Main.LocalPlayer.mouseInterface = true;
			}

			if (dragging) {
				Left.Set(Main.mouseX - offset.X, 0f);
				Top.Set(Main.mouseY - offset.Y, 0f);
				Recalculate();
			}

			var parentSpace = Parent.GetDimensions().ToRectangle();
			if (!GetDimensions().ToRectangle().Intersects(parentSpace)) {
				Left.Pixels = Utils.Clamp(Left.Pixels, 0, parentSpace.Right - Width.Pixels);
				Top.Pixels = Utils.Clamp(Top.Pixels, 0, parentSpace.Bottom - Height.Pixels);
				Recalculate();
			}
		}
	}
}
