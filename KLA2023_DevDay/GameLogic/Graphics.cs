using KLA2023_DevDay.GameLogic.GameObjects;

namespace KLA2023_DevDay.GameLogic
{
    public interface IGraphics
    {
        int PlayerOffset { get; }
        void CyclePlayer();
        int PlayerDirection { get; }
    }

    public class Graphics : IGraphics
    {
        private readonly Player _player;
        private int _playerOffset = 0;
        private DateTime _lastUpdate = DateTime.MinValue;
        private Dictionary<int, int> SpriteIndexTransform = new()
        {
            { 0, 0 },
            { 1, 20 },
            { 2, 38 },
            { 3, 56 }
        };

        public Graphics(Player player)
        {
            _player = player;
        }

        public int PlayerOffset => SpriteIndexTransform[_playerOffset];

        public int PlayerDirection =>
            _player switch
            {
                { IsWalkingLeft: true } => -1,
                { IsWalkingRight: true } => 1,
                _ => 0
            };

        public void CyclePlayer()
        {
            if (_lastUpdate.AddMilliseconds(100) > DateTime.Now)
            {
                return;
            }

            if (!_player.IsWalking)
            {
                _playerOffset = 0;
            }
            else if (_playerOffset < 3)
            {
                _playerOffset += 1;
            }
            else
            {
                _playerOffset = 1;
            }

            _lastUpdate = DateTime.Now;
        }
    }
}
