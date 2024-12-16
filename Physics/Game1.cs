using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Physics
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private PrimitiveBatch _primitiveBatch;

        Texture2D _whitePixel;
        Texture2D _whiteCircle;

        PrimitiveBatch.Circle _ballTexture;
        Circle _ball;

        PrimitiveBatch.Rectangle _floorTexture;
        Rectangle _floor;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _ball = new PrimitiveBatch.Circle(new Vector2(100, 100), 50, Color.Red);
            _ball2 = new PrimitiveBatch.Circle(new Vector2(200, 100), 50, Color.Blue);
            _floor = new PrimitiveBatch.Rectangle(new Rectangle(0, 400, 800, 100), Color.Green);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _whitePixel = Content.Load<Texture2D>("whitePixel");
            _whiteCircle = Content.Load<Texture2D>("whiteCircle");
            _primitiveBatch = new PrimitiveBatch(_whitePixel, _whiteCircle);

            // TODO: use this.Content to load your game content here
        }

        private void PhysicsUpdate()
        {
            if (_ball.origin.Y + _ball.radius >= _floor.Top)
            {
                _ball.origin.Y = _floor.Top - _ball.radius;
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (
                GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || Keyboard.GetState().IsKeyDown(Keys.Escape)
            )
                Exit();

            PhysicsUpdate();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
