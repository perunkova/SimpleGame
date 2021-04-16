using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт, отвечающий за создание и появление игрока на уровне.
/// </summary>
public class SpawnController : MonoBehaviour
{
    [SerializeField] private float _durationScale = 1f;
    [SerializeField] private ParticleSystem _portal;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _levelParent;

    public void SpawnPlayer(Player playerPrefab, Action<Player> callback)
    {
        var playerInstance = Instantiate(playerPrefab, _spawnPoint.position, Quaternion.identity, _levelParent);
        playerInstance.transform.localScale = Vector3.zero;
        _portal.Play();
        StartCoroutine(SpawnEffectRoutine(playerInstance, callback));
    }

    /// <summary>
    /// Корутина, которая маштабирует игрока и вызывает переданный ей метод по завершению эффекта
    /// </summary>
    private IEnumerator SpawnEffectRoutine(Player player, Action<Player> callback)
    {
        yield return new WaitForSeconds(1);
        var elapsedTime = 0f;

        while (elapsedTime < _durationScale)
        {
            player.transform.localScale = Mathf.Lerp(0f, 1f, elapsedTime / _durationScale) * Vector3.one;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        player.transform.localScale = Vector3.one;
        callback?.Invoke(player);
    }
}
