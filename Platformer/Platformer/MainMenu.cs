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

        Texture2D playButtonUnPressed;
        Texture2D playButtonHovered;

        MenuButton playButton;

        public void LoadContent(ContentManager Content)
        {
            playButtonUnPressed = Content.Load<Texture2D>(@"Menu Buttons/play Button Un-Pressed");
            playButtonHovered = Content.Load<Texture2D>(@"Menu Buttons/play Button Hovered");
        }

        public void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();

            playButton = new MenuButton(325, 200, 150, 90, 1, mouse, playButtonUnPressed, playButtonHovered);

            if (playButton.getButtonState())
            {
                menuOption = playButton.getButtonNum();
            }
            else
            {
                menuOption = 0;
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
            spriteBatch.Draw(playButton.getTexture(), playButton.getRectangle(), Color.White);
        }
    }

    class MenuButton
    {
        bool buttonState;
        int bNum;
        Rectangle collision;
        MouseState mouseState;
        Texture2D button0, button1, button2;

        public MenuButton(int x, int y, int width, int height, int buttonNum, MouseState mouse, Texture2D buttonNorm, Texture2D buttonHov)
        {
            collision = new Rectangle(x, y, width, height);
            mouseState = mouse;
            button1 = buttonNorm;
            button2 = buttonHov;
            bNum = buttonNum;
        }

        public bool getButtonState()
        {
            if (collision.Contains(mouseState.X, mouseState.Y))
            {
                button0 = button2;
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    buttonState = true;
                }
            }
            else
            {
                button0 = button1;
                buttonState = false;
            }

            return buttonState;
        }

        public int getButtonNum()
        {
            return bNum;
        }

        public Rectangle getRectangle()
        {
            return collision;
        }

        public Texture2D getTexture()
        {
            return button0;
        }
    }
}
