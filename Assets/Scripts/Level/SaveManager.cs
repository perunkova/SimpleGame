using UnityEngine;

/// <summary>
/// Сохранение игровых данных с использованием PlayerPrefs.
/// </summary>
public static class SaveManager
{
    private const string LastLoadSceneKey = "LastLoadScene";

    public static void SaveLevelName(string levelName)
    {
        PlayerPrefs.SetString(LastLoadSceneKey, levelName);
    }

    public static string GetLastLevelName()
    {
        return PlayerPrefs.GetString(LastLoadSceneKey, "Level1");
    }
}