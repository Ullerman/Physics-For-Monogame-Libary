using System;
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
        private Physics _physics;

        private const float PixelsPerMeter = 10f;

        const float massOfEarth = 5.972e24f;
        Texture2D _whitePixel;
        Texture2D _whiteCircle;

        PrimitiveBatch.Circle _ballTexture;
        Ball _ball;

        PrimitiveBatch.Circle _earthTexture;
        Ball _earth;
        Vector2 _ballVelocity;
        Vector2 _ballForce;
        float _ballMass;

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
            _ball = new Ball(new Vector2(100, 100), .5f,.5f);
            _ballTexture = new PrimitiveBatch.Circle(_ball.origin, _ball.radius, Color.Red);
            _ballMass = .5f;
            _ballForce = new Vector2(0, 0);
            _ballVelocity = new Vector2(0, 0);

            _floor = new Rectangle(0, 400, 800, 200);
            _floorTexture = new PrimitiveBatch.Rectangle(_floor, Color.Green);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _physics = new Physics();
            _whitePixel = Content.Load<Texture2D>("pixel");
            _whiteCircle = Content.Load<Texture2D>("Circle");
            _primitiveBatch = new PrimitiveBatch(_whitePixel, _whiteCircle);

            // TODO: use this.Content to load your game content here
        }

        private void PhysicsUpdate(float deltaTime)
        {
            Vector2 ballPositionMeters = _ball.origin / PixelsPerMeter;

            Vector2 baseForce = _physics.GravityCalculationAngle(3*MathF.PI / 2, _ballForce, .5f, 9.81f);
            baseForce = new Vector2(baseForce.X, baseForce.Y * -1);
            Vector2 ballAccelerationMeters = (baseForce + _ballForce)/.5f;

            _ballVelocity += ballAccelerationMeters * deltaTime;

            ballPositionMeters += _ballVelocity * deltaTime;

            _ball.origin = ballPositionMeters * PixelsPerMeter;

            if (_physics.IsIntersecting(_ball, _floor))
            {
                _ball.origin.Y = _floor.Y - _ball.radius;
                _ballVelocity.Y = 0;
            }
        }

        protected override void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (
                GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || Keyboard.GetState().IsKeyDown(Keys.Escape)
            )
                Exit();

            PhysicsUpdate(deltaTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _floorTexture.Draw(_spriteBatch, _primitiveBatch);
            _ballTexture.origin = _ball.origin;
            _ballTexture.Draw(_spriteBatch, _primitiveBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
