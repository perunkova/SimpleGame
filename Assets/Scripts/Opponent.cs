using UnityEngine;

/// <summary>
/// ѕротивники на уровне, след€щие за игроком.
/// </summary>
public class Opponent : MonoBehaviour
{
    [SerializeField] private WatchArea _watchArea;
    [SerializeField] private RotateController _controller;

    void Awake()
    {
        _watchArea.PlayerDetected += OnPlayerDetected;
    }

    private void OnPlayerDetected()
    {
        _controller.enabled = false;
    }

    private void OnDestroy()
    {
        _watchArea.PlayerDetected -= OnPlayerDetected;
    }
}
