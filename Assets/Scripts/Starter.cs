using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ��������� ����� ����������. ��������� � ������ ������ ������ �������� ����.
/// </summary>
public class Starter : MonoBehaviour
{
    private void Start()
    {
        var levelName = SaveManager.GetLastLevelName();
        SceneManager.LoadScene(levelName);
    }
}
