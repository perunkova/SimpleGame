using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// UI при победе.
/// </summary>
public class WinMenu : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private string _nextLevelName;

    void Awake()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _nextLevelButton.onClick.AddListener(OnNextLevelButtonClick);
    }
    private void OnDestroy()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _nextLevelButton.onClick.RemoveListener(OnNextLevelButtonClick);
    }

    private void OnRestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnNextLevelButtonClick()
    {
        SceneManager.LoadScene(_nextLevelName);
    }

}
