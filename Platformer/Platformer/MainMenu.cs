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

        Texture2D background, title, playButtonUnPressed, playButtonHovered, exitButtonUnpressed, exitButtonHovered;

        MenuButton playButton, exitButton;

        public void LoadContent(ContentManager Content)
        {
            background = Content.Load<Texture2D>(@"Menu Buttons/Background");
            title = Content.Load<Texture2D>(@"Menu Buttons/Title");
            playButtonUnPressed = Content.Load<Texture2D>(@"Menu Buttons/Play Button Un-Pressed");
            playButtonHovered = Content.Load<Texture2D>(@"Menu Buttons/Play Button Hovered");
            exitButtonUnpressed = Content.Load<Texture2D>(@"Menu Buttons/Exit Button Un-Pressed");
            exitButtonHovered = Content.Load<Texture2D>(@"Menu Buttons/Exit Button Hovered");
        }

        public void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();

            playButton = new MenuButton(275, 315, 150, 90, 1, mouse, playButtonUnPressed, playButtonHovered);
            exitButton = new MenuButton(618, 315, 150, 90, 2, mouse, exitButtonUnpressed, exitButtonHovered);

            if (playButton.getButtonState())
            {
                menuOption = playButton.getButtonNum();
            }
            else if (exitButton.getButtonState())
            {
                menuOption = exitButton.getButtonNum();
            }
            else
            {
                menuOption = 0;
            }
        }

        /// <summary>
        /// Determines what to do if a menu button is pressed.
        /// </summary>
        /// <returns></returns>
        public int detectGameState()
        {
            switch (menuOption)
            {
                case 1:
                    //Playing
                    return 1;

                case 2:
                    //Exit
                    return 2;

                default:
                    //Nothing is happening
                    return 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            spriteBatch.Draw(title, new Vector2(290, 10), null, Color.White, 0, Vector2.Zero, 0.85f, SpriteEffects.None, 0);
            spriteBatch.Draw(playButton.getTexture(), playButton.getRectangle(), Color.White);
            spriteBatch.Draw(exitButton.getTexture(), exitButton.getRectangle(), Color.White);
        }
    }

    class MenuButton
    {
        bool buttonState;
        int bNum;
        Rectangle collision;
        MouseState mouseState;
        Texture2D button0, button1, button2;

        /// <summary>
        /// Creates a new button for the menu.
        /// </summary>
        /// <param name="x">x value.</param>
        /// <param name="y">y value.</param>
        /// <param name="width">Width of button in pixels.</param>
        /// <param name="height">Height of button in pixels.</param>
        /// <param name="buttonNum">Number button uses to identify.</param>
        /// <param name="mouse">Mouse state for detection.</param>
        /// <param name="buttonNorm">Ordinary button state.</param>
        /// <param name="buttonHov">Hovered button state.</param>
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
