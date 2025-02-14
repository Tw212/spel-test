using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace spel_test
{
    public class Hink
    {
        private Texture2D texture;
        private Vector2 position;
        private Rectangle hitbox;
        private KeyboardState kState;
        public Rectangle Hitbox{
            get{return hitbox;}
        }
        public Hink(Texture2D texture, Vector2 position, int pixelSize){
            this.texture = texture;
            this.position = position;
            hitbox = new Rectangle((int)position.X,(int)position.Y,pixelSize,pixelSize);
        }

        public void Update(){
            kState = Keyboard.GetState();
            Move();
        }

       
        private void Move(){
            

            if(kState.IsKeyDown(Keys.A)&& position.X > 0){
                position.X -= 10;
            }
            if(kState.IsKeyDown(Keys.D)&& position.X< 750){
                position.X += 10;
            }
            
            hitbox.Location = position.ToPoint();
        }
        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(texture,hitbox,Color.White);
        }

        
    }
}