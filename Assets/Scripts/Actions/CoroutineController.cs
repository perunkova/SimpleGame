using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CoroutineController
{
    public static IEnumerator GuardRotateRoutine(RotateVariable variable, RotateSettings settings)
    {
        var elapsedTime = 0f;
        var viewDirection = variable.TargetPosition - variable.RotateObject.position;
        var startRotation = variable.RotateObject.rotation;
        var targetRotation = Quaternion.LookRotation(viewDirection.normalized, variable.RotateObject.up);
        var duration = Mathf.Abs(targetRotation.eulerAngles.y - variable.RotateObject.rotation.eulerAngles.y) / settings.RotationSpeed;

        while (elapsedTime < duration)
        {
            variable.RotateObject.localRotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    public static IEnumerator GuardMoveRoutine(MoveVariable variable, MoveSettings settings)
    {
        var moveDirection = variable.TargetPosition - variable.MovingObject.position;
        var step = moveDirection.normalized * Time.deltaTime * settings.Speed;

        while (step.sqrMagnitude < moveDirection.sqrMagnitude)
        {
            moveDirection = variable.TargetPosition - variable.MovingObject.position;
            step = moveDirection.normalized * Time.deltaTime * settings.Speed;
            variable.MovingObject.position += step;
            yield return null;
        }

        variable.MovingObject.position = variable.TargetPosition;
    }

    public static IEnumerator GuardScaleRoutine(ScaleVariable variable, ScaleSettings settings)
    {
        var elapsedTime = 0f;

        while (elapsedTime < settings.ScaleDuration)
        {
            variable.ScaleObject.localScale = settings.ScaleCurve.Evaluate(elapsedTime / settings.ScaleDuration) * Vector3.one;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
