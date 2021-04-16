using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardScaler : MonoBehaviour
{
    private float _duration = 1f;
    private Coroutine _scaleRoutine;

    [SerializeField] private AnimationCurve _scaleCurve;

    public void GuardScale(Action callback)
    {
        if (_scaleRoutine != null)
        {
            StopCoroutine(_scaleRoutine);
        }

        _scaleRoutine = StartCoroutine(GuardScaleCoroutine(callback));
    }

    private IEnumerator GuardScaleCoroutine(Action callback)
    {
        var elapsedTime = 0f;

        while (elapsedTime < _duration)
        {
            transform.localScale = _scaleCurve.Evaluate(elapsedTime / _duration) * Vector3.one;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        callback?.Invoke();
    }
}
