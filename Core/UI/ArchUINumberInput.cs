using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.UI;
using Terraria.UI;

namespace ArchinzelloUI.Core.UI {
    public class ArchUINumberInput : UIElement {
        private Asset<Texture2D> _texture;
        private readonly int digits = 1;
        public int number;
        private int[] stuff;
        private UIButton<string> up;
        private UIButton<string> down;

        public ArchUINumberInput(Asset<Texture2D> assets = null, int digits = 1) {
            this.digits = digits;
            stuff = new int[digits];
            number = 0;
            _texture = assets ?? ModContent.Request<Texture2D>("ArchinzelloUI/Assets/NumberInput");

            Width.Set(16 + digits * 14, 0f);
            Height.Set(30, 0f);

            up = new UIButton<string>("");
            up.Top.Set(0, 0f);
            up.Left.Set(0, 0f);
            up.Width.Set(14, 0f);
            up.Height.Set(14, 0f);
            up.OnLeftClick += (evt, e) => {
                //Logging.PublicLogger.Info("Up");
                number = Math.Clamp(number + 1, 0, (int)Math.Pow(10, digits) - 1);
                int temp = (number.ToString().Length < digits) ? digits - number.ToString().Length : 0;
                for (int i = 0; i < digits; i++) {
                    stuff[i] = (i < temp) ? 0 : int.Parse(number.ToString().Substring(i - temp, 1));
                }
                //Logging.PublicLogger.Info(number);
            };

            down = new UIButton<string>("");
            down.Top.Set(16, 0f);
            down.Left.Set(0, 0f);
            down.Width.Set(14, 0f);
            down.Height.Set(14, 0f);
            down.OnLeftClick += (evt, e) => {
                //Logging.PublicLogger.Info("Down");
                number = Math.Clamp(number - 1, 0, (int)Math.Pow(10, digits) - 1);
                int temp = (number.ToString().Length < digits) ? digits - number.ToString().Length : 0;
                for (int i = 0; i < digits; i++) {
                    stuff[i] = (i < temp) ? 0 : int.Parse(number.ToString().Substring(i - temp, 1));
                }
                //Logging.PublicLogger.Info(number);
            };

            Append(up);
            Append(down);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(_texture.Value, GetDimensions().ToRectangle().TopLeft(), new Rectangle(0, 0, 14, 14), Color.White);
            spriteBatch.Draw(_texture.Value, GetDimensions().ToRectangle().TopLeft() + new Vector2(0, 16), new Rectangle(24, 0, 14, 14), Color.White);
            spriteBatch.Draw(_texture.Value, GetDimensions().ToRectangle().TopLeft() + new Vector2(12, 0), new Rectangle(0, 0, 2, 30), Color.White);
            for (int i = 0; i < digits; i++) {
                spriteBatch.Draw(_texture.Value, GetDimensions().ToRectangle().TopLeft() + new Vector2(14 + 14 * i, 0), new Rectangle(GetType(i, digits), 12 + 28 * (1 + stuff[i]), 14, 30), Color.White);
            }
            //base.Draw(spriteBatch);
        }

        static int GetType(int type, int max) {
            if (type == max - 1) {
                return 30;
            }
            else if (type == 0) {
                return 2;
            }
            else {
                return 16;
            }
        }
    }
}