using System;
using UnityEngine;

/// <summary>
/// �������, �� ������� ������ ��������� �����.
/// </summary>
public class WinArea : MonoBehaviour
{
    private float gravity = -1;

    [SerializeField] private ParticleSystem _particleSystem;

    //�������, ������� ��������� � ���������� ������ � �������
    public event Action Activated;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.attachedRigidbody.GetComponent<Player>();
        if (player != null)
        {
            var temp = _particleSystem.main;
            temp.gravityModifier = gravity;

            player.Stop();
            Activated();
        }
    }
}
