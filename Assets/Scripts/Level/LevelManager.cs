using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ќсновной компонент уровн€, отвечающий за иницилизацию игрока и обработку игровых событий.
/// </summary>
public class LevelManager : MonoBehaviour
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private SpawnController _spawnController;
    [SerializeField] private WinArea _winArea;
    [Space]
    [SerializeField] private Canvas _winUI;
    [SerializeField] private Canvas _gameOverUI;

    private void Start()
    {
        SaveManager.SaveLevelName(SceneManager.GetActiveScene().name);
        _winArea.Activated += OnPlayerWin;
        _playerController.enabled = false;
        _spawnController.SpawnPlayer(_playerPrefab, OnPlayerSpawned);
    }
        
    private void OnPlayerSpawned(Player player)
    {
        _playerController.Player = player;
        _playerController.enabled = true;
        player.PlayerDetected += OnPlayerDetected;
    }

    private void OnPlayerWin()
    {
        _winUI.gameObject.SetActive(true);
    }

    private void OnPlayerDetected()
    {
        _gameOverUI.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        _winArea.Activated -= OnPlayerWin;
    }
}