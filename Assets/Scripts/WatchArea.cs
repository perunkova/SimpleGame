using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Скрипт, который обнаруживает игрока. 
/// Скрипт следит за объектом, который зашел в триггерную область.
/// Проверяет, находится ли объект в зоне видимости(угол обзора).
/// Определяет, если ли между целью наблюдения и наблюдателем посторонние объекты.
/// </summary>
public class WatchArea : MonoBehaviour
{
    private Player _target;
    private bool _isPlayerDetected = false;

    [SerializeField] private float _viewAngle = 45f;
    [SerializeField] private Image _areaImage;
    [SerializeField] private Color _newColor;

    public event Action PlayerDetected;

    void Update()
    {
        if (_target != null)
        {
            Vector3 targetDirection = _target.transform.position - transform.position;
            targetDirection.y = 0;

            //Проверка, попадает ли цель в область видимости (угол обзора)
            var angle = Vector3.Angle(targetDirection, transform.forward);
            if (angle < _viewAngle)
            {
                //Проверка, есть ли другие объекты перед целью
                RaycastHit hit;
                if (Physics.Raycast(transform.position, targetDirection, out hit))
                {
                    if (_target.Collider == hit.collider)
                        if (_isPlayerDetected != true)
                        {
                            _isPlayerDetected = true;
                            _target.IsDetected = true;
                            PlayerDetected();
                            _areaImage.color = _newColor;
                        }
                }
            }
            else
                _isPlayerDetected = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.attachedRigidbody.GetComponent<Player>();
        if (player != null)
        {
            _target = player;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var player = other.attachedRigidbody.GetComponent<Player>();
        if (player != null)
        {
            if (_target == player)
                _target = null;
        }
    }
}
