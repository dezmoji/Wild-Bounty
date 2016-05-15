using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace WildBounty
{
    /*
     * Authors: Dezmon Gilbert, Niko Bazos, Alex Pierce, Alex Martinelli
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
        Texture2D background2;
        Texture2D background3;
        Texture2D background4;
        Texture2D background5;
        Texture2D background6;
        SpriteFont font;
        Texture2D bImage;
        Texture2D enemyImg;
        Texture2D BarrelTex;
        Texture2D CactusTex;
        Texture2D RubbleTex;
        Player user;
        Enemy enemy;
        Bullet b;
        Ammo a;
        List<Enemy> enemyObj;
        int wave = 0;
        List<int> highScores;
        Random rgen;
        int rndX, rndY;
        int timer;
        int objCount;

        List<Bullet> EnemyBullets;
        List<Scenery> SceneryColl;
        List<Array> SceneryConColl;

        // animation
        Texture2D playerImg;
        int frame;
        double timePerFrame = 75;
        int numFrames = 3;
        int framesElapsed;
        const int HERO_Y = 6;
        const int HERO_HEIGHT = 100;
        const int HERO_WIDTH = 100;
        const int HERO_X_OFFSET = 1;

        bool bulletExist; // bool for projectile algorithim

        // Enum
        enum GameState
        {
            Menu,                   // main menu
            Game,                   // the game being played
            GameOver,               // when the game is finished
            Credits,                // credit screen
            Scores,                 // screen to display scores
            Help,                   // help screen
            About,                  // screen that gives information about the game and the creators
            Tips,                   // screen that gives the user tips on how to succeed and play
            Controls                // shows the user the controls for the game
        }
        enum PlayerState            // For animation
        {
            FaceRight,              // player faces left
            FaceLeft,               // player faces right
            WalkRight,              // player walks right
            WalkLeft,               // player walk left
            WalkDown,               // player walk down  
            WalkUp                  // player walk up
             
        }


        GameState gameState;
        PlayerState move, prevMove; 
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

            // create player
            //user = new Player(playerImg, 0, 0, 50, 100, 100);
            user = new Player(playerImg, 0, 0, HERO_WIDTH, HERO_HEIGHT, 100);
            bulletExist = false;
            rgen = new Random();

            objCount = 0;

            // initialize the lists for the enemies
            enemyObj = new List<Enemy>();
            SceneryColl = new List<Scenery>();
            SceneryConColl = new List<Array>();
            EnemyBullets = new List<Bullet>();

            // initialize the arrays for highscores
            highScores = new List<int>();

            //fill the first five spots in the list to prevent compiler error when showing scores
            for (int i = 0; i < 5; i++)
            {
                highScores.Add(0);
            }

            // read from file
            if (File.Exists("map.dat"))
            {
                FileStream str = new FileStream("map.dat", FileMode.Open);
                long lineCount = str.Length;
                str.Close();

                using (BinaryReader reader = new BinaryReader(File.Open("map.dat", FileMode.Open)))
                {
                    for (int j = 0; j < (lineCount / 28); j++)
                    {
                        int[] n = new int[7];

                        for (int k = 0; k < n.Length; k++)
                        {
                            n[k] = reader.ReadInt32();
                        }

                        SceneryConColl.Add(n);
                    }
                }
            }

            // get background from file
            foreach (var objct in SceneryConColl)
            {
                objCount++;
                int[] obj = (int[])objct;
                Scenery newObj = new Scenery(obj[0], obj[1], obj[2], obj[3], obj[4], obj[5], obj[6]);
                SceneryColl.Add(newObj);
            }

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
            background2 = Content.Load<Texture2D>("Wild-West-2");
            background3 = Content.Load<Texture2D>("Wild-Weset-3");
            background4 = Content.Load<Texture2D>("Wild-West-4");
            background5 = Content.Load<Texture2D>("Wild-West-5");
            background6 = Content.Load<Texture2D>("Wild-West-6");
            font = Content.Load<SpriteFont>("Font/Lemiesz_16");
            playerImg = Content.Load<Texture2D>("CharacterAssetAttempt");
            //playerImg = Content.Load<Texture2D>("CharacterAssetSingle");
            enemyImg = Content.Load<Texture2D>("EnemyAsset1");
            bImage = Content.Load<Texture2D>("BulletAsset");
            BarrelTex = Content.Load<Texture2D>("Barrel");
            CactusTex = Content.Load<Texture2D>("Cactus");
            RubbleTex = Content.Load<Texture2D>("Rubble");

            foreach (var sObj in SceneryColl)
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
                        this.StartGame();
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
                    // when the player dies, it's game over
                     if(user.Health <= 0)
                     {
                         SaveHighestScores(user.BountyScore);
                        gameState = GameState.GameOver;
                     }

                    // Player Movement
                    if(kbState.IsKeyDown(Keys.Up))
                    {
                        user.Rect = new Rectangle(user.Rect.X, user.Rect.Y - 5, user.Rect.Width, user.Rect.Height);
                        ScreenWrap(user);
                        strState = "WalkUp";
                        framesElapsed = (int)(gameTime.TotalGameTime.TotalMilliseconds / timePerFrame);
                        frame = framesElapsed % numFrames + 1;
                    }

                    if(kbState.IsKeyDown(Keys.Left))
                    {
                        user.Rect = new Rectangle(user.Rect.X - 5, user.Rect.Y, user.Rect.Width, user.Rect.Height);
                        ScreenWrap(user);
                        strState = "WalkLeft";
                        //strState = "FaceLeft";
                        // animation
                        framesElapsed = (int)(gameTime.TotalGameTime.TotalMilliseconds / timePerFrame);
                        frame = framesElapsed % numFrames + 1;
                    }

                    if(kbState.IsKeyDown(Keys.Down))
                    {
                        user.Rect = new Rectangle(user.Rect.X, user.Rect.Y + 5, user.Rect.Width, user.Rect.Height); 
                        ScreenWrap(user);
                        strState = "WalkDown";
                        framesElapsed = (int)(gameTime.TotalGameTime.TotalMilliseconds / timePerFrame);
                        frame = framesElapsed % numFrames + 1;
                    }

                    if(kbState.IsKeyDown(Keys.Right))
                    {
                        user.Rect = new Rectangle(user.Rect.X + 5, user.Rect.Y, user.Rect.Width, user.Rect.Height); 
                        ScreenWrap(user);
                        strState = "WalkRight";
                        //strState = "FaceRight";
                        // animation
                        framesElapsed = (int)(gameTime.TotalGameTime.TotalMilliseconds / timePerFrame);
                        frame = framesElapsed % numFrames + 1;
                    }


                    if (!kbState.IsKeyDown(Keys.Left) && !kbState.IsKeyDown(Keys.Right) && !kbState.IsKeyDown(Keys.Up) && !kbState.IsKeyDown(Keys.Down))
                    {
                        if (prevMove == PlayerState.FaceRight || prevMove == PlayerState.WalkRight)
                        {
                            strState = "FaceRight";
                        }
                        if (prevMove == PlayerState.FaceLeft || prevMove == PlayerState.WalkLeft)
                        {
                            strState = "FaceLeft";
                        }
                    }

                    if (move == PlayerState.FaceRight || move == PlayerState.FaceLeft || move == PlayerState.WalkRight || move == PlayerState.WalkLeft)
                    {
                        prevMove = move;
                    }
                    // FSM for player direction
                    switch(strState)
                    {
                        case "FaceLeft": move = PlayerState.FaceLeft; break;

                        case "FaceRight": move = PlayerState.FaceRight; break;

                        case "WalkLeft": move = PlayerState.WalkLeft; break;

                        case "WalkRight": move = PlayerState.WalkRight; break;

                        case "WalkDown": move = PlayerState.WalkDown; break;

                        case "WalkUp": move = PlayerState.WalkUp; break;
                         
                    }


                    // Bullets
                    if (user.BCount > 0)
                    {
                        
                        if (kbState.IsKeyDown(Keys.Space) && bulletExist == false)
                        {

                            b = new Bullet(10, bImage, user.Rect.X + user.Rect.Width, user.Rect.Y + 25, 10, 15, true);
                            bulletExist = true;
                            timer = 0;

                            if (move == PlayerState.FaceRight)
                            {
                                b = new Bullet(10, bImage, user.Rect.X + user.Rect.Width, user.Rect.Y + 25, 10, 15, true);
                                bulletExist = true;
                            }

                            if (move == PlayerState.FaceLeft)
                            {
                                b = new Bullet(10, bImage, user.Rect.X, user.Rect.Y +25, 10, 15, false);
                                bulletExist = true;
                            }

                            user.UseBullet();
                        }

                        if (bulletExist == true)
                        {
                            if (b.Side == true)
                            {
                                b.xRec += 10;
                                timer++;
                            }

                            if (b.Side == false)
                            {
                                b.xRec -= 10;
                                timer++;
                            }

                            /*if (b.Rect.X > GraphicsDevice.Viewport.Width || b.Rect.X < 0)
                            {
                                bulletExist = false;
                            }*/

                            if (timer > 60)
                            {
                                bulletExist = false;
                                timer = 0;
                            }
                        }
                   }
                    

                    foreach(Enemy e in enemyObj)
                    {
                        //set the enemy's bullet images
                        e.BImage = bImage;
                        if (bulletExist == true)
                        {
                            b.Collision(e);
                        }
                        Bullet EBull = e.Shoot(user);
                        if(EBull != null)
                        {
                            EnemyBullets.Add(EBull);
                        }
                    }

                    foreach(Bullet ebull in EnemyBullets)
                    {
                        if(ebull.IsActive == true)
                        {
                            if(ebull.Side == true)
                            {
                                ebull.xRec += 5; //bullet goes right
                            }
                            if(ebull.Side == false)
                            {
                                ebull.xRec -= 5; //bullet goes left
                            }
                            ebull.Travel(user);
                        }

                    }

                    for (int i = 0; i < enemyObj.Count;i++)
                    {

                        // Enemy Movement
                        if(i < enemyObj.Count/2)
                        {
                            enemyObj[i].Rect = new Rectangle(enemyObj[i].Rect.X - 2, enemyObj[i].Rect.Y - 2, enemyObj[i].Rect.Width, enemyObj[i].Rect.Height);
                            ScreenWrap(enemyObj[i]);
                        }
                        else 
                        {
                            enemyObj[i].Rect = new Rectangle(enemyObj[i].Rect.X + 2, enemyObj[i].Rect.Y + 2, enemyObj[i].Rect.Width, enemyObj[i].Rect.Height);
                            ScreenWrap(enemyObj[i]);
                        }
                    }

                    // calls the death method for enemies
                    this.Death();

                    // when the list of enemies is empty, call the next wave
                    if(enemyObj.Count == 0)
                    {
                        this.NextWave();
                    }
                    break;

                
                
                // GameOver State
                case GameState.GameOver:
                    
                     if(this.SingleKeyPress(Keys.T)== true) // for try again
                     {
                         wave = 0;
                         user.Health = 100;
                         StartGame();
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
                spriteBatch.DrawString(font, "Wild Bounty", new Vector2(250, 120), Color.Red, 0, new Vector2(0, 0), 2, SpriteEffects.None, 0f);
                spriteBatch.DrawString(font, "Press S to Start", new Vector2(200, 190), Color.Red);
                spriteBatch.DrawString(font, "Press C for Credits", new Vector2(200, 210), Color.Red);
                spriteBatch.DrawString(font, "Press H for Help", new Vector2(200, 230), Color.Red);
                spriteBatch.DrawString(font, "Press R for Scores", new Vector2(200, 250), Color.Red);
            } 

            // Game
            if (gameState == GameState.Game)
            {

                spriteBatch.Draw(background6, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                foreach (var sObj in SceneryColl)
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
                    
                }


                spriteBatch.DrawString(font, "Health " + user.Health, new Vector2(GraphicsDevice.Viewport.Width - 150, 10), Color.White);
                spriteBatch.DrawString(font, "Points " + user.BountyScore, new Vector2(GraphicsDevice.Viewport.Width - 150, 30), Color.White);
                spriteBatch.DrawString(font, "Ammo " + user.BCount, new Vector2(GraphicsDevice.Viewport.Width - 150, 50), Color.White);
                spriteBatch.DrawString(font, "Wave " + wave, new Vector2(GraphicsDevice.Viewport.Width - 150, 70), Color.White);

                foreach(Enemy e in enemyObj)
                {
                    // Enemy Direction based on player loc
                    if(user.Rect.X < e.Rect.X)
                    {
                        spriteBatch.Draw(enemyImg, e.Rect, null, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
                    }
                    else
                    {
                        e.Draw(spriteBatch);
                    }
                }

                //enemy bullet drawing
                foreach (Bullet ebull in EnemyBullets)
                {
                    if (ebull.IsActive == true)
                    {
                        //determine side
                        if(ebull.Side == true)
                        {
                            spriteBatch.Draw(bImage, ebull.Rect, Color.White);//right
                        }
                        if(ebull.Side == false)
                        {
                            spriteBatch.Draw(bImage, ebull.Rect, null, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally,0); //left
                        }
                        
                    }
                }
                //spriteBatch.DrawString(font,"" + EnemyBullets.Count, new Vector2(100, 100), Color.White); //debug drawstring -- remove before final submission!


                // Code for player direction
                if(move == null)
                {
                    move = prevMove;
                }

                if(move == PlayerState.FaceRight)
                {
                    //spriteBatch.Draw(playerImg, user.Rect, Color.White);
                    spriteBatch.Draw(playerImg, user.Rect, new Rectangle(HERO_X_OFFSET, 0, user.Rect.Width, user.Rect.Height), Color.White);
                }

                if(move == PlayerState.FaceLeft)
                {
                    //spriteBatch.Draw(playerImg, user.Rect, null, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
                    spriteBatch.Draw(playerImg, new Vector2(user.Rect.X, user.Rect.Y), new Rectangle(HERO_X_OFFSET, 0, user.Rect.Width, user.Rect.Height), Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
                }

                if(move == PlayerState.WalkRight)
                {
                    spriteBatch.Draw(playerImg, new Vector2(user.Rect.X, user.Rect.Y), new Rectangle(HERO_X_OFFSET + frame * user.Rect.Width, 0, user.Rect.Width, user.Rect.Height), Color.White);
                }

                if(move == PlayerState.WalkLeft)
                {
                    spriteBatch.Draw(playerImg, new Vector2(user.Rect.X, user.Rect.Y), new Rectangle(HERO_X_OFFSET + frame * user.Rect.Width, 0, user.Rect.Width, user.Rect.Height), Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
                }

                
                if(move == PlayerState.WalkUp)
                {
                    if (prevMove == PlayerState.FaceRight || prevMove == PlayerState.WalkRight)
                    {
                        spriteBatch.Draw(playerImg, new Vector2(user.Rect.X, user.Rect.Y), new Rectangle(HERO_X_OFFSET + frame * user.Rect.Width, 0, user.Rect.Width, user.Rect.Height), Color.White);
                    }
                    if (prevMove == PlayerState.FaceLeft || prevMove == PlayerState.WalkLeft)
                    {
                        spriteBatch.Draw(playerImg, new Vector2(user.Rect.X, user.Rect.Y), new Rectangle(HERO_X_OFFSET + frame * user.Rect.Width, 0, user.Rect.Width, user.Rect.Height), Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
                    }
                    /*
                    if(prevKbState.IsKeyDown(Keys.Right))
                    {
                        spriteBatch.Draw(playerImg, user.Rect, new Rectangle(HERO_X_OFFSET, user.Rect.Y, user.Rect.Width, user.Rect.Height), Color.White);
                    }
                    if(prevKbState.IsKeyDown(Keys.Left))
                    {
                        spriteBatch.Draw(playerImg, new Vector2(user.Rect.X, user.Rect.Y), new Rectangle(HERO_X_OFFSET, user.Rect.Y, user.Rect.Width, user.Rect.Height), Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
                    }
                     */
                }

                if(move == PlayerState.WalkDown)
                {
                    if (prevMove == PlayerState.FaceRight || prevMove == PlayerState.WalkRight)
                    {
                        spriteBatch.Draw(playerImg, new Vector2(user.Rect.X, user.Rect.Y), new Rectangle(HERO_X_OFFSET + frame * user.Rect.Width, 0, user.Rect.Width, user.Rect.Height), Color.White);
                    }
                    if (prevMove == PlayerState.FaceLeft || prevMove == PlayerState.WalkLeft)
                    {
                        spriteBatch.Draw(playerImg, new Vector2(user.Rect.X, user.Rect.Y), new Rectangle(HERO_X_OFFSET + frame * user.Rect.Width, 0, user.Rect.Width, user.Rect.Height), Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
                    }
                    /*
                    if (prevKbState.IsKeyDown(Keys.Right))
                    {
                        spriteBatch.Draw(playerImg, user.Rect, new Rectangle(HERO_X_OFFSET, user.Rect.Y, user.Rect.Width, user.Rect.Height), Color.White);
                    }
                    if (prevKbState.IsKeyDown(Keys.Left))
                    {
                        spriteBatch.Draw(playerImg, new Vector2(user.Rect.X, user.Rect.Y), new Rectangle(HERO_X_OFFSET, user.Rect.Y, user.Rect.Width, user.Rect.Height), Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
                    }
                     */
                }
                 
                
                // Code for bullet direction
                if(bulletExist == true && user.BCount > 0)
                {
                    if(b.IsActive)
                    {
                        if (move == PlayerState.FaceRight)
                        {
                            spriteBatch.Draw(bImage, b.Rect, Color.White);
                        }
                        if (move == PlayerState.FaceLeft)
                        {
                            spriteBatch.Draw(bImage, b.Rect, null, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
                        }
                    }
                }
                
            }

            // Game Over
            if (gameState == GameState.GameOver)
            {
                spriteBatch.Draw(background5, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.DrawString(font, "Game Over!", new Vector2(GraphicsDevice.Viewport.Width / 2 - 200, 100), Color.Red, 0, new Vector2(0, 0), 3, SpriteEffects.None, 0f);
                spriteBatch.DrawString(font, "Your Bounty was " + user.BountyScore, new Vector2(GraphicsDevice.Viewport.Width / 2 - 150, 200), Color.Red);
                spriteBatch.DrawString(font, "Try Again(T)", new Vector2(GraphicsDevice.Viewport.Width / 2 - 300, 300), Color.Red);
                spriteBatch.DrawString(font, "Main Menu(M)", new Vector2(GraphicsDevice.Viewport.Width / 2 + 150, 300), Color.Red);

            }

            // Scores
            if (gameState == GameState.Scores)
            {
                spriteBatch.Draw(background3, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.DrawString(font, "Press B to go Back", new Vector2(GraphicsDevice.Viewport.Width - 250, 0), Color.Black);
                spriteBatch.DrawString(font, "High Scores:", new Vector2(GraphicsDevice.Viewport.Width / 2 - 75, 100), Color.Black, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0f);
                spriteBatch.DrawString(font, "1. " + highScores[0], new Vector2(100, 150), Color.Black);
                spriteBatch.DrawString(font, "2. " + highScores[1], new Vector2(100, 200), Color.Black);
                spriteBatch.DrawString(font, "3. " + highScores[2], new Vector2(100, 250), Color.Black);
                spriteBatch.DrawString(font, "4. " + highScores[3], new Vector2(100, 300), Color.Black);
                spriteBatch.DrawString(font, "5. " + highScores[4], new Vector2(100, 350), Color.Black);

            }

            // Credits
            if (gameState == GameState.Credits)
            {
                spriteBatch.Draw(background2, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.DrawString(font, "Press B to go Back", new Vector2(GraphicsDevice.Viewport.Width - 250, 0), Color.Black);
                spriteBatch.DrawString(font, "Credits", new Vector2(50, 50), Color.Black);
                spriteBatch.DrawString(font, "Niko Bazos- Lead, Game View", new Vector2(50, 100), Color.Black);
                spriteBatch.DrawString(font, "Alex Martinelli- Design, Map Tool", new Vector2(50, 150), Color.Black);
                spriteBatch.DrawString(font, "Alex Pearce- Architecture, Asset Implementation", new Vector2(50, 200), Color.Black);
                spriteBatch.DrawString(font, "Dez Gilbert- UI, Gameplay", new Vector2(50, 250), Color.Black);
            }

            // Help
            if (gameState == GameState.Help)
            {
                spriteBatch.Draw(background4, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.DrawString(font, "Press B to go Back", new Vector2(GraphicsDevice.Viewport.Width - 250, 0), Color.Black);
                spriteBatch.DrawString(font, "Help", new Vector2(50, 50), Color.Black, 0, new Vector2(0, 0), 2, SpriteEffects.None, 0f);
                spriteBatch.DrawString(font, "About (Press A)", new Vector2(50, 100), Color.Black);
                spriteBatch.DrawString(font, "Controls (Press C)", new Vector2(50, 200), Color.Black);
                spriteBatch.DrawString(font, "Tips (Press T)", new Vector2(50, 300), Color.Black);

            }

            // About
            if (gameState == GameState.About)
            {
                spriteBatch.Draw(background4, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.DrawString(font, "About Menu", new Vector2(50,50), Color.Black);
                spriteBatch.DrawString(font, "Wild Bounty is a retro-arcade inspired, Western", new Vector2(50, 100), Color.Black);
                spriteBatch.DrawString(font, "themed 2D shooter. The goal is simple-survive. If you can ", new Vector2(50, 150), Color.Black);
                spriteBatch.DrawString(font, "last the horde of adversaries, your legendary bounty ", new Vector2(50, 200), Color.Black);
                spriteBatch.DrawString(font, "will forever be remembered. Have Fun!", new Vector2(50, 250), Color.Black);
                spriteBatch.DrawString(font, "Press B to go Back", new Vector2(GraphicsDevice.Viewport.Width - 250, GraphicsDevice.Viewport.Height - 50), Color.Black);

            }

            // Tips
            if (gameState == GameState.Tips)
            {
                spriteBatch.Draw(background4, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.DrawString(font, "Tips Menu", new Vector2(50, 50), Color.Black);
                spriteBatch.DrawString(font, "Move to avoid enemy bullets!", new Vector2(50, 100), Color.Black);
                spriteBatch.DrawString(font, "Fire your bullet and move!", new Vector2(50, 150), Color.Black);
                spriteBatch.DrawString(font, "You shoot faster near the edges of the screen!", new Vector2(50, 200), Color.Black);
                spriteBatch.DrawString(font, "Killing enemies gives ammo!", new Vector2(50, 250), Color.Black);
                spriteBatch.DrawString(font, "Do not run into enemies!", new Vector2(50, 300), Color.Black);
                spriteBatch.DrawString(font, "Press B to go Back", new Vector2(GraphicsDevice.Viewport.Width - 250, GraphicsDevice.Viewport.Height - 50), Color.Black);

            }

            // Controls
            if (gameState == GameState.Controls)
            {
                spriteBatch.Draw(background4, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.DrawString(font, "Controls Menu", new Vector2(50, 50), Color.Black);
                spriteBatch.DrawString(font, "Arrow Keys to Move", new Vector2(50, 100), Color.Black);
                spriteBatch.DrawString(font, "Space to Shoot", new Vector2(50, 150), Color.Black);
                spriteBatch.DrawString(font, "Press B to go Back", new Vector2(GraphicsDevice.Viewport.Width - 250, GraphicsDevice.Viewport.Height - 50),Color.White);
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
            // reset data
            user.BountyScore = 0;
            wave = 0;
            user.BCount = 10;
             
            
            // start the next wave
            this.NextWave();
        }

        //method to start the next waves
        public void NextWave()
        {
            // increment the wave count and calculate how many enemies to make
            wave++;
            int make = 2 * wave + 1;
            if (user.Health < 100)
            {
                user.Health += wave * 10;
            }
           

            // clear the lists
            enemyObj.Clear();

            // loop to create the objects
            for (int i = 0; i < make; i++)
            {
                rndX = rgen.Next(50, GraphicsDevice.Viewport.Width - 200);
                rndY = rgen.Next(50, GraphicsDevice.Viewport.Height - 50);
                Enemy enemy = new Enemy(100, enemyImg, rndX, rndY, 50, 100, 20);
                enemyObj.Add(enemy);
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

        // method to handle the death of an enemy
        public void Death()
        {
            // loop goes through the entire list to check each enmy
            for(int i = 0; i < enemyObj.Count;i++)
            {
                // checks if the enemy is dead and if the are, the enemy is set to inactive
                enemyObj[i].EnemyDeath();

                // if the enemy is inactive
                if (enemyObj[i].IsActive == false)
                {
                    // user gains bullets
                    user.GainBullet();

                    // player score is incremented
                    user.BountyScore += enemyObj[i].Points;

                    // enemy is removed from the list
                    enemyObj.RemoveAt(i);
                }
            }
        }

        // saves the scores *note: does not save elsewhere meaning there are no scores are not cumulative
        public void SaveHighestScores(int score)
        {
            // add the score
            highScores.Add(score);

            // have the list be sorted
            highScores.Sort();

            // displays the greatest first
            highScores.Reverse();
        }
    }
}
