using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{    
    private Coroutine _controlRoutine;

    [SerializeField] private MoveSettings _moveSettings;
    [SerializeField] private RotateSettings _rotateSettings;
    [SerializeField] private ScaleSettings _scaleSettings;
    [SerializeField] private WatchArea _watchArea;
    [SerializeField] private ParticleSystem _guardParticleSystem;

    void Awake()
    {
        _watchArea.PlayerDetected += OnPlayerDetected;
    }

    private void OnPlayerDetected()
    {
        if (_controlRoutine != null)
            StopCoroutine(_controlRoutine);
    }

    private void OnDestroy()
    {
        _watchArea.PlayerDetected -= OnPlayerDetected;
    }

    public void MoveTo(Vector3 targetPosition, Action callback)
    {
        if(_controlRoutine!=null)
        {
            StopCoroutine(_controlRoutine);
        }

        _controlRoutine = StartCoroutine(GuardControlRoutine(targetPosition, callback));
    }

    private IEnumerator GuardControlRoutine(Vector3 targetPosition, Action callback)
    {
        var moveVariable = new MoveVariable(targetPosition, transform);
        var rotateVariable = new RotateVariable(targetPosition, transform);
        var scaleVariable = new ScaleVariable(transform);

        yield return CoroutineController.GuardRotateRoutine(rotateVariable, _rotateSettings);
        yield return CoroutineController.GuardMoveRoutine(moveVariable, _moveSettings);

        _guardParticleSystem.Play();
        yield return CoroutineController.GuardScaleRoutine(scaleVariable, _scaleSettings);

        callback?.Invoke();
    }    
}
