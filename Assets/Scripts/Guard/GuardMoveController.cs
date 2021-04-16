using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMoveController : MonoBehaviour
{
    private Transform _transform;
    private Vector3 _targetPosition;
    private Coroutine _moveRoutine;

    [SerializeField] private float _speed = 2;

    private Action _callback;

    private void Awake()
    {
        _transform = transform;
    }

    public void MoveTo(Vector3 targetPosition, Action callback)
    {
        _targetPosition = targetPosition;

        if (_moveRoutine != null)
        {
            StopCoroutine(_moveRoutine);
        }

        _moveRoutine = StartCoroutine(GuardMoveRoutine(callback));
    }

    private IEnumerator GuardMoveRoutine(Action callback)
    {
        var moveDirection = _targetPosition - _transform.position;
        var step = moveDirection.normalized * Time.deltaTime * _speed;

        while (step.sqrMagnitude < moveDirection.sqrMagnitude)
        {
            moveDirection = _targetPosition - _transform.position;
            step = moveDirection.normalized * Time.deltaTime * _speed;
            _transform.position += step;
            yield return null;
        }

        _transform.position = _targetPosition;
        callback?.Invoke();
    }

}
