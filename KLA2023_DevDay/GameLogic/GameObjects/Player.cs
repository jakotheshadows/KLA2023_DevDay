using static KLA2023_DevDay.GameLogic.GameObjects.Player;

namespace KLA2023_DevDay.GameLogic.GameObjects
{
    public class Player : GameObject
    {
        private int _forceUp = 0;
        private int _forceRight = 0;
        private int _direction = 1;
        private IEnumerable<Platform> _platforms;
        public bool IsJumping => _forceUp > 0;
        public bool IsWalking => _forceRight != 0;
        public bool IsWalkingLeft => _direction < 0;
        public bool IsWalkingRight => _direction > 0;

        public delegate void JumpEventHandler(Player sender, object e);
        public event JumpEventHandler JumpEvent;

        public Player(int width, int height, int left, int top, Platform[] platforms) : base(GameObjectType.Player, width, height, left, top)
        {
            _platforms = platforms;
        }

        public virtual void Jump()
        {
            if (_forceUp == 0)
            {
                _forceUp += WorldSettings.JUMP_FORCE;
                JumpEvent?.Invoke(this, new object());
            }

        }

        public void WalkRight() => _forceRight = WorldSettings.SPEED;
        public void WalkLeft() => _forceRight = -WorldSettings.SPEED;

        public void Stop() => _forceRight = 0;

        public override void Update(int worldHeight, int worldWidth, int worldTopOffset, int worldLeftOffset)
        {
            _forceUp -= WorldSettings.GRAVITY;

            Platform platform = _platforms.FirstOrDefault(x =>
                x.Top - x.Height - Height <= Top
                && x.Left <= Left + Width && x.Left + x.Width >= Left
            );
            if (platform != null && !IsJumping)
            {
                Top = platform.Top - platform.Height - Height;
                _forceUp = 0;
            }
            else if (Top > worldHeight && !IsJumping)
            {
                Top = worldHeight;
                _forceUp = 0;
            }
            else
            {
                Top -= _forceUp;
            }

            if (Left <= 0 && _forceRight < 0)
            {
                _forceRight = 0;
                Left = 0;
            }
            else if (Left >= worldWidth)
            {
                _forceRight = 0;
                Left = worldWidth - Width;
            }
            else if (_forceRight != 0)
            {
                _direction = _forceRight;
            }

            Left += _forceRight;

        }
    }
}
