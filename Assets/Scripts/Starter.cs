using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Начальная точка приложения. Проверяет с какого уровня должна начаться игра.
/// </summary>
public class Starter : MonoBehaviour
{
    private void Start()
    {
        var levelName = SaveManager.GetLastLevelName();
        SceneManager.LoadScene(levelName);
    }
}
