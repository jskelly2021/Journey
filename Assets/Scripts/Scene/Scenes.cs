public enum Scenes
{
    Managers,
    UI,
    Main,
}

public static class ScenesMethods
{
    public static string GetSceneName(this Scenes scene)
    {
        switch (scene)
        {
            case Scenes.Managers:
                return "Managers";
            case Scenes.UI:
                return "UI";
            case Scenes.Main:
                return "Main";
            default:
                return null;
        }
    }
}