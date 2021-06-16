namespace Utils
{
    public static class Tags
    {
        // public const string Untagged = "Untagged";
        // public const string Respawn = "Respawn";
        // public const string Finish = "Finish";
        // public const string EditorOnly = "EditorOnly";
        public const string MainCamera = "MainCamera";
        public const string Player = "Player";
        // public const string GameController = "GameController";
        public const string Enemy = "Enemy";
        // public const string Hitbox = "Hitbox";
        // public const string Floor = "Floor";
        // public const string Walls = "Walls";
        // public const string UI = "UI";
    }
    
    public enum Layers
    {
        // Default       =  0,
        // TransparentFX =  1,
        // IgnoreRaycast =  2,
        // Water         =  4,
        // UI            =  5,
        // BlockingLayer =  8,
        Player        =  9,
        Enemy         = 10,
        Weapon        = 11
    }
}
