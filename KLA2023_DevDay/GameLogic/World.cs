using KLA2023_DevDay.GameLogic.GameObjects;

namespace KLA2023_DevDay.GameLogic
{
    public interface IWorld
    {
        Player GetPlayer();
        IEnumerable<Platform> GetPlatforms();
        void ApplyPhysics();
        int? Height { get; set; }
        int? Width { get; set; }
        public int? TopOffset { get; set; }
        public int? LeftOffset { get; set; }
    }

    public class World : IWorld
    {
        private readonly IEnumerable<GameObject> _gameObjects;
        public int? Height { get; set; }
        public int? Width { get; set; }
        public int? TopOffset { get; set; }
        public int? LeftOffset { get; set; }

        public World(IEnumerable<GameObject> gameObjects)
        {
            _gameObjects = gameObjects;
        }

        public Player GetPlayer()
        {
            return (Player)_gameObjects.SingleOrDefault(x => x.GameObjectType == GameObjectType.Player);
        }

        public IEnumerable<Platform> GetPlatforms()
        {
            return _gameObjects.Where(x => x.GameObjectType == GameObjectType.Platform).Select(x => (Platform)x);
        }

        public void ApplyPhysics()
        {
            foreach (GameObject gameObject in _gameObjects)
            {
                gameObject.Update(Height ?? 0, Width ?? 0, TopOffset ?? 0, LeftOffset ?? 0);
            }

        }
    }
}
