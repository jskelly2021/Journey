public enum AudioGroup 
{
    Master,
    Menu,
    Game,
    Music
}

public static class AudioGroupMethods
{
    public static string GetVolumeString(this AudioGroup audioGroup)
    {
        switch (audioGroup)
        {
            case AudioGroup.Master:
                return "MasterVolume";
            case AudioGroup.Menu:
                return "MenuFXVolume";
            case AudioGroup.Game:
                return "GameFXVolume";
            case AudioGroup.Music:
                return "MusicVolume";
            default:
                return null;
        }
    }
}
