using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
//<<<<<<< HEAD
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System;
//=======
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//>>>>>>> origin/axm8774-patch-1

namespace WildBounty
{
    /*
     * Authors: Dezmon Gilbert, Niko Bazos, Alex Pierce
     * Purpose: To handle running the game 
     * Caveats: none
     * */
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        // Attributes 

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background;
        Texture2D gameBackground;
        SpriteFont font;
        Texture2D playerImg;
        Texture2D bImage;
        Texture2D helpMenu;
        Texture2D gameoverMenu;
        Texture2D creditsMenu;
        Texture2D scoresMenu;
        Texture2D optionsMenu;
        Texture2D BarrelTex;
        Texture2D CactusTex;
        Texture2D RubbleTex;
        Player user;
        Bullet b;
        List<Enemy> enemyObj;
        List<Thread> enemyThread;
        int waveCount;

        List<Scenery> SceneryColl;

        Vector2 playerLoc;
        bool bulletExist; // bool for projectile algorithim

        // Enum
        enum GameState
        {
            Menu,   // main menu
            Game,                   // the game being played
            GameOver,               // when the game is finished
            Credits,                // credit screen
            Scores,                 // screen to display scores
            Options,                // screen to display the options
            Help,                   // help screen
            About,                  // screen that gives information about the game and the creators
            Tips,                   // screen that gives the user tips on how to succeed and play
            Controls                // shows the user the controls for the game
        }
        enum PlayerState            // For animation
        {
            FaceRight,              // player faces left
            FaceLeft                // player faces right
        }


        GameState gameState;
        PlayerState move; 
        KeyboardState kbState, prevKbState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            playerLoc = new Vector2(Window.ClientBounds.Width / 2, Window.ClientBounds.Height / 2);

            // create player
            user = new Player(playerImg, 0, 0, 50, 50,100);
            bulletExist = false;

            // initialize the lists for the enemies
            enemyObj = new List<Enemy>();
            enemyThread = new List<Thread>();

            // read from file
            try
            {
                //BinaryReader input = new BinaryReader(File.OpenRead("map.dat"));
                //gameBackground = Content.Load<Texture2D>(input.ReadString());

                try
                {
                    while(true)
                    {
                        using (Stream stream = File.Open("map.dat", FileMode.Open))
                        {
                            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                            SceneryColl.Add((Scenery)binaryFormatter.Deserialize(stream));
                        }
                    }
                }
                catch (EndOfStreamException eos)
                {

                }
                catch (IOException ioe)
                {
                }
            }
            catch (IOException ioe)
            {
                gameBackground = Content.Load<Texture2D>("defaultSand");
            }

            // get background from file

            // intial state of the game
            
            gameState = GameState.Menu;
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
            background = Content.Load<Texture2D>("Wild-West-1");
            font = Content.Load<SpriteFont>("SpriteFont1");
            playerImg = Content.Load<Texture2D>("CharacterAsset");
            bImage = Content.Load<Texture2D>("BulletAsset");
            helpMenu = Content.Load<Texture2D>("help");
            gameoverMenu = Content.Load<Texture2D>("game over");
            optionsMenu = Content.Load<Texture2D>("options");
            scoresMenu = Content.Load<Texture2D>("scores");
            creditsMenu = Content.Load<Texture2D>("credits");
            BarrelTex = Content.Load<Texture2D>("Barrel");
            CactusTex = Content.Load<Texture2D>("Cactus");
            RubbleTex = Content.Load<Texture2D>("Rubble");
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
            prevKbState = kbState;
            kbState = Keyboard.GetState();
            // For animation FSM
            string strState = "";            

