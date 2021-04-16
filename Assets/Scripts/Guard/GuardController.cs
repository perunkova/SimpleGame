using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardController : MonoBehaviour
{
    private Vector3 _startPosition;
    [SerializeField] private Guard _guard;

    [SerializeField] private Vector3 _targetPosition;

    private void Awake()
    {
        _startPosition = _guard.transform.position;
    }

    private void Start()
    {
        _guard.MoveTo(_targetPosition, GuardHasArrived);
    }

    private void GuardHasArrived()
    {
        var tempPosition = _targetPosition;
        _targetPosition = _startPosition;
        _startPosition = tempPosition;

        _guard.MoveTo(_targetPosition, GuardHasArrived);
    }
}
