using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// UI при проигрыше.
/// </summary>
public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private Button _restartButton;

    void Awake()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);
    }
    private void OnDestroy()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
    }

    private void OnRestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
