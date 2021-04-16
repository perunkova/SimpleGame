using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// —крипт, управл€ющий игроком на уровне.
/// </summary>
public class PlayerController : MonoBehaviour
{   
    private Camera _mainCamera;
    private Player _player;

    public Player Player
    {
        get
        {
            return _player;
        }
        set
        {
            _player = value;
        }
    }


    void Start()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
                _player.Move(hit.point);
        }
    }
}
