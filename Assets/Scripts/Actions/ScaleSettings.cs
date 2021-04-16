using UnityEngine;

[CreateAssetMenu(fileName = "ScaleSettings", menuName = "Assets/ScaleSettings")]
public class ScaleSettings : ScriptableObject
{
    public float ScaleDuration = 1f;
    public AnimationCurve ScaleCurve;
}
