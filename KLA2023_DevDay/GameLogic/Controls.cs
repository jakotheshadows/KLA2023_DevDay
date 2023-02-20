using KLA2023_DevDay.GameLogic.GameObjects;

namespace KLA2023_DevDay.GameLogic
{
    public interface IControls
    {
        void KeyDown(string key);
        void KeyUp(string key);
    }
    public class Controls : IControls
    {
        private readonly Player _player;

        public Controls(Player player)
        {
            _player = player;
        }

        public void KeyDown(string key)
        {
            switch (key)
            {
                case "ArrowLeft": // Left
                    if (!_player.IsJumping)
                    {
                        _player.WalkLeft();
                    }
                    break;
                case "Space": // Space
                    _player.Jump();
                    break;
                case "ArrowRight": // Right
                    if (!_player.IsJumping)
                    {
                        _player.WalkRight();
                    }
                    break;
                default:
                    break;
            }

        }

        public void KeyUp(string key)
        {
            switch (key)
            {
                case "ArrowLeft": // Left
                    _player.Stop();
                    break;

                case "ArrowRight": // Right
                    _player.Stop();
                    break;

                default:
                    break;
            }

        }
    }

}
