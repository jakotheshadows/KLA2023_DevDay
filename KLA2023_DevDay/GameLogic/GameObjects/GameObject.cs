namespace KLA2023_DevDay.GameLogic.GameObjects
{
    public abstract class GameObject
    {
        public int Width { get; protected set; }
        public int Height { get; protected set; } 
        public int Left { get; protected set; }
        public int Top { get; protected set; }
        public GameObjectType GameObjectType;

        public GameObject(GameObjectType gameObjectType, int width, int height, int left, int top)
        {
            GameObjectType = gameObjectType;
            Width = width;
            Height = height;
            Left = left;
            Top = top;
        }
        

        public abstract void Update(int worldHeight, int worldWidth, int worldTopOffset, int worldLeftOffset);
    }

    public enum GameObjectType
    {
        Player,
        Platform
    }
}
