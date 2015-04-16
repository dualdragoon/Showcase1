﻿using System;
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
        int mainMenuOption = 0, settingsMenuOption;

        Texture2D background, title, playButtonUnPressed, playButtonHovered, exitButtonUnpressed, exitButtonHovered, settingsButtonUnpressed, settingsButtonHovered, 
            backButtonUnpressed, backButtonHovered;
        SpriteFont font;

        MouseState mouse;

        MenuButton playButton, exitButton, settingsButton, backButton;

        public void LoadContent(ContentManager Content)
        {
            background = Content.Load<Texture2D>(@"Menu Images/Background");
            title = Content.Load<Texture2D>(@"Menu Images/Title");
            playButtonUnPressed = Content.Load<Texture2D>(@"Menu Images/Play Button Un-Pressed");
            playButtonHovered = Content.Load<Texture2D>(@"Menu Images/Play Button Hovered");
            exitButtonUnpressed = Content.Load<Texture2D>(@"Menu Images/Exit Button Un-Pressed");
            exitButtonHovered = Content.Load<Texture2D>(@"Menu Images/Exit Button Hovered");
            settingsButtonUnpressed = Content.Load<Texture2D>(@"Menu Images/Settings Button Un-Pressed");
            settingsButtonHovered = Content.Load<Texture2D>(@"Menu Images/Settings Button Hovered");
            backButtonUnpressed = Content.Load<Texture2D>(@"Menu Images/Back Button Un-Pressed");
            backButtonHovered = Content.Load<Texture2D>(@"Menu Images/Back Button Hovered");

            font = Content.Load<SpriteFont>(@"Fonts/Hud");
        }

        public void UpdateMainMenu(GameTime gameTime)
        {
            mouse = Mouse.GetState();

            playButton = new MenuButton(275, 315, 150, 90, 1, mouse, playButtonUnPressed, playButtonHovered);
            exitButton = new MenuButton(618, 315, 150, 90, 2, mouse, exitButtonUnpressed, exitButtonHovered);
            settingsButton = new MenuButton(444, 450, 150, 90, 3, mouse, settingsButtonUnpressed, settingsButtonHovered);

            if (playButton.getButtonState())
            {
                mainMenuOption = playButton.getButtonNum();
            }
            else if (exitButton.getButtonState())
            {
                mainMenuOption = exitButton.getButtonNum();
            }
            else if (settingsButton.getButtonState())
            {
                mainMenuOption = settingsButton.getButtonNum();
            }
            else
            {
                mainMenuOption = 0;
            }
        }

        public void UpdateSettingsMenu(GameTime gameTime)
        {
            mouse = Mouse.GetState();

            backButton = new MenuButton(10, 500, 150, 90, 2, mouse, backButtonUnpressed, backButtonHovered);

            if (backButton.getButtonState())
            {
                settingsMenuOption = backButton.getButtonNum();
            }
            else
            {
                settingsMenuOption = 0;
            }
        }

        /// <summary>
        /// Determines what to do if a menu button is pressed.
        /// </summary>
        /// <returns></returns>
        public int detectGameState()
        {
            switch (mainMenuOption)
            {
                case 1:
                    // Playing
                    return 1;

                case 2:
                    // Exit
                    return 2;

                case 3:
                    // Settings
                    return 3;

                default:
                    // Nothing is happening
                    return 0;
            }
        }

        /// <summary>
        /// Determines what to do if a settings button is pressed.
        /// </summary>
        /// <returns></returns>
        public int detectSettingsOption()
        {
            switch (settingsMenuOption)
            {
                case 1:

                    return 1;

                case 2:
                    // Back
                    return 2;

                default:
                    // Nothing is happening
                    return 0;
            }
        }

        /// <summary>
        /// Draws the main menu background, title, and buttons.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void DrawMainMenu(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            spriteBatch.Draw(title, new Vector2(290, 10), null, Color.White, 0, Vector2.Zero, 0.85f, SpriteEffects.None, 0);
            try
            {
                spriteBatch.Draw(playButton.getTexture(), playButton.getRectangle(), Color.White);
                spriteBatch.Draw(exitButton.getTexture(), exitButton.getRectangle(), Color.White);
                spriteBatch.Draw(settingsButton.getTexture(), settingsButton.getRectangle(), Color.White);
            }
            catch (NullReferenceException)
            { }
        }

        /// <summary>
        /// Draws the settings menu background, title, and buttons.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void DrawSettingsMenu(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            spriteBatch.Draw(title, new Vector2(290, 10), null, Color.White, 0, Vector2.Zero, 0.85f, SpriteEffects.None, 0);
            spriteBatch.Draw(backButton.getTexture(), backButton.getRectangle(), Color.White);

            spriteBatch.DrawString(font, "Sorry, nothing here right now.", new Vector2(520, 525), Color.White);
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
