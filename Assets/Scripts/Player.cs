using System;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent _playerAgent;
    private bool _isDetected;

    [SerializeField] private Collider _collider;

    public event Action PlayerDetected;

    public Collider Collider
    {
        get
        {
            return _collider;
        }
    }

    //Свойство, был ли обнаружен игрок. 
    //При обнаружении (true) останавливает движение и вызывает событие.
    public bool IsDetected
    {
        get
        {
            return _isDetected;
        }
        set
        {
            _isDetected = value;
            if (_isDetected)
            {
                Stop();
                PlayerDetected?.Invoke();
            }
        }
    }

    private void Awake()
    {
        _playerAgent = GetComponent<NavMeshAgent>();
    }

    public void Move(Vector3 targetPosition)
    {
        if (!_isDetected)
            _playerAgent.SetDestination(targetPosition);
    }

    public void Stop()
    {
        _playerAgent.isStopped = true;
    }
}
