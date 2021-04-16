using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveVariable
{
    public Vector3 TargetPosition;
    public Transform MovingObject;

    public MoveVariable (Vector3 targetPosition, Transform movingObject)
    {
        TargetPosition = targetPosition;
        MovingObject = movingObject;
    }
}

[Serializable]
public class MoveSettings
{
    public float Speed = 2f;
}
