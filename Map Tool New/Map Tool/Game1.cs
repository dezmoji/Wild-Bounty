using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Map_Tool
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D BarrelTex;
        Texture2D CactusTex;
        Texture2D RubbleTex;
        Form1 mapForm = new Form1();
        //Scenery test = new Scenery(20, 20, 20, 20, 20, 0, "Barrel");

        //List<Scenery> sceneryColl = mapForm.SceneryColl;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            //graphics.PreferredBackBufferHeight = 1000;
            //graphics.PreferredBackBufferWidth = 1000;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            mapForm.Activate();
            mapForm.Show();
            IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            BarrelTex = Content.Load<Texture2D>("Barrel");
            CactusTex = Content.Load<Texture2D>("Cactus");
            RubbleTex = Content.Load<Texture2D>("Rubble");

            //test
            /*
            foreach (var sObj in mapForm.SceneryColl)
            {
                if (sObj.TextureName == "Cactus")
                {
                    sObj.ObjTexture = CactusTex;
                }
                else if (sObj.TextureName == "Barrel")
                {
                    sObj.ObjTexture = BarrelTex;
                }
                sObj.RubbleTexture = RubbleTex;
            }
            //*/
            //test.ObjTexture = BarrelTex; // test obj loading
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //set added items textures. it is in the update because they are being progressively added and load and initialize only run once
            foreach (var sObj in mapForm.SceneryColl)
            {
                if (sObj.TextureNum == 0)
                {
                    sObj.ObjTexture = CactusTex;
                }
                else if (sObj.TextureNum == 1)
                {
                    sObj.ObjTexture = BarrelTex;
                }
                sObj.RubbleTexture = RubbleTex;
            }

            //get mouse state
            var mouseState = Mouse.GetState();
            //if in the game screen
            if (mouseState.X > 0 && mouseState.X < this.GraphicsDevice.Viewport.Width && mouseState.Y > 0 && mouseState.Y < GraphicsDevice.Viewport.Height)
            {
                //on click
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    //get mouse position and change the form variables
                    mapForm.FX = mouseState.X;
                    mapForm.FY = mouseState.Y;
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            foreach (var sObj in mapForm.SceneryColl)
            {
                Rectangle rect = new Rectangle(sObj.X, sObj.Y, sObj.Width, sObj.Height);
                if (sObj.Health > 0)
                {
                    spriteBatch.Draw(sObj.ObjTexture, rect, Color.White);
                }
                else
                {
                    spriteBatch.Draw(sObj.RubbleTexture, rect, Color.White);
                }
                //sObj.Draw(spriteBatch);
            }
            //spriteBatch.Draw(test.ObjTexture, test.ObjPos, Color.White);// test draw
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
