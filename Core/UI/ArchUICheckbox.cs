using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.UI;

namespace ArchinzelloUI.Core.UI {
    public class ArchUICheckbox : UIElement {
        private Asset<Texture2D> _texture;
        private Asset<Texture2D> _checkedTexture;
        public bool check = false;

        public ArchUICheckbox(Asset<Texture2D> texture, Asset<Texture2D> checkedTexture, bool defaultCheckboxBehavior = true)
        {
            _texture = texture;
            _checkedTexture = checkedTexture;
            Width.Set(_texture.Width(), 0f);
            Height.Set(_texture.Height(), 0f);

            if (defaultCheckboxBehavior) OnLeftClick += (e, evt) => { check = !check; };
        }

        public void SetCheckedImage(Asset<Texture2D> texture)
        {
            _checkedTexture = texture;
        }

        public void SetImage(Asset<Texture2D> texture)
        {
            _texture = texture;
            Width.Set(_texture.Width(), 0f);
            Height.Set(_texture.Height(), 0f);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            CalculatedStyle dimensions = GetDimensions();
            spriteBatch.Draw((check ? _checkedTexture : _texture).Value, dimensions.Position(), Color.White);
        }

        public override void LeftClick(UIMouseEvent evt)
        {
            base.LeftClick(evt);
        }
    }
}