using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Showcase
{
    class MainMenu
    {
        int menuOption = 0;

        Texture2D playButton;
        Texture2D playButtonUnPressed;
        Texture2D playButtonHovered;
        Rectangle playButtonCollision;

        public void LoadContent(ContentManager Content)
        {
            playButtonUnPressed = Content.Load<Texture2D>(@"Menu Buttons/playButtonUnPressed");
            playButtonHovered = Content.Load<Texture2D>(@"Menu Buttons/playButtonHovered");
        }

        public void Update(GameTime gameTime)
        {
            playButtonCollision = new Rectangle(325, 200, 150, 90);

            MouseState mouse = Mouse.GetState();

            if (playButtonCollision.Contains(mouse.X, mouse.Y))
            {
                playButton = playButtonHovered;
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    menuOption = 1;
                } 
            }

            if (!playButtonCollision.Contains(mouse.X, mouse.Y))
            {
                playButton = playButtonUnPressed;
            }
        }

        public int detectGameState()
        {
            switch (menuOption)
            {
                case 1:
                    //Playing
                    return 1;

                default:
                    //Nothing is happening
                    return 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playButton, playButtonCollision, Color.White);
        }
    }
}
