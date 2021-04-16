using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotateVariable
{
    public Vector3 TargetPosition;
    public Transform RotateObject;

    public RotateVariable (Vector3 targetPosition, Transform rotateObject)
    {
        TargetPosition = targetPosition;
        RotateObject = rotateObject;
    }
}

[Serializable]
public class RotateSettings
{
    public float RotationSpeed = 70f;
}