            // set up the finite state machine using a switch
            switch(gameState)
            {
                // Menu State
                case GameState.Menu:
                    
                     if(this.SingleKeyPress(Keys.S)== true)
                     {
                        gameState = GameState.Game;
                        //this.StartGame();
                     }
                     if(this.SingleKeyPress(Keys.C)== true)
                     {
                        gameState = GameState.Credits;
                     }
                     if(this.SingleKeyPress(Keys.H)== true)
                     {
                        gameState = GameState.Help;
                     }
                     if (this.SingleKeyPress(Keys.R) == true)
                     {
                        gameState = GameState.Scores;
                     }
                     
                    break;

                // Game State
                case GameState.Game:
                    
                     if(user.Health <= 0)
                     {
                        gameState = GameState.GameOver;
                     }

                    // To be added
                     /*if(enemy.Health <= 0)
                     {
                        player.BountyScore += enemy.Points;
                     }*/

                    // Player Movement
                    if(kbState.IsKeyDown(Keys.Up))
                    {
                        user.Rect = new Rectangle(user.Rect.X, user.Rect.Y - 5, user.Rect.Width, user.Rect.Height);
                        ScreenWrap(user);
                    }

                    if(kbState.IsKeyDown(Keys.Left))
                    {
                        user.Rect = new Rectangle(user.Rect.X - 5, user.Rect.Y, user.Rect.Width, user.Rect.Height);
                        ScreenWrap(user);
                        strState = "FaceLeft";
                    }

                    if(kbState.IsKeyDown(Keys.Down))
                    {
                        user.Rect = new Rectangle(user.Rect.X, user.Rect.Y + 5, user.Rect.Width, user.Rect.Height); 
                        ScreenWrap(user);
                    }

                    if(kbState.IsKeyDown(Keys.Right))
                    {
                        user.Rect = new Rectangle(user.Rect.X + 5, user.Rect.Y, user.Rect.Width, user.Rect.Height); 
                        ScreenWrap(user);
                        strState = "FaceRight";
                    }

                    // FSM for player direction
                    switch(strState)
                    {
                        case "FaceLeft": move = PlayerState.FaceLeft; break;

                        case "FaceRight": move = PlayerState.FaceRight; break;
                    }

                    // Bullets
                    if(kbState.IsKeyDown(Keys.Space)&&bulletExist == false)
                    {
                        b = new Bullet(10, bImage, user.Rect.X+50, user.Rect.Y+10, 10, 10);
                        bulletExist = true;
                    }

                    if(bulletExist == true)
                    {
                        b.Rect = new Rectangle(b.Rect.X + 10, b.Rect.Y, b.Rect.Width, b.Rect.Height);
                        if(b.Rect.X > GraphicsDevice.Viewport.Width)
                        {
                            bulletExist = false;
                        }
                    }
                    break;

                // GameOver State
                case GameState.GameOver:
                    
                     if(this.SingleKeyPress(Keys.T)== true) // for try again
                     {
                        gameState = GameState.Game;
                     }
                     if(this.SingleKeyPress(Keys.M)== true) 
                     {
                        gameState = GameState.Menu;
                     }
                    break;

                // Scores State
                case GameState.Scores:
                    
                     if(this.SingleKeyPress(Keys.B)== true)
                     {
                        gameState = GameState.Menu;
                     }   
                     
                    break;

                // Options State
                case GameState.Options:
                    if (this.SingleKeyPress(Keys.B) == true)
                    {
                        gameState = GameState.Menu;
                    } 
                    break;

                // Credits State
                case GameState.Credits:
                    if (this.SingleKeyPress(Keys.B) == true)
                    {
                        gameState = GameState.Menu;
                    } 
                    break;

                // Help State
                case GameState.Help:
                    if(this.SingleKeyPress(Keys.B)== true)
                     {
                        gameState = GameState.Menu;
                     } 
                     if(this.SingleKeyPress(Keys.A) == true)
                     {
                        gameState = GameState.About;
                     } 
                     if(this.SingleKeyPress(Keys.T) == true)
                     {
                        gameState = GameState.Tips;
                     } 
                     if(this.SingleKeyPress(Keys.C) == true)
                     {
                        gameState = GameState.Controls;
                     } 
                    break;

                // About State
                case GameState.About:
                    if (this.SingleKeyPress(Keys.B) == true)
                    {
                        gameState = GameState.Help;
                    }
                    break;

                // Tips State
                case GameState.Tips:
                    if (this.SingleKeyPress(Keys.B) == true)
                    {
                        gameState = GameState.Help;
                    }
                    break;

                // Controls State
                case GameState.Controls:
                    if (this.SingleKeyPress(Keys.B) == true)
                    {
                        gameState = GameState.Help;
                    }
                    break;
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

            // Menu
            if(gameState == GameState.Menu)
            {
                spriteBatch.Draw(background, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.DrawString(font, "Wild Bounty", new Vector2(200, 120), Color.Red, 0, new Vector2(0, 0), 3, SpriteEffects.None, 0f);
                spriteBatch.DrawString(font, "Press S to Start", new Vector2(200, 190), Color.Red);
                spriteBatch.DrawString(font, "Press C for Credits", new Vector2(200, 210), Color.Red);
                spriteBatch.DrawString(font, "Press H for Help", new Vector2(200, 230), Color.Red);
                spriteBatch.DrawString(font, "Press R for Scores", new Vector2(200, 250), Color.Red);
            } 

            // Game
            if (gameState == GameState.Game)
            {
                spriteBatch.Draw(gameBackground, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.Draw(playerImg, user.Rect, Color.White);
               

                // Code beginnings for player animation
                /*
                if(move == PlayerState.FaceRight)
                {
                    spriteBatch.Draw(playerImg, user.Rect, Color.White);
                }

                if(move == PlayerState.FaceLeft)
                {
                    spriteBatch.Draw(playerImg, playerLoc, user.Rect, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
                }
                */
          
                if(bulletExist == true)
                {
                    spriteBatch.Draw(bImage, b.Rect, Color.White);
                }
                
            }

            // Game Over
            if (gameState == GameState.GameOver)
            {
                spriteBatch.Draw(gameoverMenu, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
            }

            // Scores
            if (gameState == GameState.Scores)
            {
                spriteBatch.Draw(scoresMenu, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.DrawString(font, "Press B to go Back", new Vector2(GraphicsDevice.Viewport.Width - 200, 0), Color.Black);
            }

            // Options
            if (gameState == GameState.Options)
            {
                spriteBatch.Draw(optionsMenu, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.DrawString(font, "Press B to go Back", new Vector2(GraphicsDevice.Viewport.Width - 200,0), Color.Black);
            }

            // Credits
            if (gameState == GameState.Credits)
            {
                spriteBatch.Draw(creditsMenu, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.DrawString(font, "Press B to go Back", new Vector2(GraphicsDevice.Viewport.Width - 200, 0), Color.Black);
            }

            // Help
            if (gameState == GameState.Help)
            {
                spriteBatch.Draw(helpMenu, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.DrawString(font, "Press B to go Back", new Vector2(GraphicsDevice.Viewport.Width - 200, 0), Color.Black);
            }

            // About
            if (gameState == GameState.About)
            {
                spriteBatch.DrawString(font, "About Menu", new Vector2(0,0), Color.Black);
                spriteBatch.DrawString(font, "Press B to go Back", new Vector2(GraphicsDevice.Viewport.Width - 200, GraphicsDevice.Viewport.Height - 50), Color.Black);

            }

            // Tips
            if (gameState == GameState.Tips)
            {
                spriteBatch.DrawString(font, "Tips Menu", new Vector2(0, 0), Color.Black);
                spriteBatch.DrawString(font, "Press B to go Back", new Vector2(GraphicsDevice.Viewport.Width - 200, GraphicsDevice.Viewport.Height - 50), Color.Black);

            }

            // Controls
            if (gameState == GameState.Controls)
            {
                spriteBatch.DrawString(font, "Controls Menu", new Vector2(0, 0), Color.Black);
                spriteBatch.DrawString(font, "Press B to go Back", new Vector2(GraphicsDevice.Viewport.Width - 200, GraphicsDevice.Viewport.Height - 50),Color.White);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }

        // checks to see if a button was pressed
        public bool SingleKeyPress(Keys key)
        {
            if (kbState.IsKeyDown(key) == true && prevKbState.IsKeyDown(key) == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        //method to start the game
        public void StartGame()
        {
            // clear data
            user.BountyScore = 0;
            waveCount = 0;
            
            // start the next way
            this.NextWave();
        }

        //method to start the next waves
        public void NextWave()
        {   
            // increment the wave count and calculate how many enemies to make
            waveCount += 1;
            int make = 2*waveCount +3;

            // clear the lists
            enemyObj.Clear();
            enemyThread.Clear();
            
            // loop to create the objects
            for(int i = 0; i < make; i++)
            {

            }

            // loop for threads
            for(int i = 0; i < enemyObj.Count; i++)
            {

            }
        }

        // ScreenWrap Method
        public void ScreenWrap(GameObject g)
        {
            if (g.Rect.X < -g.Rect.Width)
            {
                g.Rect = new Rectangle(GraphicsDevice.Viewport.Width, g.Rect.Y, g.Rect.Width, g.Rect.Height);
            }
            if (g.Rect.X > GraphicsDevice.Viewport.Width)
            {
                g.Rect = new Rectangle(0, g.Rect.Y, g.Rect.Width, g.Rect.Height);
            }
            if (g.Rect.Y < -g.Rect.Height)
            {
                g.Rect = new Rectangle(g.Rect.X, GraphicsDevice.Viewport.Height, g.Rect.Width, g.Rect.Height);
            }
            if (g.Rect.Y > GraphicsDevice.Viewport.Height)
            {
                g.Rect = new Rectangle(g.Rect.X, 0, g.Rect.Width, g.Rect.Height);
            }
        }
    }
}
