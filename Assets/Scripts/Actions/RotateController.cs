using UnityEngine;

/// <summary>
/// Скрипт, который управляет вращением объекта вокруг оси Y на указанные углы поворота за определенное время.
/// </summary>
public class RotateController : MonoBehaviour
{
    private float _elapsedTime;
    private Transform _transform;
    private Quaternion _startRotation;
    private Quaternion _targetRotation;

    [SerializeField] private float _minAngle;
    [SerializeField] private float _maxAngle;
    [SerializeField] private float _duration;

    void Awake()
    {
        _transform = transform;
        _startRotation = Quaternion.Euler(0, _minAngle, 0);
        _targetRotation = Quaternion.Euler(0, _maxAngle, 0);
        _transform.localRotation = _startRotation;
    }

    void Update()
    {
        if (_elapsedTime < _duration)
        {
            _transform.localRotation = Quaternion.Lerp(_startRotation, _targetRotation, _elapsedTime / _duration);
        }
        else
        {
            var temp = _startRotation;
            _startRotation = _targetRotation;
            _targetRotation = temp;
            _elapsedTime -= _duration;
        }
        _elapsedTime += Time.deltaTime;
    }
}
