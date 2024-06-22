using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.UI;
using Terraria.UI.Chat;

namespace ArchinzelloUI.Core.UI
{
    public class ArchUIItemSlot : UIElement
    {
        internal Item Item;
        private readonly Asset<Texture2D> _texture;
        private readonly int _context;
        private readonly float _scale;
        internal Func<Item, bool> ValidItemFunc;

        public ArchUIItemSlot(Asset<Texture2D> texture = null, int context = ItemSlot.Context.BankItem, float scale = 1f)
        {
            _texture = texture ?? TextureAssets.InventoryBack9;
            _context = context;
            _scale = scale;
            Item = new Item();
            Item.SetDefaults(0);

            Width.Set(_texture.Width(), 0f);
            Height.Set(_texture.Height(), 0f);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            float oldScale = Main.inventoryScale;
            Main.inventoryScale = _scale;
            Rectangle rectangle = GetDimensions().ToRectangle();

            if (ContainsPoint(Main.MouseScreen) && !PlayerInput.IgnoreMouseInterface)
            {
                Main.LocalPlayer.mouseInterface = true;
                if (ValidItemFunc == null || ValidItemFunc(Main.mouseItem))
                {
                    ItemSlot.Handle(ref Item, _context);
                }
            }
            
            spriteBatch.Draw(_texture.Value, rectangle.TopLeft(), Color.White);
            ItemSlot.DrawItemIcon(Item, _context, spriteBatch, new Vector2(rectangle.Center().X, rectangle.Center().Y), _scale, 40f, Color.White);
            if (Item.stack > 1)
				ChatManager.DrawColorCodedStringWithShadow(spriteBatch, FontAssets.ItemStack.Value, Item.stack.ToString(), rectangle.Center.ToVector2() + new Vector2(-16f, 0f) * _scale, Color.White, 0f, Vector2.Zero, new Vector2(_scale), -1f, _scale);
            Main.inventoryScale = oldScale;
        }
    }
}
