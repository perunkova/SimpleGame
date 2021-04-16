using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardRotateController : MonoBehaviour
{
    private float _duration;
    private Quaternion _startRotation;
    private Quaternion _targetRotation;
    private Coroutine _rotateRoutine;

    [SerializeField] private float _rotationSpeed;

    public void LookTo(Vector3 viewTarget, Action callback)
    {        
        var viewDirection = viewTarget - transform.position;
        _startRotation = transform.rotation;
        _targetRotation = Quaternion.LookRotation(viewDirection.normalized, transform.up);
        _duration = Mathf.Abs(_targetRotation.eulerAngles.y - transform.rotation.eulerAngles.y) / _rotationSpeed;

        if (_rotateRoutine != null)
        {
            StopCoroutine(_rotateRoutine);
        }

        _rotateRoutine = StartCoroutine(GuardRotateRoutine(callback));
    }

    private IEnumerator GuardRotateRoutine(Action callback)
    {
        var elapsedTime = 0f;

        while (elapsedTime < _duration)
        {
            transform.localRotation = Quaternion.Lerp(_startRotation, _targetRotation, elapsedTime / _duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        callback?.Invoke();
    }
}
