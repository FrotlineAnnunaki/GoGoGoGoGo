using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Go
{
    
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D texture;
        Vector2 texturePos;
        bool danteForward = true;
        bool danteHop = true;


        Rectangle screenRectangle = new Rectangle(0, 0, 800, 480);
        

        Texture2D paddle;
        Vector2 paddlePos;

        int paddleTopLeftX;
        int paddleTopLeftY;
        int danteTopLeftX = 400;
        int danteTopLeftY = 200;

        protected bool Collide()
        {
            Rectangle paddleRectangle = new Rectangle((int)paddlePos.X, (int)paddlePos.Y, 125, 49);
            Rectangle danteRectangle = new Rectangle((int)texturePos.X, (int)texturePos.Y, 125, 105);


            return danteRectangle.Intersects(paddleRectangle);
        }

        

        //Texture2D texture;
        //Vector2 position;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";


            /*texturePos = new Vector2(danteTopLeftX, danteTopLeftY);
            paddlePos = new Vector2(325, 431);

            danteTopLeftX = 0;
            danteTopLeftY = 0;

            paddleTopLeftX = 325;
            paddleTopLeftY = 431;

            screenRectangle = new Rectangle(-1, -1, 801, 481);
            */

                        

            #region
            // this.IsFixedTimeStep = true;
            // this.graphics.SynchronizeWithVerticalRetrace = false;
            // this.TargetElapsedTime = new System.TimeSpan(0, 0, 0, 0, 17);
#endregion


        }

        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //paddlePos.X = paddleTopLeftX;
            //paddlePos.Y = paddleTopLeftY;

            //texturePos.X = 400;
            //texturePos.Y = 200;
            paddlePos.X = 325;
            paddlePos.Y = 431;

            base.Initialize();

            #region
            /*
            position = new Vector2(0, 0);
            texture = new Texture2D(this.GraphicsDevice, 100, 100);
            Color[] colorData = new Color[100 * 100];
            for (int i = 0; i < 10000; i++)
                colorData[i] = Color.Red;
            texture.SetData<Color>(colorData);
            base.Initialize();
            */
            #endregion


        }

       
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = this.Content.Load<Texture2D>("Dante");
            paddle = this.Content.Load<Texture2D>("paddle");

            #region
            //spriteBatch = new SpriteBatch(GraphicsDevice);
            #endregion


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here




            #region
            //texture.Dispose();
            #endregion
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            #region
            /*if (IsActive)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();
                position.X += 60.0f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (position.X > this.GraphicsDevice.Viewport.Width)
                    position.X = 0;
                // TODO: Add your update logic here
                //gameTime.IsRunningSlowly

                base.Update(gameTime);
            }*/
            #endregion

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //if (Keyboard.GetState().IsKeyDown(Keys.Up))
                //paddlePos.Y -= 1;
            //if (Keyboard.GetState().IsKeyDown(Keys.Down))
               // paddlePos.Y += 1;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                paddlePos.X -= 1;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                paddlePos.X += 1;
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                texturePos.X += 1;
            if(Collide())
            {
                danteHop = false; 
            }

            if (danteForward == true)
                texturePos.X += 1;
            if (danteForward == false)
                texturePos.X -= 1;

            if (danteHop == true)
                texturePos.Y += 1;
            if (danteHop == false)
                texturePos.Y -= 1;

            if (texturePos.X <= 0)
                danteForward = true;
            if (texturePos.Y < 0)
                danteHop = true;
            if (texturePos.X > 800 - 125)
                danteForward = false;
            if (texturePos.Y > 480 - 105)
                danteHop = false;




            /*if (danteForward == true)
                 texturePos.X += 1;            
            if (danteForward == false)
                 texturePos.X -= 1;*/
            /* 
            texturePos.X += 1;

            if (danteRectangle.Intersects(screenRectangle))
                texturePos = new Vector2 (-texturePos.X, texturePos.Y);
            if (danteRectangle.Left == this.GraphicsDevice.Viewport.Width - this.GraphicsDevice.Viewport.Width)
                danteForward = true;*/

            /*if (danteHop == true)
                texturePos.Y += 1;
            if (danteHop == false)
                texturePos.Y -= 1;

            if (texturePos.Y == this.GraphicsDevice.Viewport.Height - 105)
                danteHop = false;
            if (texturePos.Y == this.GraphicsDevice.Viewport.Height - this.GraphicsDevice.Viewport.Height || texturePos.Y == paddleRectangle.Top)
                danteHop = true;*/




            /*texturePos.X += 1;
            if (texturePos.X == this.GraphicsDevice.Viewport.Width)
                texturePos.X -= 1;*/

            base.Update(gameTime);
        
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, texturePos);
            spriteBatch.Draw(paddle, paddlePos);
            spriteBatch.End();

            base.Draw(gameTime);




            #region
            /*
                var fps = 1 / gameTime.ElapsedGameTime.TotalSeconds;
                Window.Title = fps.ToString();
                spriteBatch.Begin();
                spriteBatch.Draw(texture, position);
                spriteBatch.End();
            */
            #endregion


            // TODO: Add your drawing code here


        }
    }
}
