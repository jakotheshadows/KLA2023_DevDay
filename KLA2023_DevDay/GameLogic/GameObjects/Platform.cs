namespace KLA2023_DevDay.GameLogic.GameObjects
{
    public class Platform : GameObject
    {
        public Platform(int width, int height, int left, int top) : base(GameObjectType.Platform, width, height, left, top) { }

        public override void Update(int worldHeight, int worldWidth, int worldTopOffset, int worldLeftOffset)
        {
            // throw new NotImplementedException();
        }
    }
}
