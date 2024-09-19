using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.UI;

namespace ArchinzelloUI.Core.UI;

public class ArchUIImageButton : ArchUIElement
{
	private Asset<Texture2D> _texture;
	private float _visibilityActive = 1f;
	private float _visibilityInactive = 0.4f;
	private Asset<Texture2D> _borderTexture;

	public ArchUIImageButton(Asset<Texture2D> texture)
	{
		_texture = texture;
		Width.Set(_texture.Width(), 0f);
		Height.Set(_texture.Height(), 0f);
	}

	public void SetHoverImage(Asset<Texture2D> texture)
	{
		_borderTexture = texture;
	}

	public void SetImage(Asset<Texture2D> texture)
	{
		_texture = texture;
		Width.Set(_texture.Width(), 0f);
		Height.Set(_texture.Height(), 0f);
	}

	protected override void ArchDrawSelf(SpriteBatch spriteBatch)
	{
		CalculatedStyle dimensions = GetDimensions();
		spriteBatch.Draw(_texture.Value, dimensions.Position(), Color.White * (IsMouseHovering ? _visibilityActive : _visibilityInactive));
		if (_borderTexture != null && IsMouseHovering)
			spriteBatch.Draw(_borderTexture.Value, dimensions.Position(), Color.White);
	}

	public override void ArchMouseOver(UIMouseEvent evt)
	{
		MouseOver(evt);
		//SoundEngine.PlaySound(12);
	}

	public void SetVisibility(float whenActive, float whenInactive)
	{
		_visibilityActive = MathHelper.Clamp(whenActive, 0f, 1f);
		_visibilityInactive = MathHelper.Clamp(whenInactive, 0f, 1f);
	}
}
